using Newtonsoft.Json;

namespace TornAPI.UserData;

public class States {
    [JsonProperty("hospital_timestamp")]
    public int HostpitalTimestamp { get; set; }

    [JsonProperty("jail_timestamp")]
    public int JailTimestamp { get; set; }
}
