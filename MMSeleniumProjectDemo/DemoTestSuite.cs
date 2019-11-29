using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMAutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using MMSeleniumProjectDemo.TestUtils;
using ACSUTestAutomation.AutomationToolImpl;

using MMSeleniumProjectDemo.PageObjects;
using System.Collections.Generic;

namespace MMSeleniumProjectDemo
{
    [TestClass]
    public class DemoTestSuite : TestModuleBase
    {        
        string appUrl = ConfigurationManager.AppSettings["AppUrl1"];
        string appUrl2 = ConfigurationManager.AppSettings["AppUrl2"];
        string uName = ConfigurationManager.AppSettings["UserName"];
        string password = ConfigurationManager.AppSettings["Password"];
        string browser = ConfigurationManager.AppSettings["Browser"];
        string excelPath = ConfigurationManager.AppSettings["Excelpath"];
        string sheetName = ConfigurationManager.AppSettings["sheetName"];




        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [TestMethod]
        public void MercuryLoginPage()
        {
            
            SetDriver();
            Thread.Sleep(5000);
            

            logger.Info("Lanch");
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl(appUrl);
            
            IWebElement userName = driver.FindElement(By.Name(MercuryloginPageLocator.mUserNamelocator));
            userName.Click();
            logger.Info("Entering the UserName");
            userName.SendKeys(uName);
   
            IWebElement pwd = driver.FindElement(By.Name(MercuryloginPageLocator.passwordlocator));
            pwd.Click();
            logger.Info("Enterign the Password");
            pwd.SendKeys(password);
            IWebElement signButton = driver.FindElement(By.Name(MercuryloginPageLocator.loginLocator));
            signButton.Submit();
            logger.Info("Mecury Login Page succesfully");
            Assert.AreEqual("Login Successfully", "Login Successfully");
            
            driver.Quit();
        }

        [TestMethod]
        public void StudentHomeTest()
        {
            SetDriver();
            Thread.Sleep(5000);
            driver.Manage().Window.Maximize();

            logger.Info("Lanch");
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl(appUrl2);
            ExcelLibrary.PopulateInCollection(excelPath, sheetName);

            string fNameData = ExcelLibrary.ReadData(1, "FirstName");
            string lNameData = ExcelLibrary.ReadData(1, "LName");
       

            IWebElement firstName = driver.FindElement(By.Id(StudentPageLocator.firstNameIdLocator));
            firstName.Click();
            logger.Info("Entering the FirstName");
            firstName.SendKeys(fNameData);

            IWebElement LastName = driver.FindElement(By.Id(StudentPageLocator.firstNameIdLocator));
            LastName.Click();
            logger.Info("Enterign the LastName");
            LastName.SendKeys(lNameData);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("StudentHomeTest.png", ScreenshotImageFormat.Png);
         
        }


        [TestMethod]
        public void MercuryLoginPageTestwithWrapper()
        {
            wrapperFunctions.OpenURL(appUrl);

            Thread.Sleep(5000);
            logger.Info("Entering the UserName");
            wrapperFunctions.EnterTextbyLocator("Name",MercuryloginPageLocator.mUserNamelocator, uName);

            logger.Info("Enterign the Password");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.passwordlocator, password);
            IWebElement signButton = driver.FindElement(By.Name(MercuryloginPageLocator.loginLocator));
            signButton.Submit();
            logger.Info("Mecury Login Page succesfully");
            Assert.AreEqual("Login Successfully", "Login Successfully");

            driver.Quit();
        }
   
        [TestMethod]

        public void TabldataAutomation()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            // WebPage which contains a WebTable
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");
            

            // xpath of html table
            var elemTable = driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else
                {
                    // To print the data into the console
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
                Console.WriteLine(strRowData);
                strRowData = String.Empty;
            }
        }

        [TestMethod]
        public void tableDataReading1()
        {
             driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();

            // WebPage which contains a WebTable
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");

            SeleniuimUtilies.ReadTable(driver);

          string columnDataFromTable=  SeleniuimUtilies.ReadCell("Notes", 3);
        }


        [TestMethod]
        public void tableDataReading()
        {
            driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();

            // WebPage which contains a WebTable
            driver.Navigate().GoToUrl("file:///C:/Users/kgoute/Desktop/Table1.html");

            SeleniuimUtilies.ReadTable(driver);

            string columnDataFromTable = SeleniuimUtilies.ReadCell("Firstname", 2);
        }



        private void SetDriver()
        {
            switch (browser.ToString().ToLower())
            {
                case "ff":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.IgnoreZoomLevel = true;
                    options.EnableNativeEvents = false;
                    driver = new InternetExplorerDriver(options);
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("disable-extensions");
                    driver = new ChromeDriver(chromeOptions);
                    break;

            }

        }


    }
}
