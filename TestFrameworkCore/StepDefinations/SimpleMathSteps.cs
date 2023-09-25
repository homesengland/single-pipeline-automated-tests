using System;
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TestFrameworkCore.Pages;
using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using Selenium.Axe;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace TestFrameworkCore.StepDefinations
{
    [Binding]
    public class SimpleMathSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext sContext;

        public SimpleMathSteps(ScenarioContext scenarioContext)
        {
            sContext = scenarioContext;
        }


        [Given(@"I have a new calculator")]
        public void GivenIHaveANewCalculator()
        {
            superCalculatorPage = new SuperCalculatorPage(StaticObjectRepo.Driver, sContext);
        }
        

        [When(@"I add (.*) and (.*) for (.*)")]
        public void WhenIAddAnd(string first, string second, bool IsAngular)
        {
            Thread.Sleep(7000);
            superCalculatorPage.Add(first, second, IsAngular);
        }


        [When(@"I divide (.*) by (.*) for (.*)")]
        public void WhenIDivideBy(string first, string second, bool IsAngular)
        {     
            superCalculatorPage.Divide(first, second, IsAngular);
        }


        [Then(@"the latest result should be (.*) for (.*)")]
        public void ThenTheLatestResultShouldBe(string expectedResult, bool IsAngular)
        {
            if(IsAngular)
                Assert.AreEqual(expectedResult, superCalculatorPage.LatestResultNg, "Latest results does not match exp");
            else
                Assert.AreEqual(expectedResult, superCalculatorPage.LatestResult, "Latest results does not match exp");
        }


        [When(@"I check accessability of page")]
        public void WhenICheckAccessabilityOfPage()
        {
            axe = new Accessibility(StaticObjectRepo.Driver, sContext);
            AxeResult axeResult =  axe.TestAccessibilityOfPage();
            sContext.Add("TestAccessibilityResult", axeResult);
        }


        [Then(@"there should be no issues found")]
        public void ThenThereShouldBeNoIssuesFound()
        {
            AxeResult axeRes = sContext.Get<AxeResult>("TestAccessibilityResult");
            Assert.IsEmpty(axeRes.Violations, "\n There are violation as below: \n" + axe.GetViolationsDesc(axeRes.Violations));
        }


        [When(@"I check accessability of element")]
        public void WhenICheckAccessabilityOfElement()
        {
            IWebElement first = StaticObjectRepo.Driver.FindElement(By.CssSelector("input[ng-model='first']"));
            axe = new Accessibility(StaticObjectRepo.Driver, sContext);
            AxeResult axeResult = axe.TestAccessibilityOfIndividualElements(first);
            sContext.Add("TestAccessibilityResult", axeResult);
        }


        [When(@"I check accessability of list of element")]
        public void WhenICheckAccessabilityOfListOfElement()
        {
            List<string> elementList = new List<string>();
            elementList.Add ("input[ng-model='first']");
            elementList.Add ("input[ng-model='second']");
            elementList.Add ("input[ng-model='operator']");
            axe = new Accessibility(StaticObjectRepo.Driver, sContext);
            AxeResult axeResult = axe.TestAccessibilityOfIndividualElements(elementList);
            sContext.Add("TestAccessibilityResult", axeResult);
        }


        [When(@"I check accessability of elements excluding rules")]
        public void WhenICheckAccessabilityOfElementsExcludingRules()
        {
            List<string> elementList = new List<string>();
            List<string> ruleList = new List<string>();

            elementList.Add("input[ng-model='first']");
            elementList.Add("input[ng-model='second']");
            elementList.Add("input[ng-model='operator']");

            ruleList.Add("label");

            axe = new Accessibility(StaticObjectRepo.Driver, sContext);
            AxeResult axeResult = axe.TestAccessibilityOfElementsDisableRules(elementList, ruleList);
            sContext.Add("TestAccessibilityResult", axeResult);
        }


        [When(@"I check accessability of page excluding elements")]
        public void WhenICheckAccessabilityOfPageExcludingElements()
        {
            List<string> elementList = new List<string>();

            elementList.Add("input[ng-model='first']");
            elementList.Add("input[ng-model='second']");
            elementList.Add("input[ng-model='operator']");

            axe = new Accessibility(StaticObjectRepo.Driver, sContext);
            AxeResult axeResult = axe.TestAccessibilityOfPageExcludeElements(elementList);
            sContext.Add("TestAccessibilityResult", axeResult);
        }


        [When(@"I check accessability of page excluding rules")]
        public void WhenICheckAccessabilityOfPageExcludingRules()
        {
            List<string> ruleList = new List<string>();
            ruleList.Add("label");
            ruleList.Add("html-has-lang");

            axe = new Accessibility(StaticObjectRepo.Driver, sContext);
            AxeResult axeResult = axe.TestAccessibilityOfPageDisableRules(ruleList);
            sContext.Add("TestAccessibilityResult", axeResult);
        }


    }
}
