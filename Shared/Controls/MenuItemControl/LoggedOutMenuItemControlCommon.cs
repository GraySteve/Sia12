using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.Login;

namespace Sia12.Shared.Controls.MenuItemControl
{
    public class LoggedOutMenuItemControlCommon: MenuItemControlCommon
    {
        public LoggedOutMenuItemControlCommon(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement BtnSignIn =>
            _driver.FindElement(By.XPath("//a[@data-test='sign-in']"));

        public LoginPage NavigateToLoginPage()
        {
            BtnSignIn.Click();

            return new LoginPage(_driver);
        }
    }
}