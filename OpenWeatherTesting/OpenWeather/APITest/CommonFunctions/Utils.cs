using Newtonsoft.Json;
using OpenWeather.OpenWeather.DataObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherAPI.OpenWeather.APITest.CommonFunctions
{
    public static class Utils
    {
        public static WeatherResponse_Code200 GetWeatherResponse(HttpWebResponse httpResponse)
        {
            string responseBody = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Replace("base", "baseAtt");
            return JsonConvert.DeserializeObject<WeatherResponse_Code200>(responseBody);
        }
    }
}
