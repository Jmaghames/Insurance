using CarInsurance.Hooks;
using Framework.Pages;
using TechTalk.SpecFlow;

namespace Car_Insurance.Steps
{
    [Binding]
    public class FindYourCarStepDefinitions : FrameworkHooks
    {
       private FindYourCarPage findYourCarPagePage = Support.Pages.GetPage<FindYourCarPage>();

        [Given("I select the Make '(.*)'")]
        public void SelectMake(string make)
        {
            findYourCarPagePage.SelectMake(make);
        }

        [When("I select the Model '(.*)'")]
        public void SelectModel(string model)
        {
            findYourCarPagePage.SelectModel(model);
        }

        [Then("I select the year '(.*)'")]
        public void SelectYear(string year)
        {
            findYourCarPagePage.SelectYear(year);
        }

        [Then("I select the car type or series '(.*)'")]
        public void SelectTypeOrSeries(string TypeAndSeries)
        {
            findYourCarPagePage.SelectTypeOrSeries(TypeAndSeries);
        }

        [Then("I select the colour '(.*)'")]
        public void SelectColour(string colour)
        {
            findYourCarPagePage.SelectColour(colour);
        }
    }
}
