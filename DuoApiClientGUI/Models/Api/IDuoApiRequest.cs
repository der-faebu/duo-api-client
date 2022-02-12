using DuoApiClientGUI.Enums;
using DuoApiClientGUI.Models.Api;
using DuoApiClientGUI.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuoApiClientGUI.Models
{
    public interface IDuoApiRequest
    {
        string RequestDateTime { get; }
        string GetMethod();
        QueryParameters QueryParameters { get; set; }
        string Host { get; }
        string CanonicalRequest { get; }
        Uri RequestUri { get; }

        void PrepareRequest(ApiClientCredentials<IDuoApi> credentials, QueryParameters parameters);

        Task<IApiResponse> InvokeRequestAsync(string authHeader);
    }
}