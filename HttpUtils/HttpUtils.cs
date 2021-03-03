using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherAPI.HttpUtils
{
    public class HttpClientUtils
    {

        public HttpWebResponse SendGetRequest(string requestUrl)
        {
            WebRequest requestObjGet = WebRequest.Create(requestUrl);
            requestObjGet.Method = "GET";
            requestObjGet.ContentType = "application/json";
            return (HttpWebResponse)requestObjGet.GetResponse();
        }

        public HttpWebResponse SendGetRequest(string baseUrl, Dictionary<string, string> paras)
        {
            string requestUrl = baseUrl;
            //if(paras != null)
            //{
            //    string query = string.Empty;
            //    foreach (var item in paras)
            //    {
            //        query += item.Key + "=" + item.Value + "&"; 

            //    }
            //    query = query.Substring(0, query.Length - 1);

            //    requestUrl += "?" + query;
            //}
            WebRequest requestObjGet = WebRequest.Create(requestUrl);
            requestObjGet.Method = "GET";
            requestObjGet.ContentType = "application/json";
            return (HttpWebResponse)requestObjGet.GetResponse(); ;
        }
    }
}
