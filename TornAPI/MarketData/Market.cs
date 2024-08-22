using Newtonsoft.Json;

namespace TornAPI.MarketData;

public class Market {
	[JsonProperty("itemmarket")]
	public Item[] MarketItems { get; set; } = [];

	[JsonProperty("bazaar")]
	public Item[] BazaarItems { get; set; } = [];

    [JsonProperty("pointsmarket")]
    public Dictionary<long, Points> PointsMarket { get; set; } = [];
}