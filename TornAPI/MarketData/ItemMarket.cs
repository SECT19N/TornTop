using Newtonsoft.Json;

namespace TornAPI.MarketData;

public class ItemMarket {
	[JsonProperty("item")]
	public Item? Item { get; set; }

	[JsonProperty("listings")]
	public List<Listing> Listings { get; set; } = [];
}