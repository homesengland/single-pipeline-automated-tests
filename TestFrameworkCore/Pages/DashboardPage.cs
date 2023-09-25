using TestFrameworkCore.Pages;
using He.TestFramework.TestBase.Web;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Utils;
using OpenQA.Selenium.Interactions;
using System.Xml.Serialization;
using TechTalk.SpecFlow;

namespace TestFrameworkCore.Pages
{
    public class DashboardPage : BasePage
    {
        new IWebDriver driver;
        string ExpectedHeader = "Opportunities Dashboard";
        private readonly ScenarioContext sContext;
        public DashboardPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        public IWebElement Header => driver.FindElement(By.CssSelector("h1[title='Dashboard Selector'] > div > span:nth-child(1)"));
        public IWebElement LATab => driver.FindElement(By.CssSelector("li[id=sitemap-entity-NewSubArea_411eeb2]"));
        public IWebElement HomePageHeader => driver.FindElement(By.CssSelector("span[id^='Dashboard_Selector_']"));
        public IWebElement OppTabElm => driver.FindElement(By.CssSelector("li[aria-label='Opportunities']"));
        public By OppTab => By.CssSelector("li[aria-label='Opportunities']");
        public IWebElement ContactsTab => driver.FindElement(By.CssSelector("#sitemap-entity-NewSubArea_5c32cd9a"));
        public IWebElement[] sectionHeaders => driver.FindElements(By.CssSelector("div[data-id='DataSetHostContainer'] > div > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)")).ToArray();
        public IList<IWebElement> sectionTable => driver.FindElements(By.CssSelector("div[data-id='DataSetHostContainer'] > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(1)"));
        public IList<IWebElement> GraphSectionHeaders => driver.FindElements(By.CssSelector(".divViewTitle.suiter-chart, .divViewSelector.suiter-chart"));
        public IList<IWebElement> GraphSectionTitles => driver.FindElements(By.CssSelector(".chart-secondheader-row.suiter-chart"));


        public IWebElement SiteTab => driver.FindElement(By.CssSelector("#sitemap-entity-NewSubArea_6ef8daa3"));
        public By ContinueLink => By.CssSelector("#hiddenformSubmitBtn");

        public void ValidateHeader(string Expected = "")
        {
            if (!string.IsNullOrEmpty(Expected))
                ExpectedHeader = Expected;
            //Assert.IsTrue(header.Equals(Header.Text));
            Assert.AreEqual(ExpectedHeader, Header.Text);
        }

        internal void validatePartnerOppSection()
        {
            //IWebElement PartnerSecHeader = driver.FindElement(By.CssSelector("div[data-id^='MscrmControls.Containers.DashboardControl'] > div > div:nth-child(1) div[data-id='DataSetHostContainer'] > div > div > div > div"));
            Assert.AreEqual(sectionHeaders[0].Text, "Partner Opportunities");

            this.checkColumns(sectionTable[0]);
        }

        internal void checkColumns(IWebElement sectionTableElement)
        {
            string[] ExpectedColNames = { "Pipeline Opportunity Id", "Name", "Opportunity Type", "Pipeline Stage", "Source Pipeline", "Local Authority" };
            string txt = sectionTableElement.GetAttribute("innerText").Trim();
            string[] ColumnNames = txt.TrimEnd().Split('\n').Select(p => p.Trim()).ToArray();
            foreach (string header in ExpectedColNames)
            Assert.Contains(header, ColumnNames, "The Columns on opportunity section in dashboard do not match the expected!!");
        }

        internal void validateChartSection(string chart)
        {
            switch(chart)
            {
                case "OpportunityByTimescale":
                    Assert.AreEqual(GraphSectionHeaders[0].Text, "Place Based Opportunities");
                    Assert.AreEqual(GraphSectionTitles[0].Text, "Opportunity by Timescale - Modelled");
                    break;

                case "OpportunityByThematicArea":
                    Assert.AreEqual(GraphSectionHeaders[1].Text, "All Place Opportunities by Thematic Area");
                    Assert.AreEqual(GraphSectionTitles[1].Text, "Opportunity by Thematic Area");
                    break;

                case "OpportunityByPipeline":
                    Assert.AreEqual(GraphSectionHeaders[2].Text, "Place Based Opportunities");
                    Assert.AreEqual(GraphSectionTitles[2].Text, "Opportunities by Pipeline Stage");
                    break;

                case "TotalHomes":
                    Assert.AreEqual(GraphSectionHeaders[3].Text, "Active Opportunity Stats");
                    Assert.AreEqual(GraphSectionTitles[3].Text, "Total Homes");
                    break;
            }
        }

        public void Validatetitle(string header)
        {
            Assert.IsTrue(header.StartsWith(HomePageHeader.Text));
        }

        public void ValidateLHSTab(string tab)
        {
            IWebElement ValidateElement = GetElementFromString(tab);

            Assert.IsTrue(this.IsElementDisplayed(ValidateElement));
        }

        internal void ChooseView(string View)
        {
            ClickOnElement(Header);
            IWebElement ViewOption = driver.FindElement(By.CssSelector("li[title='" + View + "']"));
            ClickOnElement(ViewOption);
        }

        internal void validatePlaceOppSection()
        {
            //IWebElement PartnerSecHeader = driver.FindElement(By.CssSelector("div[data-id^='MscrmControls.Containers.DashboardControl'] > div > div:nth-child(2) div[data-id='DataSetHostContainer'] > div > div > div > div"));
            Assert.AreEqual(sectionHeaders[1].Text, "Place Opportunities");
            this.checkColumns(sectionTable[1]);
        }

        public void ClickOnElementLHSTab(string tab)
        {
            WaitForPageToLoad();
            IWebElement ClickElement = GetElementFromString(tab);
            ClickOnElement(ClickElement);
            ReturnPage(tab);
        }

        internal void validateLeadsSection()
        {
            //IWebElement PartnerSecHeader = driver.FindElement(By.CssSelector("div[data-id^='MscrmControls.Containers.DashboardControl'] > div > div:nth-child(3) div[data-id='DataSetHostContainer'] > div > div > div > div"));
            Assert.AreEqual(sectionHeaders[2].Text,"Leads");
            this.checkColumns(sectionTable[2]);
        }

        internal void validateAllOppSection()
        {
            //IWebElement PartnerSecHeader = driver.FindElement(By.CssSelector("div[data-id^='MscrmControls.Containers.DashboardControl'] > div > div:nth-child(4) div[data-id='DataSetHostContainer'] > div > div > div > div"));
            Assert.AreEqual(sectionHeaders[3].Text,"All Opportunities");
            this.checkColumns(sectionTable[3]);
        }

        public IWebElement GetElementFromString(string ElementName)
        {

            IWebElement Element = null;
            string LHSTab = ElementName.ToLower();
            if (LHSTab.Equals("partners"))
            {
                Element = LATab;
            }
            else if (LHSTab.Equals("opportunities"))
            {
                Element = WaitUntilElementVisible(OppTab);
            }
            else if (LHSTab.Equals("contacts"))
            {
                Element = ContactsTab;
            }
            else if (LHSTab.Equals("sites"))
            {
                Element = SiteTab;
            }
            else
            {
                throw new NotFoundException(ElementName + " tab not found in LHS Menu!!");
            }
            return Element;
        }

        public void ReturnPage(string ElementName)
        {
            string LHSTab = ElementName.ToLower();
            //var ReturnPg = (object)null;

                if (LHSTab.Equals("opportunities"))
                {
                    opportunityPage = new OpportunityPage(driver, sContext);
                }
                else if (LHSTab.Equals("contacts"))
                {
                    contactsPage = new ContactsPage(driver, sContext);
                }
                else
                {
                    throw new NotFoundException(ElementName + " tab not found in LHS Menu!!");
                }
            //return (T) Convert.ChangeType(ReturnPg, typeof(T));
        }

        internal void ClickContinue()
        {
            if (AppReader.GetConfigValue("browser").ToLower().Equals("chrome"))
            {
                if (dashboardPage.IsElementPresent(ContinueLink))
                {
                    ClickOnElement(driver.FindElement(ContinueLink));
                }
            }
        }
    }

}

