using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherAPI.OpenWeather.UITest
{
    public  class HomePage : BasePage
    {
        #region Page Element

        
        public By searchBox = By.XPath("//input[@id='q']");

        #endregion



        #region Page actions

        public void InputCtName(string ctName)
        {
            Driver.FindElement(By.XPath("//input[@id='q']")).SendKeys(ctName);

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


        #region Page validation

        public bool IsResultContainsInputCtName(string inputCtName)
        {
            Thread.Sleep(3000);
            bool result = false;
            string input = inputCtName.ToLower();
            var listCtNameResult = Driver.FindElements(By.XPath("//*[@id='forecast_list_ul']//b/a"));

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


        #endregion
    }
}
