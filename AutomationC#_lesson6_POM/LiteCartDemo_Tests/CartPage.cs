using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationC__lesson6_POM.LiteCartDemo_Tests
{
    public class CartPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "terms_agreed")]
        private IWebElement checkBoxTerms;

        [FindsBy(How = How.CssSelector, Using = "button[name='confirm_order']")]
        private IWebElement confirmOrderBtn;

        [FindsBy(How = How.CssSelector, Using = "#box-order-success h1")]
        public IWebElement alertSuccessOrder;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void AcceptTermsAndConfirmOrder()
        {
            driver.Navigate().GoToUrl("https://demo.litecart.net/checkout");
            checkBoxTerms.Click();
            confirmOrderBtn.Click();
        }

        public void CheckOrderSuccess(string message)
        {
            Assert.That(alertSuccessOrder.Text.Contains(message));
        }
    }
}
