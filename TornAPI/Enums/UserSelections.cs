namespace TornAPI.Enums;

/// <summary>
/// An enumerator list to represent selectable fields from Torn API.
/// </summary>
/// <remarks>
///	Not all fields are implenented in this API.
/// </remarks>
[Flags]
public enum UserSelections {
	Attacks = 0x0,
	Bars = 0x1,
	Basic = 0x2,
	BattleStats = 0x4,
	Bazaar = 0x8,
	Cooldowns = 0x10,
	Crimes = 0x20,
	Discord = 0x40,
	Display = 0x80,
	Education = 0x100,
	Equipment = 0x200,
	Events = 0x400,
	Inventory = 0x800,
	JobPoints = 0x1000,
	Merits = 0x2000,
	Messages = 0x4000,
	Money = 0x8000,
	Networth = 0x1_0000,
	NewEvents = 0x2_0000,
	NewMessages = 0x4_0000,
	Notifications = 0x8_0000,
	Perks = 0x10_0000,
	PersonalStats = 0x20_0000,
	Profile = 0x40_0000,
	Properties = 0x80_0000,
	Refills = 0x100_0000,
	Reports = 0x200_0000,
	Skills = 0x400_0000,
	Stocks = 0x800_0000,
	Timestamp = 0x1_000_0000,
	Travel = 0x2_000_0000,
	WorkStats = 0x4_000_0000,
}