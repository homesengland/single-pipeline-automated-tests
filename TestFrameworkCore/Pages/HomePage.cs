using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using He.TestFramework.TestBase.Web;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestFrameworkCore.Pages
{
    public class HomePage : BasePage
    {
        new IWebDriver driver;
        //String ExpectedHeader = "All Contacts";

        private IWebElement NewProjectButton => driver.FindElement(By.CssSelector("ul[aria-label='Project Commands'] > li:nth-child(2) > button"));
        private IWebElement BackButton => driver.FindElement(By.CssSelector("button[title='Go back']"));
        private IWebElement DiscardChangesButton => driver.FindElement(By.CssSelector("button[aria-label='Discard changes']"));
        public IWebElement Header => driver.FindElement(By.CssSelector("h1[title='All Projects'] > button > span > span"));
        public By HeaderBy => By.CssSelector("h1[title='All Projects'] > button > span > span");

        private readonly ScenarioContext sContext;
        public HomePage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        [ThreadStatic]
        public static string FullName;
        [ThreadStatic]
        public static string Email;
       // IWebElement[] RecordsList;

        public void ValidateTitle(string title="")
        {
            //WaitforFewSeconds(3);
            WaitUntilElementVisible(HeaderBy);
            Assert.AreEqual("All Projects", Header.Text);
        }

        public void CreateNewProject() 
        {
            ClickOnElement(NewProjectButton);
            WaitForPageToLoad();
            ClickOnElement(BackButton);
            ClickOnElement(DiscardChangesButton);

        }

    }
}
