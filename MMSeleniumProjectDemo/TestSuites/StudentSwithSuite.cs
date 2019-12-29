using AventStack.ExtentReports;
using MMSeleniumProjectDemo.Reports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestFixture]
    public class StudentSwithSuite : TestModuleBase
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

        public void UUTestPractice_AnchorTagText()
        {
            wrapperFunctions.CustomImplicitWait(20);
            wrapperFunctions.ReadAllHyperLinksandClickonSpecificHyperLink("Switch to");
            wrapperFunctions.CustomImplicitWait(20);
            wrapperFunctions.ReadAllHyperLinksandClickonSpecificHyperLink("Form");
        }
        [Test]

        public void UUTestPractice_Students_Switch_BackgroundColorTest()
        {
            wrapperFunctions.CustomImplicitWait(20);
            wrapperFunctions.ReadAllHyperLinksandClickonSpecificHyperLink("Home");
            wrapperFunctions.CustomImplicitWait(20);
            string bccolor = wrapperFunctions.GetBackgroundColor("xpath", "/html/body/div[2]/div[1]/table/tbody/tr[2]/td[4]/button[2]");
        }
    }
}
