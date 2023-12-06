using CompetitionProjectMars.Utilities;
using OpenQA.Selenium;

namespace CompetitionProjectMars.Pages
{
    public class LoginPage :CommonDriver
    {
        private IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
       // private IWebElement signInButton => driver.FindElement(By.XPath("//a[@class='item']"));
        private IWebElement emailMARS => driver.FindElement(By.Name("email"));
        private IWebElement passwordMARS => driver.FindElement(By.Name("password"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoginActions(IWebDriver driver, String emailId, String password)

        {
            signInButton.Click();
            emailMARS.SendKeys(emailId);
            passwordMARS.SendKeys(password);
            loginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }
    }
}



        






        
    

