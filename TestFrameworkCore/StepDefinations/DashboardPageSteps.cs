
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;


namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    public sealed class DashboardPageSteps
    {

        [Then(@"I should land on the page '(.*)'")]
        public void ThenIShouldLandOnThePage(string title)
        {
            //dashboardPage.ClickContinue();
            dashboardPage.WaitForPageToLoad();
            dashboardPage.ValidateHeader();
        }

        [Then(@"the Header Icon is valid")]
        public void ThenTheHeaderIconIsValid()
        {
            //ScenarioContext.Current.Pending();
        }

        //[Then(@"I validate that '(.*)' tab is present in the LHS menu")]
        //public void AndIValidateThatTabIsPresentInTheLHSMenu(string tab)
        //{
        //   dashboardPage.ValidateLHSTab(tab);
        //}

        //[When(@"i click on the tab '(.*)'")]
        //public void WhenIClickOnTheTab(string tab)
        //{ 
        //    dashboardPage.ClickOnElementLHSTab(tab);
        //}

        //[When(@"I navigate to Opportunities dashbord view")]
        //public void WhenINavigateToOpportunitiesDashbordView()
        //{
        //    dashboardPage.ChooseView("Opportunities Dashboard");
        //}

        //[Then(@"I should land on the opportunities dashboard page")]
        //public void ThenIShouldLandOnTheOpportunitiesDashboardPage()
        //{
        //    dashboardPage.Validatetitle("Opportunities Dashboard");
        //    dashboardPage.ValidateHeader("Opportunities Dashboard");
        //}

        //[Then(@"Then I validate that the Partner opportunities section is displayed")]
        //public void ThenThenIValidateThatThePartnerOpportunitiesSectionIsDisplayed()
        //{
        //    dashboardPage.validatePartnerOppSection();
        //}

        //[When(@"I navigate to Place Opportunities dashbord view")]
        //public void WhenINavigateToPlaceOpportunitiesDashbordView()
        //{
        //    dashboardPage.ChooseView("Place Opportunities Dashboard"); 
        //}

        //[Then(@"I should land on the Place opportunities dashboard page")]
        //public void ThenIShouldLandOnThePlaceOpportunitiesDashboardPage()
        //{
        //    dashboardPage.Validatetitle("Place Opportunities Dashboard");
        //    dashboardPage.ValidateHeader("Place Opportunities Dashboard");
        //}

        //[Then(@"Then I validate that the place opportunities section is displayed")]
        //public void ThenThenIValidateThatThePlaceOpportunitiesSectionIsDisplayed()
        //{
        //    dashboardPage.validatePlaceOppSection();
        //}

        //[Then(@"Then I validate that the leads section is displayed")]
        //public void ThenThenIValidateThatTheLeadsSectionIsDisplayed()
        //{
        //    dashboardPage.validateLeadsSection();
        //}

        //[Then(@"Then I validate that the all opportunities section is displayed")]
        //public void ThenThenIValidateThatTheAllOpportunitiesSectionIsDisplayed()
        //{
        //    dashboardPage.validateAllOppSection();
        //}

        //[Then(@"Then I validate that the Opportunity by Timescale-Modelled section is displayed")]
        //public void ThenThenIValidateThatTheOpportunityByTimescale_ModelledSectionIsDisplayed()
        //{
        //    dashboardPage.validateChartSection("OpportunityByTimescale");
        //}

        //[Then(@"Then I validate that the Opportunity by Thematic Area section is displayed")]
        //public void ThenThenIValidateThatTheOpportunityByThematicAreaSectionIsDisplayed()
        //{
        //    dashboardPage.validateChartSection("OpportunityByThematicArea");
        //}

        //[Then(@"Then I validate that the Opportunity by pipeline section is displayed")]
        //public void ThenThenIValidateThatTheOpportunityByPipelineSectionIsDisplayed()
        //{
        //    dashboardPage.validateChartSection("OpportunityByPipeline");
        //}

        //[Then(@"Then I validate that the total homes section is displayed")]
        //public void ThenThenIValidateThatTheTotalHomesSectionIsDisplayed()
        //{
        //    dashboardPage.validateChartSection("TotalHomes");
        //}

    }
}
