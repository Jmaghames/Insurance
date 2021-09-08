using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.WebDriver
{
    public class WaitUntil
    {
        private const int DefaultTimeout = 15;
        private readonly WebDriverWait _wait;

        public WaitUntil(IWebDriver driver)
        {
            _wait = new WebDriverWait(driver, new TimeSpan(0, 0, DefaultTimeout));
        }

        public WaitUntil(IWebDriver driver, int timeout)
        {
            if (timeout <= 0)
            {
                timeout = DefaultTimeout;
            }
            _wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
        }
        public void For(By locator)
        {
            _wait.Until(drv => drv.FindElement(locator));
        }

        public void IsClickable(By locator)
        {
            _wait.Until((SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator)));
        }

        public void IsInvisible(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void IsVisible(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void IsDisplayed(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public void IsExists(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }
        public void IsAjaxLoaded(IWebDriver Driver)
        {
            _wait.Until(d => (bool)(Driver as IJavaScriptExecutor).ExecuteScript("return window.jQuery != undefined && jQuery.active === 0"));
        }
    }
}
