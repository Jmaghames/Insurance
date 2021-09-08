using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using Framework.WebDriver;
using Framework;
using System.IO;
using System.Reflection;

namespace CarInsurance.Hooks
{
    public class FrameworkHooks
    {
        public static FrameworkSupport Support
        {
            get;
            set;
        }
        public static IConfiguration Configuration { get; set; }
        public static IWebDriver Driver { get; set; }

        [Binding]
        public class Initialize
        {
            [BeforeScenario]
            public void TestInitialize()
            {
                var BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Configuration = new ConfigurationBuilder().SetBasePath(BasePath).AddJsonFile("Settings.json").Build();
                var Url = Configuration.GetSection("AppSettings:URL").Value;
                Driver = GetDriver.Driver();
                Support = new FrameworkSupport(Url, Driver);
            }
        }

        [Binding]
        public class Cleanup
        {
            [AfterScenario]
            public void AfterScenario()
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
