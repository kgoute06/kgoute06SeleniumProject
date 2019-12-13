using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using System.Configuration;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestFixture]
    public class WebTableHandlingSuite :  TestModuleBase
    {
      
        string tableAutoUrl = ConfigurationManager.AppSettings["tableAutoUrl"];

        [SetUp]
        public void SetUp()
        {

            wrapperFunctions.OpenURL(tableAutoUrl);

        }
        [Test]
        public void WebTableTesting_Wiki()
        {
            string expectedText = "1,600,000,000";
          string actualtextfromTable=  wrapperFunctions.GetTextFromTable("xpath", "//div[@id='mw-content-text']//table[1]", expectedText);

            Assert.Equals(expectedText, actualtextfromTable);


           
        }

        [Test]
        public void WebTableTesting_Wiki1()
        {
            string expectedText = "The most visited social networking site";
            string actualtextfromTable = wrapperFunctions.GetElementText("xpath", "//div[@id='mw-content-text']//table[1]");

            Assert.Equals(expectedText, actualtextfromTable);



        }


    }
}

