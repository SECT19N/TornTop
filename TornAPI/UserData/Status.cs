using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Status {
    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }
    [JsonProperty("until")]
    public int Until { get; set; }
}