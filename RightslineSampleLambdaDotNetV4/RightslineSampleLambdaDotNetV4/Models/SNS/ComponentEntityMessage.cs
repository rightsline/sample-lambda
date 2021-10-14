using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.MessageQueuing.V4.Messages
{

    public class ComponentEntityMessage : ModuleEntityMessage
    {
        public MessageEntity RootEntity { get; set; }
    }

  
}