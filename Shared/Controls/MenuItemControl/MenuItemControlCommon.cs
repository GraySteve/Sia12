using OpenQA.Selenium;
using Sia12.PageObjects.Home;

namespace Sia12.Shared.Controls.MenuItemControl
{
    public class MenuItemControlCommon
    {
        public IWebDriver _driver;

        public MenuItemControlCommon(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement BtnHome =>
            _driver.FindElement(By.CssSelector(""));

        public HomePage NavigateToHomePage()
        {
            BtnHome.Click();
            return new HomePage(_driver);
        }
    }
}