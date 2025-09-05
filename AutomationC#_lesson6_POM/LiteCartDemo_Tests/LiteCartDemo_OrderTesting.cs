using AutomationC__lesson6_POM.LiteCartDemo_MakeOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationC__lesson6_POM.LiteCartDemo_Tests
{
    public class LiteCartDemo_OrderTesting : TestBase
    {
        protected override string Url => "https://demo.litecart.net/";

        [Test]
        public void WhenOpenedDuckPage_DuckShouldBeAddedToCart()
        {
            var duckPage = new DuckPage(Driver);
            Driver.Navigate().GoToUrl("https://demo.litecart.net/rubber-ducks-c-1/blue-duck-p-4");
            duckPage.AddDuckToCart();
        }

        [Test]
        public void WhenOrderConfirmed_AlertShouldShowSuccessMessage()
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.LoginWithNameAndPassword("user@email.com", "demo");
            mainPage.CheckThatAllertMessageContainsText("logged in as John Doe.");

            Driver.Navigate().GoToUrl("https://demo.litecart.net/rubber-ducks-c-1/blue-duck-p-4");
            var duckPage = new DuckPage(Driver);
            duckPage.AddDuckToCart();

            var cartPage = new CartPage(Driver);
            cartPage.AcceptTermsAndConfirmOrder();

            cartPage.CheckOrderSuccess("was completed successfully!");
        }
    }
}
