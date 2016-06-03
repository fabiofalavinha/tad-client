using Newtonsoft.Json;
using System;

namespace TadManagementTool.Model
{
    public class Post
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public User CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "modifiedBy")]
        public User ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTime Modified { get; set; }

        [JsonProperty(PropertyName = "publishedBy")]
        public User PublishedBy { get; set; }

        [JsonProperty(PropertyName = "published")]
        public DateTime? Published { get; set; }

        [JsonProperty(PropertyName = "visibility")]
        public VisibilityType Visibility { get; set; }

        [JsonProperty(PropertyName = "order")]
        public int Order { get; set; }

        [JsonIgnore]
        public bool IsPublished { get { return Published.HasValue; } }

        public void Unpublish()
        {
            Published = null;
            PublishedBy = null;
        }
    }
}
