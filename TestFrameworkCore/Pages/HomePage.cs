using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestFrameworkCore.Pages
{
    public class HomePage : BasePage
    {
        public new IWebDriver driver;
        private readonly ScenarioContext sContext;
        public HomePage(IWebDriver _driver, ScenarioContext injectedContext) : base(_driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

    }
}
