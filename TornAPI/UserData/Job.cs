using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Job {
    [JsonProperty("job")]
    public string JobStatus { get; set; }

    [JsonProperty("position")]
    public string Position { get; set; }

    [JsonProperty("company_id")]
    public int CompanyId { get; set; }

    [JsonProperty("company_name")]
    public string CompanyName { get; set; }

    [JsonProperty("company_type")]
    public CompanyTypes CompanyType { get; set; }
}
