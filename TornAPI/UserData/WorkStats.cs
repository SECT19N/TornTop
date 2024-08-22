using Newtonsoft.Json;

namespace TornAPI.UserData;

public class WorkStats {
	[JsonProperty("manual_labor")]
	public int MAN { get; set; }

	[JsonProperty("intelligence")]
	public int INT { get; set; }

	[JsonProperty("endurance")]
	public int END { get; set; }
}