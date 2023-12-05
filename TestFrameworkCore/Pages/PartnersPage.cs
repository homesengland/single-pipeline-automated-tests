using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TestFrameworkCore.Pages
{
    public class PartnersPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;

        private IWebElement SignInLabel => driver.FindElement(By.CssSelector("h1[title='All Partners']> button > span > span"));
        private IWebElement AddNewRecord => driver.FindElement(By.CssSelector("button[aria-label='Create New Record. New']"));
        private IWebElement QuickCreatePartner => driver.FindElement(By.CssSelector("button[data-id='quickCreateMenuButton_account']"));
        private IWebElement AddParnterButton => driver.FindElement(By.CssSelector("button[aria-label='Add Partner. New']"));
        private IWebElement DeleteButton => driver.FindElement(By.CssSelector("button[data-id*='DeleteMenu']"));
        private IWebElement ConfirmDeleteButton => driver.FindElement(By.CssSelector("button[aria-label='Delete'"));
        private IWebElement PartnerContainer => driver.FindElement(By.CssSelector(".ag-center-cols-viewport"));

        private IWebElement ViewRecordButton => driver.FindElement(By.CssSelector("div[col-id='name'] a"));
        private IWebElement AddContactButton => driver.FindElement(By.CssSelector("button[aria-label='Add Contact. New']"));
        private IWebElement FilterField => driver.FindElement(By.CssSelector("input[aria-label='Partner Filter by keyword']"));
        private IWebElement[] Filtered1stRecord => driver.FindElements(By.CssSelector(".ag-center-cols-container > div:nth-child(1) > div")).ToArray();
        private IWebElement[] PartnerNamesList => driver.FindElements(By.CssSelector("div[role='row']  a")).ToArray();
        private IWebElement CompanyHouseSearch => driver.FindElement(By.CssSelector("button[aria-label='Company Search']"));

        private string partnerName;
        private string partnerID;
        public PartnersPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            WaitUntilElementVisible(By.CssSelector("h1[title='All Partners']> button > span > span"));
            Assert.AreEqual("All Partners", SignInLabel.Text, "Partners page not displayed!");
        }
        internal void AddNewPartner()
        {
            ClickOnElement(AddParnterButton);
            WaitForPageToLoad();
            partnerFormPage = new PartnerFormPage(driver, sContext);
        }

        internal void SearchForPartnerWithName()
        {
            WaitForPageToLoad();
            sContext.TryGetValue("NewPartnerName", out partnerName);
            Thread.Sleep(5000);
            ClickOnElement(FilterField);
            EnterText(FilterField, partnerName + Keys.Enter);
            WaitForPageToLoad();
            
        }

        internal void VerifyPartnerVisible()
        {
            Assert.AreEqual(partnerName, Filtered1stRecord[3].Text);
            sContext.TryGetValue("NewPartnerID", out partnerID);
            Assert.AreEqual(partnerID, Filtered1stRecord[2].Text);
        }

        internal void VerifyPartnerVisibleByName()
        {
            WaitForPageToLoad();
            Assert.AreEqual(partnerName, Filtered1stRecord[3].Text);
        }

        internal void ClickDeleteButton()
        {
            string parentHandle = driver.CurrentWindowHandle;
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(DeleteButton).Click().Perform();
            }
            catch (StaleElementReferenceException)
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(DeleteButton).Click().Perform();
            }
            ConfirmDelete(parentHandle);
        }

        internal void ConfirmDelete(string handle)
        {
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
            Actions actions = new Actions(driver);
            actions.MoveToElement(ConfirmDeleteButton).Click().Perform();
            driver.SwitchTo().Window(handle);
        }

        internal void SelectPartnerRow()
        {
            ClickOnElement(PartnerContainer);
            ClickOnElement(Filtered1stRecord[2]);
            WaitForPageToLoad();
        }

        internal void PartnerIsNotVisible()
        {
            WaitForPageToLoad();
            Thread.Sleep(2000);
            Assert.False(IsElementPresent(By.CssSelector("label[aria-label='" + partnerID + "']")));
        }

        internal void ClickQuickCreatePartner()
        {
            ClickOnElement(AddNewRecord);
            Thread.Sleep(500);
            ClickOnElement(QuickCreatePartner);
            WaitForPageToLoad();
            partnersQuickFormPage = new PartnersQuickFormPage(driver, sContext);
        }

        internal void ClickViewRecord()
        {
            ClickOnElement(ViewRecordButton);
            partnerFormPage = new PartnerFormPage(driver, sContext);

        }

        internal void SelectPartner()
        {
            WaitForPageToLoad();
            ClickOnElement(Filtered1stRecord[3]);
            partnersDetailsPage = new PartnersDetailsPage(driver, sContext);
        }

        internal void SelectPartner(string partner)
        {
            foreach (var item in PartnerNamesList)
            {
                if (item.Text.ToLower().Equals(partner.ToLower()))
                {
                    sContext.Add("PartnerName", item.Text);
                    ClickOnElement(item);
                    partnersDetailsPage = new PartnersDetailsPage(driver, sContext);
                    break;
                }
            }
        }

        internal void OpenCompanyHouseSearch()
        {
            ClickElement(CompanyHouseSearch);
            WaitForPageToLoad();
            companiesHouseSearchPage = new CompaniesHouseSearchPage(driver, sContext);
        }
    }
}
