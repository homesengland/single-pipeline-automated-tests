using He.TestFramework.TestBase.Web;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TestFrameworkCore.Pages;
using TestFrameworkCore.TestAssembly;
using System;
using TestFrameworkWeb.TestAssembly;

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
            PageObjectRepo.loginPage = new LoginPage(StaticObjectRepo.Driver, sContext);
        }

        [Then(@"the login page should be displayed")]
        public void ThenTheLoginPageShouldBeDisplayed()
        {
            loginPage.ValidateHeader();
        }


        [When(@"I login as '([^']*)' to the application")]
        public void WhenILoginAsToTheApplication(string role)
        {
            loginPage.Login(role);
            Console.WriteLine("Login method completed");
        }


        [Then(@"I should land on the AppLanding page")]
        public void ThenIShouldLandOnTheAppLandingPage()
        {
            appLandingPage.ValidateHeader();
        }

 

        [When(@"I click on the CRM project")]
        public void WhenIClickOnTheCRMProject()
        {
            appLandingPage.GotoManagerPartnerInteractions();
        }


        [Then(@"I should land on the Home page")]
        public void ThenIShouldLandOnTheHomePage()
        {
            homePage.ValidateTitle();
           // homePage.CreateNewProject();
        }
    }
}
