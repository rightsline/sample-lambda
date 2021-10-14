using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{
    public class MessageEntityTemplate
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
    }
   
}