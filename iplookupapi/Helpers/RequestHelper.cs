using System;
using System.IO;
using System.Net;

namespace iplookupapi.Helpers
{
    public class RequestHelper
    {
        public const string BaseUrl = "https://api.iplookupapi.com/v1/";

        public RequestHelper()
        {
        }

        public static string Status(string apiKey = null)
        {
            string url;
            url = BaseUrl + "/status?apikey=" + apiKey;

            return GetResponse(url);
        }

        public static string Info(string apiKey, string ip, string language)
        {
            string url;
            url = BaseUrl + "/info?ip="+ ip +"&language=" + language + "&apikey=" + apiKey;

            return GetResponse(url);
        }

        private static string GetResponse(string url)
        {
            string jsonString;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    jsonString = reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        jsonString = reader.ReadToEnd();
                    }
                }
            }


            return jsonString;
        }
    }
}

