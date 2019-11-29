using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

using System.Threading;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using ACSUTestAutomation.AutomationToolImpl;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using log4net.Repository.Hierarchy;
using log4net;
using System.Diagnostics;

namespace MMSeleniumProjectDemo.AutomationToolImpl
{
    public class SeleniumToolImpl : AutomationInterface
    {
        public IWebDriver driver = null;
        string browser = null;
        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SeleniumToolImpl(IWebDriver driver)
        {
            this.driver = driver;
        }


        public override void EnterTextbyLocator(string locatorName, string pathFindlocator, string testData = "")
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));
            var IJavaScriptExecutor = (IJavaScriptExecutor)driver;
            IJavaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", element);
            element.Click();
            element.Clear();
            element.SendKeys(testData);
        }

        public override void OpenURL(string appUrl)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(appUrl);
        }

        public override void CloseandQuitApp()
        {
            driver.Close();
            driver.Quit();

        }

        public override void ClickElement(string locatorName, string pathFindlocator)
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));
            var IJavaScriptExecutor = (IJavaScriptExecutor)driver;
            IJavaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", element);
            element.Click();

        }

        public override string TakeScreenshot(string screenshotName)
        {
            DateTime today = DateTime.Now;
            string screenTime = today.ToString("MMddyyHHmmss");
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\ErrorScreenshots\\" + screenshotName + screenTime + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;

        }

        public override bool SelectingCheckBox_RadioButton(string locatorName, string pathFindlocator, string message = "")
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));
            var checkboxStatus = element.GetAttribute("checked");
            if (checkboxStatus == null)
            {
                element.Click();
                logger.Info(message + " is selected");
            }
            bool radioCheckBoxStatus = element.Selected;

            return radioCheckBoxStatus;

        }

        public override string DropdownSelectByText(string locatorName, string pathFindlocator, string dropdownText)
        {
            string dropDownValue = "";
            SelectElement drpCountry = new SelectElement(driver.FindElement(GetLocator(locatorName, pathFindlocator)));
            drpCountry.SelectByText(dropdownText);
            dropDownValue = drpCountry.SelectedOption.Text;
            return dropDownValue;

        }

        public override List<string> MultipleDropdownSelectByText(string locatorName, string pathFindlocator, string dropdownText1, string dropdownText2)
        {
            List<string> dropDownValue = new List<string>();
            SelectElement drpCountry = new SelectElement(driver.FindElement(GetLocator(locatorName, pathFindlocator)));
            drpCountry.SelectByText(dropdownText1);
            drpCountry.SelectByText(dropdownText2);
            // dropDownValue.Add(drpCountry.SelectedOption.Text);
            IList<IWebElement> multipleDropDown = drpCountry.AllSelectedOptions.ToList<IWebElement>();

            foreach (IWebElement dropdownvalues in multipleDropDown)
            {
                var tableData = dropdownvalues.Text;
                dropDownValue.Add(tableData);
            }
            return dropDownValue;

        }

        public override string GetElementText(string locatorName, string pathFindlocator)
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));

            var uiText = element.Text;

            return uiText;
        }

        public override void CustomImplicitWait(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public override void SwitchToFrame(string frameName)
        {
            driver.SwitchTo().Frame(frameName);
        }

        public override string GetTextOnAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.AlertIsPresent());
            string modalText = string.Empty;
            if (driver.SwitchTo().Alert() != null)
            {
                IAlert modalwindowhandle = driver.SwitchTo().Alert();

                modalText = modalwindowhandle.Text;
                modalwindowhandle.Accept();

            }
            else
            {
                logger.Info("Alert is not present..");

            }

            return modalText;

        }

        public override string PromptAlert(string TestdataforPromptTextbox)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.AlertIsPresent());

            driver.SwitchTo().Alert().SendKeys(TestdataforPromptTextbox);
            IAlert promptpopup = driver.SwitchTo().Alert();

            string promptpopuppopupdata = promptpopup.Text;
            promptpopup.Accept();

            return promptpopuppopupdata;
        }

        public override void SwitchBetweenDifferentWindows(string windowTitle, int timeout = 90)
        {

            try
            {
                bool windowFound = false;



                string currwintitle = string.Empty;
                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (!windowFound && sw.Elapsed.TotalSeconds < timeout)
                {
                    var windowHandles = driver.WindowHandles;

                    foreach (var window in windowHandles)
                    {
                        currwintitle = driver.SwitchTo().Window(window).Title;
                        if (currwintitle.Equals(windowTitle))
                        {
                            windowFound = true;
                            driver.Close();
                            break;

                        }

                    }

                    Thread.Sleep(500);
                    logger.Info("waiting for pop up window to appear..");

                }

                if (!windowFound)
                    driver.SwitchTo().DefaultContent();

            }
            catch (Exception e)
            {
                turnOnImplicitWaits();
            }

            turnOnImplicitWaits();
        }

        public void turnOnImplicitWaits()
        {
            int implicitWait = Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitWaitInSecs"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);

        }

        public override string GetTextFromTable(string locatorName, string pathFindlocator, string expectedText)
        {
            var elemTable = driver.FindElement(GetLocator(locatorName, pathFindlocator));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            String actualRowData = "";

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        actualRowData = elemTd.Text;
                        if (actualRowData.Equals(expectedText))
                            break;

                    }
                 
                }
                if (actualRowData.Equals(expectedText))
                    break;






            }

            return actualRowData;
        }

       


        private By GetLocator(string locatorName, string pathFindlocator)
        {
            switch (locatorName.ToString().ToLower())
            {
                case "xpath":
                    return By.XPath(pathFindlocator);
                case "id":
                    return By.Id(pathFindlocator);
                case "name":
                    return By.Name(pathFindlocator);
                case "class":
                    return By.ClassName(pathFindlocator);
                case "css":
                    return By.CssSelector(pathFindlocator);
                case "link":
                    return By.PartialLinkText(pathFindlocator);
                case "tagname":
                    return By.TagName(pathFindlocator);
                case "linktext":
                    return By.LinkText(pathFindlocator);
            }

            return null;
        }



    }
}








