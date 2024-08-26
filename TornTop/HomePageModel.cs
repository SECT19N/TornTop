using TornAPI;
using TornAPI.UserData;

namespace TornTop;

public class HomePageModel {
	public static Client Client { get; set; } = new();
	public static User User { get; set; } = new();
}