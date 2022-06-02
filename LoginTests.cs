using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sia12.PageObjects.Login;
using Sia12.Shared.Controls.MenuItemControl;

namespace Sia12
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [TestInitialize]
        public void StartUp()
        {
            //Open browser
            _driver = new ChromeDriver();
            //Maximize
            _driver.Manage().Window.Maximize();
            //Navigate to URL
            _driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click the SignIn button
            var menu = new LoggedOutMenuItemControlCommon(_driver);
            _loginPage = menu.NavigateToLoginPage();
        }

        [TestMethod]
        public void UserLoginsSuccessfully()
        {
            var homePage = _loginPage.LoginInApp("test@test.test", "test");
            //Assert some thing email is displayed.
            Assert.AreEqual("test@test.test", homePage.Menu.GetCurrentUser);
        }

        [TestMethod]
        public void UserCannotLoginWithWrongEmail()
        {
            _loginPage.LoginInApp("wrong@email.com", "test");
            //Assert some thing email is displayed.
            Assert.AreEqual("Bad email or password.", _loginPage.LblValidationMessage.Text);
        }

        [TestMethod]
        public void UserCannotLoginWithWrongPass()
        {
            _loginPage.LoginInApp("test@test.test", "test2312313213123");
            //Assert some thing email is displayed.
            Assert.AreEqual("Bad email or password.", _loginPage.LblValidationMessage.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Close browser
            _driver.Quit();
        }
    }
}
