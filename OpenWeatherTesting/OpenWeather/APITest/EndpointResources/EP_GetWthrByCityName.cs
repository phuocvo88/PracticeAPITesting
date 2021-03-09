using OpenWeather.OpenWeather.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherAPI.OpenWeather.APITest.EndpointResources
{
    public class EP_GetWthrByCityName
    {
        #region page elements
        public string baseUrl = "";
        public string cityName = ""; //this variable will be refactored to extract from a source
        public string apiKey = "";  //this variable will be refactored to extract from a source



        #endregion

        #region Page actions
        public string GetValidBaseUrlFromSource()
        {
            baseUrl = "http://api.openweathermap.org/data/2.5/weather";
            return baseUrl;
        }

        public string GetValidCtNameFromSource()
        {
            cityName = "Ha Noi";
            return cityName;
        }

        public string GetValidApiKeyFromSource()
        {
            apiKey = "2f45ec1571c6451311ed3c4b5937678b";
            return apiKey;
        }

        public string GetInValidBaseUrlFromSource()
        {
            baseUrl = "http://api.openweathermapnew.org/data/2.5/weather";
            return baseUrl;
        }

        public string GetInValidCtNameFromSource()
        {
            cityName = "Testing1234567";
            return cityName;
        }

        public string GetInValidApiKeyFromSource()
        {
            apiKey = "2f45ec1571c6451311ed3c4b123456";
            return apiKey;
        }

        #endregion



        #region Page validation

        public bool IsResponseContainCtName(string inputCtName, string responseCtName)
        {
            inputCtName = String.Concat(inputCtName.Where(c => !Char.IsWhiteSpace(c))).ToLower();
            responseCtName = String.Concat(responseCtName.Where(c => !Char.IsWhiteSpace(c))).ToLower();

            bool result = false;

            if (responseCtName.Equals(inputCtName))
            {
                result = true;
            }

            return result;
        }

        public bool IsResponseShowMessageNotFound(string responseMessage)
        {
            bool result = false;

            if (responseMessage.Equals("city not found"))
            {
                result = true;
            }
            return result;
        }

        #endregion




    }
}
