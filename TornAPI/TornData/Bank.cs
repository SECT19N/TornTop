using Newtonsoft.Json;

namespace TornAPI.TornData;

public class Bank {
    [JsonProperty("1w")]
    public decimal OneWeek { get; set; }

    [JsonProperty("2w")]
    public decimal TwoWeeks { get; set; }

    [JsonProperty("1m")]
    public decimal OneMonth { get; set; }

    [JsonProperty("2m")]
    public decimal TwoMonths { get; set; }

    [JsonProperty("3m")]
    public decimal ThreeMonths { get; set; }
}