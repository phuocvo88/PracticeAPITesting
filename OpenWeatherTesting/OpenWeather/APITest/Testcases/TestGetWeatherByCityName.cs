using NUnit.Framework;
using System.Net;

using OpenWeatherAPI.OpenWeather.APITest.CommonFunctions;
using OpenWeather.OpenWeather.DataObject;
using Newtonsoft.Json;
using OpenWeatherAPI.OpenWeather.APITest.EndpointResources;

namespace OpenWeatherAPI.OpenWeather.APITest.Testcases
{
    [TestFixture]
    class TestGetWeatherByCityName
    {
        [Test]
        public  void GetWeatherByCityName_Success()
        {
            EP_GetWthrByCityName eP_GetWthrByCityName = new EP_GetWthrByCityName();

            string inputBaseUrl = eP_GetWthrByCityName.GetValidBaseUrlFromSource();
            string inputCtName = eP_GetWthrByCityName.GetValidCtNameFromSource();
            string inputApiKey = eP_GetWthrByCityName.GetValidApiKeyFromSource();

            //Send request
            HttpWebResponse httpResponse = OpenWeatherAPIs.Get_CtNameAndApiKey(inputBaseUrl, inputCtName, inputApiKey);
            string response = new HttpUtils.HttpClientUtils().GetHttpResponseAsString(httpResponse);

            //Convert response into weatherresposne object
            WeatherResponse weathrResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            

            string respCtName = weathrResponse.name;

            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(eP_GetWthrByCityName.IsResponseContainCtName(respCtName, inputCtName));
           
        }

        [Test]
        public void GetWeatherByCityName_InvalidCity()
        {
            EP_GetWthrByCityName eP_GetWthrByCityName = new EP_GetWthrByCityName();

            string inputBaseUrl = eP_GetWthrByCityName.GetValidBaseUrlFromSource();
            string inputCtName = eP_GetWthrByCityName.GetInValidCtNameFromSource();
            string inputApiKey = eP_GetWthrByCityName.GetValidApiKeyFromSource();

            //Send request
            HttpWebResponse httpResponse = OpenWeatherAPIs.Get_CtNameAndApiKey(inputBaseUrl, inputCtName, inputApiKey);
            string response = new HttpUtils.HttpClientUtils().GetHttpResponseAsString(httpResponse);

            //Convert response into weatherresposne object
            WeatherResponse weathrResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);


            string respMessage = weathrResponse.message;

            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.NotFound);
            Assert.IsTrue(eP_GetWthrByCityName.IsResponseShowMessageNotFound(respMessage));
        }
    }
}
