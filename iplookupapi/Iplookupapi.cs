using System;
using iplookupapi.Helpers;

namespace iplookupapi
{
    public class Iplookupapi
    {
        private string ApiKey { get; }

        public Iplookupapi()
        {
        }

        public Iplookupapi(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string Status()
        {
            return RequestHelper.Status(ApiKey);
        }

        public string Info(string ip, string language = "")
        {
            return RequestHelper.Info(ApiKey, ip, language);
        }
    }
}

