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


    

        [SetUp]
        public void SetUp()
        {

          wrapperFunctions.OpenURL(appUrl);
        }

        [Test]

        public void GettextfromUI()
        {
            string text = wrapperFunctions.GetElementText("xpath", "/html/body/div/table/tbody/tr/td[2]/table/tbody/tr[4]/td/table/tbody/tr/td[2]/table/tbody/tr[2]/td[3]/form/table/tbody/tr[3]/td[1]/img");
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
        public void MecuryLognwithNUnitTest_Failed()
        {
          
            Thread.Sleep(5000);
            logger.Info("Entering the UserName");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.mUserNamelocator, uName);
            logger.Info(" Entering the Password");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.passwordlocator, password);
            logger.Info("Clicking on Login button");
            wrapperFunctions.ClickElement("Name", MercuryloginPageLocator.loginLocator);

            Assert.Fail();


        }


        [Test]
        [Category("kgoute")]
        public void MecuryLognwithNUnitTest1()
        {
            testrepo.CreateTest("MecuryLoginFailedone");
            Thread.Sleep(5000);
            logger.Info("Entering the UserName");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.mUserNamelocator, uName);
            logger.Info(" Entering the Password");
            wrapperFunctions.EnterTextbyLocator("Name", MercuryloginPageLocator.passwordlocator, password);
            logger.Info("Clicking on Login button");
            wrapperFunctions.ClickElement("Name", MercuryloginPageLocator.loginLocator);
            
            Assert.True(true);



        }



        [TearDown]
        public void TearDown()
        {
            testrepo.CreateTest("MecuryLoginFailedone");
            wrapperFunctions.TakeScreenshot("MecuryLoginscreenshot");
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "<pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            

        
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            testrepo.CreateTest("MecuryLoginFailedone");
            testrepo.Flush();
            wrapperFunctions.CloseandQuitApp();
        }
    }
}
