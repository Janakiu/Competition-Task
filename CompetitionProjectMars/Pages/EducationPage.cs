using CompetitionProjectMars.Utilities;
using AventStack.ExtentReports.Reporter;
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
    public class EducationPage : CommonDriver
    {
        public static IWebDriver webDriver;
        public WebDriverWait wait;
        public EducationPage(IWebDriver driver)
        {
            webDriver = driver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)); // Initialize the WebDriverWait
        }
        public void GoToEducationTab()
        {
            educationTab.Click();
        }
        private IWebElement educationTab => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        
        private IWebElement addNewButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
                                                                            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div
        private IWebElement collegeTextBox => webDriver.FindElement(By.Name("instituteName"));
        private IWebElement selectCountry => webDriver.FindElement(By.Name("country"));
        private IWebElement selectTitle => webDriver.FindElement(By.Name("title"));
        private IWebElement degreeTextbox => webDriver.FindElement(By.Name("degree"));
        private IWebElement selectYearOfGraduation => webDriver.FindElement(By.Name("yearOfGraduation"));
        private IWebElement addButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")));
                                                                                                        //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]          
        // Methods to interact with the page elements
        public void AddEducation(IWebDriver driver, string collegeName, string countryName, string titleName, string degree, string year)
        {

            addNewButton.Click();
            collegeTextBox.SendKeys(collegeName);
            SelectElement country = new SelectElement(selectCountry);
            country.SelectByValue(countryName);
            SelectElement title = new SelectElement(selectTitle);
            title.SelectByValue(titleName);
            degreeTextbox.SendKeys(degree);
            SelectElement graduationYear = new SelectElement(selectYearOfGraduation);
            graduationYear.SelectByValue(year);
            addButton.Click();
            Thread.Sleep(1000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
           
        }

        //Assert Education
        private IWebElement institutename => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]")));
                                                                                                            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[3]/tr/td[2] 
        public string AssertEducation(IWebDriver driver)
        {
            return institutename.Text;
        }
        //Assert country
        private IWebElement country => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
        public string AssertCountry(IWebDriver driver)
        {
            return country.Text;
        }
        //Assert Title
        private IWebElement title => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]")));
        public string AssertTitle(IWebDriver driver)
        {
            return title.Text;
        }
        //Assert Degree
        private IWebElement degree => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]")));
        public string AssertDegree(IWebDriver driver)
        {
            return degree.Text;
        }
        //Assert EducationYear
        private IWebElement educationYear => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]")));
        public string AssertEducationYear(IWebDriver driver)
        {
            return educationYear.Text;
        }

        public void ResetEducationTable(IWebDriver driver)
        {
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr")).Count;
            if (rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i")).Click();
                    Thread.Sleep(1000);
                }
            }


        }

        //Update Education
        private IWebElement editIcon => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i")));
        private IWebElement editCollegeName => webDriver.FindElement(By.Name("instituteName"));
        private IWebElement editCountry => webDriver.FindElement(By.Name("country"));
        private IWebElement editTitle => webDriver.FindElement(By.Name("title"));
        private IWebElement editDegree => webDriver.FindElement(By.Name("degree"));
        private IWebElement editYearOfGraduation => webDriver.FindElement(By.Name("yearOfGraduation"));
        private IWebElement updateButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]")));

        public void UpdateEducation(IWebDriver driver, string collegeName, string countryName, string newtitle, string degree, string yearOfGraduation)
        {
            editIcon.Click();
            editCollegeName.Clear();
            editCollegeName.SendKeys(collegeName);
            // Update country
            SelectElement country = new SelectElement(editCountry);
            country.SelectByValue(countryName);

            // Update title
            SelectElement title = new SelectElement(editTitle);
            title.SelectByValue(newtitle);

            // Update degree
            editDegree.Clear();
            editDegree.SendKeys(degree);

            // Update graduation year
            SelectElement year = new SelectElement(editYearOfGraduation);
            year.SelectByValue(yearOfGraduation);
            updateButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            
        
        }
        public void DeleteEducation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement removeIconElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i")));
            removeIconElement.Click();
            Thread.Sleep(1000);
            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/iremoveIconElement.Click();

        }
        public string PopUpMessage(IWebDriver driver)
        { 
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        IWebElement popUpMessage = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='ns-box-inner']")));
        
            return popUpMessage.Text;
        }
    
    }

}


  