using HttpUtils;
using Newtonsoft.Json;
using OpenWeather.OpenWeather.DataObject;
using System;
using System.IO;
using System.Net;


namespace OpenWeatherAPI.OpenWeather.APITest.CommonFunctions
{
    public static class OpenWeatherAPIs
    {
        // Declare the endpoints, this endpoints can be defined in the test data files
        static string route_getByCityNameEndPoint = "q={0}&appid={1}";
        static string route_GetByCityIdEndPoint = "id={0}&appid={1}";

        public static HttpWebResponse Get_CtNameAndApiKey(string baseUrl, string cityName, string apiKey)
        {
            string queries = String.Format(route_getByCityNameEndPoint, cityName, apiKey);
            string requestUrl = baseUrl + "?" + queries;

            return new HttpUtils.HttpClientUtils().SendGetRequest(requestUrl);
        }

        public static HttpWebResponse Get_CtIdAndApiKey(string baseUrl, string cityId, string apiKey)
        {
            string queries = String.Format(route_getByCityNameEndPoint, cityId, apiKey);
            string requestUrl = baseUrl + "?" + queries;

            return new HttpClientUtils().SendGetRequest(requestUrl);
        }

        
    }
}
