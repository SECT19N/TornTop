using Newtonsoft.Json;

namespace TornAPI.MarketData;

public class Points {
    [JsonProperty("cost")]
    public int Cost { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("total_cost")]
    public long TotalCost { get; set; }
}