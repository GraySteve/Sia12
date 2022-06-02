using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.AddressesOverview.Address;
using Sia12.Utils;

namespace Sia12.PageObjects.AddressesOverview
{
    public class AddressesOverviewPage
    {
        private IWebDriver driver;

        public AddressesOverviewPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By CreateAddress => By.XPath("//a[@data-test='create']");
        private IWebElement BtnCreateAddress => 
            driver.FindElement(CreateAddress);
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
            driver.WaitForElement(CreateAddress);

            BtnCreateAddress.Click();
            
            return new AddEditAddressPage(driver);
        }

        public void DeleteAddress(string addressName)
        {
            driver.WaitForElement(CreateAddress);

            BtnDelete(addressName).Click();
            driver.SwitchTo().Alert().Dismiss();
        }

        public AddEditAddressPage NavigateToEditAddress(string addressName)
        {
            driver.WaitForElement(CreateAddress);

            BtnEdit(addressName).Click();
 
            return new AddEditAddressPage(driver);
        }
    }
}
