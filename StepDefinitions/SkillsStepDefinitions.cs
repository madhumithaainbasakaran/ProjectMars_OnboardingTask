using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMars_OnboardingTask1.Pages;
using ProjectMars_OnboardingTask1.Utilities;
using System.Threading;
using TechTalk.SpecFlow;

namespace ProjectMars_OnboardingTask1.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions : CommonDriver
    {
        Profile profilePageObj = new Profile();

        [Given(@"PreConditions: Navigate to profile page")]
        public void GivenPreConditionsNavigateToProfilePage()
        {
            // Navigate to the profile page
            NavigateToProfilePage(driver);
        }

        [When(@"User goes to Skills tab and clicks on Add New button")]
        public void WhenUserGoesToSkillsTabAndClicksOnAddNewButton()
        {
            profilePageObj.NavigateToSkillsTab(driver);
            profilePageObj.ClickAddNewButton(driver);
        }

        [When(@"Add Skill as '([^']*)' and choose Level from the dropdown as '([^']*)'")]
        public void WhenAddSkillAndChooseLevelFromTheDropdown(string skill, string level)
        {
            profilePageObj.CreateSkills(driver, skill, level);
        }

        [When(@"Click on Add button")]
        public void WhenClickOnAddButton()
        {
            profilePageObj.ClickAddButton(driver);
        }

        [Then(@"New Skill Added")]
        public void ThenNewSkillAdded()
        {
            string expectedSkill = "C";
            string expectedLevel = "C++";
            Assert.IsTrue(profilePageObj.IsSkillAdded(driver, expectedSkill, expectedLevel));
        }


        [When(@"Click on Add New button and add multiple Skills and Levels")]
        public void WhenClickOnAddNewButtonAndAddMultipleSkillsAndLevels(Table table)
        {
            foreach (var row in table.Rows)
            {
                string skill = row["Skills"];
                string level = row["Level"];
                profilePageObj.CreateSkills(driver, skill, level);
                profilePageObj.ClickAddButton(driver);
            }
        }

        [Then(@"Multiple Skills Added")]
        public void ThenMultipleSkillsAdded()
        {
            Assert.IsTrue(profilePageObj.AreMultipleSkillsAdded(driver));
        }

        [Then(@"Verify that the user receives an error message as ""(.*)""")]
        public void ThenVerifyThatTheUserReceivesAnErrorMessageAs(string errorMessage)
        {
            Assert.IsTrue(profilePageObj.IsErrorMessageDisplayed(driver, errorMessage));
        }

        [Then(@"Verify that the user receives an error message as ""([^""]*)""")]
        public void ThenVerifyThatTheUserReceivesADuplicateDataErrorMessageAs(string errorMessage)
        {
            Assert.IsTrue(profilePageObj.IsDuplicateDataErrorMessageDisplayed(driver, errorMessage));
        }

        [When(@"Check whether the mentioned Skills are added")]
        public void WhenCheckWhetherTheMentionedSkillsAreAdded(Table table)
        {
            foreach (var row in table.Rows)
            {
                string skill = row["Skills"];
                string level = row["Level"];
                Assert.IsTrue(profilePageObj.IsSkillAdded(driver, skill, level));
            }
        }

        [When(@"Remove Skill '(.*)' and the Level '(.*)' from the profile")]
        public void WhenRemoveSkillAndTheLevelFromTheProfile(string skill, string level)
        {
            profilePageObj.DeleteSkills(driver, skill, level);
        }

        [Then(@"Verify that the user receives a message as ""(.*)""")]
        public void ThenVerifyThatTheUserReceivesAMessageAs(string message)
        {
            Assert.IsTrue(profilePageObj.IsSkillDeletedMessageDisplayed(driver, message));
        }

        [When(@"Edit the Skill '(.*)' and Level '(.*)' to '(.*)' and Level '(.*)'")]
        public void WhenEditTheSkillAndLevelToAndLevel(string oldSkill, string oldLevel, string newSkill, string newLevel)
        {
            profilePageObj.EditSkills(driver, oldSkill, oldLevel, newSkill, newLevel);
        }

        [Then(@"Verify that the user receives a message as ""(.*)""")]
        public void ThenVerifyThatTheUserReceivesAnUpdateMessageAs(string message)
        {
            Assert.IsTrue(profilePageObj.IsSkillUpdatedMessageDisplayed(driver, message));
        }
    }
}
