﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class CommunicationMessage 
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        public CommunicationMessage()
            : this(string.Empty)
        {
        }

        public CommunicationMessage(string message)
        {
            Content = message;
        }
    }
}
