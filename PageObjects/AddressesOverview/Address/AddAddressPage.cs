using OpenQA.Selenium;

namespace Sia12.PageObjects.AddressesOverview.Address
{
    public class AddAddressPage
    {
        private IWebDriver driver;

        public AddAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement TxtFirstName => driver.FindElement(By.Id("address_first_name"));

        public IWebElement TxtLastName => driver.FindElement(By.XPath("//input[@name='address[last_name]']"));

        public IWebElement TxtAddress1 => driver.FindElement(By.CssSelector("input[name='address[address1]']"));
        public IWebElement TxtCity => driver.FindElement(By.Id("address_city"));
        public IWebElement TxtZipCode => driver.FindElement(By.Id("address_zip_code"));

        public IWebElement BtnCreate => driver.FindElement(By.CssSelector("input[data-test='submit']"));

        public void CreateAddress(string firstName, string lastName, string address1, string city, string zipcode)
        {
            TxtFirstName.SendKeys(firstName);
            TxtLastName.SendKeys(lastName);
            TxtAddress1.SendKeys(address1);
            TxtCity.SendKeys(city);
            TxtZipCode.SendKeys(zipcode);

            BtnCreate.Click();
        }
    }
}
