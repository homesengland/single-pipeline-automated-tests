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
    public class PartnersSteps
    {
        private readonly ScenarioContext sContext;

        public PartnersSteps(ScenarioContext injectedContext)
        {
           sContext = injectedContext;
        }
        public PartnersSteps()
        {
        }


        [When(@"I click on the partners link")]
        public void WhenIClickOnThePartnersLink()
        {
            homePage.GotoPartners();
        }

        [Then(@"I should land on the partners page")]
        public void ThenIShouldLandOnThePartnersPage()
        {
            partnersPage.ValidateHeader();  
        }

        [When(@"I click on the partner name link for '([^']*)'")]
        public void WhenIClickOnThePartnerNameLinkFor(string partner)
        {
            partnersPage.SelectPartner(partner);
        }

        [Then(@"I should land on the partner details page")]
        public void ThenIShouldLandOnThePartnerDetailsPage()
        {
            partnersDetailsPage.ValidateHeader();
        }

        [When(@"I navigate to the managed contacts page")]
        public void WhenINavigateToTheManagedContactsPage()
        {
            partnersDetailsPage.GotoManagedContacts();
        }

        [When(@"When I click on the Add existing contact button")]
        public void WhenWhenIClickOnTheAddExistingContactButton()
        {
            partnersDetailsPage.GotoExistingContactSection();
        }

        [Then(@"the contact associated view should be dispalyed")]
        public void ThenTheContactAssociatedViewShouldBeDispalyed()
        {
            partnersDetailsPage.ValidateExistingContactSection();
        }

        [When(@"I add existing contact to partner")]
        public void WhenIAddExistingContactToPartner()
        {
            partnersDetailsPage.AddExistingContact();
        }


        [Then(@"I should see the contact under the contact associated view")]
        public void ThenIShouldSeeThecontactUnderTheContactAssociatedView()
        {
            partnersDetailsPage.ValidateAddedContact();
        }

        [When(@"I click on the Add Contact link in Managed contacts")]
        public void WhenIClickOnTheAddContactLinkInManagedContacts()
        {
            partnersDetailsPage.GotoNewContactSection();
        }

        [Then(@"the Quick create contact section should be displayed")]
        public void ThenTheQuickCreateContactSectionShouldBeDisplayed()
        {
            partnersDetailsPage.ValidateNewContactSection();
        }

        [When(@"I fill the mandatory fields for contact and Save and Close")]
        public void WhenIFillTheMandatoryFieldsForContactAndSaveAndClose()
        {
            partnersDetailsPage.AddNewContact();
        }


    }
}
