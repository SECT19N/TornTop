using Newtonsoft.Json;

namespace TornAPI.Utils;

public class ApiError {
	[JsonProperty("code")]
	public int Code { get; set; }

	[JsonProperty("error")]
	public string Message { get; set; }
}