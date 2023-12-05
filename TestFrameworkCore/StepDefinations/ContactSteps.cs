using He.TestFramework.TestBase.Web;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TestFrameworkCore.Pages;
using TestFrameworkCore.TestAssembly;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    public class ContactSteps
    {
        private readonly ScenarioContext sContext;

        public ContactSteps(ScenarioContext injectedContext)
        {
           sContext = injectedContext;
        }
        public ContactSteps()
        {
        }

        [When(@"I click on the contacts link")]
        public void WhenIClickOnTheContactsLink()
        {

            homePage.GotoContacts();
        }

        [Then(@"I should land on the contacts page")]
        public void ThenIShouldLandOnTheContactsPage()
        {
            contactsPage.ValidateHeader();
        }

        [When(@"I click on the Add Contact link")]
        public void WhenIClickOnTheAddContactLink()
        {
            contactsPage.AddNewContact();
        }

        [Then(@"I should land on the New Contact form page")]
        public void ThenIShouldLandOnTheNewContactFormPage()
        {
            contactsFormPage.ValidateHeader();
        }

        [When(@"I fill the mandatory fields for contact and Save")]
        public void WhenIFillTheMandatoryFieldsForContactAndSave()
        {
            contactsFormPage.FillMandatoryContactFieldsAndSave();
        }

        [When(@"I fill the mandatory fields for contact")]
        public void WhenIFillTheMandatoryFieldsForContact()
        {
            contactsFormPage.FillMandatoryContactFields();
        }


        [Then(@"I should land on the All contacts page")]
        public void ThenIShouldLandOnTheAllContactsPage()
        {
            contactsPage.ValidateHeader();
        }

        [When(@"I filter contacts using the first name")]
        public void WhenIFilterContactsUsingTheFirstName()
        {
            contactsPage.Filter();
        }

        [Then(@"I should see the recently created contract")]
        public void ThenIShouldSeeTheRecentlyCreatedContract()
        {
            contactsPage.ValidateNewContact();
        }

        [Then(@"Validate that the First Name field is mandatory and error message is correct")]
        public void ThenValidateThatTheFirstNameFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            contactsFormPage.ValidateFirstNameField();
        }

        [Then(@"Validate that the Last Name field is mandatory and error message is correct")]
        public void ThenValidateThatTheLastNameFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            contactsFormPage.ValidateLastNameField();
        }

        [Then(@"Validate that the Job Title field is mandatory and error message is correct")]
        public void ThenValidateThatTheJobTitleFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            contactsFormPage.ValidateJobTitleField();
        }

        [Then(@"Validate that the Partner field is mandatory and error message is correct")]
        public void ThenValidateThatThePartnerFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            contactsFormPage.ValidatePartnerField();
        }

        [Then(@"Validate that the Email field is mandatory and error message is correct")]
        public void ThenValidateThatTheEmailFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            contactsFormPage.ValidateEmailField();
        }

    }
}
