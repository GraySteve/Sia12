using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sia12.PageObjects.AddressDetails;
using Sia12.PageObjects.AddressesOverview.Address.InputData;
using Sia12.Utils;

namespace Sia12.PageObjects.AddressesOverview.Address
{
    public class AddEditAddressPage
    {
        private IWebDriver driver;

        public AddEditAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By FirstName => By.Id("address_first_name");
        private IWebElement TxtFirstName => driver.FindElement(FirstName);

        public IWebElement TxtLastName => driver.FindElement(By.XPath("//input[@name='address[last_name]']"));

        public IWebElement TxtAddress1 => driver.FindElement(By.CssSelector("input[name='address[address1]']"));
        public IWebElement TxtCity => driver.FindElement(By.Id("address_city"));
        public IWebElement TxtZipCode => driver.FindElement(By.Id("address_zip_code"));

        public IWebElement BtnCreate => driver.FindElement(By.CssSelector("input[data-test='submit']"));

        public IWebElement DdlState => driver.FindElement(By.Id("address_state"));
        public IList<IWebElement> LstCountry => driver.FindElements(By.XPath("//label[contains(@for,'address_country')]"));

        public IWebElement TxtColor => driver.FindElement(By.Id("address_color"));

        public AddressDetailsPage CreateEditAddress(AddressBo address)
        {
            driver.WaitForElement(FirstName,40);
            TxtFirstName.Clear();
            TxtFirstName.SendKeys(address.FirstName);
            TxtLastName.Clear();
            TxtLastName.SendKeys(address.LastName);
            TxtAddress1.SendKeys(address.Address1);
            TxtCity.SendKeys(address.City);
            TxtZipCode.SendKeys(address.Zipcode);
            
            var selectElem = new SelectElement(DdlState);
            selectElem.SelectByText(address.State);

            LstCountry.First(el => el.Text.Contains(address.Country)).Click();

            var jsEx = (IJavaScriptExecutor)driver;
            jsEx.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", TxtColor, address.Color);

            BtnCreate.Click();
            return new AddressDetailsPage(driver);
        }
    }
}
