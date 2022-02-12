using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DuoApiClientGUI.Models.Entities
{
    internal class DuoUser : IDuoUser
    {
        public DuoUser(string alias1, string email, string firstName, string lastLogin, string lastName, string userId)
        {
            Alias1 = alias1;
            Email = email;
            FirstName = firstName;
            LastLogin = lastLogin;
            LastName = lastName;
            UserId = userId;
        }

        [JsonProperty("alias1")]
        public string Alias1 { get; set; }
        [JsonProperty("alias2")]
        public string Alias2 { get; set; }
        [JsonProperty("alias3")]
        public string Alias3 { get; set; }
        [JsonProperty("alias4")]
        public string Alias4 { get; set; }
        [JsonProperty("created")]
        public string Created { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstmane")]
        public string FirstName { get; set; }
        [JsonProperty("groups")]
        public List<Dictionary<string, string>> Groups = new List<Dictionary<string, string>>();
        [JsonProperty("is_enrolled")]
        public bool IsEnrolled { get; set; }
        [JsonProperty("last_directory_sync")]
        public string LastDirectorySync { get; set; }
        [JsonProperty("last_login")]
        public string LastLogin { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("realname")]
        public string RealName { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }

        
    }

}
