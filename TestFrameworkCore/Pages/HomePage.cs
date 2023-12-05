using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using He.TestFramework.TestBase.Web;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;

namespace TestFrameworkCore.Pages
{
    public class HomePage : BasePage
    {
        new IWebDriver driver;
        //String ExpectedHeader = "All Contacts";

        private IWebElement NewProjectButton => driver.FindElement(By.CssSelector("button[aria-label='Add Partner. New']"));
        private IWebElement PartnersLink=> driver.FindElement(By.CssSelector("li[title='Partners']"));
        private IWebElement ContactsLink => driver.FindElement(By.CssSelector("li[title='Contacts']"));
        private IWebElement InteractionsLink => driver.FindElement(By.CssSelector("li[title='Interactions']"));
        private IWebElement PipelinesLink => driver.FindElement(By.CssSelector("li[title='Pipelines']"));
        private IWebElement HomeLink => driver.FindElement(By.CssSelector("li[title='Go to home page']"));
        private IWebElement BackButton => driver.FindElement(By.CssSelector("button[title='Go back']"));
        private IWebElement PlusButton => driver.FindElement(By.CssSelector("button[aria-label='Create New Record. New']"));
        private IWebElement NewPartnerLink => driver.FindElement(By.CssSelector("button[aria-label='Partner']"));
        private IWebElement AutomaticSearch => driver.FindElement(By.CssSelector("input[aria-label='Use Automatic Search?']"));
        private IWebElement SearchField => driver.FindElement(By.CssSelector("input[appmagic-control='CompanyNametextbox']"));
        public IWebElement Header => driver.FindElement(By.CssSelector("h1 > div[aria-label='Chief Executive Forward Looking Report']"));
        public By HeaderBy => By.CssSelector("h1 > div[aria-label='Chief Executive Forward Looking Report']");

        private readonly ScenarioContext sContext;
        public HomePage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        [ThreadStatic]
        public static string FullName;
        [ThreadStatic]
        public static string Email;
       // IWebElement[] RecordsList;

        public void ValidateTitle(string title="")
        {
            //WaitforFewSeconds(3);
            WaitUntilElementVisible(HeaderBy);
            Assert.AreEqual("Chief Executive Forward Looking Report", Header.Text);
        }

        public void CreateNewProject() 
        {
            ClickOnElement(PartnersLink);
            WaitForPageToLoad();
            ClickOnElement(NewProjectButton);
            WaitForPageToLoad();
            ClickOnElement(BackButton);
            //ClickOnElement(DiscardChangesButton);

        }

        internal void GotoPartners()
        {
            WaitForPageToLoad();
            ClickOnElement(PartnersLink);
            partnersPage = new PartnersPage(driver, sContext);
        }

        internal void GotoContacts()
        {
            WaitForPageToLoad();
            ClickOnElement(ContactsLink);
            contactsPage = new ContactsPage(driver, sContext);
        }

        internal void GotoInteractions()
        {
            WaitForPageToLoad();
            ClickOnElement(InteractionsLink);
            interactionsPage = new InteractionsPage(driver, sContext);
        }

        internal void testField()
        {
            ClickOnElement(PlusButton);
            ClickOnElement(NewPartnerLink);
            ClickOnElement(AutomaticSearch);
            WaitforFewSeconds(2);
            driver.SwitchTo().Frame("fullscreen-app-host");
            EnterText(SearchField, "Test");

        }
    }
}
