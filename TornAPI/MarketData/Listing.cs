using Newtonsoft.Json;

namespace TornAPI.MarketData;

public class Listing {
	[JsonProperty("id")]
	public long ID { get; set; }

	[JsonProperty("price")]
	public long Price { get; set; }

	[JsonProperty("amount")]
	public int Amount { get; set; }
}