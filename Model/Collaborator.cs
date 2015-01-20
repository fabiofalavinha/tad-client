using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class Collaborator
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }
        [JsonProperty("genederType")]
        public GenderType Gender { get; set; }
        public bool Active { get { return ReleaseDate == null; } }
        [JsonProperty("telephones")]
        public Telephone[] Telephones { get; set; }
    }
}
