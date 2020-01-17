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
using System.ComponentModel;
using System.Collections.ObjectModel;

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

        public override void OpenURL(string appUrl)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.Navigate().GoToUrl(appUrl);
        }

        public override void OpenNewTabInSameBrowserInstance(string url)
        {
            string firstTabHandle = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(firstTabHandle);
            driver.FindElement(By.CssSelector("Body")).SendKeys(Keys.Control + "t");
            string secondTabHandle = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(secondTabHandle);
            string secondPageUrl = url;
            driver.Navigate().GoToUrl(secondPageUrl);
            Thread.Sleep(2000);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="locatorName"></param>
        /// <param name="pathFindlocator"></param>
        /// <param name="testData"></param>

        public override void EnterTextbyLocator(string locatorName, string pathFindlocator, string testData = "")
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));
            var IJavaScriptExecutor = (IJavaScriptExecutor)driver;
            IJavaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", element);
            element.Click();
            element.Clear();
            element.SendKeys(testData);
        }


        /// <summary>
        /// 
        /// </summary>
        public override void CloseandQuitApp()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }

        public override void ClickElement(string locatorName, string pathFindlocator)
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));
            var IJavaScriptExecutor = (IJavaScriptExecutor)driver;
            IJavaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", element);
            element.Click();

        }

        public override List<string> ListofRadioorcheckbox(string locatorName, string pathFindlocator)
        {
            List<string> radiocheckbox = new List<string>();
          ReadOnlyCollection<IWebElement> rc=  driver.FindElements(GetLocator(locatorName, pathFindlocator));
            foreach (var item in rc)
            {
             var rcstatus=   item.GetAttribute("checked");
                
               string radios= item.Text;
                radiocheckbox.Add(item.Text);
            }

            return radiocheckbox;


        }

        public override void ReadAllHyperLinksandClickonSpecificHyperLink(string anchorLinkName)
        {
           
            ReadOnlyCollection<IWebElement> anchorLists = driver.FindElements(By.TagName("a"));
            foreach (var anchor in anchorLists)
            {

                try
                {
                    if (anchor.Text.Contains(anchorLinkName))
                        anchor.Click();
                }
                catch(StaleElementReferenceException e)
                {
                    Console.WriteLine(e);
                }





            }

           

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


        /// <summary>
        /// This method will return the inner text for the specified web element 
        /// </summary>
        /// <param name="locatorName"></param>
        /// <param name="pathFindlocator"></param>
        /// <returns></returns>
        public override string GetElementText(string locatorName, string pathFindlocator)
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));

            var uiText = element.Text;

            return uiText;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seconds"></param>
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


        public override void ScrollPage(string scrolloption)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            switch (scrolloption.ToLower())
            {
                case "up":
                    js.ExecuteScript("window.scrollTo(document.body.scrollHeight,0)");
                    break;
                case "down":
                    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                    break;
                case "right":
                    js.ExecuteScript("window.scrollBy(4000,0)");
                    break;
                case "left":
                    js.ExecuteScript("window.scrollBy(-4000,0)");
                    break;
            }
        }

        public override void ClickFirstElement(string locatorName, string pathFindlocator)
        {
            /// No Need of Test Data object here...
            IList<IWebElement> elements = GetElements(locatorName, pathFindlocator);

            foreach (IWebElement ele in elements)
            {
                if (ele.Enabled)
                    ele.Click();
                else
                {
                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
                    logger.Error(errMsg);
                    throw new Exception(errMsg);
                }

                break;

            }
        }

        //DotNetSeleniumExtras.WaitHelpers
        public override void WaitTillElementAppears(string locatorName, string pathFindlocator, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                logger.Info("Waiting for the element to be visible");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(GetLocator(locatorName, pathFindlocator)));
                logger.Info("element is visible");
            }
            catch (Exception e)
            {
                logger.Error("No Element Found: ", e);
                throw e;
            }
        }

        //DotNetSeleniumExtras.WaitHelpers

        public override void WaitTillElementIsClickable(string locatorName, string pathFindlocator, int timeout)
        {
            logger.Info("Waiting for element to be clickable");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetLocator(locatorName, pathFindlocator)));
            logger.Info("Done Waiting");
        }

        public override void UnselectAllCheckboxes(string locatorName, string pathFindlocator)
        {
            IList<IWebElement> element = GetElements(locatorName, pathFindlocator);
            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].Selected & element[i].Enabled)
                {
                    element[i].Click();
                    //ClickElement(locator, testData);
                }
            }
        }

        public override void SelectSingleCheckbox(string locatorName, string pathFindlocator)
        {
            IWebElement element = GetElement(locatorName, pathFindlocator);
            scrollElement(element);
            if (!element.Selected)
            {
                if (element.Enabled)
                    element.Click();
                else
                {
                    String errMsg = "Element is not enabled on the DOM with locator :" + element.Text;
                    logger.Error(errMsg);
                    //throw new Exception(errMsg);
                }
            }

        }

        /// <summary>
        /// check if the driver is active or closed and return true or false accordingly
        /// </summary>
        /// <returns></returns>
        public override bool isChildWindowClosed()
        {
            if (driver.WindowHandles.Count() == 1)
                return true;
            else
                return false;
        }


        public void scrollElement(IWebElement webElement)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                //logger.Info("Scrolled to the Element.. ");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IWebElement GetElement(string locatorName, string pathFindlocator)
        {
            IList<IWebElement> elements = GetElements(locatorName, pathFindlocator);
            return elements[0];
        }

        public override void Doubleclick(string locatorName, string pathFindlocator)
        {
            IList<IWebElement> elements = GetElements(locatorName, pathFindlocator);
            Actions action = new Actions(driver);

            foreach (IWebElement ele in elements)
            {
                if (ele.Enabled)
                {
                    action.DoubleClick(ele);
                    action.Perform();
                }
                else
                {
                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
                    logger.Error(errMsg);
                    throw new Exception(errMsg);
                }
            }
        }




        public override void CloseDriverInstances()
        {
            try
            {

                foreach (var proc in Process.GetProcessesByName("IEDriverServer"))
                {
                    proc.Kill();
                }
            }
            catch (Win32Exception e)
            {
                logger.Info("The process is terminating or could not be terminated." + e.Message);
            }
            catch (InvalidOperationException e)
            {
                logger.Info("The process has already exited." + e.Message);
            }

            catch (Exception e)  // some other exception
            {
                logger.Info("{0} Exception caught.", e);
            }
        }

        public override List<String> FindChildElementText(string locatorName, string pathFindlocator)
        {
            IList<IWebElement> elements = GetElements(locatorName, pathFindlocator);
            List<String> elementText = new List<String>();
            foreach (IWebElement element in elements)
            {
                if (!element.Text.Equals(""))
                {
                    elementText.Add(element.Text);
                }
            }
            return elementText;
        }


        /// <summary>
        ///     This method will return the current page title. 
        /// </summary>
        /// <returns></returns>
        public override String GetCurrentPageTitle()
        {
            return driver.Title;
        }

        /// <summary>
        ///     This method will return the Current page URL.
        /// </summary>
        /// <returns></returns>
        public override String GetCurrentPageURL()
        {
            return driver.Url;
        }

        public void SwitchToWindow(int index)
        {
            IList<string> windows = new List<string>(driver.WindowHandles);

            driver.SwitchTo().Window(windows[index]);
        }


        public override void TaboutTextbox(string locatorName, string pathFindlocator)
        {
            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));
            element.SendKeys(Keys.Tab);

        }

        public override string GetBackgroundColor(string locatorName, string pathFindlocator)
        {

            IWebElement element = driver.FindElement(GetLocator(locatorName, pathFindlocator));

            string bgcolor = element.GetCssValue("background-color").ToString();

            return bgcolor;

        }



        public IList<IWebElement> GetElements(string locatorName, string pathFindlocator)
        {
            IList<IWebElement> elements = new List<IWebElement>();
            /// If we want to search on a particualr webElement add it into locator object...
            /// if (locator.)
            elements = driver.FindElements(GetLocator(locatorName, pathFindlocator));

            if (elements.Count == 0)
            {
                String errMsg = "Couldn't find the WebElement on the DOM: ";
                logger.Error(errMsg);
                throw new Exception(errMsg);
            }
            else
                return elements;
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
                case "classname":
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

        public override void SetDropDownValue(IWebElement ulElement, string text)
        {
            IList<IWebElement> elements = new List<IWebElement>();

            var liItems = ulElement.FindElements(By.ClassName("k-item"));

            var javaScriptExecutor = (IJavaScriptExecutor)driver;
            foreach (var item in liItems)
            {
                var dropDownText = javaScriptExecutor.ExecuteScript("return arguments[0].innerText;", item).ToString();
                if (dropDownText == text)
                {
                    javaScriptExecutor.ExecuteScript("arguments[0].click()", item);
                    break;
                }
            }
        }

        public override string GettextByUsingTagName(string tagName)
        {
            IWebElement text = driver.FindElement(By.TagName(tagName));
            string gettextfromURL = text.Text;

            return gettextfromURL;

        }

        public override string HandlingActionsClasses(string sourcelocatorName, string sourcePathFindlocator,string targelocatorName, string targetPathFindlocator)
        {
            IWebElement sourcePlace = driver.FindElement(GetLocator(sourcelocatorName, sourcePathFindlocator));
            IWebElement dropIntoplace = driver.FindElement(GetLocator(targelocatorName,targetPathFindlocator));

            // Wait until all event handlers are installed.
           

            Actions actionProvider = new Actions(driver);
            actionProvider.DragAndDrop(sourcePlace, dropIntoplace).Perform();

            string destinationtext = dropIntoplace.FindElement(By.TagName("p")).Text;

            return destinationtext;



        }

        public override bool VerifyElementPresentInUI(string locatorName, string pathFindlocator)
        {
          bool element = driver.FindElement(GetLocator(locatorName, pathFindlocator)).Displayed;

            return element;         

            
        }

        public override void HandlingAjaxCall(int timeout)
        {
            timeout = 40;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                if (sw.Elapsed.Seconds > timeout) throw new Exception("Timeout");
                var ajaxIsComplete = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                    break;
                Thread.Sleep(100);
            }
        }


    }
}








