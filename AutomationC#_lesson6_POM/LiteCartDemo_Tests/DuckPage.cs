using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationC__lesson6_POM.LiteCartDemo_Tests
{
    public class DuckPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        private IWebElement addToCartBtn;

        [FindsBy(How = How.Name, Using = "quantity")]
        private IWebElement quantityField;

        [FindsBy(How = How.CssSelector, Using = "span.quantity")]
        private IWebElement cartQuantity;

        public DuckPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ChangeDuckQuantity(string quantity)
        {
            quantityField.Clear();
            quantityField.SendKeys(quantity);
        }

        public void AddDuckToCart()
        {
            //int before = int.Parse(cartQuantity.Text);
            addToCartBtn.Click();
            Thread.Sleep(1000);

            // ждём, пока количество в корзине увеличится
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => int.Parse(cartQuantity.Text) == before + 1);
        }

    }
}
