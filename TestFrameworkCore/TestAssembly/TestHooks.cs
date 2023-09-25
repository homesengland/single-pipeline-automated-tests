using System;
using TechTalk.SpecFlow;
using He.TestFramework.TestBase.Web;
using AventStack.ExtentReports.Gherkin.Model;

namespace TestFrameworkCore.TestAssembly
{
    //-------------------------------------------------------------------------------------//
    //                  Hooks class specify the methods to run after milestones            //
    //-------------------------------------------------------------------------------------//
    [Binding]
    public sealed class TestHooks : TestInitialise
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        //public static ScenarioContext SContext;
        public ScenarioContext sContext;
        public FeatureContext fContext;
        public TestHooks(ScenarioContext _scenarioContext, FeatureContext fContext) : base(_scenarioContext)
        {
            sContext = _scenarioContext;
        }

        [BeforeTestRun]
        public static void InitaliseReport()
        {
            InitialiseReport();
        }


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext fContext)
        {
            ExtractFeatureName();
            Console.WriteLine("\n Getting Feature details.................");
            StaticObjectRepo.Feature = StaticObjectRepo.Reporter.CreateTest<Feature>(fContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                InitialiseTest();
                ExtractScenarioName();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured during Test Initialisation!! \n\n {0}", e);
                CloseBrowser();
            }

        }


        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            GetStepDetials(scenarioContext);
        }



        [AfterScenario]
        public void AfterScenario()
        {
            //Helper.GetCookies();
            CloseBrowser();
        }


        [AfterTestRun]
        public static void CompleteReport()
        {
            WriteToReport();
        }

    }
}
