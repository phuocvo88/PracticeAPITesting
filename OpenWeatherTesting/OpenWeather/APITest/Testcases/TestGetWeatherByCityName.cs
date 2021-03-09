using NUnit.Framework;
using System.Net;

using OpenWeatherAPI.OpenWeather.APITest.CommonFunctions;


namespace OpenWeatherAPI.OpenWeather.APITest.Testcases
{
    [TestFixture]
    class TestGetWeatherByCityName
    {
        [Test]
        public  void GetWeatherByCityName_Success()
        {
            //These variables should be defined in test data file
            string baseUrl = "http://api.openweathermap.org/data/2.5/weather";
            string cityName = "Ha Noi";
            string apiKey = "2f45ec1571c6451311ed3c4b5937678b";

            HttpWebResponse response = OpenWeatherAPIs.GetWthBy_CtName(baseUrl, cityName, apiKey);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            //assert body contain...
        }

        public void GetWeatherByCityName_InvalidCity()
        {
            //
        }
    }
}
