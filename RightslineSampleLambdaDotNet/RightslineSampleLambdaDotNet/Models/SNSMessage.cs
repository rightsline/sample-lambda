using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RightslineSampleLambdaDotNet.Models
{
    public partial class SnsMessage
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("messageGroupId")]
        public long MessageGroupId { get; set; }

        [JsonProperty("template")]
        public Template Template { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("entityUrl")]
        public Uri EntityUrl { get; set; }

        [JsonProperty("entityId")]
        public long EntityId { get; set; }

        [JsonProperty("childrenAdded")]
        public List<string> ChildrenAdded { get; set; }

        [JsonProperty("childrenRemoved")]
        public List<string> ChildrenRemoved { get; set; }

        [JsonProperty("createdById")]
        public long CreatedById { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("deletedById")]
        public long DeletedById { get; set; }

        [JsonProperty("deletedDate")]
        public DateTimeOffset DeletedDate { get; set; }

        [JsonProperty("lastUpdatedById")]
        public long LastUpdatedById { get; set; }

        [JsonProperty("lastUpdatedDate")]
        public DateTimeOffset LastUpdatedDate { get; set; }

        [JsonProperty("parentEntityUrl")]
        public Uri ParentEntityUrl { get; set; }

        [JsonProperty("childEntityUrl")]
        public Uri ChildEntityUrl { get; set; }

        [JsonProperty("rootEntityUrl")]
        public Uri RootEntityUrl { get; set; }

    }
    public partial class SnsMessage
    {
        public static SnsMessage FromJson(string json) => JsonConvert.DeserializeObject<SnsMessage>(json, Converter.Settings);
    }

}
