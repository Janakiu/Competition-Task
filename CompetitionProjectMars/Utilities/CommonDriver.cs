using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using CompetitionProjectMars.Utilities;

namespace CompetitionProjectMars.Utilities
{
    public class CommonDriver : ExtentReportHelper
    {
        //Initialize the browser
        public static IWebDriver driver;
        

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentReportHelper.CreateExtentReport();

        }
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, status + errorMessage);

            }
            else
            {
                test.Log(Status.Pass, "Test Pass");
            }


            string img = ExtentReportHelper.SaveScreenShot(driver, "Screenshot");
            test.Log(Status.Info, "Snapshot below: " + test.AddScreenCaptureFromPath(img));

            driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }




}


