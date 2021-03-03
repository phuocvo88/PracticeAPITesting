using Newtonsoft.Json;
using OpenWeatherAPI.HttpUtils;
using OpenWeatherAPI.OpenWeather.DataObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherAPI.OpenWeather.CommonFunctions
{
    public class CallCurrWthForOneLoc
    {
        public HttpWebResponse GetWthBy_CtName(string baseUrl, string cityName, string apiKey)
        {
            string queriesTemplate = "q={0}&appid={1}";
            string queries = String.Format(queriesTemplate, cityName, apiKey);
            string requestUrl = baseUrl + "?" + queries;

            return new HttpClientUtils().SendGetRequest(requestUrl);
      

            
        }

        public void GetWthBy_CtName_StateCode(string strUrl)
        {
            //string strUrl = String.Format("http://api.openweathermap.org/data/2.5/weather?q=Ha Noi&appid=2f45ec1571c6451311ed3c4b5937678b");

            HttpClientUtils httpClient = new HttpClientUtils();
            var httpResponse = httpClient.SendGetRequest(strUrl);

            //convert response to String
            string responseBody = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Replace("base", "baseAtt");

            //convert response from string to Json
            WeatherResponse response = JsonConvert.DeserializeObject<WeatherResponse>(responseBody);
            Console.WriteLine();
        }
    }
}
