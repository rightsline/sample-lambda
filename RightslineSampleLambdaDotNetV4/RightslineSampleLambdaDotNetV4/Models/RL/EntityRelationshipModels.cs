using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
    public class RelationshipTypeRestModel
    {
        public int RelationshipTypeId { get; set; }
        public string RelationshipTypeName { get; set; }
    }
    public class EntityRelationshipSearchResponse
    {
        public int NumFound { get; set; }
        public List<EntityRelationshipRestModel> Entities { get; set; } = new List<EntityRelationshipRestModel>();
    }

    public class EntityRelationshipRestModel
    {
        public int? Id { get; set; }
        public RelationshipTypeRestModel RelationshipType { get; set; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int ParentCharTypeId { get; set; }
        public int ParentRecordId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityTemplateRestModel ParentTemplate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityStatusRestModel ParentStatus { get; set; }
        public int ChildCharTypeId { get; set; }
        public int ChildRecordId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityTemplateRestModel ChildTemplate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityStatusRestModel ChildStatus { get; set; }
        public long SequenceNumber { get; set; }
    }

    public class RelationshipTypeListModel
    {
        public List<RelationshipTypeRestModel> RelationshipTypes { get; set; } = new List<RelationshipTypeRestModel>();
    }
}