using System.Collections.Generic;
using System.Net;
using System.Xml;
using Newtonsoft.Json;

namespace DuoApiClientGUI.Models.ApiResponses
{
    public class ApiSuccessResponse : IApiResponse
    {
        [JsonProperty("stat")]
        public string Status { get; set; }
        public string Code { get; set; }
        [JsonProperty("response")] public Dictionary<string, object>[]? ResponseData { get; set; }
        [JsonProperty("metadata")] public Dictionary<string, object>? Metadata { get; set; }
        public string? Message { get; set; }
        public string? MessageDetail { get; set; }

        public ApiSuccessResponse()
        {
            
        }
    }
}