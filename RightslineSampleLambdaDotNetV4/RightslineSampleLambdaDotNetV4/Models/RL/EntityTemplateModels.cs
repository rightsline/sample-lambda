using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
    public class EntityTemplateRestModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<TemplateFieldMetaData> Fields { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }

        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<EntityTemplateAssociationModel> ParentRelationships { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<EntityTemplateAssociationModel> ChildRelationships { get; set; } 
    }

    public class EntityTemplateListModel
    {
        public List<EntityTemplateRestModel> Templates { get; set; } = new List<EntityTemplateRestModel>();
    }

    public class EntityTemplateAssociationModel
    {
        public int CharTypeID { get; set; }
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public int RelRecTypeID { get; set; }
        public string RelRecTypeDescription { get; set; }
    }

    public class DraftTemplateRestModel
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public string FileName { get; set; }
    }

    public class DraftTemplateListModel
    {
        public List<DraftTemplateRestModel> Templates { get; set; } = new List<DraftTemplateRestModel>();
    }

    public class TemplateFieldMetaData
    {
        public string FieldName { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public int MaxLength { get; set; }
        public bool Editable { get; set; }
        public string DataType { get; set; }
        public bool AllowMultiple { get; set; }
        public List<CharMetaDataValueRestModel> ListOfValues { get; set; } = new List<CharMetaDataValueRestModel>();
    }

    public class CharMetaDataValueRestModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Xref { get; set; }
        public List<CharMetaDataValueRestModel> ChildValues { get; set; } = new List<CharMetaDataValueRestModel>();
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<CharMetaDataValueWithTagLabelRestModel> LinkedFields { get; set; }
    }

    public class CharMetaDataValueWithTagLabelRestModel : CharMetaDataValueRestModel
    {
        public string TagLabel { get; set; }
    }

    public class MasterValueListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<MasterValueListItemModel> Values { get; set; }
    }

    public class MasterValueListItemModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Xref { get; set; }
        public string Status { get; set; }
    }
}