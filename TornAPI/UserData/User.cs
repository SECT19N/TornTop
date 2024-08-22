using Newtonsoft.Json;

namespace TornAPI.UserData;

public class User {
    [JsonProperty("rank")]
    public string Rank { get; set; }

    [JsonProperty("level")]
    public int Level { get; set; }

    [JsonProperty("honor")]
    public int Honor { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("property")]
    public string Property { get; set; }

    [JsonProperty("signup")]
    public string SignUp { get; set; }

    [JsonProperty("awards")]
    public int Awards { get; set; }

    [JsonProperty("points")]
    public int Points { get; set; }

    [JsonProperty("cayman_bank")]
    public int CaymanBank { get; set; }

    [JsonProperty("vault_amount")]
    public int VaultAmount { get; set; }

    [JsonProperty("company_funds")]
    public int CompanyFunds { get; set; }

    [JsonProperty("daily_networth")]
    public long DailyNetworth { get; set; }

    [JsonProperty("money_onhand")]
    public int MoneyOnhand { get; set; }

    [JsonProperty("city_bank")]
    public CityBank TornBank { get; set; }

    [JsonProperty("manual_labor")]
    public int ManualLabor { get; set; }

    [JsonProperty("intelligence")]
    public int Intelligence { get; set; }

    [JsonProperty("endurance")]
    public int Endurance { get; set; }
    
	[JsonProperty("friends")]
    public int Friends { get; set; }

    [JsonProperty("enemies")]
    public int Enemies { get; set; }

    [JsonProperty("forum_posts")]
    public int ForumPosts { get; set; }

    [JsonProperty("karma")]
    public int Karma { get; set; }

	[JsonProperty("age")]
	public int Age { get; set; }

	[JsonProperty("role")]
	public string Role { get; set; }

	[JsonProperty("donator")]
	public bool Donator { get; set; }

	[JsonProperty("player_id")]
	public int PlayerId { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("revivable")]
	public bool Revivable { get; set; }

	[JsonProperty("profile_image")]
	public string ProfileImage { get; set; }

    [JsonProperty("status")]
    public Status Status { get; set; }

	[JsonProperty("job")]
	public Job Job { get; set; }

	[JsonProperty("faction")]
	public Faction Faction { get; set; }

	[JsonProperty("graffiti")]
	public decimal Graffiti { get; set; }

	[JsonProperty("shoplifting")]
	public decimal Shoplifting { get; set; }

	[JsonProperty("cracking")]
	public decimal Cracking { get; set; }

	[JsonProperty("search_for_cash")]
	public decimal SearchForCash { get; set; }

	[JsonProperty("hunting")]
	public decimal Hunting { get; set; }

    [JsonProperty("bootlegging")]
    public decimal Bootlegging { get; set; }

	[JsonProperty("reviving")]
	public decimal Reviving { get; set; }

	[JsonProperty("burglary")]
	public decimal Burglary { get; set; }

	[JsonProperty("disposal")]
	public decimal Disposal { get; set; }

    [JsonProperty("card_skimming")]
    public decimal CardSkimming { get; set; }

	[JsonProperty("hustling")]
	public decimal Hustling { get; set; }

	[JsonProperty("racing")]
	public decimal Racing { get; set; }

	[JsonProperty("pickpocket")]
	public decimal Pickpocket { get; set; }

	[JsonProperty("forgery")]
	public decimal Forgery { get; set; }

    [JsonProperty("married")]
    public Marriage Marriage { get; set; }

	[JsonProperty("states")]
	public States States { get; set; }

    [JsonProperty("last_action")]
    public LastAction LastAction { get; set; }

    [JsonProperty("server_time")]
	public int ServerTime { get; set; }

	[JsonProperty("timestamp")]
	public int CurrentTime { get; set; }

	[JsonProperty("strength")]
	public int Strength { get; set; }

	[JsonProperty("speed")]
	public int Speed { get; set; }

	[JsonProperty("dexterity")]
	public int Dexterity { get; set; }

	[JsonProperty("defense")]
	public int Defense { get; set; }

	[JsonProperty("strength_modifier")]
	public int StrengthModifier { get; set; }

	[JsonProperty("speed_modifier")]
	public int SpeedModifier { get; set; }

	[JsonProperty("dexterity_modifier")]
	public int DexterityModifier { get; set; }

	[JsonProperty("defense_modifier")]
	public int DefenseModifier { get; set; }

	[JsonProperty("strength_info")]
	public string[] StrengthInfo { get; set; }

	[JsonProperty("defense_info")]
	public string[] DefenseInfo { get; set; }

	[JsonProperty("speed_info")]
	public string[] SpeedInfo { get; set; }

	[JsonProperty("dexterity_info")]
	public string[] DexterityInfo { get; set; }

	[JsonProperty("bazaar")]
	public string[] Bazaar { get; set; } //TODO - idek what data type it should be.

	[JsonProperty("networth")]
	public Networth Networth { get; set; }

	[JsonProperty("happy")]
	public Bar Happy { get; set; } = new Bar();

	[JsonProperty("life")]
	public Bar Life { get; set; } = new Bar();

	[JsonProperty("energy")]
	public Bar Energy { get; set; } = new Bar();

	[JsonProperty("nerve")]
	public Bar Nerve { get; set; } = new Bar();

	[JsonProperty("chain")]
	public Chain Chain { get; set; } = new Chain();

	[JsonProperty("cooldowns")]
	public Cooldown Cooldowns { get; set; } = new Cooldown();

	[JsonProperty("travel")]
	public Travel Travel { get; set; } = new Travel();

	[JsonProperty("criminalrecord")]
	public CriminalRecord Crimes { get; set; } = new CriminalRecord();
}