using Newtonsoft.Json;

namespace TornAPI.CompanyData;

public class Detailed {
	public int ID { get; set; }

	[JsonProperty("company_funds")]
	public long CompanyFunds { get; set; }

	[JsonProperty("company_bank")]
	public long CompanyBank { get; set; }

	[JsonProperty("popularity")]
	public int Popularity { get; set; }

	[JsonProperty("efficiency")]
	public int Efficiency { get; set; }

	[JsonProperty("environment")]
	public int Environment { get; set; }

	[JsonProperty("trains_available")]
	public int TrainsAvailable { get; set; }

	[JsonProperty("upgrades")]
	public int Upgrades { get; set; }

	[JsonProperty("value")]
	public long Value { get; set; }
}