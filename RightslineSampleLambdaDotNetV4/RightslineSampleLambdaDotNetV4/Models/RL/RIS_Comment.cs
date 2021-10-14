using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RightsLine.Contracts.Data.Entities;

namespace RightsLine.Contracts.Data.Comment
{
    [DataContract]
    [Serializable]
    public class RIS_Comment
    {
        [DataMember]
        public int? ParentID { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserEmail { get; set; }
        [DataMember]
        public string ProfileAvatar { get; set; }
        [DataMember]
        public RIS_EntityID EntityID { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        [DataMember]
        public DateTime Updated { get; set; }
        [DataMember]
        public List<RIS_Comment> Children { get; set; }

        public RIS_Comment()
        {
            this.Children = new List<RIS_Comment>();
        }
    }
}
