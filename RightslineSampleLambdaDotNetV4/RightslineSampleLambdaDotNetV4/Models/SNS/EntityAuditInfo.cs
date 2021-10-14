using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{
    
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


}