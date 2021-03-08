using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.ExtentReportUtils
{
    public class ExtentReportUtils
    {

        public void ExtentHtmlReport()
        {
            var htmlReporter = new ExtentHtmlReporter("extentReport.html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            

            //var test = extent.CreateTest();


        }

    }
}

