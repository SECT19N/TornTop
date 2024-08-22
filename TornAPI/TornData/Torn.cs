using Newtonsoft.Json;

namespace TornAPI.TornData;

public class Torn {
	[JsonProperty("items")]
	public Dictionary<int, Item> Items { get; set; } = [];

	[JsonProperty("bank")]
	public Bank Bank { get; set; }

	[JsonProperty("cards")]
	public Dictionary<int, Card> Cards { get; set; } = [];
	
	[JsonProperty("cityshops")]
	public Dictionary<int, CityShop> CityShops { get; set; } = [];
}