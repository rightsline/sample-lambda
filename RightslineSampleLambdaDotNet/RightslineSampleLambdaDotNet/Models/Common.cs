using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RightslineSampleLambdaDotNet.Models
{
    public interface IRLObject
    {
    }

    public partial class Status
    {
        [JsonProperty("statusId")]
        public long StatusId { get; set; }

        [JsonProperty("statusName")]
        public string StatusName { get; set; }
    }

    public partial class Template
    {
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("processId")]
        public long ProcessId { get; set; }

        [JsonProperty("processName")]
        public string ProcessName { get; set; }

        [JsonProperty("templateId")]
        public long TemplateId { get; set; }

        [JsonProperty("templateName")]
        public string TemplateName { get; set; }
    }

    public partial class Field
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("required")]
        public bool FieldRequired { get; set; }

        [JsonProperty("maxLength")]
        public long MaxLength { get; set; }

        [JsonProperty("editable")]
        public bool Editable { get; set; }

        [JsonProperty("dataType")]
        public string DataType { get; set; }

        [JsonProperty("allowMultiple")]
        public bool AllowMultiple { get; set; }

        [JsonProperty("listOfValues")]
        public List<ListOfValue> ListOfValues { get; set; }
    }

    public partial class ListOfValue
    {
        public static implicit operator string(ListOfValue instance)
        {
            if (instance == null) return "";
            else return instance.Value;
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("xref")]
        public string Xref { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("parentId")]
        public long? ParentId { get; set; }

        public override string ToString() { return Value; }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };
    }
}
