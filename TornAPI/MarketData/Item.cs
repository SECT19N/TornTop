using Newtonsoft.Json;

namespace TornAPI.MarketData;

public class Item {
    [JsonProperty("id")]
    public int ID { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("average_price")]
    public long AveragePrice { get; set; }
}