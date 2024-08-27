namespace TornAPI.Enums;

/// <summary>
/// An enumerator list to represent selectable fields from Torn API.
/// </summary>
/// <remarks>
///	Not all fields are implenented in this API.
/// </remarks>
[Flags]
public enum UserSelections {
	Profile = 0x0,
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
	JobPoints = 0x1_000,
	Merits = 0x2_000,
	Messages = 0x4_000,
	Money = 0x8_000,
	Networth = 0x10_000,
	NewEvents = 0x20_000,
	NewMessages = 0x40_000,
	Notifications = 0x80_000,
	Perks = 0x100_000,
	PersonalStats = 0x200_000,
	Attacks = 0x400_000,
	Properties = 0x800_000,
	Refills = 0x1_000_000,
	Reports = 0x2_000_000,
	Skills = 0x4_000_000,
	Stocks = 0x8_000_000,
	Timestamp = 0x10_000_000,
	Travel = 0x20_000_000,
	WorkStats = 0x40_000_000,
}