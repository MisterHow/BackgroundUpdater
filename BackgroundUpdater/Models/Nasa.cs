using Newtonsoft.Json;

namespace BackgroundUpdater.Models
{
    [Serializable]
    public class Nasa
    {
        [JsonProperty("copyright")]
        public string? Copyright { get; set; }
        [JsonProperty("date")]
        public string? Date { get; set; }
        [JsonProperty("explanation")]
        public string? Explanation { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("url")]
        public string? ImageUrl { get; set; }
    }
}
