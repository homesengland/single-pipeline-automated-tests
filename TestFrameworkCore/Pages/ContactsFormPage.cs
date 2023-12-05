using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System.Configuration;
using System;
using TestFrameworkWeb.TestAssembly;
using Bogus.DataSets;
using OpenQA.Selenium.Interactions;

namespace TestFrameworkCore.Pages
{
    public class ContactsFormPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;


        private IWebElement Header => driver.FindElement(By.CssSelector("h1"));
        private IWebElement SummaryContainer => driver.FindElement(By.CssSelector("div[aria-label='Summary']"));
        private IWebElement Firstname => driver.FindElement(By.CssSelector("input[aria-label='First Name']"));
        private IWebElement Lastname => driver.FindElement(By.CssSelector("input[aria-label='Last Name']"));
        private IWebElement JobTitle => driver.FindElement(By.CssSelector("input[aria-label='Job Title']"));
        private IWebElement Partner => driver.FindElement(By.CssSelector("input[aria-label='Partner, Lookup']"));
        private IWebElement PartnerSearch => driver.FindElement(By.CssSelector("button[title='Search']"));
        private IWebElement PartnerList => driver.FindElement(By.CssSelector("div[aria-label='Company Name Lookup results'] > ul > li"));
        private IWebElement PartnerSelected => driver.FindElement(By.CssSelector("ul[title='Partner']"));
        private IWebElement Email => driver.FindElement(By.CssSelector("input[aria-label='Email']"));
        private IWebElement SaveClose => driver.FindElement(By.CssSelector("button[aria-label='Save & Close']"));
        private IWebElement Street1 => driver.FindElement(By.CssSelector("input[aria-label='Street 1']"));
        private IWebElement Street2 => driver.FindElement(By.CssSelector("input[aria-label='Street 2']"));
        private IWebElement City => driver.FindElement(By.CssSelector("input[aria-label='City']"));
        private IWebElement Postcode => driver.FindElement(By.CssSelector("input[aria-label='Postcode']"));
        private By DontShowCheckbox => By.CssSelector("#KmsiCheckboxField");
        private IWebElement FnameErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='firstname-error-message']"));
        private IWebElement LnameErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='lastname-error-message']"));
        private IWebElement JobtitleErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='jobtitle-error-message']"));
        private IWebElement PartnerErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='parentcustomerid-error-message']"));
        private IWebElement EmailErrorMessage => driver.FindElement(By.CssSelector("span[data-id$='emailaddress11-error-message']"));
        private IWebElement DeleteAddedPartner => driver.FindElement(By.CssSelector("button[aria-label^='Delete']"));

        //private IWebElement RegistryLink => driver.FindElement(By.CssSelector("div[class='elsa-flex elsa-items-center'] > div:nth-child(2) stencil-route-link:nth-child(3) > a"));
        //private IWebElement HomesLink => driver.FindElement(By.CssSelector("div[class='elsa-flex elsa-items-center'] > div:nth-child(1) stencil-route-link:nth-child(1) > a"));

        private IWebElement ContinueButton => driver.FindElement(By.CssSelector("button[type='submit']"));


        public ContactsFormPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            Assert.AreEqual("New Contact", Header.Text, "Login page not displayed!");

        }


        internal void FillMandatoryContactFieldsAndSave()
        {
            FillMandatoryFields();
            //FillAddress();
            ClickOnElement(SaveClose);

        }

        internal void FillMandatoryContactFields()
        {
            FillMandatoryFields();
            //FillAddress();

        }


        private void FillAddress()
        {
            var rand = new Bogus.Faker();
            string value = "";

            value = rand.Address.BuildingNumber();
            EnterText(Street1, value);
            sContext.Add("Street1", value);

            value = rand.Address.StreetName();
            EnterText(Street2, value);
            sContext.Add("Street2", value);

            value = rand.Address.City();
            EnterText(City, value);
            sContext.Add("City", value);

            value = Helpers.GetRandomPostcode();
            ScrollToElement("down", () => Postcode);
            EnterText(Postcode,value );
            sContext.Add("Postcode", value);
        }


        internal void FillMandatoryFields()
        {
            var rand = new Bogus.Faker();
            Lorem lorem = new Lorem();
            string value = "";

            value = rand.Person.FirstName;
            EnterText(Firstname, value);
            sContext.Add("Firstname", value);

            value = rand.Person.LastName;
            EnterText(Lastname, value);
            sContext.Add("Lastname", value);

            value = lorem.Word();
            EnterText(JobTitle, value);
            sContext.Add("JobTitle", value);

            value = rand.Person.Email;
            EnterText(Email, value);
            sContext.Add("Email", value);

            ClickOnElement(PartnerSearch);
            ClickOnElement(PartnerList);

            SContext.Add("Partner", PartnerSelected.Text);
        }

        internal void ValidateFirstNameField()
        {
            EnterText(Firstname, "");
            ClickOnElement(SaveClose);
            Assert.AreEqual("First Name: Required fields must be filled in.", FnameErrorMessage.Text, "First Name error message is not displayed!");
        }

        internal void ValidateLastNameField()
        {
            EnterText(Lastname, "");
            ClickOnElement(SaveClose);
            Assert.AreEqual("Last Name: Required fields must be filled in.", LnameErrorMessage.Text, "Last Name error message is not displayed!");
        }

        internal void ValidateJobTitleField()
        {
            EnterText(JobTitle, "");
            ClickOnElement(SaveClose);
            Assert.AreEqual("Job Title: Required fields must be filled in.", JobtitleErrorMessage.Text, "JobTitle error message is not displayed!");
        }

        internal void ValidatePartnerField()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(PartnerSelected).Perform();
            ClickOnElement(DeleteAddedPartner);
            ClickOnElement(SaveClose);
            Assert.AreEqual("Partner: Required fields must be filled in.", PartnerErrorMessage.Text, "Partner error message is not displayed!");
        }

        internal void ValidateEmailField()
        {
            EnterText(Email, "");
            ClickOnElement(SaveClose);
            Assert.AreEqual("Email: Required fields must be filled in.", EmailErrorMessage.Text, "Email error message is not displayed!");
        }

        public void ScrollToElement(string direction, Func<IWebElement> elementProvider)
        {
            bool isElementVisible = false;

            ClickElement(SummaryContainer);
            while (!isElementVisible)
            {
                if (direction == "up")
                {
                    SummaryContainer.SendKeys(Keys.PageUp);
                }
                else
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
    }
}
