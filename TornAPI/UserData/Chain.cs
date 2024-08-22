using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Chain {
	[JsonProperty("current")]
	public int Current { get; set; }

	[JsonProperty("maximum")]
	public int Maximum { get; set; }

	[JsonProperty("timeout")]
	public int TimeOut { get; set; }

	[JsonProperty("modifier")]
	public decimal Modifier { get; set; }

	[JsonProperty("cooldown")]
	public int Cooldown { get; set; }
}