
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;

namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    public sealed class ContactPageSteps
    {

        private readonly ScenarioContext context;

        public ContactPageSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }


        [When(@"I validate the total number of records for contacts are '(.*)'")]
        public void WhenIValidateTheTotalNumberOfRecordsForContactsAre(int records)
        {
            contactsPage.ValidateTotal(records);
        }

    }
}
