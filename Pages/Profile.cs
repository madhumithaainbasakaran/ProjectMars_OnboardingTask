using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace ProjectMars_OnboardingTask1.Pages
{
    public class Profile
    {
        private WebDriverWait GetWait(IWebDriver driver) =>
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // ── Language methods ──────────────────────────────────────────────────

        public void CreateLanguage(IWebDriver driver, string language, string languageLevel)
        {
            var wait = GetWait(driver);

            // Verify Language tab is visible
            IWebElement languageTab = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")));
            Assert.That(languageTab.Displayed);

            // Click Add New
            IWebElement addNewButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")));
            addNewButton.Click();

            // Fill in language name
            IWebElement addLanguage = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
            addLanguage.SendKeys(language);

            // Select level from dropdown
            IWebElement addLanguageLevel = driver.FindElement(By.Name("level"));
            new SelectElement(addLanguageLevel).SelectByText(languageLevel);

            // Click Add
            IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")));
            addButton.Click();
        }

        public void VerifyLanguageAdded(IWebDriver driver, string language)
        {
            var wait = GetWait(driver);
            IWebElement languageTable = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table")));
            Assert.IsTrue(languageTable.Text.Contains(language),
                $"Language '{language}' was not found in the language table.");
        }

        public void EditLanguage(IWebDriver driver, string language, string newLanguage)
        {
            var wait = GetWait(driver);

            IWebElement languageTab = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")));
            Assert.That(languageTab.Displayed);

            string tableValue = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > tbody:nth-child(2) > tr > td.right.aligned > span:nth-child(1)";
            IWebElement tableData = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(tableValue)));
            tableData.Click();

            IWebElement languageName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
            languageName.Clear();
            languageName.SendKeys(newLanguage);

            IWebElement updateButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")));
            updateButton.Click();
        }

        public void DeleteLanguage(IWebDriver driver, string language)
        {
            var wait = GetWait(driver);

            IWebElement languageTab = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")));
            Assert.That(languageTab.Displayed);

            IWebElement languageMainTable = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table")));

            var rows = languageMainTable.FindElements(By.TagName("tr"));
            if (rows.Count > 1)
            {
                IWebElement deleteButton = driver.FindElement(
                    By.XPath($"//td[contains(text(),'{language}')]/following-sibling::td/span[@class='remove ui icon button']"));
                deleteButton.Click();
            }
        }

        // ── Skills methods ────────────────────────────────────────────────────

        public void NavigateToSkillsTab(IWebDriver driver)
        {
            var wait = GetWait(driver);
            IWebElement skillsTab = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            skillsTab.Click();
        }

        /// <summary>
        /// Fills in skill name + level and clicks Add. Assumes the Add New row is already open.
        /// Does NOT re-click the Skills tab or Add New button.
        /// </summary>
        public void FillAndAddSkill(IWebDriver driver, string skill, string skillLevel)
        {
            var wait = GetWait(driver);

            IWebElement addSkills = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
            addSkills.Clear();
            addSkills.SendKeys(skill);

            IWebElement addSkillsLevel = driver.FindElement(By.Name("level"));
            new SelectElement(addSkillsLevel).SelectByText(skillLevel);

            IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")));
            addButton.Click();
        }

        /// <summary>
        /// Full helper: navigates to Skills tab, opens Add New, fills skill, and clicks Add.
        /// Use only for single-skill scenarios.
        /// </summary>
        public void CreateSkills(IWebDriver driver, string skill, string skillLevel)
        {
            NavigateToSkillsTab(driver);
            ClickAddNewButton(driver);
            FillAndAddSkill(driver, skill, skillLevel);
        }

        public void EditSkills(IWebDriver driver, string oldSkill, string oldLevel, string newSkill, string newLevel)
        {
            var wait = GetWait(driver);
            NavigateToSkillsTab(driver);

            string tableValue = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > tbody:nth-child(2) > tr > td.right.aligned > span:nth-child(1)";
            IWebElement tableData = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(tableValue)));
            tableData.Click();

            IWebElement skillName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
            skillName.Clear();
            skillName.SendKeys(newSkill + Keys.Tab);

            IWebElement skillLevel_el = driver.FindElement(By.Name("level"));
            skillLevel_el.Clear();
            skillLevel_el.SendKeys(newLevel + Keys.Tab);

            IWebElement updateButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")));
            updateButton.Click();
        }

        public void DeleteSkills(IWebDriver driver, string skill, string level)
        {
            var wait = GetWait(driver);
            NavigateToSkillsTab(driver);

            IWebElement deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath($"//td[contains(text(),'{skill}')]/following-sibling::td/span[@class='remove ui icon button']")));
            deleteButton.Click();
        }

        public void ClickAddNewButton(IWebDriver driver)
        {
            var wait = GetWait(driver);
            IWebElement addNewButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
            addNewButton.Click();
        }

        public void ClickAddButton(IWebDriver driver)
        {
            var wait = GetWait(driver);
            IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//input[@value='Add']")));
            addButton.Click();
        }

        public bool IsSkillAdded(IWebDriver driver, string skill, string level)
        {
            // FIX: original logic searched for input[@value='{skill}'] which only works
            // in edit-mode. Instead verify the skill row exists in the table.
            try
            {
                IWebElement skillRow = driver.FindElement(
                    By.XPath($"//td[normalize-space(text())='{skill}']"));
                return skillRow.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsNotificationMessageDisplayed(IWebDriver driver, string expectedMessage)
        {
            // Shared helper: checks the notification banner text matches the expected message
            try
            {
                var wait = GetWait(driver);
                IWebElement messageElement = wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("//div[@class='ns-box-inner']")));
                return messageElement.Displayed && messageElement.Text.Contains(expectedMessage);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // Keep individual named wrappers for readability in step definitions
        public bool IsSkillDeletedMessageDisplayed(IWebDriver driver, string message) =>
            IsNotificationMessageDisplayed(driver, message);

        public bool IsErrorMessageDisplayed(IWebDriver driver, string errorMessage) =>
            IsNotificationMessageDisplayed(driver, errorMessage);

        public bool IsDuplicateDataErrorMessageDisplayed(IWebDriver driver, string errorMessage) =>
            IsNotificationMessageDisplayed(driver, errorMessage);

        public bool IsSkillUpdatedMessageDisplayed(IWebDriver driver, string message) =>
            IsNotificationMessageDisplayed(driver, message);

        public bool AreMultipleSkillsAdded(IWebDriver driver, List<string> expectedSkills)
        {
            // FIX: original used hardcoded dummy list {"Skill1","Skill2","Skill3"}.
            // Now accepts the actual expected list and verifies each skill row exists.
            foreach (string skill in expectedSkills)
            {
                if (!IsSkillAdded(driver, skill, ""))
                    return false;
            }
            return true;
        }
    }
}
