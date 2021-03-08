using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeather.OpenWeather.DataObject;

namespace OpenWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string baseUrl = "http://api.openweathermap.org/data/2.5/weather";
            //string queriesTemplate = "q={0}&appid={1}";
            //string queries_1 = String.Format(queriesTemplate, "Ha Noi", "2f45ec1571c6451311ed3c4b5937678b");
            //string requestUrl = baseUrl + "?" + queries_1;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            queries.Add("q", "Ha Noi");
            queries.Add("appid", "2f45ec1571c6451311ed3c4b5937678b");

            //new HttpClientUtils().SendGetRequest(baseUrl, queries);
            //OpenWeather.CommonFunctions.CallCurrWthForOneLoc func = new OpenWeather.CommonFunctions.CallCurrWthForOneLoc();
            //func.GetWthBy_CtName_StateCode(strUrl);
            //Console.WriteLine() ;


        }
    }
}
