using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DuoApiClientGUI.Enums;
using DuoApiClientGUI.Models.Api;
using DuoApiClientGUI.Models.ApiResponses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DuoApiClientGUI.Models
{
    public class DuoApiRequest : IDuoApiRequest
    {
        private readonly IConfiguration _config;
        private ApiClientCredentials<IDuoApi>? _credentials;
        private static readonly HttpClient client = new HttpClient();
        public string RequestDateTime { get; private set; }
        public QueryParameters? QueryParameters { get; set; } = new QueryParameters();
        public string GetMethod()
        {
            return QueryParameters.Method.ToUpper();
        }

        public string Host { get; private set; }
        public string? CanonicalRequest { get; private set; }
        public Uri? RequestUri { get; private set; }

        public DuoApiRequest(IConfiguration config)
        {
            _config = config;
        }
        public void PrepareRequest(ApiClientCredentials<IDuoApi>? credentials, QueryParameters? parameters)
        {
            this.QueryParameters = parameters;
            if (parameters.Parameters == null)
            {
                QueryParameters.Parameters = new Dictionary<string, string>();
            }
            else
            {
                QueryParameters = parameters;
            }
            _credentials = credentials;
            Host = _credentials.ApiHost;
            RequestDateTime = GetRfc2822Representation(DateTime.UtcNow);
            CanonicalizeRequest();
            SetRequestUri();
        }

        static string GetRfc2822Representation(DateTime dateTime)
        {
            TimeSpan offset = TimeZoneInfo.Local.BaseUtcOffset;
            var rfcDAteTime = dateTime.ToString("ddd, dd MMM yyyy HH:mm:ss -") + "0000";
            return rfcDAteTime;
        }

        void SetRequestUri()
        {
            var uri = "https://" + Host + QueryParameters?.Path;
            this.RequestUri = new UriBuilder(uri).Uri;
        }

        string GetCanonicalParams()
        {
            var srotedParams = QueryParameters?.Parameters.OrderBy(key => key.Key);
            var ret = new List<String>();
            foreach (KeyValuePair<string, string> pair in srotedParams)
            {
                var key = HttpUtility.UrlEncode(pair.Key);
                var value = HttpUtility.UrlEncode(pair.Value);
                string p = $"{key}={value}";

                p = FinishCanonicalize(p);
                ret.Add(p);
            }

            ret.Sort(StringComparer.Ordinal);
            return string.Join("&", ret.ToArray());
        }

        string FinishCanonicalize(string p)
        {
            // Signatures require upper-case hex digits.
            p = Regex.Replace(p,
                "(%[0-9A-Fa-f][0-9A-Fa-f])",
                c => c.Value.ToUpperInvariant());
            // Escape only the expected characters.
            p = Regex.Replace(p,
                "([!'()*])",
                c => "%" + Convert.ToByte(c.Value[0]).ToString("X"));
            p = p.Replace("%7E", "~");
            // UrlEncode converts space (" ") to "+". The
            // signature algorithm requires "%20" instead. Actual
            // + has already been replaced with %2B.
            p = p.Replace("+", "%20");
            return p;
        }

        void CanonicalizeRequest()
        {
            List<string> lines = new List<string>()
            {
                RequestDateTime,
                GetMethod().ToString().ToUpperInvariant(),
                Host.ToLower(),
                QueryParameters.Path,
                GetCanonicalParams()
            };

            string canon = String.Join("\n",
                lines.ToArray());
            CanonicalRequest = canon;
        }

        public async Task<IApiResponse> InvokeRequestAsync(string authHeader)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = RequestUri;
            request.Method = new HttpMethod(this.GetMethod());
            request.Headers.Add("X-Duo-Date", RequestDateTime);
            request.Headers.Add("Authorization", authHeader);


            if (QueryParameters.Method == "POST" && QueryParameters.Parameters.Count > 0)
            {
                request.Content = new FormUrlEncodedContent(QueryParameters.Parameters);

                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            }
            var responseMessage = await client.SendAsync(request);
            var responseString = await responseMessage.Content.ReadAsStringAsync();


            var responseJObject = JObject.Parse(responseString);
            IApiResponse response;

            if (responseJObject["stat"].ToString() == "OK")
            {
                // todo: optimise response models. Might currently throw if single object instead of array is returned
                try
                {
                    return JsonConvert.DeserializeObject<ApiSuccessResponse>(responseString);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                Console.WriteLine(responseString);
            }
            else
            {
                try
                {
                    return JsonConvert.DeserializeObject<ApiErrorResponse>(responseString);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            return new ApiErrorResponse();
        }
    }
}