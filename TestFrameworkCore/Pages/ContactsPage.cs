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
    public class ContactsPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;


        private IWebElement SignInLabel => driver.FindElement(By.CssSelector("h1[title='All Contacts']> button > span > span"));
        private IWebElement AddContactButton => driver.FindElement(By.CssSelector("button[aria-label='Add Contact. New']"));
        private IWebElement FilterField => driver.FindElement(By.CssSelector("input[aria-label='Contact Filter by keyword']"));
        private IWebElement[] Filtered1stRecord => driver.FindElements(By.CssSelector(".ag-center-cols-container > div:nth-child(1) > div")).ToArray();


        private IWebElement ContinueButton => driver.FindElement(By.CssSelector("button[type='submit']"));


        public ContactsPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            WaitforFewSeconds(5);
            Assert.AreEqual("All Contacts", SignInLabel.Text, "Contacts page not displayed!");

        }

        internal void AddNewContact()
        {
            ClickOnElement(AddContactButton);
            WaitForPageToLoad();
            contactsFormPage = new ContactsFormPage(driver, sContext);
        }

        internal void Filter(string filterVal = "")
        {
            if(filterVal!="")
                EnterText(FilterField, filterVal + Keys.Enter);
            else
                EnterText(FilterField, sContext.Get<string>("Firstname") + " " + sContext.Get<string>("Lastname") + Keys.Enter);
        }

        internal void ValidateNewContact()
        {
            WaitForPageToLoad();
            Assert.AreEqual(sContext.Get<string>("Firstname") + " " + sContext.Get<string>("Lastname"), Filtered1stRecord[1].Text);
            Assert.AreEqual(sContext.Get<string>("Email"), Filtered1stRecord[2].Text);
            Assert.AreEqual(sContext.Get<string>("Partner"), Filtered1stRecord[3].Text);
            //Assert.IsTrue((Filtered1stRecord[4].Text).Contains(sContext.Get<string>("Street1")));
            //Assert.IsTrue((Filtered1stRecord[4].Text).Contains(sContext.Get<string>("Street2")));
            

        }

        
    }
}
