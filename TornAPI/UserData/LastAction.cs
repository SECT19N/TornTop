using Newtonsoft.Json;

namespace TornAPI.UserData;

public class LastAction {
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("timestamp")]
    public int Timestamp { get; set; }

    [JsonProperty("relative")]
    public string Relative { get; set; }
}
