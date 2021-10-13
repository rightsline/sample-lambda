using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RightslineSampleLambdaDotNetV4.Requests
{
    [Serializable]
    [DataContract]
    public class EntitySearchRequest
    {
        [DataMember]
        public string Keywords { get; set; }
        [DataMember]
        public Dictionary<string, List<object>> Query { get; set; } = new Dictionary<string, List<object>>();
        [DataMember]
        public int? Start { get; set; }
        [DataMember]
        public int? Rows { get; set; }
        [DataMember]
        public string CursorToken { get; set; }
        [DataMember]
        public List<string> SortOrders { get; set; } = new List<string>();

        [DataMember]
        public Dictionary<int, Dictionary<string, List<object>>> ParentQuery { get; set; } =
            new Dictionary<int, Dictionary<string, List<object>>>();

        [DataMember]
        public Dictionary<int, Dictionary<string, List<object>>> ChildQuery { get; set; } =
            new Dictionary<int, Dictionary<string, List<object>>>();
    }
}
