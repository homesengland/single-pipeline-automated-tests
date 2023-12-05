using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;

namespace TestFrameworkCore.Pages
{
    public class PartnerFormPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;
        private IWebElement SignInLabel => driver.FindElement(By.CssSelector("h1[title='New Partner']"));
        private IWebElement SummaryContainer => driver.FindElement(By.CssSelector("div[aria-label='Summary']"));
        private IWebElement QuickCreateContainer => driver.FindElement(By.CssSelector("div[id='quickCreateTabContainer']"));
        private IWebElement PartnerID => driver.FindElement(By.CssSelector("input[aria-label='ID']"));
        private IWebElement PartnerName => driver.FindElement(By.CssSelector("input[aria-label='Partner Name']"));
        private IWebElement PartnerSector => driver.FindElement(By.CssSelector("select[aria-label='Sector']"));
        private IWebElement PartnerType => driver.FindElement(By.CssSelector("select[aria-label='Partner Type']"));
        private IWebElement KeyAccount => driver.FindElement(By.CssSelector("select[aria-label='Key Account']"));
        private IWebElement KeyAccountManager => driver.FindElement(By.CssSelector("input[aria-label='Look for Key Account Manager']"));
        private IWebElement SMEIndicator => driver.FindElement(By.CssSelector("select[aria-label='SME Indicator']"));
        private IWebElement CompaniesHouseNumber => driver.FindElement(By.CssSelector("input[aria-label='Companies House Number']"));
        private IWebElement HECGOC => driver.FindElement(By.CssSelector("input[aria-label='Homes England Central Government Organisation Code']"));
        private IWebElement HECAC => driver.FindElement(By.CssSelector("input[aria-label='Homes England Combined Authority Code']"));
        private IWebElement LocalAuthCode => driver.FindElement(By.CssSelector("input[aria-label='Local Authority Code']"));
        private IWebElement SocialHousingRegNumber => driver.FindElement(By.CssSelector("input[aria-label='Social Housing Provider Registration Number']"));
        private IWebElement PrimaryOpRegion => driver.FindElement(By.CssSelector("input[aria-label='Primary Operating Region']"));
        private IWebElement ParentPartner => driver.FindElement(By.CssSelector("input[aria-label='Look for Parent Partner']"));
        private IWebElement UltParent => driver.FindElement(By.CssSelector("input[aria-label='Look for Ultimate Parent']"));
        private IWebElement Email => driver.FindElement(By.CssSelector("input[aria-label='Email']"));
        private IWebElement Website => driver.FindElement(By.CssSelector("input[aria-label='Website']"));
        private IWebElement Phone => driver.FindElement(By.CssSelector("input[aria-label='Phone']"));
        private IWebElement PartnerStreetOne => driver.FindElement(By.CssSelector("input[aria-label='Street 1']"));
        private IWebElement PartnerStreetTwo => driver.FindElement(By.CssSelector("input[aria-label='Address 1: Street 2']"));
        private IWebElement PartnerStreetThree => driver.FindElement(By.CssSelector("input[aria-label='Address 1: Street 3']"));
        private IWebElement City => driver.FindElement(By.CssSelector("input[aria-label='City']"));
        private IWebElement County => driver.FindElement(By.CssSelector("input[aria-label='County']"));
        private IWebElement PartnerPostcode => driver.FindElement(By.CssSelector("input[aria-label='Postcode']"));
        private IWebElement Country => driver.FindElement(By.CssSelector("input[aria-label='Country']"));
        private IWebElement KeyAccountManagerOption => driver.FindElement(By.CssSelector("div[aria-label='Key Account Manager Lookup results']"));
        private IWebElement ParentPartnerOption => driver.FindElement(By.CssSelector("div[aria-label='Parent Partner Lookup results']"));
        private IWebElement UltimateParentOption => driver.FindElement(By.CssSelector("div[aria-label='Ultimate Parent Lookup results']"));
        private IWebElement PrimaryOpRegionOption;
        private IWebElement BackButton => driver.FindElement(By.CssSelector("button[title='Go back']"));
        private IWebElement SaveButton => driver.FindElement(By.CssSelector("button[aria-label='Save (CTRL+S)']"));
        private IWebElement QuickSaveAndClose => driver.FindElement(By.CssSelector("button[data-id='quickCreateSaveAndCloseBtn']"));
        private IWebElement DeactivateButton => driver.FindElement(By.CssSelector("button[aria-label='Deactivate']"));
        private IWebElement ActivateButton => driver.FindElement(By.CssSelector("button[aria-label='Activate']"));
        private IWebElement DeleteButton => driver.FindElement(By.CssSelector("button[aria-label='Delete']"));
        private IWebElement confirmDeactivateActivate => driver.FindElement(By.CssSelector("button[data-id='ok_id']"));

        private IWebElement WarningNotif => driver.FindElement(By.CssSelector("span[data-id='warningNotification']"));
        private IWebElement PartnerStatus => driver.FindElement(By.CssSelector("div[role='presentation']"));
        private IWebElement PartnerNameErrorMessage => driver.FindElement(By.CssSelector("span[data-id='name-error-message']"));
        private IWebElement PartnerTypeErrorMessage => driver.FindElement(By.CssSelector("span[data-id='he_partnertype-error-message']"));
        private IWebElement SectorErrorMessage => driver.FindElement(By.CssSelector("span[data-id='he_partner_sector-error-message']"));
        private IWebElement Street1ErrorMessage => driver.FindElement(By.CssSelector("span[data-id='address1_composite_compositionLinkControl_address1_line1-error-message']"));
        private IWebElement PostcodeErrorMessage => driver.FindElement(By.CssSelector("span[data-id='address1_composite_compositionLinkControl_address1_postalcode-error-message']"));

        string readonlyNotif = "Read-only This record’s status: Inactive";
        private string newPartnerID;
        public PartnerFormPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        public void enterPartnerName(string name)
        {
            EnterText(PartnerName, name);
            sContext.Add("NewPartnerName", name);
        }

        public void enterSector(string sectorOption)
        {
            SelectListOption(PartnerSector, sectorOption);
        }

        public void enterPartnerType()
        {
            ScrollAndClickElement(PartnerType);
            SelectListOption(PartnerType, Resources.Partners.PartnerData.PartnerType);
        }
        /*
         * the below two steps have been removed from the tests but this code
         * shall remain in case we need to use them in the future
         * keyAccount + keyAccountManager
        */
        public void enterKeyAccount()
        {
            SelectListOption(KeyAccount, Resources.Partners.PartnerData.KeyAccount);
        }

        public void enterKeyAccountManager()
        {
            EnterText(KeyAccountManager, Resources.Partners.PartnerData.KeyAccountManager);
            Thread.Sleep(1500);
            ClickElement(KeyAccountManagerOption);
        }
        public void enterSMEIndicator()
        {
            SelectListOption(SMEIndicator, Resources.Partners.PartnerData.SMEIndicator);
        }

        public void enterCompaniesHouseNumber()
        {
            EnterText(CompaniesHouseNumber, Resources.Partners.PartnerData.CHNumber);
        }
        public void enterHECGOrgCode()
        {
            EnterText(HECGOC, Resources.Partners.PartnerData.HECentralGovOrgCode);
        }
        public void enterHECACode()
        {
            EnterText(HECAC, Resources.Partners.PartnerData.HECombAuthCode);
        }
        public void enterLocalAuthCode()
        {
            EnterText(LocalAuthCode, Resources.Partners.PartnerData.LocalAuthCode);
        }
        public void enterSocialHousingProviderRegNumber()
        {
            EnterText(SocialHousingRegNumber, Resources.Partners.PartnerData.SocHPRegNum);
        }

        public void selectPrimaryOperatingRegion()
        {
            EnterText(PrimaryOpRegion, Resources.Partners.PartnerData.PrimaryOpRegion);
            PrimaryOpRegionOption = driver.FindElement(By.CssSelector("label[title='"+Resources.Partners.PartnerData.PrimaryOpRegion+"'"));
            ClickElement(PrimaryOpRegionOption);
        }
        public void enterParentPartner()
        {
            ScrollToElement("down", () => ParentPartner);
            EnterText(ParentPartner, Resources.Partners.PartnerData.ParentPartner);
            Thread.Sleep(1000);
            ClickElement(ParentPartnerOption);
        }
        public void enterUltimateParent()
        {
            ScrollToElement("down", () => UltParent);
            EnterText(UltParent, Resources.Partners.PartnerData.UltParent);
            Thread.Sleep(1000);
            ClickElement(UltimateParentOption);
        }
        public void enterEmail()
        {
            EnterText(Email, Resources.Partners.PartnerData.Email);
        }
        public void enterWebsite()
        {
            EnterText(Website, Resources.Partners.PartnerData.Website);
        }
        public void enterPhone()
        {
            EnterText(Phone, Resources.Partners.PartnerData.Phone);
        }

        public void enterStreetOne(string street)
        {
            ScrollToElement("down", () => PartnerStreetOne);
            EnterText(PartnerStreetOne, street);
        }
        public void enterStreetTwo()
        {
            EnterText(PartnerStreetTwo, Resources.Partners.PartnerData.StreetTwo);
        }
        public void enterStreetThree()
        {
            EnterText(PartnerStreetThree, Resources.Partners.PartnerData.StreetThree);
        }
        public void enterCity()
        {
            EnterText(City, Resources.Partners.PartnerData.City);
        }
        public void enterCounty()
        {
            EnterText(County, Resources.Partners.PartnerData.County);
        }

        public void enterPostcode(string postcode)
        {
            ScrollToElement("down", () => PartnerPostcode);
            EnterText(PartnerPostcode, postcode);
        }
        public void enterCountry()
        {
            EnterText(Country, Resources.Partners.PartnerData.Country);
        }

        public void clickBackButton()
        {
            ClickElement(BackButton);
            partnersPage = new PartnersPage(driver, sContext);
            WaitForPageToLoad();
        }

        public void clickSaveButton()
        {
            ClickElement(SaveButton);
            WaitForPageToLoad();
        }

        public void getPartnerID()
        {
            WaitForPageToLoad();
            ScrollToElement("up", () => PartnerID);
            try
            {
                Thread.Sleep(1000);
                newPartnerID = PartnerID.GetAttribute("value");
                sContext.Add("NewPartnerID", newPartnerID);
            }
            catch(NoSuchElementException e)
            {
                TestInitialise.saveScreenshot(TestInitialise.errorDirectory, "Error_" + DateTime.Now);
                StaticObjectRepo.Scenario.Log(Status.Fail, "PartnerID not found " + e.Message);
            }
        }
        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            Assert.AreEqual("New Partner", SignInLabel.Text, "New partners form page not displayed!");
        }

        public  void ScrollToElement(string direction, Func<IWebElement> elementProvider)
        {
            bool isElementVisible = false;

            ClickElement(SummaryContainer);
            while (!isElementVisible)
            {
                if (direction == "up")
                {
                    SummaryContainer.SendKeys(Keys.PageUp);
                }else
                {
                    SummaryContainer.SendKeys(Keys.PageDown);
                }
                try
                {
                    IWebElement element = elementProvider();
                    IsElementDisplayed(element);

                    isElementVisible = true;
                }
                catch (NoSuchElementException)
                {
                    continue;
                }                
            }
        }

        public void ClickDeactivate()
        {
            string parentHandle = driver.CurrentWindowHandle;
            ClickElement(DeactivateButton);
            ConfirmDeactivate(parentHandle);
            WaitForPageToLoad();
        }
        internal void ConfirmDeactivate(string handle)
        {
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
            Actions actions = new Actions(driver);
            actions.MoveToElement(confirmDeactivateActivate).Click().Perform();
            driver.SwitchTo().Window(handle);
            WaitForPageToLoad();
        }
        public void ClickActivate()
        {
            string parentHandle = driver.CurrentWindowHandle;
            ClickElement(ActivateButton);
            ConfirmActivate(parentHandle);
            WaitForPageToLoad();
        }
        internal void ConfirmActivate(string handle)
        {
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
            Actions actions = new Actions(driver);
            actions.MoveToElement(confirmDeactivateActivate).Click().Perform();
            driver.SwitchTo().Window(handle);
            WaitForPageToLoad();
        }
        internal void ConfirmPartnerDeactivated()
        {
            Assert.IsTrue(PartnerName.GetAttribute("readonly") != null, "Partner name has not been made read only after partner deactivation");
            Assert.IsTrue(WarningNotif.Text == readonlyNotif, "No read only warning message displayed");
        }

        internal void ConfirmPartnerActive()
        {
            Assert.IsTrue(PartnerName.GetAttribute("readonly") == null, "Partner name remains read only");
            bool isWarningDisplayed;
            try
            {
                isWarningDisplayed = WarningNotif.Displayed;
            }
            catch(NoSuchElementException) 
            { 
                isWarningDisplayed = false;
            }
            Assert.False(isWarningDisplayed, "Read only warning message still present");
        }

        internal void ClickDeleteButton()
        {
            ClickElement(DeleteButton);
        }

        internal void ValidateMandatoryFields()
        {
            Assert.AreEqual("Partner Name: Required fields must be filled in.", PartnerNameErrorMessage.Text, "Partner Name error message is not displayed!");
            Assert.AreEqual("Sector: Required fields must be filled in.", SectorErrorMessage.Text, "Sector error message is not displayed!");
            Assert.AreEqual("Partner Type: Required fields must be filled in.", PartnerTypeErrorMessage.Text, "Partner Type error message is not displayed!");
            ScrollToElement("down", () => Street1ErrorMessage);
            WaitforFewSeconds(1);
            Assert.AreEqual("Street 1: Required fields must be filled in.", Street1ErrorMessage.Text, "Street 1 error message is not displayed!");
            ScrollToElement("down", () => PostcodeErrorMessage);
            Assert.AreEqual("Postcode: Required fields must be filled in.", PostcodeErrorMessage.Text, "Postcode error message is not displayed!");
        }       
    }
}
