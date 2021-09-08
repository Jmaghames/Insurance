using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Framework.Pages
{
    public class CoverLevelPage : Page
    {
        public IWebDriver _webDriver;

        protected CoverLevelPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        private By pageText = By.XPath(".//div[contains(@data-baseweb,'form-control-label')]");
        private IList<IWebElement> ButtonsListRoot => _webDriver.FindElements(By.XPath(".//div[contains(@aria-label,'button group')]"));
        private IList<IWebElement> CoverButtonsList => ButtonsListRoot[0].FindElements(By.XPath(".//button[contains(@data-baseweb,'button')]"));
        private IList<IWebElement> DropDownMenu => _webDriver.FindElements(By.XPath(".//div[contains(@data-baseweb,'form-control-container')]"));
        public IWebElement Yes => ButtonsListRoot[0].FindElement(By.XPath(".//button[contains(@data-baseweb,'button')]"));
        private By dropDownDetails = By.TagName("li");
        private IList<IWebElement> dropDownDetailsList => _webDriver.FindElements(dropDownDetails);
        private By TransRoot = By.XPath(".//div[contains(@style,'transition')]");
        private IWebElement ElementRoot => _webDriver.FindElement(TransRoot);
        private By OkButton = By.XPath("//button[contains(text(), 'Ok')]");
        public IWebElement alertText => ElementRoot.FindElement(By.XPath("//span[contains(text(), 'Please select an option')]"));

        public IWebElement Ok
        {
            get
            {
                Wait.IsDisplayed(OkButton);
                var OkBtn = ElementRoot.FindElement(OkButton);
                return OkBtn;
            }         
        }

        public string getAlertText()
        {
            Wait.IsDisplayed(TransRoot);
            var text = alertText.Text;
            return text;
        }

        public string getPageText()
        {
            WaitForPageTextToLoad(pageText);
            var text = _webDriver.FindElement(pageText).Text;
            return text;
        }

        public void selectCoverLevelButton(string button)
        {
            foreach (var cover in CoverButtonsList)
                if (cover.Text == button)
                    cover.Click();        
        }

        public void SelectTextFromDropdown(string text)
        {
            WaitForPageTextToLoad(pageText);
            DropDownMenu[0].Click();
            Wait.IsDisplayed(dropDownDetails);
            IWebElement reasonToClick = dropDownDetailsList
                .FirstOrDefault(x => x.Text.Trim().Equals(text));
            reasonToClick.Click();
        }

        public void FactoryFittedOptionDropdown(string text)
        {
            WaitForPageTextToLoad(pageText);
            DropDownMenu[1].Click();
            Wait.IsDisplayed(dropDownDetails);
            IWebElement reasonToClick = dropDownDetailsList
                .FirstOrDefault(x => x.Text.Trim().Equals(text));
            reasonToClick.Click();
        }

        public void WaitForPageTextToLoad(By pageText, int timeout = 10 )
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                do
                {
                    var loadingElements = _webDriver.FindElements(pageText);
                    if (loadingElements.Count > 0)
                        break;

                    if (stopwatch.Elapsed.TotalSeconds > timeout)
                        throw new TimeoutException("Content was not loaded on the page");
                } while (true);
            }
            catch
            {
            }
            Thread.Sleep(1000);
        }
    }
}
