using System;
using System.Collections.Generic;
using System.Text;

namespace RightslineSampleLambdaDotNet.Models
{
    public class TemplatesResponse
    {
        public IEnumerable<EntityTemplateModel> Templates { get; set; }
    }

    public class EntityTemplateModel
    {
        public List<TemplateFieldMetaData> Fields { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int ProcessID { get; set; }
        public string ProcessName { get; set; }

        public EntityTemplateModel()
        {

        }
        
        public EntityTemplateModel(EntityTemplateModel model)
        {
            this.TemplateId = model.TemplateId;
            this.TemplateName = model.TemplateName;
        }
    }

    public class TemplateFieldMetaData
    {
        public string Label { get; set; }
        public bool Required { get; set; }
        public int MaxLength { get; set; }
        public bool Editable { get; set; }
        public string DataType { get; set; }
        public bool AllowMultiple { get; set; }
        public IEnumerable<LovValue> ListOfValues { get; set; }
    }

    public class LovValue
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Xref { get; set; }
        public IEnumerable<LovValue> ChildValues { get; set; }
    }
}
