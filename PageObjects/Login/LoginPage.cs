using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.Home;
using Sia12.Utils;

namespace Sia12.PageObjects.Login
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By Email => By.Id("session_email");
        private IWebElement TxtEmail => _driver.FindElement(Email);
        private IWebElement TxtPassword => _driver.FindElement(By.Name("session[password]"));
        private IWebElement BtnLogin => _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/input"));
        public IWebElement LblValidationMessage => _driver.FindElement(By.XPath("//div[@data-test='notice']"));

        public HomePage LoginInApp(string email, string password)
        {
            _driver.WaitForElement(Email);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);

            BtnLogin.Click();


            return new HomePage(_driver);
        }
    }
}
