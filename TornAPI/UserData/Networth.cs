using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Networth {
	[JsonProperty("total")]
	public long Total { get; set; }

	[JsonProperty("pending")]
	public long Pending { get; set; }

	[JsonProperty("wallet")]
	public long Wallet { get; set; }

	[JsonProperty("bank")]
	public long Bank { get; set; }

	[JsonProperty("cayman")]
	public long Cayman { get; set; }

	[JsonProperty("points")]
	public long Points { get; set; }

	[JsonProperty("vault")]
	public long Vault { get; set; }

	[JsonProperty("piggybank")]
	public long PiggyBank { get; set; }

	[JsonProperty("items")]
	public long Items { get; set; }

	[JsonProperty("displaycase")]
	public long DisplayCase { get; set; }

	[JsonProperty("bazaar")]
	public long Bazaar { get; set; }

	[JsonProperty("trade")]
	public long Trade { get; set; }

	[JsonProperty("itemmarket")]
	public long ItemMarket { get; set; }

	[JsonProperty("properties")]
	public long Properties { get; set; }

	[JsonProperty("stockmarket")]
	public long StockMarket { get; set; }

	[JsonProperty("auctionhouse")]
	public long AuctionHouse { get; set; }

	[JsonProperty("company")]
	public long Company { get; set; }

	[JsonProperty("bookie")]
	public long Bookie { get; set; }

	[JsonProperty("enlistedcars")]
	public long EnlistedCars { get; set; }

	[JsonProperty("loan")]
	public long Loan { get; set; }

	[JsonProperty("unpaidfees")]
	public long UnpaidFees { get; set; }
}
