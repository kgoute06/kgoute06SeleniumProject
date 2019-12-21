using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSeleniumProjectDemo.TestModels;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

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

        }

        [Test]
        public void ReadTabledata_TestingControles()
        {
            

            List<string> childEle = wrapperFunctions.FindChildElementText("xpath", "//div[1]/table/tbody");

            foreach (var item in childEle)
            {
                
                if (!string.IsNullOrEmpty(item))
                {
                    
                    var res = item.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item1 in res)
                    {
                        if(item1.Contains("Sterling"))
                        {
                            Console.WriteLine(item1);
                        }
                        else
                        {
                            Assert.Fail();
                        }
                     
                    }
   

                }
            }
        }
    }
}
