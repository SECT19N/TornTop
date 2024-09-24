using Newtonsoft.Json;

namespace TornAPI.CompanyData;

public class Effectiveness {
	[JsonProperty("working_stats")]
	public int WorkingStats { get; set; } = 0;

	[JsonProperty("settled_in")]
	public int SettledIn { get; set; } = 0;

	[JsonProperty("director_education")]
	public int DirectorEducation { get; set; } = 0;

	[JsonProperty("management")]
	public int Management { get; set; } = 0;

	[JsonProperty("addiction")]
	public int Addiction { get; set; } = 0;

	[JsonProperty("inactivity")]
	public int Inactivity { get; set; } = 0;

	[JsonProperty("total")]
	public int Total { get; set; } = 0;
}
