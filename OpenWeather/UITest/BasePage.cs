using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenWeatherAPI.ExtentReportUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace OpenWeatherAPI.OpenWeather.UITest
{
    public  class  BasePage
    {
        #region Page element
        public static IWebDriver Driver;
        ExtentReports extent;
        ExtentTest test;

        public static string baseUrl = "https://openweathermap.org/";

        #endregion

        #region Page actions




        [OneTimeSetUp]
        protected void Setup()
        {
            /*
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");

            string TCName = GetTCName();
            DateTime time = DateTime.Now;
            string fileName = TCName + $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}" + ".html";
            var reportPath = projectPath + fileName;
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "openweathermap.org");
            extent.AddSystemInfo("Environment", "Production");
            */

            //To obtain the current solution path/project path

            string pth = Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;



            //Append the html report file to current project path

            string reportPath = projectPath + "Reports\\TestRunReport1.html";

            //ExtentHtmlReporter html = new ExtentHtmlReporter(reportPath);
            ExtentHtmlReporter html = new ExtentHtmlReporter(@"E:\NAB assignments\Reports\" + TestContext.CurrentContext.Test.MethodName + ".html");

            extent = new ExtentReports();

            extent.AttachReporter(html);
            //test = extent.CreateTest(TestContext.CurrentContext.Test.MethodName);


        }

        [SetUp]
        public void StartBrowser()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativePath = @"..\..\packages\Selenium.WebDriver.ChromeDriver.88.0.4324.2700\driver\win32";
            var file_path = Path.GetFullPath(Path.Combine(assemblyPath, relativePath));


            //Driver = new ChromeDriver("E:\\NAB assignments\\packages\\Selenium.WebDriver.ChromeDriver.88.0.4324.2700\\driver\\win32");
            Driver = new ChromeDriver(file_path);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.Manage().Window.Maximize();
            test = extent.CreateTest(TestContext.CurrentContext.Test.MethodName);


        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            GetScreenShot scrShot = new GetScreenShot();
            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}" + ".png";
            string screenShotPath = scrShot.Capture(Driver, fileName);

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    
                    test.Log(Status.Fail, "Fail");
                    //test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath("Screenshots\\" +fileName));
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, "Test ended with " +logstatus + stacktrace);
            extent.Flush();
            Driver.Quit();
        }

        public void InputTxt(By control, string txt)
        {
            Driver.FindElement(control).SendKeys(txt);
        }



        public string GetTxt(By control)
        {
            return Driver.FindElement(control).Text;
        }


        public string GetTCName()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            return testName;
        }

        public void NavigateHomePage()
        {
            Driver.Url = baseUrl;
            Thread.Sleep(3000);

        }

        public void PressEnterKeys()
        {
            Actions builder = new Actions(Driver);
            builder.SendKeys(Keys.Enter);


        }

        public void ElementPressKeyEnter(By control)
        {
            Driver.FindElement(control).SendKeys(Keys.Enter);
        }

        public void ElementClick(By control)
        {
            Driver.FindElement(control).Click();
        }

       
        //public void CaptureScreenShot


        /* this will search for the element until a timeout is reached
         * Existence - An expectation for checking that an element is present on the DOM of a page. 
         * This does not necessarily mean that the element is visible.
         */
        public static IWebElement WaitUntilElementExists(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }



      
        /* this will search for the element until a timeout is reached
         * Visibility - An expectation for checking that an element is present on the DOM of a page and visible. 
         * Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
        */
        public static IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }


        #endregion



        #region Page validation




        #endregion









    }
}
