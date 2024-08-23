using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWithSpecflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumWithSpecflow.Hooks
{
    [Binding]
    internal class HomepageHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public HomepageHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //action before each feature

        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Instantiate WebDriver before each scenario
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _scenarioContext["WebDriver"] = driver;

        }
        [AfterScenario]
        public void AfterScenario()
        {
            // Clean up WebDriver after each scenario
            if (_scenarioContext.ContainsKey("WebDriver"))
            {
                var driver = _scenarioContext["WebDriver"] as IWebDriver;
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }

        }
        [AfterFeature]
        public static void AfterFeature()
        {
            //action after feature scenario

        }
    }
}
