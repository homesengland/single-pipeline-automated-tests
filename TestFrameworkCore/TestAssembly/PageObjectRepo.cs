using TestFrameworkCore.Pages;
using He.TestFramework.TestBase.Web;
using OpenQA.Selenium;
using System;

namespace TestFrameworkCore.TestAssembly
{
    //-------------------------------------------------------------------------------------//
    //                     Page instance repositoryer to define class instances            // 
    //-------------------------------------------------------------------------------------//
    public static class PageObjectRepo
    {
        [ThreadStatic]
        public static AppLandingPage appLandingPage;

        [ThreadStatic]
        public static HomePage homePage;
        
        [ThreadStatic]
        public static LoginPage loginPage;

        [ThreadStatic]
        public static HomePage contactsPage;

        [ThreadStatic]
        public static LoginPage dashboardPage;

        [ThreadStatic]
        public static BasePage basePage;

        [ThreadStatic]
        public static SuperCalculatorPage superCalculatorPage;

        [ThreadStatic]
        public static Accessibility axe;
 
    }
}
