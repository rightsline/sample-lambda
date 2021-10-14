using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{
    public class MessageEntity
    {
        public int EntityId { get; set; }
        public int CharTypeId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MessageEntityTemplate Template { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MessageEntityStatus Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MessageEntity ParentEntity { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MessageEntity ChildEntity { get; set; }
    }


}