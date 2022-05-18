using OpenQA.Selenium;

namespace Sia12.PageObjects.AddressDetails
{
    public class AddressDetailsPage
    {
        private IWebDriver _driver;

        public AddressDetailsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement LblNotice =>
            _driver.FindElement(By.CssSelector("div[data-test=notice]"));


        public string NoticeText => LblNotice.Text;
    }
}