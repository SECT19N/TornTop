using Newtonsoft.Json;

namespace TornAPI.UserData;

public class Cooldown {
	[JsonProperty("drug")]
	public int DrugCooldown { get; set; }

	[JsonProperty("medical")]
	public int MedicalCooldown { get; set; }

	[JsonProperty("booster")]
	public int BoosterCooldown { get; set; }
}
