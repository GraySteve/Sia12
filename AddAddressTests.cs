using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sia12.PageObjects.AddressesOverview;
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
        private AddEditAddressPage _addEditPage;
        private AddressesOverviewPage addressesPage;

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

            addressesPage = homePage.NavigateToAddressesOverview();


        }

        [TestMethod]
        public void AddAddressSuccessfully()
        {
            _addEditPage = addressesPage.NavigateToAddAddress();
            var addressDetailsPage = _addEditPage.CreateEditAddress(_inputAddress);

            Assert.Equals("Address was successfully created.", addressDetailsPage.NoticeText);
        }


        [TestMethod]
        public void EditAddressSuccessfully()
        {
            var inputData = new AddressBo()
            {
                FirstName = "Pretty please don't edit/delete",
                LastName = "SIA 12 Edit"
            };

            _addEditPage = addressesPage.NavigateToEditAddress(inputData.FirstName);
            var addressDetailsPage = _addEditPage.CreateEditAddress(_inputAddress);

            Assert.AreEqual("Address was successfully updated.", addressDetailsPage.NoticeText);
        }

        [TestMethod]
        public void DismissAlertSuccessfully()
        {
            var inputData = new AddressBo()
            {
                FirstName = "Pretty please don't edit/delete",
                LastName = "SIA 12 Edit"
            };
            addressesPage.DeleteAddress(inputData.FirstName);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}
