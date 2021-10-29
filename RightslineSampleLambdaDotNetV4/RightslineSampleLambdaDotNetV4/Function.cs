using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Newtonsoft.Json;
using RightsLine.Contracts.MessageQueuing.V4.Messages;
using RightslineSampleLambdaDotNetV4.Consts;
using RightslineSampleLambdaDotNetV4.Models;
using RightslineSampleLambdaDotNetV4.RightslineAPI;
using System;
using System.Linq;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RightslineSampleLambdaDotNetV4
{
    public class Function
    {
        private readonly v4 _v4 = new v4();

        public Function()
        {
        }

        public async Task<object> FunctionHandler(SNSEvent snsEvent, ILambdaContext context)
        {
            try
            {
                Console.WriteLine($"SNS Record Count {snsEvent.Records.Count}");

                foreach (var record in snsEvent.Records)
                {

                    //
                    //Sanity checks to confirm message have required attributes used below.
                    //
                    if (!record.Sns.MessageAttributes.ContainsKey(EntityBaseMessageAttributes.Action))
                    {
                        Console.WriteLine($"Message missing action attribute.");
                        continue;
                    }


                    if (!record.Sns.MessageAttributes.ContainsKey(EntityBaseMessageAttributes.CharTypeID))
                    {
                        Console.WriteLine($"Message missing char type id attribute.");
                        continue;
                    }


                    //
                    //The SNS topics are differentiated by char type in the SNS topics name 'ENV-rtl-divNNN-v4-ctNN' 
                    //This makes it unnecessary to extract the char type id from the attributes, however we are
                    //showed how this could be done if a customer were to use a generic lambda for multiple SNS topics.
                    //
                    var charType = (CharTypeID)(Convert.ToInt32(record.Sns.MessageAttributes[EntityBaseMessageAttributes.CharTypeID].Value));
                    switch (charType)
                    {
                        case CharTypeID.CatalogItem:
                            Console.WriteLine($"Catalog-Item message received.");
                            break;

                        case CharTypeID.Right:
                            Console.WriteLine($"Right message received.");
                            break;
                    }


                    //
                    //act on a particular action as needed
                    //
                    var action = record.Sns.MessageAttributes[EntityBaseMessageAttributes.Action].Value;
                    switch (action)
                    {
                        case EntityBaseMessageActions.EntityActionCreated:
                            Console.WriteLine($"Created");
                            break;

                        case EntityBaseMessageActions.EntityActionUpdated:
                            Console.WriteLine($"Updated");
                            break;

                        case EntityBaseMessageActions.EntityActionDeleted:
                            Console.WriteLine($"Deleted");
                            break;
                    }

                    var messageEntity = JsonConvert.DeserializeObject<ModuleEntityMessage>(record.Sns.Message, Converter.Settings);

                    //SAMPLES
                    //Get a catalog item - assuming it was the message received on the queue
                    var catalogResult = await this._v4.Get("catalog-item", messageEntity.Entity.EntityId);

                    //Search for the first 25 catalog items with the same template as the one received on the queue
                    var catalogPayload = @"
                        {""query"":
                        {""$and"":[
                        {""$eq"":[""templateid""," + messageEntity.Entity.Template.TemplateId + @"]}]},
                        ""start"":0,""rows"":25,""sortOrders"":[""sequencenumber asc""]}";

                    var catalogResults = await this._v4.Search("catalog-item", catalogPayload);

                    if (catalogResults.Count() == 0)
                    {
                        Console.WriteLine($"Cannot find Catalog Items with template id {messageEntity.Entity.Template.TemplateId}.");
                        Console.WriteLine("Lambda processing aborted");
                    }


                    //
                    //Example for checking if the catalog item / title is available
                    //Additional information related to this call can be found @ https://api-docs.rightsline.com/v/4-1/avails/avails-is-catalog-item-available
                    //
                    var isCatalogItemAvailablePayload = @"
                        {
                          ""recordId"": " + messageEntity.Entity.EntityId + @",
                          ""dim1"": [2],
                          ""dim2"": [1],
                          ""dim3"": [4],
                          ""windowStart"": ""2018-12-22"", 
                          ""windowEnd"": ""2019-12-22"",   
                          ""isExclusive"": true,
                        }";
                    var catalogItemAvailable = await this._v4.IsCatalogItemAvailable(isCatalogItemAvailablePayload);


                    //
                    //Example for fetching availability information
                    //Additional information related to this call can be found @ https://api-docs.rightsline.com/v/4-1/avails/avails-get-availability
                    //
                    var getAvailablilityPayload = @"
                    {
                        ""recordId"": [
                              " + messageEntity.Entity.EntityId + @"
                            ], 
                            ""windowStart"": ""2018-02-13"", 
                            ""windowEnd"": ""2021-10-31"",   
                            ""matchType"": ""CoverEntire"",
                            ""isExclusive"": false,
                            ""start"": 0,   
                            ""rows"": 25
                        }";

                    var availability = await this._v4.GetAvailability(getAvailablilityPayload);


                    //
                    //Example for fetching additional rights information for a right-update message
                    //
                    if (charType == CharTypeID.Right && action == EntityBaseMessageActions.EntityActionUpdated)
                    {
                        var rightResult = await this._v4.Get("right", messageEntity.Entity.EntityId);


                        //
                        //example call to get 10 catalog items associated to a rightset when it is changed
                        //
                        var rightSearchPayload = @"{
                                ""start"": 0,
                                ""rows"": 10,
                                ""childQuery"": { 3:{ ""$eq"":[""recordid"", " + messageEntity.Entity.EntityId + @"]} }
                                }
                                ";

                        var catalogRightResults = await this._v4.Search("catalog-item", rightSearchPayload);
                    }


                    //Update a catalog item
                    //A sample cannot be given here as every client has different fields in their unique environment
                    //A recommended approach would be to GET the desired catalog item, modify its value(s), serialize it, and pass to the PUT method
                    //The API call will return the EntityModel with its updated data
                    //var updatedCatalogResult = await this._v4.Put("catalog-item", entityID, entityJSON);


                    //Create a catalog item
                    //A sample cannot be given here as every client has different fields in their unique environment
                    //A recommended approach would be to create a new EntityModel, or custom object with the necessary information,
                    //serialize it, and pass to the POST method
                    //The API call will return the ID of the new entity
                    //var newCatalogItemIDResult = await this._v4.Post("catalog-item", entityJSON);


                    //Delete a catalog item
                    //var deleteCatalogItemResult = await this._v4.Delete("catalog-item", newCatalogItemIDResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[arn:sns {DateTime.Now}] ERROR = {ex.Message} {ex.StackTrace}");
                return new { body = "SNS Event Processing Error at " + DateTime.Now.ToString() + " " + ex.Message, statusCode = 400 };
            }

            return new { body = "SNS Event Processing Completed at " + DateTime.Now.ToString(), statusCode = 200 };
        }
    }
}



