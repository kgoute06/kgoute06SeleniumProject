﻿using System;
using NUnit.Framework;
using System.Configuration;
using AventStack.ExtentReports;
using MMSeleniumProjectDemo.Reports;
using MMSeleniumProjectDemo.PageObjects;
using System.Threading;
using MMSeleniumProjectDemo.TestUtils;
using System.Collections.Generic;
using System.IO;
using MMSeleniumProjectDemo.TestData;
using System.Collections.ObjectModel;
using System.Data;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestFixture]

    public class StudentsFormTestSuite : TestModuleBase
    {

        
        string appUrl2 = ConfigurationManager.AppSettings["AppUrl2"];
  
        string excelPath = ConfigurationManager.AppSettings["Excelpath"];
        string sheetName = ConfigurationManager.AppSettings["sheetName"];

        string baseDirpath = baseDir + "";

        ExtentReports testrepo = ExtentReportsManager.GetExtentInstanceReport();


        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            testrepo.CreateTest("NUnitTestFrameworkWithMucuryApp");
        }

        [SetUp]
        [Parallelizable]
        public void SetUp()
        {

            wrapperFunctions.OpenURL(appUrl2);

        }

        [Test]
  
        public void UUTestPractice_Students_Form_RadiobuttonByUsingLIst()
        {
          List<string> radiobutonscontrainer=  wrapperFunctions.ListofRadioorcheckbox("classname", "radio-inline");

            foreach (var item in radiobutonscontrainer)
            {
                Console.WriteLine(item);
            }



        }
        [Test]
        public void DBconnectionTest()
        {
            String dbType = "ACSU";
            String envNum = ConfigurationManager.AppSettings["environment"];
            String dbName = ConfigurationManager.AppSettings[dbType + "_" + envNum];
            String dbServer = ConfigurationManager.AppSettings[dbType + "_Server"];

            String dbEditAdmissionSource = "select * from acsuAdmissionSource where regionid = '1674'";

            Thread.Sleep(15000);

            DBConnect db1 = new DBConnect(dbEditAdmissionSource, dbName, dbServer);
            DataTable dt1 = db1.ExecuteDBQuery();
        }



     
        [Test]
        public void UUTestPractice_Students_Form()
        {
            
            ExcelLibrary.PopulateInCollection(excelPath, sheetName);
            string fNameData = ExcelLibrary.ReadData(1, "FirstName");
            string lNameData = ExcelLibrary.ReadData(1, "LName");
            Thread.Sleep(5000);
            logger.Info("Entering the FirstName");
            wrapperFunctions.EnterTextbyLocator("id", StudentPageLocator.firstNameIdLocator, fNameData);
            logger.Info(" Entering the LastName");
            wrapperFunctions.EnterTextbyLocator("id", StudentPageLocator.lastNameIdLocator, lNameData);
            wrapperFunctions.ClickElement("xpath", "/html/body/div[1]/div/div[2]/ul/li[8]/a");
            bool checkoxStatus = wrapperFunctions.SelectingCheckBox_RadioButton("xpath", "/html/body/div[2]/div[1]/div/form/div[4]/label[4]/input", "cricket");
            Assert.True(checkoxStatus, "Cricket Checkbox is checked");
            bool singleRadioButton = wrapperFunctions.SelectingCheckBox_RadioButton("xpath", "/html/body/div[2]/div[1]/div/form/div[3]/label[3]/input", "Single");
            Assert.True(singleRadioButton, "Single Radiobutton is clicked");
            string dropdowntext = wrapperFunctions.DropdownSelectByText("id", "sel1", "Canada");
            if (dropdowntext == "Canda")
            {
                logger.Info("Canada dropdown selected succesfully");
            }
            else
            {
                logger.Error("Canada dropdown not selected succesfully");
                Assert.Fail();


            }

        }

        [Test]
       
        public void UUTestPractice_Students_Select_SingleDropdownSelection()
        {
           
            
            wrapperFunctions.ClickElement("xpath", "/html/body/div[1]/div/div[2]/ul/li[8]/a");
            string dropdowntext = wrapperFunctions.DropdownSelectByText("id", "countriesSingle", "United states of America");
            if (dropdowntext == "United states of America")
            {
                logger.Info("dropdown selected correctly");
            }
            else
            {
                logger.Error("");
                Assert.Fail();


            }

        }

        [Test]
      
        public void UUTestPractice_Students_Select_MultipleDropdownSelection()
        {
            wrapperFunctions.ClickElement("xpath", "/html/body/div[1]/div/div[2]/ul/li[8]/a");
            List<string> actualDropdownValues = new List<string>();
            actualDropdownValues.Add("India");
            actualDropdownValues.Add("United states of America");

            wrapperFunctions.CustomImplicitWait(100);
            List<string> multipledropValues = wrapperFunctions.MultipleDropdownSelectByText("id", "countriesMultiple", "United states of America", "India");

            for (int i = 0; i < multipledropValues.Count; i++)
            {

                if (multipledropValues[i].Equals(actualDropdownValues[i]))
                {
                    logger.Info("Mulitple dropdown values selected correctly " + multipledropValues[i]);
                }
                else
                {
                    logger.Error("Mulitple dropdown values selected correctly");
                    Assert.Fail();

                }
            }

            
            string uiActualText = wrapperFunctions.GetElementText("id", "result");
            string expectedValue = "India United states of America";
            if(uiActualText.Equals(expectedValue))
            {
                logger.Info(string.Format("Mulitple dropdown values selected correctly and value of actualvalue is {0}  and Expected Value is  {1}" , uiActualText, expectedValue));
            }
            else
            {
                logger.Error("Mulitple dropdown values selected correctly");
                Assert.Fail();

            }


        }

        [Test]
     
        public void UUTestPractice_Students_Switchto_HandingIframe()
        {
            wrapperFunctions.ClickElement("xpath", "/html/body/div[1]/div/div[2]/ul/li[7]/a");
            wrapperFunctions.CustomImplicitWait(50);
            wrapperFunctions.SwitchToFrame("iframe_a");

            wrapperFunctions.EnterTextbyLocator("id", "name", "Handling IFrame by Krishna");

        }

        [Test]
     
        public void UUTestPractice_Students_Switchto_AlterHandling()
        {
            string expectedAlterPopwindowTex = "Hello Alert";
            //Navigate  to Switch tab
            SwitchPageNavigatioin();
            wrapperFunctions.CustomImplicitWait(50);
            wrapperFunctions.ClickElement("id", "alert");
            string actualAlterPopwindowText = wrapperFunctions.GetTextOnAlert();
         string confirmationAlertText=    wrapperFunctions.GetElementText("id", "demo");
            if(expectedAlterPopwindowTex.Equals(actualAlterPopwindowText))
            {
                logger.Info("Alter pop winodw closed and text is  " + confirmationAlertText);
            }
            else
            {
                logger.Error("Alter pop winodw is not closed");
                Assert.Fail();
            }
          
        }

        [Test]
       
        public void UUTestPractice_Students_Switchto_AlertConfirmHandling()
        {
            string expectedAlterPopwindowTex = "Hello Alert";
            //Navigate  to Switch tab
            SwitchPageNavigatioin();
            wrapperFunctions.CustomImplicitWait(50);
            wrapperFunctions.ClickElement("id", "alert");
            string actualAlterPopwindowText = wrapperFunctions.GetTextOnAlert();
            string confirmationAlertText = wrapperFunctions.GetElementText("id", "demo");
            if (expectedAlterPopwindowTex.Equals(actualAlterPopwindowText))
            {
                logger.Info("Alter pop winodw closed and text is  " + confirmationAlertText);
            }
            else
            {
                logger.Error("Alter pop winodw is not closed");
                Assert.Fail();
            }
        }

        [Test]
       
        public void UUTestPractice_Students_Switchto_PromptConfirmHandling()
        {
            string expectedAlterPopwindowTex = "Hello Alert";
            string actualPromptText = "Hello Hello Alert! How are you today?";
            //Navigate  to Switch tab
            SwitchPageNavigatioin();
            #region
            wrapperFunctions.CustomImplicitWait(50);
            #endregion
            wrapperFunctions.ClickElement("id", "prompt");
           string promptPopwindowText= wrapperFunctions.PromptAlert(expectedAlterPopwindowTex);
            string confirmationAlertText = wrapperFunctions.GetElementText("id", "demo");
            if (actualPromptText.Equals(promptPopwindowText))
            {
                logger.Info("Alter pop winodw closed and text is  " + confirmationAlertText);
            }
            else
            {
                logger.Error("Alter pop winodw is not closed");
                Assert.Fail();
            }
        }

        [Test]
        [Parallelizable]
        public void UUTestPractice_Students_Switchto_HandlingMultipleWindowHandles()
        {
            SwitchPageNavigatioin();
            ClickonLinkText();
            wrapperFunctions.SwitchBetweenDifferentWindows("Testing Controls");
            Console.WriteLine("Before click");
            Console.WriteLine("Number of windows opened by selenium : " + driver.WindowHandles.Count);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }
        }

        private void ClickonLinkText()
        {
            wrapperFunctions.ClickElement("linktext", "Opens in a new window");
        }

        private void SwitchPageNavigatioin()
        {
            wrapperFunctions.ClickElement("xpath", "/html/body/div[1]/div/div[2]/ul/li[7]/a");
        }


        [Test]
        [Parallelizable]
        public void scrollBarTest_Guru99()
        {

            wrapperFunctions.OpenURL("http://www.uitestpractice.com/Students/Form");
            wrapperFunctions.ReadAllHyperLinksandClickonSpecificHyperLink("Select");
            wrapperFunctions.ScrollPage("down");
            wrapperFunctions.ScrollPage("up");
        }

        [Test]
        [Parallelizable]
        public void scrollBarTest_Student_Controls()
        {

            wrapperFunctions.OpenURL("http://www.uitestpractice.com/Students/Form");
            wrapperFunctions.ScrollPage("down");
            wrapperFunctions.ScrollPage("up");
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

    public static class EnumSeleniumLocators
    {
        enum SeleniumLocators
        {
            id,
            xpath,
            classname,
            name,
            tagname,
            link

        }
    }
}
