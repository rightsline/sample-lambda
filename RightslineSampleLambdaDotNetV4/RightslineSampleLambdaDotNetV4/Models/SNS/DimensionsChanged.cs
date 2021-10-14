using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{
    

    public class DimensionsChanged
    {
        public int Dimension { get; set; }
        public ICollection<Dimension> Added { get; set; }
        public ICollection<Dimension> Removed { get; set; }
    }

   
}