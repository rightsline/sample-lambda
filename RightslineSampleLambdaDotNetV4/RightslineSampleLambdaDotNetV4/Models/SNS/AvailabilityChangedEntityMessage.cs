using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{
    
    public class AvailabilityChangedEntityMessage : EntityAuditInfo
    {
        public AvailabilityChangedEntityMessage()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public ICollection<MessageEntity> RootEntities { get; set; }
        public string Action { get; set; }
        public int MessageGroupId { get; set; }
        public MessageEntity Entity { get; set; }

        public DateTime? WindowStart { get; set; }
        public DateTime? WindowEnd { get; set; }
        public bool? IsExclusive { get; set; }
        public bool ActiveIndicatorChanged { get; set; }

        public ICollection<Dimension> Dim1 { get; set; }
        public ICollection<Dimension> Dim1Added { get; set; }
        public ICollection<Dimension> Dim1Removed { get; set; }

        public ICollection<Dimension> Dim2 { get; set; }
        public ICollection<Dimension> Dim2Added { get; set; }
        public ICollection<Dimension> Dim2Removed { get; set; }

        public ICollection<Dimension> Dim3 { get; set; }
        public ICollection<Dimension> Dim3Added { get; set; }
        public ICollection<Dimension> Dim3Removed { get; set; }

        public ICollection<Dimension> Dim4 { get; set; }
        public ICollection<Dimension> Dim4Added { get; set; }
        public ICollection<Dimension> Dim4Removed { get; set; }
    }


}