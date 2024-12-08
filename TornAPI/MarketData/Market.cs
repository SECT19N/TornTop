using Newtonsoft.Json;

namespace TornAPI.MarketData;

public class Market {
	[JsonProperty("itemmarket")]
	public ItemMarket ItemMarket { get; set; }
}