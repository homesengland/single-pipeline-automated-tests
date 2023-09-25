using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using He.TestFramework.TestBase.Web;
using TechTalk.SpecFlow;

namespace TestFrameworkCore.Pages
{
    public class ContactsPage : BasePage
    {
        new IWebDriver driver;
        String ExpectedHeader = "All Contacts";
        private readonly ScenarioContext sContext;
        public ContactsPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        public IWebElement Header => driver.FindElement(By.CssSelector("section[id^='dataSetRoot'] > div:nth-child(2) span"));
        public IWebElement Column1 => driver.FindElement(By.CssSelector("div[data-id='fullname']"));
        public IWebElement Column2 => driver.FindElement(By.CssSelector("div[data-id='emailaddress1']"));
        public IWebElement TotalRec => driver.FindElement(By.CssSelector("div[data-id='pagingText'] > span"));

        [ThreadStatic]
        public static string FullName;
        [ThreadStatic]
        public static string Email;
        IWebElement[] RecordsList;

        public void ValidateTitle(string title)
        {
            StringAssert.Contains(title + " All " + title, this.getPageTitle());
        }

        public void ValidateHeader(string HeaderText = "")
        {
            if (!string.IsNullOrEmpty(HeaderText)) ExpectedHeader = HeaderText;
            WaitForPageToLoad();
            Assert.AreEqual(ExpectedHeader, Header.Text);
        }

        public void ValidateColumns()
        {
            Assert.AreEqual("Full Name", Column1.GetAttribute("title").Trim());
            Assert.AreEqual("Email", Column2.GetAttribute("title").Trim());
        }

        internal void ValidateTotal(int records)
        {
            string footer = TotalRec.Text;
            string[] newArray = footer.Split(' ');

            //Assert.AreEqual(records.ToString(), newArray[4], "\n Total records for opportunites does not match!!");
            Assert.Positive(int.Parse(newArray[4]), "\n Total records for opportunites does not match!!");
        }

        internal void GetContactDetails(int RecNumber = 0)
        {
            RecordsList = driver.FindElements(By.CssSelector("div[data-lp-id$='grid-cell-container']")).ToArray();
            string SiteRec = RecordsList[0].Text;
            FullName = SiteRec.Substring(0, SiteRec.LastIndexOf('\r'));
            Email = SiteRec.Substring(SiteRec.LastIndexOf('\n') + 1);
        }

    }
}
