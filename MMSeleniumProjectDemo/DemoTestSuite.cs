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
