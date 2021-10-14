using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{
    public class MessageEntityStatus
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }


}