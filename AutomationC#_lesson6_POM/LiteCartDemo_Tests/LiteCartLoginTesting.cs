using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationC__lesson6_POM.LiteCartDemo_MakeOrder
{
    [TestFixture]
    public class LiteCartLoginTesting : TestBase
    {
        protected override string Url => "https://demo.litecart.net/";
        [Test]
        public void WhenLoginWithValidNameAndPassword_SuccessMessageShouldAppear()
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.LoginWithNameAndPassword("user@email.com", "demo");
            mainPage.CheckThatAllertMessageContainsText("logged in as John Doe.");
        }

        [Test]
        public void WhenLoginWithNotValidNameAndPassword_UnsuccessMessageShouldAppear()
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.LoginWithNameAndPassword("invalid@email.com", "incorrectpass");
            mainPage.CheckThatAllertMessageContainsText("The email does not exist in our database");
        }
    }
}
