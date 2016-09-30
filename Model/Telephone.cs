using Newtonsoft.Json;

namespace TadManagementTool.Model
{
    public class Telephone
    {
        [JsonProperty("phoneType")]
        public PhoneType PhoneType { get; set; }
        [JsonProperty("areaCode")]
        public int AreaCode { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: ({1}) {2}", PhoneType.Translate(), AreaCode, Number);
        }
    }
}
