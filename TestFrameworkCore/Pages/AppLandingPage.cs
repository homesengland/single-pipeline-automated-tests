using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;

namespace TestFrameworkCore.Pages
{
    public class AppLandingPage : BasePage
    {
        public new IWebDriver driver;

        private IWebElement AppiFrame => driver.FindElement(By.CssSelector("#AppLandingPage"));
        private IWebElement ManagePartnerLink => driver.FindElement(By.CssSelector("div[title=\"Manage Partner Interactions\"]"));
        private By ManagePartnerLinkBy => By.CssSelector("div[title=\"Manage Partner Interactions\"]");
        private IWebElement Header => driver.FindElement(By.CssSelector("div[data-id='topBar'] > div:nth-child(2) > span"));
        private By HeaderBy => By.CssSelector("div[data-id='topBar'] > div:nth-child(2) > span");
        private readonly ScenarioContext sContext;
        public AppLandingPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        internal void GotoManagerPartnerInteractions()
        {
            driver.SwitchTo().Frame(AppiFrame);
            ClickOnElement(ManagePartnerLink);
            homePage = new HomePage(driver, sContext);

        }

        internal void ValidateHeader()
        {
            WaitforFewSeconds(7);
            WaitUntilElementVisible(HeaderBy);
            Assert.IsTrue(Header.Text.Contains("SANDBOX"),"The text 'SANDBOX' not found on page! \n Home page not loaded properly!");
        }
    }
}
