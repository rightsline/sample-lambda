using System;
using System.Collections.Generic;
using System.Linq;

namespace RightslineSampleLambdaDotNetV4.Models
{
    public class EntityModel
    {
        public List<EntityRelationshipModel> ParentRelationship { get; set; } = new List<EntityRelationshipModel>();
        public int? Id { get; set; }
        public int? RevisionId { get; set; }
        public string Title { get; set; }
        public EntityTemplateModel Template { get; set; }
        public EntityStatusModel Status { get; set; }
        public Dictionary<string, object> Characteristics { get; set; } = new Dictionary<string, object>();
        public List<string> Errors { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public EntityModel()
        {

        }

        public bool MergeEntity(EntityTemplateModel template, EntityModel model, bool onlyUpdateWhenNullOrEmpty = false, bool updateParentRelationship = false, List<string> allowOverrideFieldNames = null)
        {
            var hasChanges = false;

            if (this.Title != model.Title && !onlyUpdateWhenNullOrEmpty)
            {
                hasChanges = true;
                this.Title = model.Title;
            }

            if (updateParentRelationship)
            {
                var hasParentChanges = !this.ParentRelationship.All(model.ParentRelationship.Contains) ||
                                        !model.ParentRelationship.All(this.ParentRelationship.Contains) ||
                                        model.ParentRelationship.Count != this.ParentRelationship.Count;
                if (hasParentChanges)
                {
                    hasChanges = true;
                    this.ParentRelationship = model.ParentRelationship;
                }
            }

            foreach (var field in template.Fields)
            {
                var oldCharData = this.Characteristics.SingleOrDefault(x => x.Key == field.Label);
                var newCharData = model.Characteristics.SingleOrDefault(x => x.Key == field.Label);

                if (!String.IsNullOrEmpty(newCharData.Value?.ToString()) && newCharData.Value?.ToString().ToUpper() != oldCharData.Value?.ToString().ToUpper())
                {
                    if (!onlyUpdateWhenNullOrEmpty || (onlyUpdateWhenNullOrEmpty && String.IsNullOrEmpty(oldCharData.Value?.ToString())) || (allowOverrideFieldNames != null && allowOverrideFieldNames.Contains(field.Label.ToUpper())))
                    {
                        hasChanges = true;
                        this.Characteristics.Remove(field.Label);
                        this.Characteristics.Add(newCharData.Key, newCharData.Value);
                    }
                }
            }

            return hasChanges;
        }
    }
}
