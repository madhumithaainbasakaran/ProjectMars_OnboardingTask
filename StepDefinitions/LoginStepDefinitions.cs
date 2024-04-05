using OpenQA.Selenium;
using System;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using ProjectMars_OnboardingTask1.Utilities;

namespace ProjectMars_OnboardingTask1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : CommonDriver
    {
        Pages.Login loginPageObj = new Pages.Login();

        [Given(@"the user attempts to access the profile page")]
        public void GivenTheUserAttemptsToAccessTheProfilePage()
        {
            // No specific action required here
        }

        [When(@"the user launches the URL ""([^""]*)""")]
        public void WhenTheUserLaunchesTheURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [Then(@"the user should be able to access the URL")]
        public void ThenTheUserShouldBeAbleToAccessTheURL()
        {
            Assert.AreEqual(driver.Url, "http://localhost:5000/");
        }

        [When(@"the user clicks the Sign In button on the Home Page")]
        public void WhenTheUserClicksTheSignInButtonOnTheHomePage()
        {
            loginPageObj.ClickSignInButton(driver);
        }

        [Then(@"the user should be able to navigate to the Home page and click on the Sign In button successfully")]
        public void ThenTheUserShouldBeAbleToNavigateToTheHomePageAndClickOnTheSignInButtonSuccessfully()
        {
            Assert.IsTrue(loginPageObj.IsSignInPageOpened(driver));
        }

        [When(@"the user signs in with valid credentials:")]
        public void WhenTheUserSignsInWithValidCredentials(Table table)
        {
            var username = table.Rows[0]["Username"];
            var password = table.Rows[0]["Password"];
            loginPageObj.LoginActions(driver, username, password);
        }

        [Then(@"the user should be able to enter the Username and Password correctly")]
        public void ThenTheUserShouldBeAbleToEnterTheUsernameAndPasswordCorrectly()
        {
            // No specific assertion needed here
        }

        [When(@"the user clicks on the login button")]
        public void WhenTheUserClicksOnTheLoginButton()
        {
            loginPageObj.ClickLoginButton(driver);
        }

        [Then(@"the user should be successfully logged in and redirected to the Profile page")]
        public void ThenTheUserShouldBeSuccessfullyLoggedInAndRedirectedToTheProfilePage()
        {
            Assert.IsTrue(loginPageObj.IsProfilePageOpened(driver));
        }

        [When(@"the user signs in with invalid credentials:")]
        public void WhenTheUserSignsInWithInvalidCredentials(Table table)
        {
            var username = table.Rows[0]["Username"];
            var password = table.Rows[0]["Password"];
            loginPageObj.LoginActions(driver, username, password);
        }

        [Then(@"the user should be redirected to the login page")]
        public void ThenTheUserShouldBeRedirectedToTheLoginPage()
        {
            Assert.IsTrue(loginPageObj.IsLoginPageOpened(driver));
        }

    }
}
