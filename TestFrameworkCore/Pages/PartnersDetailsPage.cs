using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System.Configuration;
using System;
using TestFrameworkWeb.TestAssembly;
using System.Linq;

namespace TestFrameworkCore.Pages
{
    public class PartnersDetailsPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;


        private IWebElement Header => driver.FindElement(By.CssSelector("h1"));
        private IWebElement RelatedLink => driver.FindElement(By.CssSelector("li[aria-label='Related']"));
        private IWebElement ManagedContactsLink => driver.FindElement(By.CssSelector("div[aria-label='Managed Contacts Related - Common']"));
        private IWebElement ManagedInteractionsLink => driver.FindElement(By.CssSelector("div[aria-label='Interactions Related - Common']"));
        private IWebElement AddExistingContactLink => driver.FindElement(By.CssSelector("button[aria-label='Add Existing Contact']"));
        private IWebElement NewContactLink => driver.FindElement(By.CssSelector("button[aria-label='New Contact. Add New Contact']"));
        private IWebElement NewInteractionLink => driver.FindElement(By.CssSelector("button[aria-label='Add Interaction. Add New Interaction']"));
        private IWebElement RecordsLookUpField => driver.FindElement(By.CssSelector("input[aria-label^='Select record']"));
        private IWebElement AddButton => driver.FindElement(By.CssSelector("button[aria-label='Add']"));
        private IWebElement NewSectionTitle => driver.FindElement(By.CssSelector("h1[data-id='quickHeaderTitle']"));
        private IWebElement ExistingSectionTitle => driver.FindElement(By.CssSelector("h1[data-id='lookupDialogTitle']"));
        private IWebElement FirstNameField => driver.FindElement(By.CssSelector("input[aria-label='First Name']"));
        private IWebElement LastNameField => driver.FindElement(By.CssSelector("input[aria-label='Last Name']"));
        private IWebElement JobTitleField => driver.FindElement(By.CssSelector("input[aria-label='Job Title']"));
        private IWebElement InteractionFilterField => driver.FindElement(By.CssSelector("input[aria-label='Interaction Filter by keyword']"));

        private IWebElement Emailfield => driver.FindElement(By.CssSelector("section[data-id='quickCreateRoot'] input[aria-label='Email']"));
        private IWebElement SaveCloseButton => driver.FindElement(By.CssSelector("button[aria-label='Save and Close']"));

        private IWebElement[] AssociatedInteractions => driver.FindElements(By.CssSelector("div[data-id='editFormRoot'] > div > div> div:nth-child(2) > div:nth-child(2) a")).ToArray();
        private IWebElement[] FilteredRecords => driver.FindElements(By.CssSelector("ul[aria-label='Lookup results'] > li")).ToArray();
        private IWebElement[] FullNameList => driver.FindElements(By.CssSelector("div[col-id='fullname']")).ToArray();

        private IWebElement ContactSearchField => driver.FindElement(By.CssSelector("input[aria-label='Contact Filter by keyword']"));
        private IWebElement ContinueButton => driver.FindElement(By.CssSelector("button[type='submit']"));


        public PartnersDetailsPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            WaitforFewSeconds(3);
            Assert.IsTrue(Header.Text.Contains(sContext.Get<string>("PartnerName")), "Partners page not displayed!");

        }


        internal void GotoManagedContacts()
        {
            WaitForPageToLoad();
            ClickOnElement(RelatedLink);
            ClickOnElement(ManagedContactsLink);
        }


        internal void AddExistingContact()
        {
            var rand = new Bogus.Faker();
            
           
            EnterText(RecordsLookUpField, "Arturo");
            int rn = rand.Random.Number(0, FilteredRecords.Length - 1);
            sContext.Add("ContactName", FilteredRecords[rn].FindElement(By.CssSelector("div:nth-child(2) > span")).Text);
            ClickOnElement(FilteredRecords[rn]);
            
            
            ClickOnElement(AddButton);
            WaitforFewSeconds(4);
        }

        internal void AddNewContact()
        {
            var rand = new Bogus.Faker();
            string fname = rand.Person.FirstName;
            string lname = rand.Person.LastName;

            EnterText(FirstNameField, fname);
            EnterText(LastNameField, lname);
            EnterText(JobTitleField, rand.Random.Word());
            EnterText(Emailfield, rand.Person.Email);
            
            sContext.Add("ContactName", fname + " " + lname);
            ClickOnElement(SaveCloseButton);


           // ClickOnElement(AddButton);
            WaitforFewSeconds(4);
        }


        internal void ValidateAddedContact()
        {
            WaitForPageToLoad();
            EnterText(ContactSearchField, sContext.Get<string>("ContactName") + Keys.Enter);
            bool flag = false;
            WaitforFewSeconds(2);     
            foreach (var record in FullNameList)
                if (record.Text.Equals(sContext.Get<string>("ContactName")))
                {
                    flag = true;
                    break;
                }
            Assert.IsTrue(flag, "Contact not associated to partner");
        }

        internal void GotoExistingContactSection()
        {
            ClickOnElement(AddExistingContactLink);
            WaitForPageToLoad();
        }

        internal void ValidateExistingContactSection()
        {
            WaitForPageToLoad();
            WaitforFewSeconds(3);
            Assert.AreEqual(ExistingSectionTitle.Text, "Lookup Records", "Existing contact lookup section displayed!");
        }

        internal void GotoNewContactSection()
        {
            ClickOnElement(NewContactLink);
            WaitForPageToLoad();
        }

        internal void ValidateNewContactSection()
        {
            WaitForPageToLoad();
            WaitforFewSeconds(3);
            Assert.AreEqual(NewSectionTitle.Text, "Quick Create: Contact", "New contact lookup section displayed!");
        }

        internal void GotoRelatedInteractions()
        {
            WaitForPageToLoad();
            ClickOnElement(RelatedLink);
            ClickOnElement(ManagedInteractionsLink);
        }

        internal void GotoNewInteractionSection()
        {
            ClickOnElement(NewInteractionLink);
            interactionsFormPage = new InteractionsFormPage(driver, sContext);  
            WaitForPageToLoad();
        }

        internal void ValidateNewInteraction()
        {
            WaitForPageToLoad();
            WaitforFewSeconds(3);
            Assert.AreEqual(ExistingSectionTitle.Text, "Lookup Records", "Existing contact lookup section displayed!");
        }

        internal void FilterInteractions()
        {
            EnterText(InteractionFilterField, sContext.Get<string>("InteractionTitle") + Keys.Enter);
            WaitforFewSeconds(2);
        }

        internal void ValidateNewinteraction()
        {
            WaitForPageToLoad();
            Assert.AreEqual(sContext.Get<string>("InteractionTitle"), AssociatedInteractions[0].Text, "Interaction Title does not match!");
        }
    }
    
}
