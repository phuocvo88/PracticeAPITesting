using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather.OpenWeather.UITest
{
    [TestFixture]
    public class HomePageTest : BaseTest
    {

        
        //public void Login()
        //{

        //}


        [Test]
        public void SearchValidCty()
        {
            
            HomePage hPage = new HomePage();

            hPage.NavigateHomePage();
            //WaitUntilElementExists(search.searchBox);

            hPage.ClkSearchBox();
            string kWord = "Ho Chi Minh";
            hPage.InputCtName(kWord);
            //PressEnterKeys();
            hPage.PressEnterOnSearchBox();

            //wait for page load

            Assert.IsTrue(hPage.IsResultContainsInputCtName(kWord));

        }

        [Test]
        public void SearchInvalidCty()
        {

            HomePage hPage = new HomePage();

            hPage.NavigateHomePage();
            //WaitUntilElementExists(search.searchBox);

            hPage.ClkSearchBox();
            string kWord = "Ho Chi Minh33";
            hPage.InputCtName(kWord);
            //PressEnterKeys();
            hPage.PressEnterOnSearchBox();

            //wait for page load

            Assert.IsTrue(hPage.IsResultContainsInputCtName(kWord));

        }





    }
}
