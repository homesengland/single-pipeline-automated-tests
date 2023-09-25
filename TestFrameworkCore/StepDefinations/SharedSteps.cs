using He.TestFramework.TestBase.Web;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TestFrameworkCore.Pages;
using TestFrameworkCore.TestAssembly;

namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    public class SharedSteps
    {
        private readonly ScenarioContext sContext;

        public SharedSteps(ScenarioContext injectedContext)
        {
           sContext = injectedContext;
        }
        public SharedSteps()
        {
        }

        [Given(@"I navigate to the url")]
        public void GivenNavigateToTheUrl()
        {
            BasePage basePage = new BasePage(StaticObjectRepo.Driver, sContext);
            basePage.GoToURL();
            PageObjectRepo.superCalculatorPage = new SuperCalculatorPage(StaticObjectRepo.Driver, sContext);
        }

        [Then(@"the page '(.*)' is displayed")]
        public void ThenThePageIsDisplayed(string title)
        {
            if (title.ToLower().Equals("opportunities"))
            {
                opportunityPage.WaitForPageToLoad();
                opportunityPage.ValidateTitle(title);
            }
            else if (title.ToLower().Equals("contacts"))
            {
                contactsPage.WaitForPageToLoad();
                contactsPage.ValidateTitle(title);
            }
            else
            {
                throw new NotFoundException(title + " title not found!!");
            }
        }


        [Then(@"I validate the Page title and columns displayed on '(.*)' page")]
        public void ThenIValidateThePageTitleAndColumnsDisplayedOnPage(string tab)
        {
            if (tab.ToLower().Equals("opportunities"))
            {
                opportunityPage.ValidateHeader();
                opportunityPage.ValidateColumns();
            }
            else if (tab.ToLower().Equals("contacts"))
            {
                contactsPage.ValidateHeader();
                contactsPage.ValidateColumns();
            }
            else
            {
                throw new NotFoundException(tab + " page not found!!");
            }
        }

    }
}
