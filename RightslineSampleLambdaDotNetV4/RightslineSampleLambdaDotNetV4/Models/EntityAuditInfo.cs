using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightslineSampleLambdaDotNetV4.Models
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

    public class EntityAuditInfo
    {
        public EntityAuditInfo()
        {
        }

        public EntityAuditInfo(int? createdById, DateTime? createdDate, int? lastUpdatedById, DateTime? lastUpdatedDate,
            int? deletedById, DateTime? deletedDate, int? statusUpdatedById, DateTime? statusUpdatedDate)
        {
            CreatedById = createdById;
            CreatedDate = createdDate;
            LastUpdatedById = lastUpdatedById;
            LastUpdatedDate = lastUpdatedDate;
            DeletedById = deletedById;
            DeletedDate = deletedDate;
            StatusUpdatedById = statusUpdatedById;
            StatusUpdatedDate = statusUpdatedDate;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedById { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? LastUpdatedById { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastUpdatedDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ActionExecutedById { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ActionExecutedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DeletedById { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DeletedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ExecutedActionId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? StatusUpdatedById { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StatusUpdatedDate { get; set; }

    }



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

    public class MessageEntityTemplate
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
    }

    public class MessageEntityStatus
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }

}
