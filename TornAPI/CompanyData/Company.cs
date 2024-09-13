using Newtonsoft.Json;

namespace TornAPI.CompanyData;

public class Company {
	[JsonProperty("company_detailed")]
	public Detailed Detailed { get; set; }

	[JsonProperty("applications")]
	public Application[] Applications { get; set; } = [];

	[JsonProperty("company_employees")]
	public Dictionary<int, Employee> Employees { get; set; } = [];

	[JsonProperty("company")]
	public CompanyProfile Profile { get; set; }

	[JsonProperty("company_stock")]
	public Dictionary<string, Stock> Stocks { get; set; } = [];

    [JsonProperty("timestamp")]
    public int TimeStamp { get; set; }
}