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
        static string getByCityNameEndPoint = "q={0}&appid={1}";
        static string getByCityIdEndPoint = "id={0}&appid={1}";

        public static HttpWebResponse GetWthBy_CtName(string baseUrl, string cityName, string apiKey)
        {
            string queries = String.Format(getByCityNameEndPoint, cityName, apiKey);
            string requestUrl = baseUrl + "?" + queries;

            return new HttpUtils.HttpClientUtils().SendGetRequest(requestUrl);
        }

        public static HttpWebResponse GetWthBy_CtName_StateCode(string baseUrl, string cityId, string apiKey)
        {
            string queries = String.Format(getByCityNameEndPoint, cityId, apiKey);
            string requestUrl = baseUrl + "?" + queries;

            return new HttpClientUtils().SendGetRequest(requestUrl);
        }

        public static void verifyGetWeather(WeatherResponse actualWeatherResponse, WeatherResponse expectedWeatherRepsone)
        {
            // verify the resopne 
        }
    }
}
