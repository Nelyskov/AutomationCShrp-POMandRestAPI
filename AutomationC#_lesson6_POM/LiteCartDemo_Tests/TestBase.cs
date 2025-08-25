using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationC__lesson6_POM.LiteCartDemo_MakeOrder
{
    public abstract class TestBase
    {
        protected IWebDriver Driver;
        protected abstract string Url { get; }

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
