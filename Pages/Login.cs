using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ProjectMars_OnboardingTask1.Pages
{
    public class Login
    {
        private readonly WebDriverWait _wait;

        public Login(IWebDriver driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Enters credentials and clicks Login. Does NOT navigate or click Sign In —
        /// those steps are handled separately in the feature flow.
        /// </summary>
        public void LoginActions(IWebDriver driver, string username, string password)
        {
            // Enter the Username
            IWebElement userNameField = _wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input")));
            userNameField.Clear();
            userNameField.SendKeys(username);

            // Enter the Password
            IWebElement passwordField = driver.FindElement(
                By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        public void ClickSignInButton(IWebDriver driver)
        {
            IWebElement signInButton = _wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")));
            signInButton.Click();
        }

        public bool IsSignInPageOpened(IWebDriver driver)
        {
            try
            {
                IWebElement signInButton = _wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")));
                return signInButton.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void ClickLoginButton(IWebDriver driver)
        {
            IWebElement loginButton = _wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")));
            loginButton.Click();
        }

        public bool IsProfilePageOpened(IWebDriver driver)
        {
            try
            {
                // FIX: was "/*[@id=..." (missing leading slash) — corrected to "//*[@id=..."
                IWebElement profileElement = _wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span")));
                return profileElement.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsLoginPageOpened(IWebDriver driver)
        {
            try
            {
                IWebElement loginElement = _wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")));
                return loginElement.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
