using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Bar {
	[JsonProperty("current")]
	public int Current { get; set; }

	[JsonProperty("maximum")]
	public int Maximum { get; set; }

	[JsonProperty("increment")]
	public int Increment { get; set; }

	[JsonProperty("interval")]
	public int Interval { get; set; }

	[JsonProperty("ticktime")]
	public int TickTime { get; set; }

	[JsonProperty("fulltime")]
	public int FullTime { get; set; }
}
