using System.Collections.Generic;

namespace RightslineSampleLambdaDotNet.Models
{
    public class EntitySearchModel
    {
        public int NumFound { get; set; }
        public List<EntityModel> Entities { get; set; } = new List<EntityModel>();

        public EntitySearchModel()
        {

        } 
    }
}
