using CompetitionProjectMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionProjectMars.Pages
{
    public class CertificationsPage : CommonDriver
    {
        public static IWebDriver webDriver;
        public WebDriverWait wait;
        public CertificationsPage(IWebDriver driver)
        {
            webDriver = driver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)); // Initialize the WebDriverWait
        }
        public void GoToCertificationsTab()
        {
            certificationsTab.Click();
        }
        //Add New Certification
        private IWebElement certificationsTab => webDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private IWebElement addNewButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private IWebElement certificationTextBox => webDriver.FindElement(By.Name("certificationName"));
        private IWebElement certifiedFromTextBox => webDriver.FindElement(By.Name("certificationFrom"));
        private IWebElement selectYear => webDriver.FindElement(By.Name("certificationYear"));
        private IWebElement addButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        public void CreateCertification(IWebDriver driver, string certification, string certifiedFrom, string year)
        {
            addNewButton.Click();
            certificationTextBox.SendKeys(certification);
            certifiedFromTextBox.SendKeys(certifiedFrom);
            SelectElement certificationYear = new SelectElement(selectYear);
            certificationYear.SelectByValue(year);
            addButton.Click();
            Thread.Sleep(1000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        //Assert Certification
        private IWebElement certificationname => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]")));

        public string AssertCertification(IWebDriver driver)
        {
            return certificationname.Text;
        }
        //Assert CertifiedFrom

        private IWebElement certifiedFrom => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]")));

        public string AssertCertifiedFrom(IWebDriver driver)
        {
            return certifiedFrom.Text;
        }

        //Assert CertificationYear

        private IWebElement certifiedYear => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]")));

        public string AssertCertifiedYear(IWebDriver driver)
        {
            return certifiedYear.Text;
        }
        //Reset Certification Table
        public void ResetCertificationTable(IWebDriver driver)
        {
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr")).Count;

            if (rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i")).Click();

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                }
            }

        }
        //Update Certification

        private IWebElement editIcon => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i"));
                                                                        //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[1]/i
        private IWebElement editCertificationTextBox => webDriver.FindElement(By.Name("certificationName"));
        private IWebElement editCertifiedFromTextBox => webDriver.FindElement(By.Name("certificationFrom"));
        private IWebElement editYear => webDriver.FindElement(By.Name("certificationYear"));
        private IWebElement updateButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]")));
                                                                                                         //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[2]/tr/td/div/span/input[1]
        public void UpdateCertification(IWebDriver driver, string certificationName, string certifiedFrom, string year)
        {
            editIcon.Click();
            editCertificationTextBox.Clear();
            editCertificationTextBox.SendKeys(certificationName);
            editCertifiedFromTextBox.Clear();
            editCertifiedFromTextBox.SendKeys(certifiedFrom);
            SelectElement certificationYear = new SelectElement(editYear);
            certificationYear.SelectByValue(year);
            updateButton.Click();
            Thread.Sleep(1000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

        }
        
        public void DeleteCertification()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement removeIconElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i")));
            removeIconElement.Click();
            Thread.Sleep(1000);
        }
        //private IWebElement popUpMessage => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        public string PopUpMessage(IWebDriver driver)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement popUpMessage = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='ns-box-inner']")));
            return popUpMessage.Text;
        }
    }
}
    



        

