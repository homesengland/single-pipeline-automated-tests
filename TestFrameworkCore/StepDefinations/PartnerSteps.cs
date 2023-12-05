using He.TestFramework.TestBase.Web;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TestFrameworkCore.Pages;
using TestFrameworkCore.TestAssembly;
using System;
using System.ComponentModel;

namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    internal class PartnerSteps
    { 
        [Given(@"I click on the Partners link")]
        [Then(@"I click on the Partners link")]
        public void GivenIClickOnThePartnersLink()
        {
            homePage.GotoPartners();
        }

        [Given(@"I enter a Partner Name (.*)")]
        public void GivenIEnterAPartnerName(string name)
        {
            partnerFormPage.enterPartnerName(name);
        }

        [Given(@"I select a Sector (.*)")]
        public void GivenISelectASector(string sector)
        {
            partnerFormPage.enterSector(sector);
        }

        [Given(@"I enter a Street (.*)")]
        public void GivenIEnterAStreet(string streetOne)
        {
            partnerFormPage.enterStreetOne(streetOne);
        }

        [Given(@"I enter a Postcode (.*)")]
        public void GivenIEnterAPostcode(string postcode)
        {
            partnerFormPage.enterPostcode(postcode);
        }

        [When(@"I click Save")]
        public void WhenIClickSave()
        {
            partnerFormPage.clickSaveButton();
        }

        [When(@"I click back")]
        public void WhenIClickBack()
        {
            partnerFormPage.clickBackButton();
        }

        [Given(@"I should land on the New Partner form page")]
        public void GivenIShouldLandOnTheNewPartnerFormPage()
        {
            partnerFormPage.ValidateHeader();
        }

        [Given(@"I should land on the Partners page")]
        [Then(@"I should land on the Partners page")]
        public void GivenIShouldLandOnThePartnersPage()
        {
            partnersPage.ValidateHeader();
        }

        [Given(@"I click on the Add Partner link")]
        public void GivenIClickOnTheAddPartnerLink()
        {
            partnersPage.AddNewPartner();
        }

        [Then(@"the Partner ID is populated")]
        public void ThenThePartnerIDIsPopulated()
        {
            partnerFormPage.getPartnerID();
        }

        [When(@"I search for the new Partner")]
        [Then(@"I search for the new Partner")]
        public void WhenISearchForTheNewPartner()
        {
            partnersPage.SearchForPartnerWithName();
        }

        [Then(@"I should see the newly created partner")]
        public void ThenIShouldSeeTheNewlyCreatedPartner()
        {
            partnersPage.VerifyPartnerVisible();
        }

        [When(@"I select the new partner")]
        public void WhenISelectTheNewPartner()
        {
            partnersPage.SelectPartnerRow();
        }

        [When(@"I click the delete button")]
        [Then(@"I click the delete button")]
        public void WhenIClickTheDeleteButton()
        {
            partnersPage.ClickDeleteButton();
        }

        [Then(@"the new partner should be deleted")]
        public void ThenTheNewPartnerShouldBeDeleted()
        {
            partnersPage.PartnerIsNotVisible();
        }

        [Given(@"I select a Partner Type")]
        public void GivenISelectAPartnerType()
        {
            partnerFormPage.enterPartnerType();
        }

        [Given(@"I select a Key Account")]
        public void GivenISelectAKeyAccount()
        {
            partnerFormPage.enterKeyAccount();
        }

        [Given(@"I select a Key Account Manager")]
        public void GivenISelectAKeyAccountManager()
        {
            partnerFormPage.enterKeyAccountManager();
        }

        [Given(@"I select a SME Indicator")]
        public void GivenISelectASMEIndicator()
        {
            partnerFormPage.enterSMEIndicator();
        }

        [Given(@"I enter a Companies House Number")]
        public void GivenIEnterACompaniesHouseNumber()
        {
            partnerFormPage.enterCompaniesHouseNumber();
        }

        [Given(@"I enter a Homes England Central Government Organisation Code")]
        public void GivenIEnterAHomesEnglandCentralGovernmentOrganisationCode()
        {
            partnerFormPage.enterHECGOrgCode();
        }

        [Given(@"I enter a Homes England Combined Authority Code")]
        public void GivenIEnterAHomesEnglandCombinedAuthorityCode()
        {
            partnerFormPage.enterHECACode();
        }

        [Given(@"I enter a Local Authority Code")]
        public void GivenIEnterALocalAuthorityCode()
        {
            partnerFormPage.enterLocalAuthCode();
        }

        [Given(@"I enter a Social Housing Provider Registration Number")]
        public void GivenIEnterASocialHousingProviderRegistrationNumber()
        {
            partnerFormPage.enterSocialHousingProviderRegNumber();
        }

        [Given(@"I select a Primary Operating Region")]
        public void GivenISelectAPrimaryOperatingRegion()
        {
            partnerFormPage.selectPrimaryOperatingRegion();
        }

        [Given(@"I enter a Parent Partner")]
        public void GivenIEnterAParentPartner()
        {
            partnerFormPage.enterParentPartner();
        }

        [Given(@"I enter a Ultimate Parent")]
        public void GivenIEnterAUltimateParent()
        {
            partnerFormPage.enterUltimateParent();
        }

        [Given(@"I enter an Email")]
        public void GivenIEnterAnEmail()
        {
            partnerFormPage.enterEmail();
        }

        [Given(@"I enter a Website")]
        public void GivenIEnterAWebsite()
        {
            partnerFormPage.enterWebsite();
        }

        [Given(@"I enter a Phone Number")]
        public void GivenIEnterAPhoneNumber()
        {
            partnerFormPage.enterPhone();
        }

        [Given(@"I enter a Address 1: Street 2")]
        public void GivenIEnterAAddressOneStreetTwo()
        {
            partnerFormPage.enterStreetTwo();
        }

        [Given(@"I enter a Address 1: Street 3")]
        public void GivenIEnterAAddressOneStreetThree()
        {
            partnerFormPage.enterStreetThree();
        }

        [Given(@"I enter a City")]
        public void GivenIEnterACity()
        {
            partnerFormPage.enterCity();
        }

        [Given(@"I enter a County")]
        public void GivenIEnterACounty()
        {
            partnerFormPage.enterCounty();
        }

        [Given(@"I enter a Country")]
        public void GivenIEnterACountry()
        {
            partnerFormPage.enterCountry();
        }

        [Given(@"I click on the Quick Add Partner button")]
        public void GivenIClickOnTheQuickAddPartnerButton()
        {
            partnersPage.ClickQuickCreatePartner();
            partnersQuickFormPage.ValidateHeader();
        }

        //consider moving steps below to a quick partners steps file, but might not be required
        [Given(@"I populate the Add Partner fields")]
        public void GivenIPopulateTheAddPartnerFields()
        {
            partnersQuickFormPage.CreateNewQuickPartner();
        }

        [When(@"I click Save and Close")]
        public void WhenIClickSaveAndClose()
        {
            partnersQuickFormPage.ClickQuickSaveAndClose();
        }

        [When(@"I click on View Record")]
        public void WhenIClickOnViewRecord()
        {
            partnersPage.ClickViewRecord();
        }

        [Given(@"I click Use Automatic Search")]
        public void GivenIClickUseAutomaticSearch()
        {
            partnersQuickFormPage.ClickUsePartnerSearch();
        }

        [Given(@"I search for the company (.*)")]
        public void GivenISearchForTheCompany(string company)
        {
            companiesHouseSearchPage.EnterCompanySearch(company);
            companiesHouseSearchPage.ClickSearchButton();
        }

        [When(@"I save the company")]
        public void WhenISaveTheCompany()
        {
            companiesHouseSearchPage.SaveFirstResult();
        }

        [Then(@"I should see a confirmation popup")]
        public void ThenIShouldSeeAConfirmationPopup()
        {
            companiesHouseSearchPage.ValidateConfirmMessage();
        }

        [Then(@"I close the Companies Search popup")]
        public void ThenICloseTheCompaniesSearchPopup()
        {
            companiesHouseSearchPage.CloseCompaniesSearch();
        }

        [Then(@"I should see the newly created partner by name")]
        public void ThenIShouldSeeTheNewlyCreatedPartnerByName()
        {
            partnersPage.VerifyPartnerVisibleByName();
        }

        [Given(@"I click on the Company House button")]
        public void GivenIClickOnTheCompanyHouseButton()
        {
            partnersPage.OpenCompanyHouseSearch();
        }

        [Given(@"I enter the mandatory partner details")]
        public void GivenIEnterTheMandatoryPartnerDetails()
        {
            //this has to become modular
            partnerFormPage.enterPartnerName("Deactivate Me");
            partnerFormPage.enterSector("Financial");
            partnerFormPage.enterPartnerType();
            partnerFormPage.enterStreetOne("9 Manor Road");          
            partnerFormPage.enterPostcode("CV1 2LF");
        }

        [When(@"I click the Deactivate button")]
        public void WhenIClickTheDeactivateButton()
        {
            partnerFormPage.ClickDeactivate();
        }

        [Then(@"the partner should be inactive and readonly")]
        public void ThenThePartnerShouldBeInactiveAndReadonly()
        {
            partnerFormPage.ConfirmPartnerDeactivated();
        }

        [When(@"I click the Activate button")]
        public void WhenIClickTheActivateButton()
        {
            partnerFormPage.ClickActivate();
        }

        [Then(@"the parter should be active and editable")]
        public void ThenTheParterShouldBeActiveAndEditable()
        {
            partnerFormPage.ConfirmPartnerActive();
        }
        [Then(@"I validate all mandatory fields and error message is correct")]
        public void ThenIValidateAllMandatoryFieldsAndErrorMessageIsCorrect()
        {
            partnerFormPage.ValidateMandatoryFields();
        }

    }
}
