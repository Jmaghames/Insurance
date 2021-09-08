using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Framework.WebDriver
{
    public class GetDriver
    {
        public static IWebDriver Driver()
        {                                              
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-translate");
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.AddArgument("--test-type");                                 
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);                               
        }
    }
}

