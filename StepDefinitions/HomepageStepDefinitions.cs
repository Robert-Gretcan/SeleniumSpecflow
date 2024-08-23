using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWithSpecflow.Pages;
using TechTalk.SpecFlow;


namespace SeleniumWithSpecflow.Steps
{

    [Binding]
    public class HomepageSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public HomepageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private IWebDriver _driver;
        private Homepage _demoPage;

        [Given(@"I open the demo page")]
        public void GivenIOpenTheDemoPage()
        {
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _driver.Manage().Window.Maximize();

            _demoPage = new Homepage(_driver);
            _demoPage.Open();
        }

        [When(@"I fill in the text input")]
        public void WhenIFillInTheTextInput()
        {
            _demoPage.FillTextInput("This is a test");
        }

        [When(@"I hover over the dropdown and check items count")]
        public void WhenIHoverOverTheDropdownAndLogItems()
        {
            int itemCount = _demoPage.HoverOverDropdownAndReturnItems();
            itemCount.Should().Be(3);
        }

        [When(@"I select multiple options from the dropdown and check the page")]
        public void WhenISelectMultipleOptionsFromTheDropdown()
        {
            var options = new List<string> { "Set to 50%", "Set to 75%", "Set to 100%" };
            foreach (var option in options)
            {
                _demoPage.SelectMultipleDropdownOptions(option);
                _demoPage.IsOptionSelected(option).Should().BeTrue();
            }

        }

        [Then(@"I should see the correct text inside the iframe")]
        public void ThenIShouldSeeTheCorrectTextInsideTheIframe()
        {
            _demoPage.GetTextFromIframe().Should().Be("iFrame Text");

            _driver.Quit();
        }
    }
}