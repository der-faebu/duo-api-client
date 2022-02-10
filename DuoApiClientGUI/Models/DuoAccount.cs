using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoApiClientGUI.Models
{
    public class DuoAccount
    {
        [JsonProperty("name")]
        public string Name { get; set;}
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("api_hostname")]
        public string ApiHostname { get; set; }

    }
}
