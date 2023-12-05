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
        public static ContactsPage contactsPage;

        [ThreadStatic]
        public static ContactsFormPage contactsFormPage;

        [ThreadStatic]
        public static PartnersPage partnersPage;

        [ThreadStatic]
        public static PartnersDetailsPage partnersDetailsPage;

        [ThreadStatic]
        public static LoginPage dashboardPage;

        [ThreadStatic]
        public static BasePage basePage;

        [ThreadStatic]
        public static Accessibility axe;

        [ThreadStatic]
        public static PartnerFormPage partnerFormPage;


        [ThreadStatic]
        public static PartnersQuickFormPage partnersQuickFormPage;

        [ThreadStatic]
        public static InteractionsPage interactionsPage;

        [ThreadStatic]
        public static InteractionsFormPage interactionsFormPage;

        [ThreadStatic]
        public static CompaniesHouseSearchPage companiesHouseSearchPage;
    }
}
