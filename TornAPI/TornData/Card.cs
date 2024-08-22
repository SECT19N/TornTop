using Newtonsoft.Json;

namespace TornAPI.TornData;

public class Card {
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("class")]
	public string Class { get; set; }

	[JsonProperty("short")]
	public string Short { get; set; }

	[JsonProperty("rank")]
	public string Rank { get; set; }
}