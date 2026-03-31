using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using ProjectMars_OnboardingTask1.Utilities;

namespace ProjectMars_OnboardingTask1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : CommonDriver
    {
        // FIX: pass driver into Login constructor so it can build its WebDriverWait
        Pages.Login loginPageObj;

        public LoginStepDefinitions()
        {
            loginPageObj = new Pages.Login(driver);
        }

        [Given(@"the user attempts to access the profile page")]
        public void GivenTheUserAttemptsToAccessTheProfilePage()
        {
            // No specific action required here
        }

        [When(@"the user launches the URL ""([^""]*)""")]
        public void WhenTheUserLaunchesTheURL(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [Then(@"the user should be able to access the URL")]
        public void ThenTheUserShouldBeAbleToAccessTheURL()
        {
            Assert.AreEqual("http://localhost:5000/", driver.Url);
        }

        [Then(@"the user should be able to access the URL and be redirected to the login page")]
        public void ThenTheUserShouldBeAbleToAccessTheURLAndBeRedirectedToLoginPage()
        {
            Assert.AreEqual("http://localhost:5000/", driver.Url);
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
            // FIX: LoginActions no longer re-navigates or re-clicks Sign In.
            // It only fills in credentials, matching the step's intent.
            var username = table.Rows[0]["Username"];
            var password = table.Rows[0]["Password"];
            loginPageObj.LoginActions(driver, username, password);
        }

        [When(@"the user signs in with invalid credentials:")]
        public void WhenTheUserSignsInWithInvalidCredentials(Table table)
        {
            var username = table.Rows[0]["Username"];
            var password = table.Rows[0]["Password"];
            loginPageObj.LoginActions(driver, username, password);
        }

        [Then(@"the user should be able to enter the Username and Password correctly")]
        public void ThenTheUserShouldBeAbleToEnterTheUsernameAndPasswordCorrectly()
        {
            // Intentionally empty — validation happens in the next step
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

        [Then(@"the user should be redirected to the login page")]
        public void ThenTheUserShouldBeRedirectedToTheLoginPage()
        {
            Assert.IsTrue(loginPageObj.IsLoginPageOpened(driver));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }
    }
}
