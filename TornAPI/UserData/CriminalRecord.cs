using Newtonsoft.Json;

namespace TornAPI.UserData;

public class CriminalRecord {
	[JsonProperty("vandalism")]
	public int Vandalism { get; set; }

	[JsonProperty("theft")]
	public int Theft { get; set; }

	[JsonProperty("counterfeiting")]
	public int Counterfeiting { get; set; }

	[JsonProperty("fraud")]
	public int Fraud { get; set; }

	[JsonProperty("illicitservices")]
	public int IllicitServices { get; set; }

	[JsonProperty("cybercrime")]
	public int CyberCrime { get; set; }

	[JsonProperty("extortion")]
	public int Extortion { get; set; }

	[JsonProperty("illegalproduction")]
	public int IllegalProduction { get; set; }

	[JsonProperty("total")]
	public int Total { get; set; }
}
