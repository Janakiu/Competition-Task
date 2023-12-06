using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionProjectMars.Utilities
{
    public class Wait
    {
        public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var WaitTime = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            if (locatorType == "XPath")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));

            }
            if (locatorType == "Id")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
            if (locatorType == "CssSelector")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            }
        }
        public static void WaitToExist(IWebDriver driver, string locatortype, string locatorValue, int seconds)
        {
            var WaitTime = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            if (locatortype == "XPath")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorValue)));
            }
            if (locatortype == "Id")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(locatorValue)));
            }
            if (locatortype == "CssSelector")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(locatorValue)));
            }
        }
        public static void WaitToBeVisible(IWebDriver driver, string locatortype, string locatorValue, int seconds)
        {
            var WaitTime = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locatortype == "XPath")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorValue)));
            }
            if (locatortype == "Id")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(locatorValue)));
            }
            if (locatortype == "CssSelector")
            {
                WaitTime.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(locatorValue)));
            }
        }


    }
}
