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
    public class InteractionSteps
    {
        private readonly ScenarioContext sContext;

        public InteractionSteps(ScenarioContext injectedContext)
        {
           sContext = injectedContext;
        }
        public InteractionSteps()
        {
        }


        [When(@"I click on the interactions link")]
        public void WhenIClickOnTheInteractionsLink()
        {
            homePage.GotoInteractions();
        }

        [Then(@"I should land on the interactions page")]
        public void ThenIShouldLandOnTheInteractionsPage()
        {
            interactionsPage.ValidateHeader();
        }

        [When(@"I click on the Add Interaction link")]
        public void WhenIClickOnTheAddInteractionLink()
        {
            interactionsPage.AddNewInteraction();
        }

        [Then(@"I should land on the New Interaction form page")]
        public void ThenIShouldLandOnTheNewInteractionFormPage()
        {
            interactionsFormPage.ValidateHeader();
        }

        [When(@"I fill the mandatory fields and save to create interaction")]
        public void WhenIFillTheMandatoryFieldsAndSaveToCreateInteraction()
        {
            interactionsFormPage.createInteractionAndSave(true);
        }

        [When(@"I fill the mandatory fields for interaction and Save")]
        public void WhenIFillTheMandatoryFieldsForInteractionAndSave()
        {
            interactionsFormPage.createInteractionAndSave(false);
        }

        [When(@"I fill the mandatory fields for interaction")]
        public void WhenIFillTheMandatoryFieldsForInteraction()
        {
            interactionsFormPage.createInteraction(false);
        }


        [When(@"I fill the mandatory fields for interaction and mark as sensetive and Save")]
        public void WhenIFillTheMandatoryFieldsForInteractionAndMarkAsSensetiveAndSave()
        {
            interactionsFormPage.createSensetiveInteraction();
        }


        [When(@"I filter interactions using the title of interaction")]
        public void WhenIFilterInteractionsUsingInteractionTitle()
        {
            interactionsPage.Filter();
        }

        [When(@"I filter interactions using the title of interaction on association view")]
        public void WhenIFilterInteractionsUsingTheTitleOfInteractionOnAssociationView()
        {
            partnersDetailsPage.FilterInteractions();
        }


        [Then(@"I should see the recently created interaction in associated view")]
        public void ThenIShouldSeeTheRecentlyCreatedInteractionInAssociatedView()
        {
            partnersDetailsPage.ValidateNewinteraction();
        }


        [Then(@"I should see the recently created interaction")]
        public void ThenIShouldSeeTheRecentlyCreatedInteraction()
        {
            interactionsPage.ValidateNewinteraction(true);
        }

        [Then(@"I should not see the recently created interaction")]
        public void ThenIShouldNotSeeTheRecentlyCreatedInteraction()
        {
            interactionsPage.ValidateNewinteraction(false);
        }


        [When(@"I navigate to the managed interactions page")]
        public void WhenINavigateToTheManagedInteractionsPage()
        {
            partnersDetailsPage.GotoRelatedInteractions();
        }


        [When(@"I click on the Add Interaction link in Managed interactions")]
        public void WhenIClickOnTheAddInteractionLinkInManagedInteractions()
        {
            partnersDetailsPage.GotoNewInteractionSection();
        }

        [Then(@"the Quick create interaction section should be displayed")]
        public void ThenTheQuickCreateInteractionSectionShouldBeDisplayed()
        {
            partnersDetailsPage.ValidateNewInteraction();
        }

        //[When(@"I fill the mandatory fields for interaction and Save and Close")]
        //public void WhenIFillTheMandatoryFieldsForInteractionAndSaveAndClose()
        //{
        //    throw new PendingStepException();
        //}


        //[Then(@"I should see the interaction under the interaction associated view")]
        //public void ThenIShouldSeeTheInteractionUnderTheInteractionAssociatedView()
        //{
        //    throw new PendingStepException();
        //}

        [When(@"I test")]
        public void WhenITest()
        {
            homePage.testField();
        }


        [Then(@"Validate that the Interaction Title field is mandatory and error message is correct")]
        public void ThenValidateThatTheInteractionTitleFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            interactionsFormPage.ValidateInteractionTitleField();
        }


        [Then(@"Validate that the Interaction Type field is mandatory and error message is correct")]
        public void ThenValidateThatTheInteractionTypeFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            interactionsFormPage.ValidateInteractionTypeField();
        }

        [Then(@"Validate that the Partner associated field is mandatory and error message is correct")]
        public void ThenValidateThatThePartnerAssociatedFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            interactionsFormPage.ValidatePartnerAssociatedField();
        }

        [Then(@"Validate that the Notes field is mandatory and error message is correct")]
        public void ThenValidateThatTheNotesFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            interactionsFormPage.ValidateNotesField();
        }

        [Then(@"Validate that the RelateTo field is mandatory and error message is correct")]
        public void ThenValidateThatTheRelateToFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            interactionsFormPage.ValidatRelatedToField();
        }

        [Then(@"Validate that the Contact field is mandatory and error message is correct")]
        public void ThenValidateThatTheContactFieldIsMandatoryAndErrorMessageIsCorrect()
        {
            interactionsFormPage.ValidateContactField();
        }


    }
}
