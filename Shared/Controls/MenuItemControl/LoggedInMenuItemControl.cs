using OpenQA.Selenium;

namespace Sia12.Shared.Controls.MenuItemControl
{
    public class LoggedInMenuItemControl: MenuItemControl
    {
        public LoggedInMenuItemControl(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement BtnAddresses =>
            _driver.FindElement(By.CssSelector(""));

        private IWebElement BtnSignOut =>
            _driver.FindElement(By.CssSelector(""));

        private IWebElement LblUserEmail =>
            _driver.FindElement(By.CssSelector(""));
    }
}