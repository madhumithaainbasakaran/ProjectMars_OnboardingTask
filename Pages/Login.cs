using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardingTask1.Pages
{
    public class Login
    {
        public void LoginActions(IWebDriver driver, string username, string password)
        {
            //Maximize the browser
            driver.Manage().Window.Maximize();

            //Launch the Url and navigate to Home page
            driver.Navigate().GoToUrl("http://localhost:5000/");

            // Click on Sign In
            IWebElement SignButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            Thread.Sleep(1000);
            SignButton.Click();

            // Enter the Username and Password and Click on Login Button
            IWebElement UserName = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            UserName.SendKeys(username);

            IWebElement Password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            Password.SendKeys(password);

            IWebElement Loginbutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            Thread.Sleep(1000);
            Loginbutton.Click();
        }

        public void ClickSignInButton(IWebDriver driver)
        {
            // Implement the logic to click on the Sign In button
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();
        }

        public bool IsSignInPageOpened(IWebDriver driver)
        {
            // Implement the logic to check if the Sign In page is opened
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            return signInButton.Displayed;
        }

        public void ClickLoginButton(IWebDriver driver)
        {
            // Implement the logic to click on the Login button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
        }

        public bool IsProfilePageOpened(IWebDriver driver)
        {
            // Implement the logic to check if the Profile page is opened
            try
            {
                IWebElement profileElement = driver.FindElement(By.XPath("/*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public bool IsLoginPageOpened(IWebDriver driver)
        {
            // Implement the logic to check if the Login page is opened
            try
            {
                IWebElement loginElement = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}