using System;
using NUnit.Framework;
using System.Configuration;
using AventStack.ExtentReports;
using MMSeleniumProjectDemo.Reports;
using MMSeleniumProjectDemo.PageObjects;
using System.Threading;
using MMSeleniumProjectDemo.TestUtils;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestFixture]
    public class StudentsFormTestSuite :TestModuleBase
    {

        
        string appUrl2 = ConfigurationManager.AppSettings["AppUrl2"];
        string browser = ConfigurationManager.AppSettings["Browser"];
        string excelPath = ConfigurationManager.AppSettings["Excelpath"];
        string sheetName = ConfigurationManager.AppSettings["sheetName"];



        ExtentReports testrepo = ExtentReportsManager.GetExtentInstanceReport();
       

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            testrepo.CreateTest("NUnitTestFrameworkWithMucuryApp");
        }

        [SetUp]
        public void SetUp()
        {

            wrapperFunctions.OpenURL(appUrl2);

        }

        [Test]
        public void UsersApplicationFormTest()
        {
             ExcelLibrary.PopulateInCollection(excelPath, sheetName);
            string fNameData = ExcelLibrary.ReadData(1, "FirstName");
            string lNameData = ExcelLibrary.ReadData(1, "LName");
            Thread.Sleep(5000);
            logger.Info("Entering the FirstName");
            wrapperFunctions.EnterTextbyLocator("id", StudentPageLocator.firstNameIdLocator, fNameData);
            logger.Info(" Entering the LastName");
            wrapperFunctions.EnterTextbyLocator("id", StudentPageLocator.lastNameIdLocator, lNameData);
     
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            wrapperFunctions.TakeScreenshot("MecuryLoginscreenshot");
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "<pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
