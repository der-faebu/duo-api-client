using System.Collections.Generic;
using System.Net;
using DuoApiClientGUI.Helpers;
using Newtonsoft.Json;

namespace DuoApiClientGUI.Models.ApiResponses
{
    public interface IApiResponse
    {
        string Code { get; set; }
        [JsonProperty("code")]  string Status { get; set; }
        [JsonProperty("response")]
        [JsonConverter(typeof(SingleOrArrayConverter<Dictionary<string, object>>))]
        List<Dictionary<string, object>> ResponseData { get; set; }
        [JsonProperty("metadata")]  Dictionary<string, object> Metadata { get; set; }
        [JsonProperty("message")]  string Message { get; set; }
        [JsonProperty("message_detail")]  string MessageDetail { get; set; }
    }
}