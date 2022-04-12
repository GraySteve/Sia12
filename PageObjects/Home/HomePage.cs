using OpenQA.Selenium;
using Sia12.PageObjects.AdressesOverview;

namespace Sia12.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement BtnAddressesOverview => driver.FindElement(By.CssSelector("a[data-test='addresses']"));

        public AddressesOverviewPage NavigateToAddressesOverview()
        {
            return new AddressesOverviewPage(driver);
        }
    }
}
