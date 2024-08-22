using Newtonsoft.Json;

namespace TornAPI.MarketData;

public class Item {
    [JsonProperty("cost")]
    public long Cost { get; set; }

    [JsonProperty("quantity")]
    public long Quantity { get; set; }
}