using System;
using System.Collections.Generic;
using System.Text;

namespace RightslineSampleLambdaDotNet.Models
{
    public class EntityStatusModel
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public EntityStatusModel(int statusID, string statusName)
        {
            this.StatusId = statusID;
            this.StatusName = statusName;
        }
    }
}
