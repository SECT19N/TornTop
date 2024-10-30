using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Event {
    [JsonProperty("timestamp")]
    public int TimeStamp { get; set; }

    [JsonProperty("event")]
    public string EventDetail { get; set; }
}