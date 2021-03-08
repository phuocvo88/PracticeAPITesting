using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather.OpenWeather.UITest
{
    public  class HomePage : BasePage
    {
        #region Page Element

        
        public By searchBox = By.XPath("//input[@id='q']");
        public By forecastListTableResult = By.XPath("//*[@id='forecast_list_ul']//b/a");
        public By forecastListWarningTxt = By.XPath("//*[@class='alert alert-warning']");
        #endregion



        #region Page actions

        public void InputCtName(string ctName)
        {
            Driver.FindElement(searchBox).SendKeys(ctName);

        }

        public void ClkSearchBox()
        {
            ElementClick(searchBox);
        }

        public void PressEnterOnSearchBox()
        {
            ElementPressKeyEnter(searchBox);
        }
        #endregion

        public string GetNotFoundMessage()
        {
            string warn = GetTxt(forecastListWarningTxt).Substring(3);


            return warn;
        }
       

        #region Page validation

        public bool IsResultContainsInputCtName(string inputCtName)
        {
            Thread.Sleep(1000);
            bool result = false;
            string input = inputCtName.ToLower();
            var listCtNameResult = Driver.FindElements(forecastListTableResult);



            for (int i = 0; i < listCtNameResult.Count; i++)
            {
                
                if (listCtNameResult[i].Text.ToLower().Contains(input))
                {
                    result = true;
                    break;
                }

            }
            return result;
        }

        public bool IsResultShowNotFound()
        {
            Thread.Sleep(1000);
            bool result = false;
            
            string warnTxt = GetNotFoundMessage();
            if (warnTxt.Equals("Not found"))
            {
                result = true;
                
            }

            return result;
        }

        #endregion
    }
}
