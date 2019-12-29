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

        public void JsTest()
        {

        }


        [Test]
        public void DoubleClickTest()
        {
            wrapperFunctions.Doubleclick("xpath", "//div[2]/button");

        }

        [Test]

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
