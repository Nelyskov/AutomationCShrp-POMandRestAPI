using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationC__lesson6_POM.LiteCartDemo_MakeOrder
{
    /// <summary>
    /// Сбор элементов для прохождения авторизации на сайте
    /// signIn - поиск кнопки для открытия меню (выпадающего списка) авторизации
    /// email, password - ввод почты и пароля
    /// loginBtn - кнопка авторизации, нажимать после ввода почты и пароля
    /// alert - отображаемое сообщение после авторизации
    /// </summary>
    public class MainPage
    {
        public IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Sign In")]
        public IWebElement signIn;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement email;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[@name='login' and text()='Sign In']")]
        public IWebElement loginBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"notices\"]/div")]
        private IWebElement alert;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public MainPage LoginWithNameAndPassword(string name, string pass)
        {
            signIn.Click();

            email.Clear();
            email.SendKeys(name);

            password.Clear();
            password.SendKeys(pass);

            loginBtn.Click();

            return new MainPage(driver);
        }

        public void CheckThatAllertMessageContainsText(string message)
        {
            Assert.That(alert.Text.Contains(message));
        }
    }
}
