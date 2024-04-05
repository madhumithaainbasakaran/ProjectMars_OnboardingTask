using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ProjectMars_OnboardingTask1.Pages
{
    public class Profile
    {
        // Language methods
        public void CreateLanguage(IWebDriver driver, string language, string languageLevel)
        {
            // Verify that the Language tab is displayed
            Thread.Sleep(1000);
            IWebElement languageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            Assert.That(languageTab.Displayed);

            // Click on the Add New button
            Thread.Sleep(2000);
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            Thread.Sleep(2000);

            // Fill in language details
            IWebElement addLanguage = driver.FindElement(By.Name("name"));
            addLanguage.SendKeys(language);
            Thread.Sleep(2000);

            IWebElement addLanguageLevel = driver.FindElement(By.Name("level"));
            SelectElement select = new SelectElement(addLanguageLevel);
            select.SelectByText(languageLevel);
            Thread.Sleep(2000);

            // Click on the Add button
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();
        }

        public void VerifyLanguageAdded(IWebDriver driver, string language)
        {
            // Verify that the language is added successfully
            Thread.Sleep(1000);
            IWebElement languageTable = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
            Assert.IsTrue(languageTable.Text.Contains(language), $"Language '{language}' is not added successfully.");
        }

        public void EditLanguage(IWebDriver driver, string language, string newLanguage)
        {
            // Verify that the Language tab is displayed
            Thread.Sleep(1000);
            IWebElement languageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            Assert.That(languageTab.Displayed);

            // Click on the Edit button for the specified language
            Thread.Sleep(2000);
            string tableValue = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > tbody:nth-child(2) > tr > td.right.aligned > span:nth-child(1)";
            IWebElement tableData = driver.FindElement(By.CssSelector(tableValue));
            tableData.Click();

            // Update the language name
            IWebElement languageName = driver.FindElement(By.Name("name"));
            languageName.Clear();
            languageName.SendKeys(newLanguage);

            Thread.Sleep(2000);
            // Click on the Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            updateButton.Click();
        }

        public void DeleteLanguage(IWebDriver driver, string language)
        {
            // Verify that the Language tab is displayed
            Thread.Sleep(1000);
            IWebElement languageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            Assert.That(languageTab.Displayed);

            // Find the language to delete and click on the delete button
            Thread.Sleep(1000);
            IWebElement languageMainTable = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
            var tableElements = languageMainTable.FindElements(By.TagName("tr"));
            var tbRowCount = tableElements.Count;
            if (tbRowCount > 1)
            {
                IWebElement deleteButton = driver.FindElement(By.XPath($"//td[contains(text(),'{language}')]/following-sibling::td/span[@class='remove ui icon button']"));
                deleteButton.Click();
                Thread.Sleep(1000);
            }
        }

        // Skills methods
        public void NavigateToSkillsTab(IWebDriver driver)
        {
            // Navigate to the Skills tab
            Thread.Sleep(1000);
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();
        }

        public void CreateSkills(IWebDriver driver, string skills, string skillLevel)
        {
            // Skills tab should be clicked
            Thread.Sleep(1000);
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            // Click on the Add New button
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            Thread.Sleep(1000);

            // Fill in skills details
            IWebElement addSkills = driver.FindElement(By.Name("name"));
            addSkills.SendKeys(skills);

            IWebElement addSkillsLevel = driver.FindElement(By.Name("level"));
            addSkillsLevel.SendKeys(skillLevel);

            // Select skill level from dropdown
            SelectElement select = new SelectElement(addSkillsLevel);
            select.SelectByText(skillLevel);
            Thread.Sleep(1000);

            // Click on the Add button
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();
        }

        public void EditSkills(IWebDriver driver, string oldSkill, string oldLevel, string newSkill, string newLevel)
        {
            // Skills tab should be clicked
            Thread.Sleep(1000);
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            // Click on the Edit button for the specified skills
            Thread.Sleep(1000);
            string tableValue = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > tbody:nth-child(2) > tr > td.right.aligned > span:nth-child(1)";
            IWebElement tableData = driver.FindElement(By.CssSelector(tableValue));
            tableData.Click();

            // Update the skill name
            IWebElement skillName = driver.FindElement(By.Name("name"));
            skillName.Clear();
            skillName.SendKeys(newSkill + Keys.Tab);

            // Update the skill level
            IWebElement skillLevel = driver.FindElement(By.Name("level"));
            skillLevel.Clear();
            skillLevel.SendKeys(newLevel + Keys.Tab);

            // Click on the Update button
            Thread.Sleep(2000);
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            updateButton.Click();
        }

        public void DeleteSkills(IWebDriver driver, string skills, string level)
        {
            // Skills tab should be clicked
            Thread.Sleep(1000);
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();

            // Find the skills to delete and click on the delete button
            Thread.Sleep(1000);
            IWebElement deleteButton = driver.FindElement(By.XPath($"//td[contains(text(),'{skills}')]/following-sibling::td/span[@class='remove ui icon button']"));
            deleteButton.Click();
            Thread.Sleep(1000);
        }

        public void ClickAddNewButton(IWebDriver driver)
        {
            // Click on the Add New button
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            Thread.Sleep(1000);
        }

        public void ClickAddButton(IWebDriver driver)
        {
            // Click on the Add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            Thread.Sleep(1000);
        }

        public bool IsSkillAdded(IWebDriver driver, string skill, string level)
        {
            // Implement logic to verify if the skill with the specified level is added
            IWebElement skillElement = driver.FindElement(By.XPath($"//input[@name='name'][@value='{skill}']"));
            IWebElement levelElement = driver.FindElement(By.XPath("//select[@name='level']"));

            return skillElement != null && levelElement != null;
        }

        public bool IsSkillDeletedMessageDisplayed(IWebDriver driver, string message)
        {
            // Implement logic to verify if the deletion message is displayed
            try
            {
                IWebElement messageElement = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                return messageElement != null && messageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public bool AreMultipleSkillsAdded(IWebDriver driver)
        {
            // Implement logic to check if multiple skills are added successfully
            try
            {
                // Use a list of expected skills to check against the actual skills displayed
                List<string> expectedSkills = new List<string> { "Skill1", "Skill2", "Skill3" };

                foreach (string skill in expectedSkills)
                {
                    IWebElement skillElement = driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
                    if (!skillElement.Displayed)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public bool IsErrorMessageDisplayed(IWebDriver driver, string errorMessage)
        {
            try
            {
                // Find the error message element on the page
                IWebElement errorMessageElement = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

                // Check if the error message element is displayed
                return errorMessageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                // If the error message element is not found, return false
                return false;
            }
        }

        public bool IsDuplicateDataErrorMessageDisplayed(IWebDriver driver, string errorMessage)
        {
            try
            {
                // Find the error message element on the page
                IWebElement errorMessageElement = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

                // Check if the error message element is displayed
                return errorMessageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                // If the error message element is not found, return false
                return false;
            }
        }

        public bool IsSkillUpdatedMessageDisplayed(IWebDriver driver, string message)
        {
            // Check if the skill updated message is displayed
            try
            {
                IWebElement messageElement = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                return messageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
