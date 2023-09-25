using AventStack.ExtentReports.Utils;
using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace TestFrameworkCore.Pages
{
    public class OpportunityPage : BasePage
    {
        private readonly ScenarioContext sContext;
        public OpportunityPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        new IWebDriver driver;
        String ExpectedHeader = "All Opportunities";
        string[] ExpectedColNames = { "Pipeline Opportunity Id", "Name", "Opportunity Type", "Pipeline Stage", "Source Pipeline", "Local Authority", "Funding Ask", "Timescale - Modelled", "Homes - Full", "Homes - Modelled Overlap", "Partner AOI", "Partner AOI Codes", "Pipeline Identified Intervention" };

        [ThreadStatic]
        public static Hashtable GridValues = new Hashtable();

        public IWebElement Header => driver.FindElement(By.CssSelector("section[id^='dataSetRoot'] > div:nth-child(2) span"));
        public By HeaderBy => By.CssSelector("section[id^='dataSetRoot'] > div:nth-child(2) span");
        public IWebElement LeadsOption => driver.FindElement(By.CssSelector("li[title='Leads']"));
        //public IWebElement HeaderDropDown2 => driver.FindElement(By.CssSelector("span[aria-owns='ViewSelector_1_5bd2527c - a882 - de11 - 9ff3 - 00155da3b012_60e88fd8 - 5556 - 4968 - b9ad - eec855e9a218_list_empty']"));
        public IList<IWebElement> TableHeader => driver.FindElements(By.CssSelector(".wj-row"));
        public IWebElement TotalRec => driver.FindElement(By.CssSelector("div[data-id='pagingText'] > span"));
        public IList<IWebElement> StatusList => driver.FindElements(By.CssSelector("div[aria-colindex='5']"));
        public IList<IWebElement> OppTypeList => driver.FindElements(By.CssSelector("div[aria-colindex='4']"));
        public IWebElement SortByLetterA => driver.FindElement(By.CssSelector("A_link"));
        public IWebElement SearchField => driver.FindElement(By.CssSelector("input[title='Select to enter data']"));

        [ThreadStatic]
        public static string[] RecValues;
        IWebElement[] RecordsList;

        public void ValidateTitle(string title)
        {
            WaitUntilElementVisible(HeaderBy);
            //StringAssert.Contains(title + " All " + title, this.getPageTitle());
        }

        public void ValidateHeader(string view = "")
        {
            if (string.IsNullOrEmpty(view))
                view = ExpectedHeader;
            WaitUntilElementVisible(HeaderBy);
            //Assert.AreEqual(view, Header.Text);
        }

        public void ValidateColumns()
        {
            string txt = TableHeader[TableHeader.Count() - 2].Text.Trim();    

            string[] ColumnNames = txt.TrimEnd().Split('\n').Select(p => p.Trim()).ToArray();
            foreach (string header in ExpectedColNames)
            Assert.Contains(header, ColumnNames, "The Columns on All opportunity view do not match the expected!!");
        }

        internal void ValidateTotal(int records)
        {
            string footer = TotalRec.Text;
            string[] newArray = footer.Split(' ');

            //Assert.AreEqual(records.ToString(), newArray[4], "\n Total records for opportunites does not match!!");
            Assert.Positive(int.Parse(newArray[4]), "\n Total records for opportunites does not match!!");
        }


        internal void SortBy(string sortLetter)
        {
            string LetterCSS = "#" + sortLetter;
            IWebElement SortByLetter = driver.FindElement(By.CssSelector(LetterCSS + "_link"));
            ClickOnElement(SortByLetter);
        }


        internal void LeadStageRecords(bool Required)
        {
            bool ValueFound = FindValueInGrid("Lead", 5);
            if (Required)
            {
                Assert.IsTrue(ValueFound);
            }
            else
            {
                Assert.IsFalse(ValueFound);
            }
        }

        internal void OpportunityStageRecords(bool Required)
        {
            bool ValueFound = FindValueInGrid("Opportunity", 5);
            if (Required)
            {
                Assert.IsTrue(ValueFound);
            }
            else
            {
                Assert.IsFalse(ValueFound);
            }
        }

        internal void ViewRecords()
        {
            throw new NotImplementedException();
        }

        internal void PartnerOpportunityRecords(bool Required)
        {
            bool ValueFound = FindValueInGrid("Partner", 4);
            if (Required)
            {
                Assert.IsTrue(ValueFound);
            }
            else
            {
                Assert.IsFalse(ValueFound);
            }
        }

        internal void PlaceOpportunityRecords(bool Required)
        {
            bool ValueFound = FindValueInGrid("Place", 4);
            if (Required)
            {
                Assert.IsTrue(ValueFound);
            }
            else
            {
                Assert.IsFalse(ValueFound);
            }
        }

        internal void ChangeView(string View)
        {
            ClickOnElement(Header);
            IWebElement ViewOption = driver.FindElement(By.CssSelector("li[title='" + View + "']"));
            ClickOnElement(ViewOption);
        }

        internal bool FindValueInGrid(string Value, int ColumnNo)
        {
            Thread.Sleep(2000);
            IList<IWebElement> ColumnList = driver.FindElements(By.CssSelector("div[aria-colindex='"+ ColumnNo +"']"));
            bool IsValueFound = false;
           
            foreach (IWebElement Item in ColumnList)
            {
                if (Item.Text.Equals(Value) && IsValueFound == false)
                {
                    IsValueFound = true;
                }

                if (IsValueFound) break;
            }
            return(IsValueFound);
        }

        internal void GetOpportunityDetails(int RecNumber = 1)
        {
            char[] sep = { '\n', '\r' };
            RecordsList = driver.FindElements(By.CssSelector("div[data-lp-id$='grid-cell-container']")).ToArray();
            string PartnerRec = RecordsList[RecNumber].Text;
            RecValues = PartnerRec.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            GridValues.Clear();
            foreach (string val in RecValues)
            {
                val.Trim();
                GridValues.Add(ExpectedColNames[i++], val);
            }

        }

        internal void SearchOpportunity(string oppName)
        {
            SearchField.SendKeys(oppName + Keys.Enter);
        }


    }
}
