using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{

    public class RelationshipMessage : EntityAuditInfo
    {
        public string Action { get; set; }

        public int MessageGroupId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MessageEntity ParentEntity { get; set; }

        public int EntityId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MessageEntity ChildEntity { get; set; }

        public RelationshipType RelationshipType { get; set; }
    }

}