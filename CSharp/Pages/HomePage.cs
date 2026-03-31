using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardingTask1.Pages
{
    public class HomePage
    {
        public void HomePageActions(IWebDriver driver)
        {
            //Navigate to profile tab
            Thread.Sleep(3000);
            IWebElement ProfileTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            ProfileTab.Click();
        }

    }
}