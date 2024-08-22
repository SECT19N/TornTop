using Newtonsoft.Json;

namespace TornAPI.Utils;

public class ErrorWrapper {
	[JsonProperty("error")]
	public ApiError Error { get; set; }
}