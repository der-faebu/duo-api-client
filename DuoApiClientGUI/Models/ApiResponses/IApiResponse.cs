using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace DuoApiClientGUI.Models.ApiResponses
{
    public interface IApiResponse
    {
        public string  Code { get; set; }
        [JsonProperty("code")] public string Status { get; set; }
        [JsonProperty("response")] public Dictionary<string, object>[]? ResponseData { get; set; }
        [JsonProperty("metadata")] public Dictionary<string, object>? Metadata { get; set; }
        [JsonProperty("message")] public string? Message { get; set; }
        [JsonProperty("message_detail")] public string? MessageDetail { get; set; }
    }
}