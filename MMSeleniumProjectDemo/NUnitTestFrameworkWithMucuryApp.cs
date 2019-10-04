using System;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports;
using MMSeleniumProjectDemo.PageObjects;
using MMSeleniumProjectDemo.Reports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MMSeleniumProjectDemo
{
    [TestFixture]
    public class NUnitTestFrameworkWithMucuryApp : TestModuleBase
    {
        string appUrl = ConfigurationManager.AppSettings["AppUrl1"];
        string appUrl2 = ConfigurationManager.AppSettings["AppUrl2"];
        string uName = ConfigurationManager.AppSettings["UserName"];
        string password = ConfigurationManager.AppSettings["Password"];
        string browser = ConfigurationManager.AppSettings["Browser"];
        string excelPath = ConfigurationManager.AppSettings["Excelpath"];
        string sheetName = ConfigurationManager.AppSettings["sheetName"];
        ExtentReports testrepo = ExtentReportsManager.GetExtentInstanceReport();

        ExtentTest testlogs;


        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            testrepo.CreateTest("NUnitTestFrameworkWithMucuryApp");
        }

        [SetUp]
        public void SetUp()
        {

          wrapperFunctions.OpenURL(appUrl);
        }

        [Test][Category("kgoute")]
        public void MecuryLognwithNUnitTest()
        {
         
            Thread.Sleep(5000);
            logger.Info("Entering the UserName");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.mUserNamelocator, uName);
            logger.Info(" Entering the Password");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.passwordlocator, password);
            logger.Info("Clicking on Login button");
            wrapperFunctions.ClickElement("Name", MercuryloginPageLocator.loginLocator);
            

        }


        [Test]
        [Category("kgoute")]
        public void MecuryLognwithNUnitTest1()
        {

            Thread.Sleep(5000);
            logger.Info("Entering the UserName");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.mUserNamelocator, uName);
            logger.Info(" Entering the Password");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.passwordlocator, password);
            logger.Info("Clicking on Login button");
            wrapperFunctions.ClickElement("Name", MercuryloginPageLocator.loginLocator);
            
            Assert.True(false);



        }



        [TearDown]
        public void TearDown()
        {
            wrapperFunctions.TakeScreenshot("MecuryLoginscreenshot");
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "<pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            

        
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            testrepo.Flush();
            wrapperFunctions.CloseandQuitApp();
        }
    }
}
