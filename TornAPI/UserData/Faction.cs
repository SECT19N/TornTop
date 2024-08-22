using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Faction {
    [JsonProperty("position")]
    public string Position { get; set; }

    [JsonProperty("faction_id")]
    public int FactionId { get; set; }

	[JsonProperty("days_in_faction")]
	public int DaysInFaction { get; set; }

	[JsonProperty("faction_name")]
    public string FactionName { get; set; }

    [JsonProperty("faction_tag")]
    public string FactionTag { get; set; }
}
