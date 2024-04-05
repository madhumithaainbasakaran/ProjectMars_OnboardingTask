using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMars_OnboardingTask1.Pages;
using ProjectMars_OnboardingTask1.Utilities;
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
            // Navigate to the profile page
            NavigateToProfilePage(driver);
        }

        [When(@"User goes to Languages tab and clicks on Add New button")]
        public void WhenUserGoesToLanguagesTabAndClicksOnAddNewButton()
        {
            profilePageObj.CreateLanguage(driver, "English", "Fluent");
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
            // Assert that all languages are added successfully
            Assert.AreEqual(numberOfLanguages, GetNumberOfLanguagesAdded());
        }

        private int GetNumberOfLanguagesAdded()
        {
            // Locate the table containing the added languages
            var languageTable = driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[1]"));

            // Count the rows in the table (excluding the header row)
            var rowCount = languageTable.FindElements(By.TagName("tr")).Count;

            // Subtract 1 for the header row
            return rowCount - 1;
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
            // Assert that only specified number of languages are added successfully
            Assert.AreEqual(numberOfLanguages, GetNumberOfLanguagesAdded());
        }

        [When(@"User goes to Languages tab")]
        public void WhenUserGoesToLanguagesTab()
        {
            // Navigate to Languages tab
            driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[1]")).Click();
        }

        [When(@"Clicks on Add New button")]
        public void WhenClicksOnAddNewButton()
        {
            // Click on Add New button
            driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']")).Click();
        }

        [When(@"Clicks on Add button without entering anything")]
        public void WhenClicksOnAddButtonWithoutEnteringAnything()
        {
            // Click on Add button without entering anything
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"User should receive an error message as ""([^""]*)""")]
        public void ThenUserShouldReceiveAnErrorMessageAs(string errorMessage)
        {
            // Assert that the error message is displayed
            Assert.IsTrue(IsErrorMessageDisplayed(errorMessage));
        }

        private bool IsErrorMessageDisplayed(string errorMessage)
        {
            try
            {
                // Locate the element displaying the error message
                var errorMessageElement = driver.FindElement(By.XPath("Please enter language and level"));

                // Check if the error message matches the expected message
                return errorMessageElement.Displayed && errorMessageElement.Text.Contains(errorMessage);
            }
            catch (NoSuchElementException)
            {
                // If the error message element is not found, return false
                return false;
            }
        }


        [When(@"Removes Language '([^']*)' and the Language Level '([^']*)' from the profile")]
        public void WhenRemovesLanguageAndTheLanguageLevelFromTheProfile(string language, string languageLevel)
        {
            profilePageObj.DeleteLanguage(driver, language);
        }

        [Then(@"User should receive a message as ""([^""]*)""")]
        public void ThenUserShouldReceiveAMessageAs(string message)
        {
            // Assert that the message is displayed
            Assert.IsTrue(IsMessageDisplayed(message));
        }

        private bool IsMessageDisplayed(string message)
        {
            try
            {
                // Locate the element displaying the message
                var messageElement = driver.FindElement(By.XPath("Tamil has been deleted from your languages"));

                // Check if the message matches the expected message and is displayed
                return messageElement.Displayed && messageElement.Text.Contains(message);
            }
            catch (NoSuchElementException)
            {
                // If the message element is not found, return false
                return false;
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            // Cleanup after scenario
            driver.Quit();
        }
    }
}
