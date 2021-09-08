using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Pages
{
   public class FindYourCarPage : Page
    {
        public IWebDriver _webDriver;
        protected FindYourCarPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        private By findyourcartext = By.XPath("//h2[contains(text(), 'Find your car')]");
        private IList<IWebElement> DropDownMenu => Driver.FindElements(By.XPath(".//div[contains(@data-baseweb,'form-control-container')]"));
        private By carDetails = By.TagName("li");
        private IList<IWebElement> carDetailsList => Driver.FindElements(carDetails);

        public void SelectMake(string make)
        {
            Wait.IsDisplayed(findyourcartext);
            DropDownMenu[0].Click();
            Wait.IsDisplayed(carDetails);
            IWebElement makeToClick = carDetailsList
                .FirstOrDefault(x => x.Text.Trim().Equals(make));
            makeToClick.Click();
        }

        public void SelectModel(string model)
        {        
            Wait.IsDisplayed(carDetails);
            IWebElement makeToClick = carDetailsList
                .FirstOrDefault(x => x.Text.Trim().Equals(model));
            makeToClick.Click();
        }

        public void SelectYear(string year)
        {
            Wait.IsDisplayed(carDetails);
            IWebElement yearToClick = carDetailsList
                .FirstOrDefault(x => x.Text.Trim().Equals(year));
            yearToClick.Click();
        }

        public void SelectTypeOrSeries(string year)
        {
            Wait.IsDisplayed(carDetails);
            IWebElement typeOrSeriesToClick = carDetailsList
                .FirstOrDefault(x => x.Text.Trim().Equals(year));
            typeOrSeriesToClick.Click();
        }

        public void SelectColour(string colour)
        {
            Wait.IsDisplayed(carDetails);
            IWebElement colourToClick = carDetailsList
                .FirstOrDefault(x => x.Text.Trim().Equals(colour));
            colourToClick.Click();
        }
    }
}
