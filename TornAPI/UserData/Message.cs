using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Message {
    [JsonProperty("timestamp")]
    public int TimeStamp { get; set; }

    [JsonProperty("ID")]
    public int SenderID { get; set; }

    [JsonProperty("name")]
    public required string SenderName { get; set; }

    [JsonProperty("type")]
    public required string MessageType { get; set; }

    [JsonProperty("title")]
    public required string MessageTitle { get; set; }

    [JsonProperty("seen")]
    public bool Seen { get; set; }

    [JsonProperty("read")]
    public bool Read { get; set; }
}