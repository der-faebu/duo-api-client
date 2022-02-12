using System;
using System.Security.Cryptography;
using System.Text;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Models.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DuoApiClientGUI.BusinessLogic.Services.Authentication
{
    public class AuthHeaderService : IAuthHeaderService
    {
        private readonly ILogger<AuthHeaderService> _logger;
        private readonly IConfiguration _config;

        public AuthHeaderService(ILogger<AuthHeaderService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public string CreateAuthHeader(ApiClientCredentials<IDuoApi> credentials, IDuoApiRequest request)
        {
            _logger.LogInformation("Called CreateAuthHeader.");
            var signedRequest = HmacSign(request, credentials);
            
            var myHeader = SetHeaderContent(credentials?.AuthMethod.ToString(), Encode64(signedRequest,credentials));

            return myHeader;
        }

        string SetHeaderContent(string method, string headerValue)
        {
            // first name = integration key from creds
            return $"{method} {headerValue}";
        }
        
        string HmacSign(IDuoApiRequest request, ApiClientCredentials<IDuoApi> credentials)
        {
            var data = request.CanonicalRequest;
            byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(credentials.SecretKey);
            HMACSHA1 hmac = new HMACSHA1(keyBytes);

            byte[] dataBytes = ASCIIEncoding.ASCII.GetBytes(data);
            hmac.ComputeHash(dataBytes);

            string hex = BitConverter.ToString(hmac.Hash);
            return hex.Replace("-", "").ToLower();
        }

        private static string Encode64(string signedRequest, ApiClientCredentials<IDuoApi> credentials)
        {
            var credentialsToEncode = $"{credentials.IntegrationKey}:{signedRequest}";
            byte[] plaintextBytes = ASCIIEncoding.ASCII.GetBytes(credentialsToEncode);
            string encoded = Convert.ToBase64String(plaintextBytes);
            return encoded;
        }
    }
}