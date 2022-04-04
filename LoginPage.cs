using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace Sia12
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement TxtEmail => _driver.FindElement(By.Id("session_email"));
        private IWebElement TxtPassword => _driver.FindElement(By.Name("session[password]"));
        private IWebElement BtnLogin => _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/input"));
        public IWebElement LblValidationMessage => _driver.FindElement(By.XPath("//div[@data-test='notice']"));

        public void LoginInApp(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);

            BtnLogin.Click();
            Thread.Sleep(2000);
        }
    }
}
