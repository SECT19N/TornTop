using Newtonsoft.Json;

namespace TornAPI.TornData;

public class CityShop {
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("inventory")]
	public Dictionary<int, Inventory> Inventory { get; set; } = [];
}

public class Inventory {
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; }

	[JsonProperty("price")]
	public int Price { get; set; }

	[JsonProperty("in_stock")]
	public int InStock { get; set; }
}