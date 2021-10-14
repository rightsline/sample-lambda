using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RIS_Common.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RightsLine.Contracts.RestApi.V4
{
    public class CharacteristicDataItemConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object);
        }

        public List<CharDataRestModel> ReadCharDataList(JsonReader reader)
        {
            List<CharDataRestModel> output = null;
            switch (reader.TokenType)
            {
                // dictionary value was a single object
                case JsonToken.StartObject:
                    output = new List<CharDataRestModel>() { this.ReadCharData(reader) };
                    break;
                // dictionary value was an array
                case JsonToken.StartArray:
                    // create a new 
                    output = new List<CharDataRestModel>();
                    while (reader.Read())
                    {
                        // read each item until end of array reached
                        if (reader.TokenType == JsonToken.EndArray)
                        {
                            break;
                        }
                        // add one value
                        output.Add(this.ReadCharData(reader));
                    }
                    break;
                // dictionary value was a string
                case JsonToken.Integer:
                case JsonToken.Boolean:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Date:
                    output = new List<CharDataRestModel>() { this.ReadCharData(reader) };
                    break;
                default:
                    break;
            }
            return output;
        }

        public CharDataRestModel ReadCharData(JsonReader reader)
        {
            CharDataRestModel output = null;
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    output = new CharDataRestModel();
                    var objectDictionary = new Dictionary<string, object>();
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.EndObject)
                        {
                            break;
                        }
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            var propertyName = (string)reader.Value;
                            switch (propertyName.ToLower())
                            {
                                case "id":
                                    reader.Read(); // read in Id value
                                    switch (reader.TokenType) // is the Id field a string or an actual integer
                                    {
                                        case JsonToken.String:
                                        case JsonToken.Integer:
                                            objectDictionary[propertyName] = MainUtil.GetInt(reader.Value, -1);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    reader.Read(); // read in property value
                                    objectDictionary[propertyName] = reader.Value;
                                    break;
                            }
                        }
                    }
                    var moneyKeys = new string[] { "locAmt", "locCur", "locSym", "divAmt", "divCur", "divSym" }.Select(v => v.ToLower()).ToArray();

                    if (objectDictionary.Keys.Any(k => moneyKeys.Contains(k.ToLower())))
                    {
                        output.Value = JsonConvert.SerializeObject(objectDictionary);
                    }
                    else
                    {
                        if (objectDictionary.ContainsKey("id"))
                        {
                            output.Id = (int?)objectDictionary["id"];
                        }
                        if (objectDictionary.ContainsKey("xref"))
                        {
                            output.Xref = (string)objectDictionary["xref"];
                        }
                        if (objectDictionary.ContainsKey("value"))
                        {
                            output.Value = (string)objectDictionary["value"];
                        }
                    }
                    break;
                case JsonToken.Integer:
                case JsonToken.Boolean:
                case JsonToken.Float:
                case JsonToken.String:
                    output = new CharDataRestModel()
                    {
                        Value = reader.Value.ToString()
                    };
                    break;
                case JsonToken.Date:
                    output = new CharDataRestModel()
                    {
                        Value = ((DateTime)reader.Value).ToString("yyyy-MM-dd")
                    };
                    break;
                default:
                    break;
            }
            return output;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, List<CharDataRestModel>> output = null;
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    break;
                case JsonToken.StartObject:  // start of characteristics dictionary
                    output = new Dictionary<string, List<CharDataRestModel>>();
                    while (reader.Read()) // read out the first property
                    {
                        if (reader.TokenType == JsonToken.EndObject) // reached the end of the property
                        {
                            break;
                        }
                        if (reader.TokenType == JsonToken.PropertyName) // key of property
                        {
                            var tagLabel = (string)reader.Value;
                            reader.Read(); // move to value of property

                            var charDataValue = this.ReadCharDataList(reader);
                            if (charDataValue != null)
                            {
                                output[tagLabel] = charDataValue;
                            }
                        }
                    }
                    break;
                default:
                    output = (Dictionary<string, List<CharDataRestModel>>)serializer.Deserialize(reader);
                    break;
            }
            return output;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Dictionary<string, List<CharDataRestModel>>)
            {
                var input = value as Dictionary<string, List<CharDataRestModel>>;
                writer.WriteStartObject();
                foreach (var kvp in input)
                {
                    if (kvp.Value.Any())
                    {
                        writer.WritePropertyName(kvp.Key);
                        this.WriteCharDataList(writer, kvp.Value);
                    }
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull();
            }
        }

        public void WriteCharDataList(JsonWriter writer, List<CharDataRestModel> list)
        {
            bool isMultipleCMD = list is CharDataListRestModel && (list as CharDataListRestModel).IsMultiple;
            if (isMultipleCMD || list.Count > 1)
            {
                // start an array
                writer.WriteStartArray();
                foreach (var item in list)
                {
                    // write each element of the arra
                    this.WriteCharData(writer, item);
                }
                // end an array
                writer.WriteEndArray();
            }
            else if (list.Count == 0)
            {
                // write a null
                writer.WriteNull();
            }
            else
            {
                // single item, no array
                this.WriteCharData(writer, list[0]);
            }
        }

        public void WriteCharData(JsonWriter writer, CharDataRestModel item)
        {
            if (Regex.IsMatch(item.Value, @"^\{.*\}") && IsValidJSON(item.Value))
            {
                var moneyValue = JsonConvert.DeserializeObject<MoneyValueRestModel>(item.Value);
                if (moneyValue != null)
                {
                    writer.WriteStartObject();

                    writer.WritePropertyName("locAmt");
                    writer.WriteValue(moneyValue.LocAmt);

                    writer.WritePropertyName("locCur");
                    writer.WriteValue(moneyValue.LocCur);

                    writer.WritePropertyName("locSym");
                    writer.WriteValue(moneyValue.LocSym);

                    writer.WritePropertyName("divAmt");
                    writer.WriteValue(moneyValue.DivAmt);

                    writer.WritePropertyName("divCur");
                    writer.WriteValue(moneyValue.DivCur);

                    writer.WritePropertyName("divSym");
                    writer.WriteValue(moneyValue.DivSym);

                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull();
                }
            }
            else
            {
                if (item.Id == null && item.Xref == null)
                {
                    writer.WriteValue(item.Value);
                }
                else
                {
                    writer.WriteStartObject();
                    if (item.Id != null)
                    {
                        writer.WritePropertyName("id");
                        writer.WriteValue(item.Id);
                    }

                    if (item.Xref != null)
                    {
                        writer.WritePropertyName("xref");
                        writer.WriteValue(item.Xref);
                    }

                    if (item.Value != null)
                    {
                        writer.WritePropertyName("value");
                        writer.WriteValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
            }
        }

        public bool IsValidJSON(string input)
        {
            try
            {
                JToken.Parse(input);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }

    public class CustomIsoDateOnlyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime output = DateTime.MinValue;
            if (reader.TokenType == JsonToken.String)
            {
                output = DateTime.Parse((string)reader.Value, null, DateTimeStyles.RoundtripKind);
            }
            return output;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd"));
            }
            else
            {
                writer.WriteNull();
            }
        }
    }
}
