using System.Threading;
using OpenQA.Selenium;

namespace Sia12.PageObjects.AddressesOverview.Address
{
    public class EditAddressPage
    {
        private IWebDriver _driver;
        public EditAddressPage(IWebDriver browser)
        {
            _driver = browser;
        }
    }
}
