using Newtonsoft.Json;

namespace TornAPI.CompanyData;

public class Effectiveness {
	[JsonProperty("working_stats")]
	public int WorkingStats { get; set; }

	[JsonProperty("settled_in")]
	public int SettledIn { get; set; }

	[JsonProperty("director_education")]
	public int DirectorEducation { get; set; }

	[JsonProperty("addiction")]
	public int Addiction { get; set; }

	[JsonProperty("total")]
	public int Total { get; set; }
}
