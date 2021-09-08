using CarInsurance.Hooks;
using Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CarInsurance.Steps
{
    [Binding]
    public class CoverLevelsStepDefinitions : FrameworkHooks
    {
        private CoverLevelPage coverLevelPage = Support.Pages.GetPage<CoverLevelPage>();

        [Given("I am on the '(.*)' page")]
        [Then("I am on the '(.*)' page")]
        public void VerifyPageHeader(string header)
        {
            Assert.AreEqual(header, coverLevelPage.getPageText());
        }

        [When("I select the level of cover '(.*)'")]
        public void SelectCoverLevel(string cover)
        {
            coverLevelPage.selectCoverLevelButton(cover);
        }

        [Then("I select '(.*)' from the dropdown menu")]
        public void SelectTextFromDropdown(string text)
        {
            coverLevelPage.SelectTextFromDropdown(text);
        }

        [Then("I select '(.*)' factory options from the dropdown menu")]
        public void FactoryFittedOptionDropdown(string text)
        {
            coverLevelPage.FactoryFittedOptionDropdown(text);
        }

        [Then("I click '(.*)' button")]
        public void SelectButton(string button)
        {
            if (button == "Yes")
                coverLevelPage.Yes.Click();
            if (button == "Ok")
             coverLevelPage.Ok.Click();
        }

        [Then("I verify the Alert '(.*)' is displayed on the page")]
        public void VerifyAlert(string alert)
        {
            Assert.AreEqual(alert, coverLevelPage.getAlertText());
        }
    }
}
