
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;

namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    public sealed class HomePage
    {

        private readonly ScenarioContext context;

        public HomePage(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }


       

    }
}
