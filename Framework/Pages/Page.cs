using Framework.WebDriver;
using OpenQA.Selenium;
using System;
using System.Reflection;

namespace Framework.Pages
{
    public class Page
    {
        private readonly IWebDriver _webDriver;
        private readonly WaitUntil _wait;

        protected Page(IWebDriver driver)
        {
            _webDriver = driver;
            _wait = new WaitUntil(_webDriver);
        }

        public WaitUntil Wait { get { return _wait; } }

        public IWebDriver Driver
        {
            get { return _webDriver; }
            set => throw new NotImplementedException();
        }

        public TPage GetPage<TPage>() where TPage : Page
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;

            return (TPage)Activator.CreateInstance(typeof(TPage), flags, null, new object[] { _webDriver }, null);
        }
    }
}
