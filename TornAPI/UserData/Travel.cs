using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Travel {
	[JsonProperty("destination")]
	public string Destination { get; set; } = "N/A";

	[JsonProperty("method")]
	public string Method { get; set; } = "N/A";

	[JsonProperty("timestamp")]
	public int ArrivalTime { get; set; }

	[JsonProperty("departed")]
	public int Departed { get; set; }
	[JsonProperty("time_left")]
	public int TimeLeft { get; set; }
}
