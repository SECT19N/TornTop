namespace TornAPI.Enums;

[Flags]
public enum CompanySelections {
	Applications = 0x1,
	Detailed = 0x2,
	Employees = 0x4,
	Profile = 0x8,
	Stock = 0x10,
	TimeStamp = 0x20
}