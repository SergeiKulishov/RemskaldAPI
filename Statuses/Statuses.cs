using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemskaldAPI.Statuses
{
    public class Status
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("group")]
        public int Group { get; set; }
    }

    public class Statuses
    {
        [JsonProperty("data")]
        public List<Status> Data { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}