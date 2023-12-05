using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System.Linq;

namespace TestFrameworkCore.Pages
{
    public class CompaniesHouseSearchPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;
        private string parentHandle;
        private IWebElement Title => driver.FindElement(By.CssSelector("h1[aria-label='Companies House']"));
        private IWebElement CompaniesSearchInput => driver.FindElement(By.CssSelector("input[appmagic-control='CompanyNametextbox']"));
        private IWebElement CompaniesSearchButton => driver.FindElement(By.CssSelector("div[data-control-name='BtnCompanyNameSearch']"));
        private IWebElement CompaniesSearchCreateButton => driver.FindElement(By.CssSelector("div[data-control-name='SaveButton']"));
        private IWebElement CloseSearchButton => driver.FindElement(By.CssSelector("button[data-id='dialogCloseIconButton']"));

        static string confirmCreate = "Your record has been saved! You now may close this window";
        static string confirmXpath = $"//span[contains(text(), '{confirmCreate}')]";
        private IWebElement ConfirmMessage => driver.FindElement(By.XPath(confirmXpath));
        public CompaniesHouseSearchPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;

            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void EnterCompanySearch(string company)
        {
            sContext.Add("NewPartnerName", company);
            ClickElement(Title);
            //have to go through nested iframes
            driver.SwitchTo().Frame(5);
            driver.SwitchTo().Frame(0);
            driver.SwitchTo().Frame(0);
            IsElementDisplayed(CompaniesSearchInput);
            ClickElement(CompaniesSearchInput);
            CompaniesSearchInput.SendKeys(company);
        }

        public void ClickSearchButton()
        {
            ClickElement(CompaniesSearchButton);
        }

        public void SaveFirstResult()
        {
            IsElementDisplayed(CompaniesSearchCreateButton);
            ClickElement(CompaniesSearchCreateButton);
        }

        public void ValidateConfirmMessage()
        {
            //the message exists in the iframe above, so you have to navigate up one and then back down.
            driver.SwitchTo().ParentFrame();
            Assert.True(IsElementDisplayed(ConfirmMessage));
            driver.SwitchTo().Frame(0);
        }

        public void CloseCompaniesSearch()
        {
            //exit the nested iframes
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().DefaultContent();
            ClickElement(CloseSearchButton);
            partnersPage = new PartnersPage(driver, sContext);
        }
    }
}
