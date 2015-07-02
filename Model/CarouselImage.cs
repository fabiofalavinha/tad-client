using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class CarouselImage
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
