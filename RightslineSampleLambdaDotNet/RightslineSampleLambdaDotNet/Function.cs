using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Newtonsoft.Json.Linq;
using RightslineSampleLambdaDotNet.Consts;
using RightslineSampleLambdaDotNet.Models;
using RightslineSampleLambdaDotNet.Extensions;
using RightslineSampleLambdaDotNet.RightslineAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RightslineSampleLambdaDotNet
{
    public class Function
    {
        private readonly v3 _v3 = new v3();
        protected string _host = Environment.GetEnvironmentVariable(EnvironmentVariables.Host);

        public Function()
        {
        }

        public async Task<object> FunctionHandler(SQSEvent sqsEvent, ILambdaContext context)
        {
            try
            {
                Console.WriteLine($"SQS Record Count {sqsEvent.Records.Count}");

                foreach (var record in sqsEvent.Records)
                {
                    var sqsMessage = record.Body;
                    var innerMessage = SnsMessage.FromJson(sqsMessage);

                    if (innerMessage.RootEntityUrl == null)
                    {
                        Console.WriteLine("There is no root entity in this message.");
                        Console.WriteLine("Lambda processing aborted");
                        return new { body = "SQS Event Processing Completed at " + DateTime.Now.ToString(), statusCode = 200 };
                    }

                    var messageGroupID = innerMessage.MessageGroupId;
                    var rootEntityURL = innerMessage.RootEntityUrl;
                    var entityID = (int)innerMessage.EntityId;
                    var templateID = (int)innerMessage.Template.TemplateId;

                    //TODO - Function logic here

                    //SAMPLES
                    //Get a catalog item - assuming it was the message received on the queue
                    var catalogResult = await this._v3.Get("catalog-item", entityID);

                    //Search for the first 25 catalog items with the same template as the one received on the queue
                    var catalogPayload = @"
                        {""query"":
                        {""$and"":[
                        {""$eq"":[""templateid""," + templateID + @"]}]},
                        ""start"":0,""rows"":25,""sortOrders"":[""sequencenumber asc""]}";

                    var catalogResults = await this._v3.Search("catalog-item", catalogPayload);

                    if (catalogResults.Count() == 0)
                    {
                        Console.WriteLine($"Cannot find Catalog Items with template id {templateID}.");
                        Console.WriteLine("Lambda processing aborted");
                    }

                    //Update a catalog item
                    //A sample cannot be given here as every client has different fields in their unique environment
                    //A recommended approach would be to GET the desired catalog item, modify its value(s), serialize it, and pass to the PUT method
                    //The API call will return the EntityModel with its updated data
                    //var updatedCatalogResult = await this._v3.Put("catalog-item", entityID, entityJSON);

                    //Create a catalog item
                    //A sample cannot be given here as every client has different fields in their unique environment
                    //A recommended approach would be to create a new EntityModel, or custom object with the necessary information,
                    //serialize it, and pass to the POST method
                    //The API call will return the ID of the new entity
                    //var newCatalogItemIDResult = await this._v3.Post("catalog-item", entityJSON);

                    //Delete a catalog item
                    //var deleteCatalogItemResult = await this._v3.Delete("catalog-item", newCatalogItemIDResult);

                    //Get all Rights templates and find the Territory LOV on a Rights In template
                    var rightTemplates = await this._v3.GetTemplates("rightset");
                    var rightsInTemplate = rightTemplates.Templates.Where(t => t.TemplateId == 1).First();
                    List<LovValue> territories = rightsInTemplate.Fields.Where(f => f.Label == "territory").First().ListOfValues.ToList();
                }
            }
            catch (Exception ex)
            {
                var record = sqsEvent.Records.First();

                Console.WriteLine($"[arn:sqs {DateTime.Now}] ERROR = {ex.Message} {ex.StackTrace}");

                return new { body = "SQS Event Processing Error at " + DateTime.Now.ToString() + " " + ex.Message, statusCode = 400 };
            }

            return new { body = "SQS Event Processing Completed at " + DateTime.Now.ToString(), statusCode = 200 };
        }
    }
}