using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestFrameworkAPI.ActionMethods.POST;
using TestFrameworkAPI.SetupMethods;
using TestFrameworkAPI.Repo;

namespace TestFrameworkAPI.StepDefinations
{
    [Binding]
    public sealed class SearchProjectSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public SearchProjectSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [When(@"I search for the project using text '(.*)' and '(.*)'")]
        public void WhenISearchForTheProjectUsingText(string SearchText, string UserType)
        {
            CommonMethods.CreateRequest("POST", StaticObjectRepo.BaseURL, StaticObjectRepo.Endpoint);
            CommonMethods.AddHeaders(UserType);
            //CommonMethods.AddParameters("PartnerDetails");
            //PostRequest.CreateSearch(SearchText);
        }


        [Then(@"then I validate that the response is as expected for '(.*)'")]
        public void ThenThenIValidateThatTheResponseIsAsExpectedfor(string APIType)
        {
            //CommonMethods.ValidateResponse(APIType);
        }

    }
}
