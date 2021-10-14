using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{

    public class RelationshipType
    {
        public int RelationshipTypeId { get; set; }
        public string RelationshipTypeName { get; set; }
    }
}