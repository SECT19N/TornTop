using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Marriage {
    [JsonProperty("spouse_id")]
    public int SpouseId { get; set; }

    [JsonProperty("spouse_name")]
    public string SpouseName { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }
}
