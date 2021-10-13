using RightslineSampleLambdaDotNetV4.Consts;
using System;

namespace RightslineSampleLambdaDotNetV4.Models
{
    public class EntityRelationshipModel
    {
        public int? Id { get; set; }
        public string ParentURL { get; set; }
        public string ChildURL { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDate { get; set; }        

        public EntityRelationshipModel(CharTypeID parentCharTypeID, int parentRecID, CharTypeID? childCharTypeID = null, int? childRecID = null)
        {
            var endpoint = Environment.GetEnvironmentVariable(EnvironmentVariables.ApiUrl);

            this.ParentURL = $"http://{endpoint}/v2/{Enumerations.GetEnumDescription(parentCharTypeID)}/{parentRecID}";

            if (childCharTypeID != null && childRecID != null)
            {
                this.ChildURL = $"http://{endpoint}/v2/{Enumerations.GetEnumDescription(childCharTypeID)}/{childRecID}";
            }
        }

        public EntityRelationshipModel()
        {

        }
    }
    public class RelationshipType
    {
        public int RelationshipTypeId { get; set; }
        public string RelationshipTypeName { get; set; }

        public RelationshipType()
        {

        }
    }
}
