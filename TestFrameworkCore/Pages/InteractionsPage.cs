using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System.Configuration;
using System;
using TestFrameworkWeb.TestAssembly;
using System.Linq;

namespace TestFrameworkCore.Pages
{
    public class InteractionsPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;


        private IWebElement HomeButton => driver.FindElement(By.CssSelector("li[aria-label='Home']"));
        private IWebElement SignInLabel => driver.FindElement(By.CssSelector("h1[title='Active Interactions']> button > span > span"));
        private IWebElement AddInteractionButton => driver.FindElement(By.CssSelector("button[aria-label='Add Interaction. New']"));
        private IWebElement FilterField => driver.FindElement(By.CssSelector("input[aria-label='Interaction Filter by keyword']"));
        private IWebElement[] Filtered1stRecord => driver.FindElements(By.CssSelector(".ag-center-cols-container > div:nth-child(1) > div")).ToArray();
        private By Filtered1stRecordBy => By.CssSelector(".ag-center-cols-container > div:nth-child(1) > div");


        private IWebElement ContinueButton => driver.FindElement(By.CssSelector("button[type='submit']"));


        public InteractionsPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        internal void ValidateHeader()
        {

            WaitforFewSeconds(5);
            WaitForPageToLoad(); ;
            Assert.AreEqual("Active Interactions", SignInLabel.Text, "Interactions page not displayed!");
            
        }

        internal void AddNewInteraction()
        {
            ClickOnElement(AddInteractionButton);
            WaitForPageToLoad();
            interactionsFormPage = new InteractionsFormPage(driver, sContext);
        }

        internal void Filter(string filterVal = "")
        {
            if(filterVal!="")
                EnterText(FilterField, filterVal + Keys.Enter);
            else
                EnterText(FilterField, sContext.Get<string>("InteractionTitle") + Keys.Enter);
        }

        internal void ValidateNewinteraction(bool exists = true)
        {
            WaitForPageToLoad();
            if (exists)
            { 
            Assert.AreEqual(sContext.Get<string>("InteractionTitle"), Filtered1stRecord[1].Text, "Interaction Title does not match!");
            Assert.AreEqual(sContext.Get<string>("InteractionType"), Filtered1stRecord[2].Text, "Interaction Type does not match!");
            Assert.AreEqual(sContext.Get<string>("Partner"), Filtered1stRecord[4].Text, "Partner does not match!");
            Assert.AreEqual(sContext.Get<string>("Contact"), Filtered1stRecord[3].Text, "Contact does not match!");
            driver.Url = "chrome://settings";
            ((IJavaScriptExecutor)driver).ExecuteScript("chrome.settingsPrivate.setDefaultZoom(0.70);");
            driver.Navigate().Back();
            Assert.AreEqual(sContext.Get<string>("RelatedOpportunity"), Filtered1stRecord[9].Text, "Does interaction relate to any Pipeline does not match!");
            }
            else
            {
               // StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                Assert.False(IsElementPresent(Filtered1stRecordBy));
               // StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["IMPLICIT_WAIT"]));
            }
            ClickOnElement(HomeButton);
        }
    }
}
