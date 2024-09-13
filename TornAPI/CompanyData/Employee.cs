using Newtonsoft.Json;
using TornAPI.UserData;

namespace TornAPI.CompanyData;

public class Employee {
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("position")]
	public string Position { get; set; }

	[JsonProperty("days_in_company")]
	public int DaysInCompany { get; set; }

	[JsonProperty("wage")]
	public int Wage { get; set; } = 0;

	[JsonProperty("manual_labor")]
	public long ManualLabor { get; set; } = 0;

	[JsonProperty("intelligence")]
	public long Intelligence { get; set; } = 0;

	[JsonProperty("endurance")]
	public long Endurance { get; set; } = 0;

	[JsonProperty("effectiveness")]
	public Effectiveness? Effectiveness { get; set; }

	[JsonProperty("last_action")]
	public LastAction LastAction { get; set; }

	[JsonProperty("status")]
	public Status Status { get; set; }
}
