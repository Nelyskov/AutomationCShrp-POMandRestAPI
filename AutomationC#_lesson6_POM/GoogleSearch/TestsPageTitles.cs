using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationC__lesson6_POM.GoogleSearch
{
    [TestFixture]
    public class TestsPageTitles : TestBase
    {
        [Test]
        public void WhenSearch_PageTitleContainsText()
        {
            GoogleMainPage googleMainPage = new GoogleMainPage(Driver);
            googleMainPage.Search("Selenium");
            googleMainPage.GoogleSearch_TitleCheck("Selenium");
        }
    }
}
