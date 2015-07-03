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

        public override bool Equals(object obj)
        {
            var other = obj as CarouselImage;
            return other != null && Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            var hash = 3;
            hash += 17 * (Name == null ? 0 : Name.GetHashCode());
            return hash;
        }
    }
}
