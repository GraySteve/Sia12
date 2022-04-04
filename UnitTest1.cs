using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Sia12
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserLoginsSuccessfully()
        {
            //Open browser
            var driver = new ChromeDriver();
            //Maximize
            driver.Manage().Window.Maximize();
            //Navigate to URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click the SignIn button
            driver.FindElement(By.XPath("//a[@data-test='sign-in']")).Click();
            Thread.Sleep(2000);
            //Fill username
            driver.FindElement(By.Id("session_email")).SendKeys("test@test.test");
            //Fill password
            driver.FindElement(By.Name("session[password]")).SendKeys("test");
            //Click login btn
            driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/input")).Click();
            Thread.Sleep(2000);
            //Assert some thing email is displayed.
            Assert.AreEqual("test@test.test", driver.FindElement(By.XPath("//span[@data-test='current-user']")).Text);
            //Close browser
            driver.Quit();
        }

        [TestMethod]
        public void UserCannotLoginWithWrongEmail()
        {
            //Open browser
            var driver = new ChromeDriver();
            //Maximize
            driver.Manage().Window.Maximize();
            //Navigate to URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click the SignIn button
            driver.FindElement(By.XPath("//a[@data-test='sign-in']")).Click();
            Thread.Sleep(2000);
            //Fill username
            driver.FindElement(By.Id("session_email")).SendKeys("wrong@email.com");
            //Fill password
            driver.FindElement(By.Name("session[password]")).SendKeys("test");
            //Click login btn
            driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/input")).Click();
            Thread.Sleep(2000);
            //Assert some thing email is displayed.
            Assert.AreEqual("Bad email or password.", driver.FindElement(By.XPath("//div[@data-test='notice']")).Text);
            //Close browser
            driver.Quit();
        }

        [TestMethod]
        public void UserCannotLoginWithWrongPass()
        {
            //Open browser
            var driver = new ChromeDriver();
            //Maximize
            driver.Manage().Window.Maximize();
            //Navigate to URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click the SignIn button
            driver.FindElement(By.XPath("//a[@data-test='sign-in']")).Click();
            Thread.Sleep(2000);
            //Fill username
            driver.FindElement(By.Id("session_email")).SendKeys("test@test.test");
            //Fill password
            driver.FindElement(By.Name("session[password]")).SendKeys("test12321e2");
            //Click login btn
            driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/input")).Click();
            Thread.Sleep(2000);
            //Assert some thing email is displayed.
            Assert.AreEqual("Bad email or password.", driver.FindElement(By.XPath("//div[@data-test='notice']")).Text);
            //Close browser
            driver.Quit();
        }
    }
}