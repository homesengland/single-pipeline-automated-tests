using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System.Configuration;
using System;
using TestFrameworkWeb.TestAssembly;
using Bogus.DataSets;
using System.Linq;
using static Azure.Core.HttpHeader;
using OpenQA.Selenium.Interactions;

namespace TestFrameworkCore.Pages
{
    public class InteractionsFormPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;


        private IWebElement Header => driver.FindElement(By.CssSelector("h1"));
        private IWebElement InteractionTitle => driver.FindElement(By.CssSelector("input[aria-label='Title of Interaction']"));
        private IWebElement InteractionType => driver.FindElement(By.CssSelector("select[aria-label='Interaction Type']"));
        private IWebElement JobTitle => driver.FindElement(By.CssSelector("input[aria-label='Job Title']"));
        private IWebElement PartnerSelected => driver.FindElement(By.CssSelector("ul[title='Partner'] > li > div > div"));
        private IWebElement PartnerField => driver.FindElement(By.CssSelector("input[aria-label='Partner, Lookup']"));
        private IWebElement[] PartnerSearchList => driver.FindElements(By.CssSelector("ul[aria-label='Lookup results'] > li")).ToArray();
        private IWebElement NotesField => driver.FindElement(By.CssSelector("textarea[aria-label='Notes']"));
        private IWebElement SensetiveCheckbox => driver.FindElement(By.CssSelector("input[aria-label='Sensitive']"));
        private IWebElement RelatedToOpportunity => driver.FindElement(By.CssSelector("select[aria-label='Does this interaction relate to any Pipeline Opportunity']"));
        private IWebElement SaveClose => driver.FindElement(By.CssSelector("button[aria-label='Save & Close']"));
        private IWebElement ContactField => driver.FindElement(By.CssSelector("input[aria-label='Contact, Lookup']"));
        private IWebElement ContactValue => driver.FindElement(By.CssSelector("ul[title='Contact']"));
        private IWebElement[] ContactList => driver.FindElements(By.CssSelector("ul[aria-label='Lookup recently used results'] > li")).ToArray();
        private IWebElement ContactSelected => driver.FindElement(By.CssSelector("ul[title='Contact'] > li > div"));

        private IWebElement ContinueButton => driver.FindElement(By.CssSelector("button[type='submit']"));
        private IWebElement TitleErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='he_name-error-message']"));
        private IWebElement DeleteAddedPartner => driver.FindElement(By.CssSelector("button[aria-label^='Delete']"));
        private IWebElement InterationTypeErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='he_interationtype-error-message']"));
        private IWebElement PartnerErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='he_partner-error-message']"));
        private IWebElement NotesErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='he_notes-error-message']"));
        private IWebElement RelatedToErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='he_doesinteractionrelatetoanypipeline-error-message']"));
        private IWebElement ContactErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='he_contact-error-message']"));
        private IWebElement DeleteAddedContact => driver.FindElement(By.CssSelector("button[aria-label^='Delete']"));

        public InteractionsFormPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            Assert.AreEqual("New Interaction", Header.Text, "Login page not displayed!");

        }


        internal void createInteractionAndSave(bool forPartner)
        {
            FillMandatoryFields(forPartner);
            ClickOnElement(SaveClose);

        }

        internal void createInteraction(bool forPartner)
        {
            FillMandatoryFields(forPartner);

        }

        //private void FillAddress()
        //{
        //    var rand = new Bogus.Faker();
        //    EnterText(Street1, rand.Address.BuildingNumber());
        //    EnterText(Street2, rand.Address.StreetName());
        //    EnterText(City, rand.Address.City());
        //    EnterText(Postcode, Helpers.GetRandomPostcode());
        //}

        internal void FillMandatoryFields(bool forPartner)
        {
            var rand = new Bogus.Faker();
            Lorem lorem = new Lorem();
            string value = "";

            value = rand.Random.Words(3);
            EnterText(InteractionTitle, value);
            sContext.Add("InteractionTitle", value);

            SelectListOption(InteractionType, rand.Random.Number(1,8));
            sContext.Add("InteractionType", InteractionType.GetAttribute("title"));

            if (!forPartner)
            {
                EnterText(PartnerField, "Test Partner");
                //WaitforFewSeconds(1);
                ClickElement(PartnerSearchList[0]);
                sContext.Add("Partner", "Test Partner");
            }
            else
                sContext.Add("Partner", PartnerSelected.Text); 

            EnterText(NotesField, rand.Random.Words(25));

            SelectListOption(RelatedToOpportunity, "Not Related to any opportunity");
            sContext.Add("RelatedOpportunity", "Not Related to any opportunity");

            ClickOnElement(ContactField);
            //WaitforFewSeconds(2);
            ClickElement(ContactList[0]);
            sContext.Add("Contact", ContactValue.Text);

        }

        internal void createSensetiveInteraction()
        {
            ClickOnElement(SensetiveCheckbox);
            FillMandatoryFields(false);
            //FillAddress();
            ClickOnElement(SaveClose);
        }

        internal void ValidateInteractionTitleField()
        {
            EnterText(InteractionTitle, "");
            ClickOnElement(SaveClose);
            Assert.AreEqual("Title of Interaction: Required fields must be filled in.", TitleErrorMessage.Text, "Title of Interaction error message is not displayed!");
        }

        internal void ValidateInteractionTypeField()
        { 
            ClickOnElement(SaveClose);
            Assert.AreEqual("Interaction Type: Required fields must be filled in.", InterationTypeErrorMessage.Text, "Interaction Type error message is not displayed!");
        }

        internal void ValidatePartnerAssociatedField()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(PartnerSelected).Perform();
            ClickOnElement(DeleteAddedPartner);
            ClickOnElement(SaveClose);
            Assert.AreEqual("Partner: Required fields must be filled in.", PartnerErrorMessage.Text, "Partner error message is not displayed!");
        }

        internal void ValidateNotesField()
        {
            EnterText(NotesField, "");
            ClickOnElement(SaveClose);
            Assert.AreEqual("Notes: Required fields must be filled in.", NotesErrorMessage.Text, "Notes error message is not displayed!");
        }

        internal void ValidatRelatedToField()
        {
            ClickOnElement(SaveClose);
            Assert.AreEqual("Does this interaction relate to any Pipeline Opportunity: Required fields must be filled in.", RelatedToErrorMessage.Text, "Related to Pipeline Opportunity error message is not displayed!");
        }

        internal void ValidateContactField()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ContactSelected).Perform();
            ClickOnElement(DeleteAddedContact);
            ClickOnElement(SaveClose);
            Assert.AreEqual("Contact: Required fields must be filled in.", ContactErrorMessage.Text, "Contact error message is not displayed!");

        }
    }
}
