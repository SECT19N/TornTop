using Newtonsoft.Json;

namespace TornAPI.CompanyData;

public class Stock {
	[JsonProperty("cost")]
	public int Cost { get; set; }

	[JsonProperty("in_stock")]
	public int InStock { get; set; }

	[JsonProperty("on_order")]
	public int OnOrder { get; set; }

	[JsonProperty("price")]
	public int Price { get; set; }

	[JsonProperty("rrp")]
    public int RRP { get; set; }

	[JsonProperty("sold_amount")]
	public int SoldAmount { get; set; }

	[JsonProperty("SoldWorth")]
    public int SoldWorth { get; set; }
}
