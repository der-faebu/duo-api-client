using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using DuoApiClientGUI.Helpers;

namespace DuoApiClientGUI.Models.ApiResponses
{
    public class ApiErrorResponse : IApiResponse
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("stat")] public string? Status { get; set; }
        [JsonProperty("response")]
        [JsonConverter(typeof(SingleOrArrayConverter<Dictionary<string, object>>))]
        public List<Dictionary<string, object>>? ResponseData { get; set; }
        [JsonProperty("metadata")] public Dictionary<string, object>? Metadata { get; set; }
        [JsonProperty("message")] public string? Message { get; set; }
        [JsonProperty("message_detail")] public string? MessageDetail { get; set; }

    }
    
}