using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void DoubleClickTest()
        {
            wrapperFunctions.Doubleclick("xpath", "//div[2]/button");

        }
    }
}
