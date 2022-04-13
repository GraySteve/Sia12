using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.AddressesOverview;

namespace Sia12.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver browser)
        {
            _driver = browser;
        }

        private IWebElement BtnAddressesOverview => _driver.FindElement(By.CssSelector("a[data-test='addresses']"));

        public AddressesOverviewPage NavigateToAddressesOverview()
        {
            BtnAddressesOverview.Click();
            Thread.Sleep(1000);
            return new AddressesOverviewPage(_driver);
        }
    }
}
