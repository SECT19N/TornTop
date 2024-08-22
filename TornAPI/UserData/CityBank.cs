using Newtonsoft.Json;

namespace TornAPI.UserData;

public class CityBank {
	[JsonProperty("amount")]
	public long Amount { get; set; }

	[JsonProperty("time_left")]
	public int TimeLeft { get; set; }
}