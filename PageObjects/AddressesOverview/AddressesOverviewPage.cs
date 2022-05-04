﻿using System.Threading;
using OpenQA.Selenium;
using Sia12.PageObjects.AddressesOverview.Address;

namespace Sia12.PageObjects.AddressesOverview
{
    public class AddressesOverviewPage
    {
        private IWebDriver driver;

        public AddressesOverviewPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement BtnCreateAddress => driver.FindElement(By.XPath("//a[@data-test='create']"));
        private IWebElement TblAddresses => driver.FindElement(By.XPath("//table[@class='table']//tbody"));
        public AddAddressPage NavigateToAddAddress()
        {
            BtnCreateAddress.Click();
            Thread.Sleep(1000);
            return new AddAddressPage(driver);
        }

        public EditAddressPage NavigateToEditAddress()
        {

            return new EditAddressPage(driver);
        }
    }
}