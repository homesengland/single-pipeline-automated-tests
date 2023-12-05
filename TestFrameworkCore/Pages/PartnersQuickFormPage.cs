using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using TestFrameworkWeb.TestAssembly;

namespace TestFrameworkCore.Pages
{
    public class PartnersQuickFormPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;
        private IWebElement SignInLabel => driver.FindElement(By.CssSelector("h1[data-id='quickHeaderTitle']"));
        private IWebElement UseAutomaticSearch => driver.FindElement(By.CssSelector("input[aria-label='Use Automatic Search?']"));
        private IWebElement QuickCreateContainer => driver.FindElement(By.CssSelector("div[id='quickCreateTabContainer']"));
        private IWebElement QuickPartnerName => driver.FindElement(By.CssSelector("input[aria-label='Partner Name']"));
        private IWebElement QuickPartnerSector => driver.FindElement(By.CssSelector("select[aria-label='Sector']"));
        private IWebElement QuickKeyAccount => driver.FindElement(By.CssSelector("select[aria-label='Key Account']"));
        private IWebElement QuickPartnerType => driver.FindElement(By.CssSelector("select[aria-label='Partner Type']"));
        private IWebElement QuickCompaniesHouseNumber => driver.FindElement(By.CssSelector("input[aria-label='Companies House Number']"));
        private IWebElement QuickHECGOC => driver.FindElement(By.CssSelector("input[aria-label='Homes England Central Government Organisation Code']"));
        private IWebElement QuickHECAC => driver.FindElement(By.CssSelector("input[aria-label='Homes England Combined Authority Code']"));
        private IWebElement QuickLocalAuthCode => driver.FindElement(By.CssSelector("input[aria-label='Local Authority Code']"));
        private IWebElement QuickSocialHousingRegNumber => driver.FindElement(By.CssSelector("input[aria-label='Social Housing Provider Registration Number']"));
        private IWebElement QuickPrimaryOpRegion => driver.FindElement(By.CssSelector("input[aria-label='Primary Operating Region']"));
        private IWebElement QuickPartnerStreetOne => driver.FindElement(By.CssSelector("input[aria-label='Street 1']"));
        private IWebElement QuickPartnerStreetTwo => driver.FindElement(By.CssSelector("input[aria-label='Street 2']"));
        private IWebElement QuickCity => driver.FindElement(By.CssSelector("input[aria-label='City']"));
        private IWebElement QuickPartnerPostcode => driver.FindElement(By.CssSelector("input[aria-label='ZIP/Postal Code']"));
        private IWebElement QuickPrimaryOpRegionOption;

        private IWebElement QuickSaveAndClose => driver.FindElement(By.CssSelector("button[data-id='quickCreateSaveAndCloseBtn']"));
        public PartnersQuickFormPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }
        public void enterPartnerName(string name)
        {
            EnterText(QuickPartnerName, name);
            sContext.Add("NewPartnerName", name);
        }

        public void enterSector(string sectorOption)
        {
            SelectListOption(QuickPartnerSector, sectorOption);
        }

        public void enterPartnerType()
        {
            ScrollAndClickElement(QuickPartnerType);
            SelectListOption(QuickPartnerType, Resources.Partners.PartnerData.PartnerType);
        }
        public void enterKeyAccount()
        {
            ScrollAndClickElement(QuickKeyAccount);
            SelectListOption(QuickKeyAccount, Resources.Partners.PartnerData.KeyAccount);
        }

        public void enterCompaniesHouseNumber()
        {
            EnterText(QuickCompaniesHouseNumber, Resources.Partners.PartnerData.CHNumber);
        }
        public void enterHECGOrgCode()
        {
            EnterText(QuickHECGOC, Resources.Partners.PartnerData.HECentralGovOrgCode);
        }
        public void enterHECACode()
        {
            EnterText(QuickHECAC, Resources.Partners.PartnerData.HECombAuthCode);
        }
        public void enterLocalAuthCode()
        {
            EnterText(QuickLocalAuthCode, Resources.Partners.PartnerData.LocalAuthCode);
        }
        public void enterSocialHousingProviderRegNumber()
        {
            EnterText(QuickSocialHousingRegNumber, Resources.Partners.PartnerData.SocHPRegNum);
        }

        public void selectPrimaryOperatingRegion()
        {
            EnterText(QuickPrimaryOpRegion, Resources.Partners.PartnerData.PrimaryOpRegion);
            QuickPrimaryOpRegionOption = driver.FindElement(By.CssSelector("label[title='" + Resources.Partners.PartnerData.PrimaryOpRegion + "'"));
            ClickElement(QuickPrimaryOpRegionOption);
        }

        public void enterStreetOne(string street)
        {
            ScrollAndClickElement(QuickPartnerStreetOne);
            EnterText(QuickPartnerStreetOne, street);
        }
        public void enterStreetTwo()
        {
            ScrollAndClickElement(QuickPartnerStreetTwo);
            EnterText(QuickPartnerStreetTwo, Resources.Partners.PartnerData.StreetTwo);
        }

        public void enterCity()
        {
            ScrollAndClickElement(QuickCity);
            EnterText(QuickCity, Resources.Partners.PartnerData.City);
        }

        public void enterPostcode(string postcode)
        {
            ScrollAndClickElement(QuickPartnerPostcode);
            EnterText(QuickPartnerPostcode, postcode);
        }

        public void CreateNewQuickPartner()
        {
            var rand = new Bogus.Faker();

            enterPartnerName("Automated Quick Partner");
            enterCompaniesHouseNumber();
            enterHECGOrgCode();
            enterHECACode();
            enterLocalAuthCode();
            enterSocialHousingProviderRegNumber();
            enterSector("Financial");
            enterPartnerType();
            selectPrimaryOperatingRegion();
            enterStreetOne(rand.Address.StreetName());
            enterStreetTwo();
            enterCity();
            enterPostcode(Helpers.GetRandomPostcode());
        }
        public void ClickQuickSaveAndClose()
        {
            ClickElement(QuickSaveAndClose);
            partnersPage = new PartnersPage(driver, sContext);
            WaitForPageToLoad();
        }
        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            Assert.AreEqual("Quick Create: Partner", SignInLabel.Text, "New partners form page not displayed!");
        }

        public void ClickUsePartnerSearch()
        {
            string parentHandle = driver.CurrentWindowHandle;

            ClickElement(UseAutomaticSearch);
            WaitForPageToLoad();
            companiesHouseSearchPage = new CompaniesHouseSearchPage(driver, sContext);
        }
    }
}
