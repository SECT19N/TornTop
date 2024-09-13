using Newtonsoft.Json;

namespace TornAPI.CompanyData;

public class CompanyProfile {
    public int ID { get; set; }

	[JsonProperty("company_type")]
    public int CompanyType { get; set; }

	[JsonProperty("rating")]
    public int Stars { get; set; }

	[JsonProperty("name")]
    public string Name { get; set; }

	[JsonProperty("director")]
    public int Director { get; set; }

	[JsonProperty("employees_hired")]
    public int EmployeesHired { get; set; }

	[JsonProperty("employees_capacity")]
    public int EmployeesCapacity { get; set; }

	[JsonProperty("daily_income")]
    public int DailyIncome { get; set; }

	[JsonProperty("daily_customers")]
    public int DailyCustomers { get; set; }

	[JsonProperty("weekly_income")]
    public int WeeklyIncome { get; set; }

	[JsonProperty("weekly_customers")]
    public int WeeklyCustomers { get; set; }

	[JsonProperty("days_old")]
    public int DaysOld { get; set; }

	[JsonProperty("weekly_customers")]
    public Dictionary<int, Employee> Employees { get; set; }
}
