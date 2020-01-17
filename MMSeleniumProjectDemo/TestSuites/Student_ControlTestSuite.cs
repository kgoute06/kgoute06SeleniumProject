using System;
using System.Configuration;
using System.Data;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSeleniumProjectDemo.TestUtils;
using NUnit.Framework;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestClass]
    public class Student_ControlTestSuite : TestModuleBase
    {
        string stdControllApp = ConfigurationManager.AppSettings["student_controls"];
        string baseDirpath = baseDir + "";





        [SetUp]
        public void SetUp()
        {

            wrapperFunctions.OpenURL(stdControllApp);

        }

        [Test]
        public void ScrollTest()
        {
            wrapperFunctions.ScrollPage("down");
        }


        [Test]

        public void ActionClassDragAndDrop()
        {
            wrapperFunctions.CustomImplicitWait(20);
            wrapperFunctions.ReadAllHyperLinksandClickonSpecificHyperLink("Actions");
            wrapperFunctions.CustomImplicitWait(20);
            string actualDestinationPlace= wrapperFunctions.HandlingActionsClasses("id", "draggable", "id", "droppable");
            if(actualDestinationPlace.Equals("Dropped!"))
            {
                Console.WriteLine("working fine");
            }


        }

        [Test]

        public void ButtonBoolVerification()
        {
            wrapperFunctions.CustomImplicitWait(20);
            wrapperFunctions.ReadAllHyperLinksandClickonSpecificHyperLink("Actions");
            wrapperFunctions.CustomImplicitWait(20);
            bool uiEelement=wrapperFunctions.VerifyElementPresentInUI("xpath", "//div[1]/button[2]");
            if(uiEelement)
            {
                Console.WriteLine("Element is present");
            }
        }


        [Test]
        public void DoubleClickTest()
        {
            wrapperFunctions.Doubleclick("xpath", "//div[2]/button");

        }

        [Test]
        public void BackgroundColorTest()
        {
            wrapperFunctions.CustomImplicitWait(20);
            wrapperFunctions.ReadAllHyperLinksandClickonSpecificHyperLink("Actions");
            wrapperFunctions.CustomImplicitWait(20);
            string backgrondColovrValue= wrapperFunctions.GetBackgroundColor("id", "div2");
            if(backgrondColovrValue.Equals("rgba(0, 0, 255, 1)"))
            {
                Console.WriteLine("working fine");
            }
        }

        public void DBTest1()
        {
            String dbType = "ACSU";
            String envNum = ConfigurationManager.AppSettings["environment"];
            String dbName = ConfigurationManager.AppSettings[dbType + "_" + envNum];
            String dbServer = ConfigurationManager.AppSettings[dbType + "_Server"];

            String DBAdmissionSource = "select * from acsuAdmissionSource where regionid = '1674' ";

     

            DBConnect db = new DBConnect(DBAdmissionSource, dbName, dbServer);
            DataTable dt = db.ExecuteDBQuery();

            string dbCodefromADT = dt.Rows[0]["Code from ADT"].ToString();
        }


    }
}
