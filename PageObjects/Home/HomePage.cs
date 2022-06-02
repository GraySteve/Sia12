using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.AddressesOverview;
using Sia12.Shared.Controls.MenuItemControl;

namespace Sia12.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver browser)
        {
            _driver = browser;
        }


        public LoggedInMenuItemControlCommon Menu => new LoggedInMenuItemControlCommon(_driver);
    }
}
