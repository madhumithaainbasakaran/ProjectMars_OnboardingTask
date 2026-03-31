using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ProjectMars_OnboardingTask1.Pages;
using ProjectMars_OnboardingTask1.Utilities;
using System;
using TechTalk.SpecFlow;

namespace ProjectMars_OnboardingTask1.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {
        Profile profilePageObj = new Profile();

        [Given(@"PreConditions: Navigate to profile page")]
        public void GivenPreConditionsNavigateToProfilePage()
        {
            NavigateToProfilePage(driver);
        }

        // FIX: was calling CreateLanguage("English","Fluent") directly, which skipped
        // the separate "Adds Language as..." step and hardcoded the values.
        // Now only navigates to the tab and opens Add New — matching the step's intent.
        [When(@"User goes to Languages tab and clicks on Add New button")]
        public void WhenUserGoesToLanguagesTabAndClicksOnAddNewButton()
        {
            driver.FindElement(By.XPath(
                "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"))
                .Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")))
                .Click();
        }

        // FIX: this step binding was missing entirely — feature file referenced it but
        // no method existed, causing a missing step binding error at runtime.
        [When(@"Adds Language as '([^']*)' and choose Language Level from the dropdown as '([^']*)'")]
        public void WhenAddsLanguageAndChoosesLanguageLevel(string language, string languageLevel)
        {
            profilePageObj.CreateLanguage(driver, language, languageLevel);
        }

        [When(@"Clicks on Add button")]
        public void WhenClicksOnAddButton()
        {
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"Language should be successfully added to profile")]
        public void ThenLanguageShouldBeSuccessfullyAddedToProfile()
        {
            profilePageObj.VerifyLanguageAdded(driver, "English");
        }

        [When(@"Adds upto (.*) languages with Language Levels")]
        public void WhenAddsUptoLanguagesWithLanguageLevels(int numberOfLanguages, Table table)
        {
            foreach (var row in table.Rows)
            {
                string language = row["Language"];
                string languageLevel = row["Language Level"];
                profilePageObj.CreateLanguage(driver, language, languageLevel);
                profilePageObj.VerifyLanguageAdded(driver, language);
            }
        }

        [Then(@"All (.*) languages should be successfully added to profile")]
        public void ThenAllLanguagesShouldBeSuccessfullyAddedToProfile(int numberOfLanguages)
        {
            Assert.AreEqual(numberOfLanguages, GetNumberOfLanguagesAdded());
        }

        [When(@"Adds (.*) languages with Language Levels")]
        public void WhenAddsLanguagesWithLanguageLevels(int numberOfLanguages, Table table)
        {
            foreach (var row in table.Rows)
            {
                string language = row["Language"];
                string languageLevel = row["Language Level"];
                profilePageObj.CreateLanguage(driver, language, languageLevel);
            }
        }

        [Then(@"User should only be able to add (.*) languages successfully")]
        public void ThenUserShouldOnlyBeAbleToAddLanguagesSuccessfully(int numberOfLanguages)
        {
            Assert.AreEqual(numberOfLanguages, GetNumberOfLanguagesAdded());
        }

        [When(@"User goes to Languages tab")]
        public void WhenUserGoesToLanguagesTab()
        {
            driver.FindElement(By.XPath(
                "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"))
                .Click();
        }

        [When(@"Clicks on Add New button")]
        public void WhenClicksOnAddNewButton()
        {
            driver.FindElement(By.XPath(
                "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"))
                .Click();
        }

        [When(@"Clicks on Add button without entering anything")]
        public void WhenClicksOnAddButtonWithoutEnteringAnything()
        {
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"User should receive an error message as ""([^""]*)""")]
        public void ThenUserShouldReceiveAnErrorMessageAs(string errorMessage)
        {
            Assert.IsTrue(IsNotificationDisplayed(driver, errorMessage),
                $"Expected error message '{errorMessage}' was not displayed.");
        }

        [When(@"Checks whether up to (.*) languages have been added")]
        public void WhenChecksWhetherUpToLanguagesHaveBeenAdded(int count)
        {
            int actual = GetNumberOfLanguagesAdded();
            Assert.LessOrEqual(actual, count,
                $"Expected at most {count} languages but found {actual}.");
        }

        [When(@"Removes Language '([^']*)' and the Language Level '([^']*)' from the profile")]
        public void WhenRemovesLanguageAndTheLanguageLevelFromTheProfile(string language, string languageLevel)
        {
            profilePageObj.DeleteLanguage(driver, language);
        }

        [Then(@"User should receive a message as ""([^""]*)""")]
        public void ThenUserShouldReceiveAMessageAs(string message)
        {
            Assert.IsTrue(IsNotificationDisplayed(driver, message),
                $"Expected message '{message}' was not displayed.");
        }

        // ── Private helpers ───────────────────────────────────────────────────

        private int GetNumberOfLanguagesAdded()
        {
            // FIX: original XPath targeted the tab link element (which has no <tr> children).
            // Now targets the actual language data table body rows.
            try
            {
                IWebElement languageTable = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                    .Until(ExpectedConditions.ElementIsVisible(
                        By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table")));

                var rows = languageTable.FindElements(By.TagName("tr"));
                // Subtract 1 for the header row
                return Math.Max(0, rows.Count - 1);
            }
            catch (WebDriverTimeoutException)
            {
                return 0;
            }
        }

        private bool IsNotificationDisplayed(IWebDriver driver, string message)
        {
            // FIX: original passed the message text directly as the XPath expression —
            // e.g. By.XPath("Please enter language and level") which is invalid XPath.
            // Now correctly locates the notification element and checks its text.
            try
            {
                IWebElement messageElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                    .Until(ExpectedConditions.ElementIsVisible(
                        By.XPath("//div[@class='ns-box-inner']")));
                return messageElement.Displayed && messageElement.Text.Contains(message);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }
    }
}
