using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{
    
    public class ModuleEntityMessage : EntityAuditInfo
    {
        public string Action { get; set; }
        public int MessageGroupId { get; set; }
        public MessageEntity Entity { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<MessageEntity> ChildrenAdded { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<MessageEntity> ChildrenRemoved { get; set; }
    }


}