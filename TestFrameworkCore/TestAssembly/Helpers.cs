using AventStack.ExtentReports.Utils;
using OpenQA.Selenium;
using Protractor;
using System;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Data.SqlClient;
using He.TestFramework.TestBase.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Resources;
using TestFrameworkCore;
using System.Buffers.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using AventStack.ExtentReports.Model;
using Bogus;
using System.Collections.Generic;

namespace TestFrameworkWeb.TestAssembly
{
    public static class Helpers
    {

        public static void UploadDocument(NgWebElement UploadButton, string DocPath = "")
        {
            //string path = "";
            //DirectoryInfo projDir = new DirectoryInfo(Environment.CurrentDirectory);
            //if (DocPath.IsNullOrEmpty())
            //    path = projDir.Parent.Parent.FullName + @"\UploadFile\UploadDoc.pdf";
            //else
            // path = DocPath;

            UploadButton.SendKeys(DocPath);

        }

        //public static string ConvertToCurrency(string amount)
        //{
        //    string currency = amount;
        //    int len = amount.IndexOf(".");

        //    for (int i = len, j = 1; i > 2; i--, j++)
        //    {
        //        if (j % 3 == 0)
        //            currency = currency;
        //    }

        //    return currency;
        //}
        //public static bool IsElementPresent(By by, IWebDriver driver)
        //{
        //    if (driver.FindElements(by).Count != 0)
        //        return true;
        //    else
        //        return false;
        //}


        public static bool IsElementDisplayed(By webElement, IWebDriver driver)
        {
            //bool flag = false;
            StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            try
            {
                return driver.FindElement(webElement).Displayed;
                //StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["IMPLICIT_WAIT"]));
            }
            catch (NoSuchElementException)
            {
                return false;
                //StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["IMPLICIT_WAIT"]));
            }
            StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["IMPLICIT_WAIT"]));
        }

        //StaticObjectRepo.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["IMPLICIT_WAIT"]));


        // To be added to base page at later time
        public static void ClearField(NgWebElement field)
        {
            field.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        public static void SelectListOptionByPartialText(IWebElement ListElement, string text = "")
        {
            int i = 1;
            IWebElement[] ListOptions = ListElement.FindElements(By.CssSelector("option")).ToArray();
            SelectElement selectElement = new SelectElement(ListElement);
            for (; i <= ListOptions.Count(); i++)
            {
                if (ListOptions[i].Text.Contains(text))
                {
                    selectElement.SelectByIndex(i);
                    break;
                }
            }
        }


        public static bool IsSectionCompleted(IWebElement[] elementList)
        {
            bool SCompleted = false;

            foreach (IWebElement el in elementList)
            {
                if (el.GetAttribute("type").ToLower().Equals("checkbox") && el.Selected)
                    SCompleted = true;
                else if (el.GetAttribute("type").ToLower().Equals("text") && !el.Text.IsNullOrEmpty())
                    SCompleted = true;
            }
            return SCompleted;
        }

        public static string FormatNumber<T>(T number, int maxDecimals = 8)
        {
            return Regex.Replace(String.Format("{0:n" + maxDecimals + "}", number),
                                 @"[" + System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "]?0+$", "");
        }

        //public static void ExecuteQuery()
        //{

        //    try
        //    {

        //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        //        builder.DataSource = "sql-ccflow-qa-01.database.windows.net";
        //        builder.UserID = "amos.awaghade@homesengland.gov.uk";
        //        builder.Password = "password";
        //        builder.InitialCatalog = "sqldb-elsa-ccflow-qa-01";

        //        SqlConnection connection = new SqlConnection(builder.ConnectionString);

        //            Console.WriteLine("\nQuery data example:");
        //            Console.WriteLine("=========================================\n");

        //            connection.Open();

        //            String sql = "SELECT * FROM Elsa.WorkflowInstances";

        //            SqlCommand command = new SqlCommand(sql, connection);

        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //    Console.WriteLine("\nDone. Press enter.");
        //    Console.ReadLine();
        //}


        public static string GetResourceUser(String key)
        {
            string returnVal;
            ResourceManager myManager = new ResourceManager(typeof(QAUsers));
            returnVal = myManager.GetString(key);

            return returnVal;
        }

        public static string GetRandomPostcode()
        {
            string[] Postcodes = { "SK7 1DG", "L16 3GS", "KY8 3QR", "BD1 1NT", "EH48 3EX", "PO20 8SS", "PL17 7PH", "B49 5HZ", "BS36 2SS", "NG13 8YT", "EH19 3GQ", "TN37 7ST", "CH48 6DS", "CF64 5BQ", "TQ10 9FB", "PO14 3AD", "OX16 5UA", "G81 4SS", "BD20 8HL", "LL30 2JX", "G31 2LF", "PH1 2HU", "PH2 1TQ", "CV6 7JP", "BH22 8LB" };
            List<string> PostcodeList = Postcodes.ToList();

            var rand = new Faker();

            string SelectedPostcode = rand.PickRandom<string>(PostcodeList);

            return SelectedPostcode;

        }

        public static string encryptXOR(string message, string key)
        {

            try
            {
                if (message == null || key == null)
                    return null;
                char[] keys = key.ToCharArray();
                char[] mesg = message.ToCharArray();
                int ml = mesg.Length;
                int kl = keys.Length;
                char[] newmsg = new char[ml];
                for (int i = 0; i < ml; i++)
                {
                    newmsg[i] = (char)(mesg[i] ^ keys[i % kl]);
                }
                mesg = null;
                keys = null;
                return Convert.ToBase64String(newmsg.Select(c=>(byte)c).ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException occured: " + e.Message);
                return null;
            }
        }

        public static String dcryptXOR(string message, string key)
        {

            try
            {
                if (message == null || key == null)
                    return null;
                char[] keys = key.ToCharArray();
                char[] mesg = Encoding.UTF8.GetChars(Convert.FromBase64String(message));
                int ml = mesg.Length;
                int kl = keys.Length;
                char[] newmsg = new char[ml];
                for (int i = 0; i < ml; i++)
                {
                    newmsg[i] = (char)(mesg[i] ^ keys[i % kl]);
                }
                mesg = null;
                keys = null;
                return new String(newmsg);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException occured: " + e.Message);
                return null;
            }
        }
    }
}

