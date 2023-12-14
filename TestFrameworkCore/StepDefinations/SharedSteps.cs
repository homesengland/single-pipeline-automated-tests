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

        [When(@"I restart the browser and navigate to the url")]
        public void WhenIRestartTheBrowserAndNavigateToTheUrl()
        {
            StaticObjectRepo.Driver.Close();

            basePage.GoToURL();
            PageObjectRepo.loginPage = new LoginPage(StaticObjectRepo.Driver, sContext);
        }


        [Then(@"the login page should be displayed")]
        public void ThenTheLoginPageShouldBeDisplayed()
        {
            loginPage.ValidateHeader();
        }


        [When(@"I login as '([^']*)' user to the application")]
        public void WhenILoginAsuserToTheApplication(string role)
        {
            loginPage.Login(role);
            Console.WriteLine("Login method completed");
        }

        [When(@"I log out of the application")]
        public void WhenILogOutOfTheApplication()
        {
            homePage.logout();
            loginPage.UseAnotherAcc();
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
