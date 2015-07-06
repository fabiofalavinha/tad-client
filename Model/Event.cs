using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public static class ColorExtensions
    {
        public static string ToHex(this Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        public static Color FromHex(this string color, Color defaultColor)
        {
            if (string.IsNullOrWhiteSpace(color))
            {
                return defaultColor;
            }
            return color.FromHex();
        }
        public static Color FromHex(this string color)
        {
            return (Color)new ColorConverter().ConvertFromString(color);
        }
    }

    public class Event
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("visibility")]
        public VisibilityType Visibility { get; set; }

        [JsonProperty("backColor")]
        public string BackColor { get; set; }

        [JsonProperty("fontColor")]
        public string FontColor { get; set; }
    }
}
