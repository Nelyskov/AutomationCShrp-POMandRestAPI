using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace AutomationC__lesson6_POM.GoogleSearch
{
    public class GoogleMainPage
    {
        IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#APjFqb")]
        public IWebElement searchField;

        public GoogleMainPage(IWebDriver driver)
        { 
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void Search(string text)
        { 
            searchField.Click();
            searchField.Clear();
            searchField.SendKeys(text);
            searchField.SendKeys(Keys.Enter);
        }
        public string GetPageTitle()
        { 
           return _driver.Title;
        }

        public void GoogleSearch_TitleCheck(string message)
        { 
            string _title = GetPageTitle();
            Assert.That(_title.Contains(message));
        }
    }
}
