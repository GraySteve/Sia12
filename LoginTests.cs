using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sia12.PageObjects.Login;

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
            _driver.FindElement(By.XPath("//a[@data-test='sign-in']")).Click();
            Thread.Sleep(2000);
            _loginPage = new LoginPage(_driver);
        }

        [TestMethod]
        public void UserLoginsSuccessfully()
        {
            _loginPage.LoginInApp("test@test.test", "test");
            //Assert some thing email is displayed.
            Assert.AreEqual("test@test.test", _driver.FindElement(By.XPath("//span[@data-test='current-user']")).Text);
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
