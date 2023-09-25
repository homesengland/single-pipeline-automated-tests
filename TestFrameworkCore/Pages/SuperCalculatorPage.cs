using He.TestFramework.TestBase.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace TestFrameworkCore.Pages
{
    public class SuperCalculatorPage : BasePage
    {
        private readonly ScenarioContext sContext;
        public SuperCalculatorPage(IWebDriver _driver, ScenarioContext injectedContext) : base(driver, injectedContext)
        {
            driver = _driver;
            sContext = injectedContext;
        }

        NgWebElement firstNg = ngdriver.FindElement(NgBy.Model("first"));
        IWebElement first = driver.FindElement(By.CssSelector("input[ng-model='first']"));

        NgWebElement secondNg = ngdriver.FindElement(NgBy.Model("second"));
        IWebElement second = driver.FindElement(By.CssSelector("input[ng-model='second']"));

        SelectElement operatorSelectNg = new SelectElement(ngdriver.FindElement(NgBy.Model("operator")));
        SelectElement operatorSelect = new SelectElement(driver.FindElement(By.CssSelector("select[ng-model='operator']")));

        public string LatestResult
        {
           get { return driver.FindElement(By.CssSelector("h2")).Text; }
        }

        public string LatestResultNg
        {
            get { return ngdriver.FindElement(NgBy.Binding("latest")).Text; }
        }

        public void Add(string first, string second, bool IsAngular)
        {
            DoMath(first, second, "+", IsAngular);
        }

        public void Subtract(string first, string second, bool IsAngular)
        {
            DoMath(first, second, "-", IsAngular);
        }

        public void Multiply(string first, string second, bool IsAngular)
        {
            DoMath(first, second, "*", IsAngular);
        }

        public void Divide(string first, string second, bool IsAngular)
        {
            DoMath(first, second, "/", IsAngular);
        }

        private void DoMath(string first, string second, string op, bool IsAngular)
        {
            SetFirst(first, IsAngular);
            SetSecond(second, IsAngular);
            SetOperator(op, IsAngular);
            ClickGo();
        }

        private void SetFirst(string number, bool IsAngular)
        {
            if (IsAngular)
            {
                firstNg.Clear();
                firstNg.SendKeys(number);
            }
            else
            {
                first.Clear();
                first.SendKeys(number);
            }
        }

        private void SetSecond(string number, bool IsAngular)
        {
            if (IsAngular)
            {
                secondNg.Clear();
                secondNg.SendKeys(number);
            }
            else
            {
                second.Clear();
                second.SendKeys(number);
            }
        }

        private void SetOperator(string op, bool IsAngular)
        {
            if (IsAngular)
            {
                operatorSelectNg.SelectByText(op);
            }
            else
            {
                operatorSelect.SelectByText(op);
            }
        }

        private void ClickGo()
        {
            driver.FindElement(By.Id("gobutton")).Click();
        }
    }
}
