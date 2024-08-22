namespace TornAPI.Enums;

/// <summary>
/// An enumerator list to represent selectable fields from Torn API.
/// </summary>
/// <remarks>
///	Not all fields are implenented in this API.
/// </remarks>
[Flags]
public enum TornSelections {
	Bank = 0x0,
	Cards = 0x1,
	CityShops = 0x2,
	Companies = 0x4,
	DirtyBomb = 0x8,
	Education = 0x10,
	FactionTree = 0x20,
	Gyms = 0x40,
	Honors = 0x80,
	Items = 0x100,
	LogCategories = 0x200,
	LogType = 0x400,
	Medals = 0x800,
	OrganizedCrimes = 0x1_000,
	Pawnshop = 0x2_000,
	PokerTables = 0x4_000,
	Properties = 0x8_000,
	Rackets = 0x10_000,
	Raids = 0x20_000,
	RankedWars = 0x40_000,
	RockPaperScissors = 0x80_000,
	SearchForCash = 0x100_000,
	Shoplifting = 0x200_000,
	Stats = 0x400_000,
	Stocks = 0x800_000,
	Territory = 0x1_000_000,
	TerritorNames = 0x2_000_000,
	TerritoryWars = 0x4_000_000
}