using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWithSpecflow.Pages
{
    internal class Homepage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://seleniumbase.io/demo_page";
        private readonly Actions Actions;

        private IWebElement InputText => _driver.FindElement(By.Id("myTextInput"));
        private IWebElement HoverDropDownButton => _driver.FindElement(By.CssSelector(".dropdown .dropbtn"));
        private IEnumerable<IWebElement> HoverDropDownItems => _driver.FindElements(By.CssSelector(".dropdown-content a"));
        private SelectElement SelectDropdown => new SelectElement(_driver.FindElement(By.XPath("//*[@id='mySelect']")));
        private IWebElement Iframe => _driver.SwitchTo().Frame("frameName2").FindElement(By.TagName("h4"));

        public Homepage(IWebDriver driver)
        {
            _driver = driver;
            Actions = new Actions(_driver);
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public void FillTextInput(string text)
        {
            InputText.Clear();
            InputText.SendKeys(text);
        }

        public int HoverOverDropdownAndReturnItems()
        {
            Actions.MoveToElement(HoverDropDownButton).Perform();

            return HoverDropDownItems.Count();
        }

        public void SelectMultipleDropdownOptions(string option)
        {
            Thread.Sleep(500);
            SelectDropdown.SelectByText(option);

        }

        public bool IsOptionSelected(string option)
        {
            return SelectDropdown.SelectedOption.Text.Equals(option);
        }

        public string GetTextFromIframe()
        {            
            var iframeText = Iframe.Text;
            _driver.SwitchTo().DefaultContent(); // Switch back to the main content
            return iframeText;
        }
    }
}
