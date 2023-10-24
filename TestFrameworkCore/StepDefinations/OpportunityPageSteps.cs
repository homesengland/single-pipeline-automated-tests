using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;

namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    public sealed class OpportunityPageSteps
    {

        private readonly ScenarioContext context;

        public OpportunityPageSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }


        [When(@"I validate the total number of records for opportunities are '(.*)'")]
        public void WhenIValidateTheTotalNumberOfRecordsForOpportunitiesAre(int records)
        {
            //opportunityPage.ValidateTotal(records);
        }

    }
}
