using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardingTask1.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver = new ChromeDriver();

        public void NavigateToProfilePage(IWebDriver driver)
        {
            // Navigate to the profile page
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }
    }
}