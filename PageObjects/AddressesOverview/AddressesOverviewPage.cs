using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.AddressesOverview.Address;

namespace Sia12.PageObjects.AddressesOverview
{
    public class AddressesOverviewPage
    {
        private IWebDriver driver;

        public AddressesOverviewPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement BtnCreateAddress => 
            driver.FindElement(By.XPath("//a[@data-test='create']"));
        private IList<IWebElement> LstAddresses => 
            driver.FindElements(By.CssSelector("tbody tr"));

        private IWebElement BtnEdit(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-test*=edit]"));

        private IWebElement BtnDelete(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-test*=destroy]"));

        public AddEditAddressPage NavigateToAddAddress()
        {
            BtnCreateAddress.Click();
            Thread.Sleep(1000);
            return new AddEditAddressPage(driver);
        }

        public void DeleteAddress(string addressName)
        {
            BtnDelete(addressName).Click();
            driver.SwitchTo().Alert().Dismiss();
        }

        public AddEditAddressPage NavigateToEditAddress(string addressName)
        {
            BtnEdit(addressName).Click();
            return new AddEditAddressPage(driver);
        }
    }
}
