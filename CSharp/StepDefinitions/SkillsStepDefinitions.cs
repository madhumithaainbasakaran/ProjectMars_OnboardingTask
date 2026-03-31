using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars_OnboardingTask1.Pages;
using ProjectMars_OnboardingTask1.Utilities;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ProjectMars_OnboardingTask1.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions : CommonDriver
    {
        Profile profilePageObj = new Profile();

        // Tracks skills added during a scenario so assertions can verify the right list
        private List<string> _addedSkills = new List<string>();

        [Given(@"PreConditions: Navigate to profile page")]
        public void GivenPreConditionsNavigateToProfilePage()
        {
            NavigateToProfilePage(driver);
        }

        [When(@"User goes to Skills tab and clicks on Add New button")]
        public void WhenUserGoesToSkillsTabAndClicksOnAddNewButton()
        {
            profilePageObj.NavigateToSkillsTab(driver);
            profilePageObj.ClickAddNewButton(driver);
        }

        [When(@"User goes to Skills tab")]
        public void WhenUserGoesToSkillsTab()
        {
            profilePageObj.NavigateToSkillsTab(driver);
        }

        [When(@"Click on Add New button")]
        public void WhenClickOnAddNewButton()
        {
            profilePageObj.ClickAddNewButton(driver);
        }

        [When(@"Add Skill as '([^']*)' and choose Level from the dropdown as '([^']*)'")]
        public void WhenAddSkillAndChooseLevelFromTheDropdown(string skill, string level)
        {
            // FIX: use FillAndAddSkill — Add New was already clicked in the prior step.
            // CreateSkills would click Skills tab + Add New again, doubling up.
            profilePageObj.FillAndAddSkill(driver, skill, level);
            _addedSkills.Add(skill);
        }

        [When(@"Click on Add button")]
        public void WhenClickOnAddButton()
        {
            profilePageObj.ClickAddButton(driver);
        }

        [Then(@"New Skill Added")]
        public void ThenNewSkillAdded()
        {
            // FIX: was checking expectedLevel = "C++" against a skill added as "Intermediate"
            string expectedSkill = "C";
            string expectedLevel = "Intermediate";
            Assert.IsTrue(profilePageObj.IsSkillAdded(driver, expectedSkill, expectedLevel),
                $"Expected skill '{expectedSkill}' at level '{expectedLevel}' was not found.");
        }

        [When(@"Click on Add New button and add multiple Skills and Levels")]
        public void WhenClickOnAddNewButtonAndAddMultipleSkillsAndLevels(Table table)
        {
            // FIX: original called CreateSkills() per row which re-clicked Skills tab + Add New
            // each iteration. Now we click Add New once per row cleanly.
            foreach (var row in table.Rows)
            {
                string skill = row["Skills"];
                string level = row["Level"];

                profilePageObj.ClickAddNewButton(driver);
                profilePageObj.FillAndAddSkill(driver, skill, level);
                _addedSkills.Add(skill);
            }
        }

        [When(@"Add Skills and Levels again")]
        public void WhenAddSkillsAndLevelsAgain(Table table)
        {
            foreach (var row in table.Rows)
            {
                string skill = row["Skills"];
                string level = row["Level"];

                profilePageObj.ClickAddNewButton(driver);
                profilePageObj.FillAndAddSkill(driver, skill, level);
            }
        }

        [When(@"Click on Add button for each added skills")]
        public void WhenClickOnAddButtonForEachAddedSkills()
        {
            // Add button is already clicked inside FillAndAddSkill; this step is now a no-op.
            // Kept so existing feature files don't break.
        }

        [Then(@"Multiple Skills Added")]
        public void ThenMultipleSkillsAdded()
        {
            // FIX: pass the actual list of skills added in this scenario
            Assert.IsTrue(profilePageObj.AreMultipleSkillsAdded(driver, _addedSkills),
                "One or more expected skills were not found in the skills table.");
        }

        [Then(@"Verify that the user receives an error message as ""(.*)""")]
        public void ThenVerifyThatTheUserReceivesAnErrorMessageAs(string errorMessage)
        {
            Assert.IsTrue(profilePageObj.IsErrorMessageDisplayed(driver, errorMessage),
                $"Expected error message '{errorMessage}' was not displayed.");
        }

        // FIX: removed duplicate [Then] binding that shared the exact same regex.
        // "Verify that the user receives a message as" (delete/update confirmation)
        // is now a single method that covers both cases via the shared notification helper.
        [Then(@"Verify that the user receives a message as ""(.*)""")]
        public void ThenVerifyThatTheUserReceivesAMessageAs(string message)
        {
            Assert.IsTrue(profilePageObj.IsNotificationMessageDisplayed(driver, message),
                $"Expected message '{message}' was not displayed.");
        }

        [When(@"Check whether the mentioned Skills are added")]
        public void WhenCheckWhetherTheMentionedSkillsAreAdded(Table table)
        {
            foreach (var row in table.Rows)
            {
                string skill = row["Skills"];
                string level = row["Level"];
                Assert.IsTrue(profilePageObj.IsSkillAdded(driver, skill, level),
                    $"Expected skill '{skill}' at level '{level}' was not found.");
            }
        }

        [When(@"Remove Skill '(.*)' and the Level '(.*)' from the profile")]
        public void WhenRemoveSkillAndTheLevelFromTheProfile(string skill, string level)
        {
            profilePageObj.DeleteSkills(driver, skill, level);
        }

        [When(@"Edit the Skill '(.*)' and Level '(.*)' to '(.*)' and Level '(.*)'")]
        public void WhenEditTheSkillAndLevelToAndLevel(string oldSkill, string oldLevel, string newSkill, string newLevel)
        {
            profilePageObj.EditSkills(driver, oldSkill, oldLevel, newSkill, newLevel);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }
    }
}
