using Newtonsoft.Json;
using TornAPI.UserData;

namespace TornAPI.CompanyData;

public class Application {
	[JsonProperty("expires")]
	public int Expires { get; set; }

	[JsonProperty("level")]
	public int Level { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("stats")]
	public WorkStats Stats { get; set; }

	[JsonProperty("status")]
	public Status Status { get; set; }

	[JsonProperty("userID")]
	public int UserID { get; set; }
}
