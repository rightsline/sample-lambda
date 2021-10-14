using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{

    public class Dimension
    {
        public int? Id { get; set; }
        public string Xref { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            var change = obj as Dimension;
            return change != null &&
                   EqualityComparer<int?>.Default.Equals(Id, change.Id) &&
                   Xref == change.Xref &&
                   Value == change.Value;
        }

        public override int GetHashCode()
        {
            var hashCode = -1260537582;
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Xref);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }
    }

 
}