using Newtonsoft.Json;

namespace TornAPI.TornData;

public class Item {
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("effect")]
	public string Effect { get; set; }

	[JsonProperty("requirement")]
	public string Requirement { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; }

	[JsonProperty("weapon_type")]
	public string WeaponType { get; set; }

	[JsonProperty("buy_price")]
	public long BuyPrice { get; set; }

	[JsonProperty("sell_price")]
	public long SellPrice { get; set; }

	[JsonProperty("market_value")]
	public long? MarketValue { get; set; }

	[JsonProperty("circulation")]
	public long Circulation { get; set; }

	[JsonProperty("image")]
	public string Image { get; set; }
}