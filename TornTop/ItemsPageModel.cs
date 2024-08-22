using TornAPI;
using TornAPI.MarketData;
using TornAPI.TornData;

namespace TornTop;

class ItemsPageModel {
	public static Client Client { get; set; } = new();
	public static Market Market { get; set; } = new();
	public static Torn Torn { get; set; } = new();
}