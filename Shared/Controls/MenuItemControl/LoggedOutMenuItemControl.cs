using OpenQA.Selenium;

namespace Sia12.Shared.Controls.MenuItemControl
{
    public class LoggedOutMenuItemControl: MenuItemControl
    {
        public LoggedOutMenuItemControl(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement BtnSignIn =>
            _driver.FindElement(By.CssSelector(""));
    }
}