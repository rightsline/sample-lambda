using Newtonsoft.Json;
using RightsLine.Contracts.Converters;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
    public class EntityExRestSearchModel
    {
        public int NumFound { get; set; }
        public List<EntityExRestModel> Entities { get; set; } = new List<EntityExRestModel>();

        public EntityExRestSearchModel()
        {

        }
    }

    public class EntityExRestModel : EntityRestModel
    {
        [JsonConverter(typeof(SingleOrArrayConverter<EntityRelationshipRestModel>))]
        public List<EntityRelationshipRestModel> ParentRelationship { get; set; }

        public RelationshipUpdateRules RelationshipUpdateRules { get; set; }
        public int ParentRelationshipCount { get; set; }
    }

    public class EntityExRestCopyModel : EntityExRestModel
    {
        public int CharTypeId { get; set; }
        public bool CopyRelationships { get; set; }
    }

    public class FileResponseModel
    {
        public int Id { get; set; }
        public FileLinkRestModel Link { get; set; }
    }

    public class FileLinkRestModel 
    {
        public string Url { get; set; }
        public DateTime Expiration { get; set; }
    }

    public class AttachmentUploadRestModel
    {
        public string Label { get; set; }
        public string FileName { get; set; }
    }

    public class RelationshipUpdateRuleTypes
    {
        public const string ReplaceAll = "ReplaceAll";
        public const string AddUpdateOnly = "AddUpdateOnly";
    }

    public class RelationshipUpdateException
    {
        public string ParentEntityType { get; set; }
        public List<string> ParentEntityTemplateIds { get; set; } = new List<string>();
        public string ChildEntityType { get; set; }
        public List<string> ChildEntityTemplateIds { get; set; } = new List<string>();
    }

    public class RelationshipUpdateRules
    {
        public string Rule { get; set; }
        public List<RelationshipUpdateException> Exceptions { get; set; } = new List<RelationshipUpdateException>();
    }
}