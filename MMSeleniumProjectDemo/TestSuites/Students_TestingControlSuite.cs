using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSeleniumProjectDemo.TestModels;
using NUnit.Framework;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestClass]
    public class Students_TestingControlSuite : TestModuleBase
    {
        string stestingControllApp = ConfigurationManager.AppSettings["Student_TestingControlUrl"];


        string baseDirpath = baseDir + "";





        [SetUp]
        public void SetUp()
        {

            wrapperFunctions.OpenURL(stestingControllApp);

        }
        [Test]
        public void GetCurrentUrlTest()
        {
            string currentUrl = wrapperFunctions.GetCurrentPageURL();

            List<string> childEle = wrapperFunctions.FindChildElementText("xpath", "//div[1]/table/tbody");

            foreach (var item in childEle)
            {
                Student_TestingControlModel tcmode = new Student_TestingControlModel();
                if (!string.IsNullOrEmpty(item))
                {
                    List<Student_TestingControlModel> stdTabledata = new List<Student_TestingControlModel>();
                    var res = item.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item1 in res)
                    {
                        Console.WriteLine(item1);
                    }
                 


                    stdTabledata.Add(tcmode);

                }
            }
        }
    }
}
