using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.AddressesOverview;
using Sia12.Utils;

namespace Sia12.Shared.Controls.MenuItemControl
{
    public class LoggedInMenuItemControlCommon : MenuItemControlCommon
    {
        public LoggedInMenuItemControlCommon(IWebDriver driver) : base(driver)
        {
        }

        private By Addresses => By.CssSelector("a[data-test='addresses']");
        private IWebElement BtnAddresses =>
            _driver.FindElement(Addresses);

        private IWebElement BtnSignOut =>
            _driver.FindElement(By.CssSelector(""));

        private IWebElement LblUserEmail =>
            _driver.FindElement(By.XPath("//span[@data-test='current-user']"));

        public string GetCurrentUser => LblUserEmail.Text;


        public AddressesOverviewPage NavigateToAddressesOverview()
        {
            _driver.WaitForElement(Addresses);
            BtnAddresses.Click();

            return new AddressesOverviewPage(_driver);
        }

    }
}