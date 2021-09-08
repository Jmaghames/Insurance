using Framework.Pages;
using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Threading;

namespace Framework
{
    public class FrameworkSupport
    {
        private const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
        private IWebDriver _webDriver;

        public Page Pages
        {
            get;
            private set;
        }

        public FrameworkSupport(string url, IWebDriver driver)
        {
            _webDriver = driver;       
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            Pages = (Page)Activator.CreateInstance(typeof(Page), flags, null, new object[] { _webDriver }, null);
        }
    }
}
