using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using static TestFrameworkCore.TestAssembly.PageObjectRepo;
using TechTalk.SpecFlow;
using System.Configuration;
using System;
using TestFrameworkWeb.TestAssembly;
using OpenQA.Selenium.Interactions;

namespace TestFrameworkCore.Pages
{
    public class LoginPage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;


        private IWebElement SignInLabel => driver.FindElement(By.CssSelector("div[role='heading']"));
        private IWebElement Username => driver.FindElement(By.CssSelector("input[type='email']"));
        private IWebElement Password => driver.FindElement(By.CssSelector("input[type='password']"));
        private IWebElement NextButton => driver.FindElement(By.CssSelector("#idSIButton9"));
        private IWebElement AnotherAccountLink => driver.FindElement(By.CssSelector(".row.tile #otherTile"));
        private By DontShowCheckbox => By.CssSelector("#KmsiCheckboxField");
        //private IWebElement RegistryLink => driver.FindElement(By.CssSelector("div[class='elsa-flex elsa-items-center'] > div:nth-child(2) stencil-route-link:nth-child(3) > a"));
        //private IWebElement HomesLink => driver.FindElement(By.CssSelector("div[class='elsa-flex elsa-items-center'] > div:nth-child(1) stencil-route-link:nth-child(1) > a"));

        private IWebElement ContinueButton => driver.FindElement(By.CssSelector("button[type='submit']"));


        public LoginPage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
            //((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom = '90%'");
        }

        internal void ValidateHeader()
        {
            WaitForPageToLoad();
            Assert.AreEqual("Sign in", SignInLabel.Text, "Login page not displayed!");

        }


        internal void Login(string UserType = "Admin")
        {
           // string encloded = "";
            WaitForPageToLoad();
            string UNameKey = AppReader.GetConfigValue(UserType + "Username");
            string UPassKey = AppReader.GetConfigValue(UserType + "Password");

            if (AppReader.GetConfigValue("Execution").ToLower().Equals("local"))
            {
                StaticObjectRepo.UserName = Helpers.GetResourceUser(UNameKey);
                
                // StaticObjectRepo.Password = Helpers.dcryptXOR(Helpers.GetResourceUser(UPassKey), "SinglePipeline");
                // removed line due to issues with character in password
                // do not push this change
                StaticObjectRepo.Password = Helpers.dcryptXOR(Helpers.GetResourceUser(UPassKey), "SinglePipeline");

            }
            else if (AppReader.GetConfigValue("Execution").ToLower().Equals("pipeline"))
                AzureSecret.GetCredentialsFromAzureSecrets(UNameKey, UPassKey).Wait();


            EnterText(Username, StaticObjectRepo.UserName);
            Console.WriteLine("Username entered: " + StaticObjectRepo.UserName);
            ClickOnElement(NextButton);

            WaitForPageToLoad();
            EnterText(Password, StaticObjectRepo.Password);

            Console.WriteLine("Password entered is encrypted: " + Helpers.GetResourceUser(UPassKey));
            ClickOnElement(NextButton);
            //if (UserType.ToLower().Equals("admin"))
            //{ 
            //    WaitUntilElementClickable(DontShowCheckbox);
            //    ClickOnElement(NextButton);
            //}

            try
            {
                StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                WaitUntilElementClickable(DontShowCheckbox);
                StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["IMPLICIT_WAIT"]));

                ClickOnElement(NextButton);
            }
            catch (Exception e)
            {
                Console.WriteLine("Do not show message box not diaplayed. \n\nError: " + e.Message);
            }

            appLandingPage = new AppLandingPage(driver, sContext);
        }

        internal void UseAnotherAcc()
        {
            ClickOnElement(AnotherAccountLink);
            WaitforFewSeconds(3);
        }
    }
}
