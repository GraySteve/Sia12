using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sia12.PageObjects.AddressesOverview.Address;
using Sia12.PageObjects.AddressesOverview.Address.InputData;
using Sia12.PageObjects.Home;
using Sia12.PageObjects.Login;

namespace Sia12
{
    [TestClass]
    public class AddAddressTests
    {
        private IWebDriver _driver;
        private AddAddressPage _addPage;

        private AddressBo _inputAddress = new AddressBo()
        {
            FirstName = "First Test",
            LastName = "Last Test",
            Address1 = "Address1 test",
            City = "New York",
            State = "Texas",
            Country = "United",
            Color = "#FF0000",
            Zipcode = "Test Zip"
        };

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
            var _loginPage = new LoginPage(_driver);

            _loginPage.LoginInApp("test@test.test", "test");

            Thread.Sleep(1000);
            var homePage = new HomePage(_driver);

            var addressesPage = homePage.NavigateToAddressesOverview();

            _addPage = addressesPage.NavigateToAddAddress();
        }

        [TestMethod]
        public void AddAddressSuccessfully()
        {
            _addPage.CreateAddress(_inputAddress);

        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}
