//using eCACWebAutomationTests.PageModels;
//using eCACWebAutomationTests.Utils;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
//using OptumAutomationFramework.Reportings;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Configuration;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading;
//using OptumAutomationFramework.FrameworkComponents.Interface;
//using OptumAutomationFramework.FrameworkComponents.TestDataManagement;
//using eCACWebAutomationTests;

//namespace eCACAutomationTests.WebDriverImpl
//{
//    public class SeleniumWrapperImpl : AutomationToolInterface
//    {
//        public static IWebDriver driver { get; set; }
//        private IWebDriver auxDriver = null;
//        private IWebDriver tempDriver = null;
//        private static string whichWindow = "Last";
//        private static string parentWindow;
//        private static string childWindow;
//        private int defaultWaitTime = 30;
//        string value = null;
//        string url = null;

//        public static string browserName = string.Empty;
//        Logger logger = new Logger();

//        //CommonUtils cUtils = new CommonUtils();
//        private static String browser = null; //{ get; set; } ;
//        private static string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;

//        public IWebDriver GetDriver()
//        {
//            return driver;
//        }

//        public string Browser() { return browser; }



//        /// <summary>
//        /// Initializing the driver to Open Browser (Firefox, Chrome or IE)
//        /// </summary>
//        public void initialize(string browsernm)
//        {
//            string url = LoginPage.GetURL();
//            browserName = browsernm;

//            bool ensureCleanSessionOnIE = false;
//            bool headlessMode = Convert.ToBoolean(ConfigurationManager.AppSettings["HeadlessMode"].ToString());


//            CommonUtils cUtils = new CommonUtils();
//            if (cUtils.isRemoteMachine())
//            {
//                ensureCleanSessionOnIE = Convert.ToBoolean(ConfigurationManager.AppSettings["EnsureCleanSession"].ToString());
//            }

//            browser = browserName;

//            try
//            {
//                switch (browserName.ToLower())
//                {
//                    case "firefox":
//                        driver = new FirefoxDriver();
//                        break;
//                    case "edge":
//                        driver = new EdgeDriver();
//                        break;
//                    case "chrome":
//                        ChromeOptions o = new ChromeOptions();
//                        // o.AddUserProfilePreference("disable-popup-blocking", "true");
//                        o.ToCapabilities();
//                        o.AddArguments("disable-extensions");

//                        if (headlessMode)
//                        {
//                            o.AddArguments("--headless");
//                            o.AddArguments("no-sandbox");
//                        }

//                        // o.AddArguments("load-extension=C:/Users/vande/AppData/Local/Google/Chrome/User Data/Default/Extensions");
//                        o.AddArguments("--start-maximized");
//                        driver = new ChromeDriver(baseDir, o);
//                        break;
//                    //case "htmlunit":
//                    //    driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
//                    //    break;
//                    //case "phantomjs":
//                    //    driver = new PhantomJSDriver();
//                    //    break;
//                    default:
//                        InternetExplorerOptions options = new InternetExplorerOptions();
//                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
//                        options.IgnoreZoomLevel = true;
//                        options.EnableNativeEvents = false;
//                        options.RequireWindowFocus = true;
//                        options.EnsureCleanSession = ensureCleanSessionOnIE;
//                        options.InitialBrowserUrl = url;//on some IE instances if we do not provide initial url the driver is not paired with browser
//                        var driverService = InternetExplorerDriverService.CreateDefaultService();
//                        driverService.HideCommandPromptWindow = true;
//                        driver = new InternetExplorerDriver(driverService, options);
//                        break;
//                }
//                turnOnImplicitWaits();//if someone trunoff implict waits on previous test,it should not effect the current test
//                logger.Info("Launched the Web browser: " + browserName);
//                driver.Manage().Window.Maximize();
//            }
//            catch (Exception e)
//            {
//                logger.Error("Cannot Launch the Browser: " + e);
//            }
//        }


//        /// <summary>
//        /// To get the title of the Page
//        /// </summary>
//        public string Title
//        {
//            get { return driver.Title; }
//        }

//        /// <summary>
//        /// Opens the New Tab in the same Browser Instance.. 
//        /// </summary>
//        public void OpenNewTabInSameBrowserInstance(string url)
//        {
//            string firstTabHandle = driver.CurrentWindowHandle;
//            driver.SwitchTo().Window(firstTabHandle);
//            driver.FindElement(By.CssSelector("Body")).SendKeys(Keys.Control + "t");
//            //IWebElement element = driver.FindElement(By.TagName("body"));
//            //Actions action = new Actions(driver);
//            //action.SendKeys(Keys.Control + "t").Release().Perform();
//            string secondTabHandle = driver.CurrentWindowHandle;
//            driver.SwitchTo().Window(secondTabHandle);
//            string secondPageUrl = url;
//            driver.Navigate().GoToUrl(secondPageUrl);
//            Thread.Sleep(2000);
//        }

//        /// <summary>
//        /// scrolls to find the element..
//        /// </summary>
//        /// <param name="locator"></param>
//        public void scrollElement(ILocator locator)
//        {
//            try
//            {
//                IWebElement webElement = driver.FindElement(getByObject(locator));
//                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
//                executor.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
//                //logger.Info("Scrolled to the Element.. ");
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        /// <summary>
//        /// scrolls to find the element..
//        /// </summary>
//        /// <param name="locator"></param>
//        public void scrollElement(IWebElement webElement)
//        {
//            try
//            {
//                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
//                executor.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
//                //logger.Info("Scrolled to the Element.. ");
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        //get parent element
//        public IWebElement GetParentElement(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(getByObject(locator));
//            IWebElement parent = element.FindElement(By.XPath(".."));
//            return parent;
//        }



//        #region ClickOperations
//        /// <summary>
//        /// Clicks the Link based on the index.. 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="index"></param>
//        public void ClickLinkValues(ILocator locator, int index)
//        {
//            IWebElement t = driver.FindElement(getByObject(locator));
//            List<IWebElement> alllinks = new List<IWebElement>(t.FindElements(By.TagName("span")));
//            if (alllinks.Count >= index)
//            {
//                alllinks[index].Click();
//            }
//            else
//                logger.Error("ClickLinkValues() : Index is greater than the total count of elements present..");
//        }


//        /// <summary>
//        /// Clicks the Element if displayed.. 
//        /// </summary>
//        /// <param name="locator"></param>
//        public void ClickingElementUsingJavascript(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(getByObject(locator));
//            if (element.Displayed || element.Enabled)
//            {
//                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
//                executor.ExecuteScript("arguments[0].click();", element);
//                Thread.Sleep(1000);
//            }
//            else
//            {
//                String errMsg = "Element is not enabled on the DOM with locator :" + element.Text;
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }
//        }

//        #endregion


//        #region EnterTextOperations

//        /// <summary>
//        ///     Enter the text value provided in the testData object in the input fields.
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public override void EnterText(ILocator locator, TestData testData)
//        {
//            value = testData.TextToTextBox;
//            IList<IWebElement> elements = GetElements(locator);

//            bool isEnabled = false;

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Displayed && ele.Enabled)
//                {
//                    isEnabled = true;
//                    ele.Click();
//                    ele.Clear();

//                    ele.SendKeys(value.Trim());
//                    Thread.Sleep(2000);
//                    break;
//                }
//                else
//                    isEnabled = false;

//            }

//            if (!isEnabled)
//            {
//                String errMsg = "Element is not enabled on the DOM with locator :";
//                logger.Error(errMsg);
//                throw new Exception(errMsg);

//            }


//        }

//        /// <summary>
//        ///     Clear the text in the textbox
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public void ClearText(ILocator locator)
//        {

//            IList<IWebElement> elements = GetElements(locator);

//            bool isEnabled = false;

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Displayed && ele.Enabled)
//                {
//                    isEnabled = true;
//                    ele.Click();
//                    ele.Clear();

//                    Thread.Sleep(1000);
//                    break;
//                }
//                else
//                    isEnabled = false;

//            }

//            if (!isEnabled)
//            {
//                String errMsg = "Element is not enabled on the DOM with locator :";
//                logger.Error(errMsg);
//                throw new Exception(errMsg);

//            }


//        }

//        /// <summary>
//        /// Ikhutail - method sends the Values in the WebElement
//        /// resolves the issue with the IE Send Keys truncation
//        /// </summary>
//        /// <param name="locator">property of Element</param>
//        /// <param name="ValuetoEnter">string to be entered</param>
//        public void SendKeystoElements(ILocator locator, string ValuetoEnter)
//        {
//            //driver.Navigate().Refresh();
//            IWebElement element = driver.FindElement(getByObject(locator));
//            Thread.Sleep(500);
//            element.Clear();
//            element.Click();
//            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
//            executor.ExecuteScript("arguments[0].value = arguments[1];", "", element);
//            Thread.Sleep(1000);
//            element.Clear();
//            Thread.Sleep(1000);
//            element.SendKeys(ValuetoEnter);
//            logger.Info("Entered the value: " + ValuetoEnter);
//            Thread.Sleep(500);
//        }



//        #endregion


//        #region SelectTextOpeartions

//        /// <summary>
//        /// Select the text in any element
//        /// </summary>
//        /// <param name="locator"></param>
//        public void SelectText(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(getByObject(locator));
//            Actions actions = new Actions(driver);
//            element.Click();
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

//            js.ExecuteScript(" var doc = document; " + " if (doc.body.createTextRange) { " + " var range = doc.body.createTextRange(); " + " range.moveToElementText(arguments[0]); " + "range.select(); " + " } " + " else if (window.getSelection) { " + " var selection = window.getSelection(); " + " range.selectNodeContents(arguments[0]); " + " selection.removeAllRanges(); " + " selection.addRange(range); " + "}", element);
//            actions.MoveToElement(element).ClickAndHold().MoveByOffset(10, 0).Release().Perform();
//            // element.Click();
//        }


//        /// <summary>
//        /// Select the text in Text docviewer and release mouse
//        /// </summary>
//        /// <param name="locator"></param>
//        public void SelectTextInTextDocViewer_AndRelease(ILocator locator)
//        {
//            Thread.Sleep(3000);
//            IWebElement element = driver.FindElement(getByObject(locator));
//            Actions actions = new Actions(driver);
//            element.Click();
//            ScrollPage("Up");
//            ScrollPage("left");
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

//            //var tagname = "lci";

//            //js.ExecuteScript("var Win = window;"+"var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.selection.createRange(); " + "var range3 = document.createRange();"+ "var lci;"+ "lci = document.getElementsByTagName("+tagname+")[0];" + "range3.setStart(lci.firstChild, 0);"+ "range3.setEnd(lci, 2);"+ "selection1.addRange(range3);");
//            try
//            {
//                js.ExecuteScript("var Win = window;" + "var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.selection.createRange(); " + "var range3 = document.createRange();" + "var lci;" + "lci = document.getElementsByTagName('p')[0];" + "range3.setStart(lci.firstChild, 0);" + "range3.setEnd(lci, 2);" + "selection1.addRange(range3);");

//            }
//            catch (Exception e)
//            {
//                js.ExecuteScript("var Win = window;" + "var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.selection.createRange(); " + "var range3 = document.createRange();" + "var lci;" + "lci = document.getElementsByTagName('body')[0];" + "range3.setStart(lci.firstChild, 0);" + "range3.setEnd(lci, 1);" + "selection1.addRange(range3);");
//            }

//            actions.MoveToElement(element).ClickAndHold().MoveByOffset(10, 0).Release().Perform();
//            //actions.Release();
//            //actions.KeyDown(Keys.Alt);
//            //actions.KeyUp(Keys.Alt);
//            //actions.DoubleClick();
//            // element.Click();
//            //actions.ContextClick(element).Build().Perform();
//            //actions.ContextClick(element).SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown).SendKeys(Keys.Return).Build().Perform();

//        }


//        /// <summary>
//        /// Select the text in Text docviewer and release mouse
//        /// </summary>
//        /// <param name="locator"></param>
//        public void SelectTextInPDfViewer_AndRelease(ILocator locator)
//        {
//            Thread.Sleep(1000);
//            IWebElement element = driver.FindElement(getByObject(locator));
//            Actions actions = new Actions(driver);

//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

//            //var tagname = "lci";

//            //js.ExecuteScript("var Win = window;"+"var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.selection.createRange(); " + "var range3 = document.createRange();"+ "var lci;"+ "lci = document.getElementsByTagName("+tagname+")[0];" + "range3.setStart(lci.firstChild, 0);"+ "range3.setEnd(lci, 2);"+ "selection1.addRange(range3);");
//            try
//            {
//                //js.ExecuteScript("var range = document.createRange(); " + "range.selectNodeContents("+element+"); " + "var selection = window.getSelection(); " + " selection.removeAllRanges(); " + " selection.addRange(range);");
//                js.ExecuteScript("var Win = window;" + "var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.createRange(); " + "var range3 = document.createRange();" + "range3.selectNodeContents(" + element + ");" + "selection.removeAllRanges(); " + "selection1.addRange(range3);");
//            }
//            catch (Exception e)
//            {

//            }
//            actions.MoveToElement(element).ClickAndHold().MoveByOffset(10, 0).Release().Perform();
//            // actions.MoveToElement(element, 3, 3).Click().KeyDown(Keys.Shift).MoveToElement(element, 10, 3).Click().KeyUp(Keys.Shift).Build().Perform();
//            //actions.MoveToElement(element).Build().Perform();
//            //actions.MoveByOffset(1,0).ClickAndHold().MoveByOffset(5, 0).Release().Build().Perform();
//            //actions.Release();
//            //actions.KeyDown(Keys.Alt);
//            //actions.KeyUp(Keys.Alt);
//            //actions.DoubleClick();
//            // element.Click();
//            //actions.ContextClick(element).Build().Perform();
//            // actions.DoubleClick(element).Perform();
//            //actions.DragAndDropToOffset(element, 0, 10).Build().Perform();


//        }

//        /// <summary>
//        /// Select the text in Text docviewer and right click
//        /// </summary>
//        /// <param name="locator"></param>
//        public void SelectTextInTextDocViewer_AndRightClick(ILocator locator)
//        {
//            Thread.Sleep(3000);
//            IWebElement element = driver.FindElement(getByObject(locator));
//            Actions actions = new Actions(driver);
//            element.Click();
//            ScrollPage("Up");
//            ScrollPage("left");
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            try
//            {
//                js.ExecuteScript("var Win = window;" + "var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.selection.createRange(); " + "var range3 = document.createRange();" + "var lci;" + "lci = document.getElementsByTagName('p')[0];" + "range3.setStart(lci.firstChild, 2);" + "range3.setEnd(lci, 5);" + "selection1.addRange(range3);");

//            }
//            catch (Exception e)
//            {
//                js.ExecuteScript("var Win = window;" + "var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.selection.createRange(); " + "var range3 = document.createRange();" + "var lci;" + "lci = document.getElementsByTagName('body')[0];" + "range3.setStart(lci.firstChild, 2);" + "range3.setEnd(lci, 5);" + "selection1.addRange(range3);");
//            }


//            //actions.MoveToElement(element).ClickAndHold().MoveByOffset(0, 0).Release().Perform();
//            //actions.ContextClick(element).Build().Perform();
//            //actions.ContextClick(element).SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();


//            RightClickUsingJavascript(locator);

//        }

//        #endregion






//        public int GetIndexForDocumentCountForCodeSummary(ILocator locator)
//        {
//            int count = 1;
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(getByObject(locator)));
//            foreach (IWebElement element in elements)
//            {
//                if (element.Text == "#")
//                    break;
//                count = count + 1;
//            }
//            return count;
//        }

//        //gets the index of the column position
//        public int GetIndexForColumnFromCodeSummary(ILocator locator, string columnName)
//        {
//            int count = 1;
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(getByObject(locator)));
//            foreach (IWebElement element in elements)
//            {
//                if (element.Text.ToLower() == columnName.ToLower())
//                    break;
//                count = count + 1;
//            }
//            return count;
//        }

//        //gets the index of the all the columns as dictionary
//        public Dictionary<string, int> GetIndexForColumnAsDictionary(ILocator locator)
//        {
//            int count = 0;
//            Dictionary<string, int> dict = new Dictionary<string, int>();
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(getByObject(locator)));
//            foreach (IWebElement element in elements)
//            {
//                scrollElement(element);

//                if (element.Displayed)
//                {
//                    string column = element.Text.ToLower();
//                    count = count + 1;

//                    if (!dict.ContainsKey(column))
//                        dict.Add(column, count);

//                }


//            }
//            return dict;
//        }

//        //gets the index of the all the columns as dictionary
//        public Dictionary<string, int> GetIndexForColumnAsDictionaryForChargeMaster(ILocator locator)
//        {
//            int count = 0;
//            Dictionary<string, int> dict = new Dictionary<string, int>();
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(getByObject(locator)));
//            foreach (IWebElement element in elements)
//            {
//                scrollElement(element);

//                if (element.Displayed)
//                {
//                    string column = element.Text.ToLower();
//                    if (string.IsNullOrEmpty(column))
//                        column = count.ToString();

//                    count = count + 1;

//                    if (!dict.ContainsKey(column))
//                        dict.Add(column, count);

//                }


//            }
//            return dict;
//        }

//        public int GetPositionOfAddedScratchCode(ILocator locator)
//        {
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(getByObject(locator)));
//            return elements.Count();
//        }



//        public void HighlightTextByDoubleClick(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(getByObject(locator));

//            Actions actions = new Actions(driver);
//            element.Click();
//            Thread.Sleep(1200);
//            try
//            {
//                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//                js.ExecuteScript("var Win = window;" + "var Doc = document;" + " var selection1 = Win.getSelection ? Win.getSelection() : Doc.selection.createRange(); " + "var range3 = document.createRange();" + "var lci;" + "lci = document.getElementsByTagName('p')[0];" + "range3.setStart(lci.firstChild, 0);" + "range3.setEnd(lci, 2);" + "selection1.addRange(range3);");
//            }
//            catch (Exception e)
//            {
//                logger.Error("exception occured.." + e.Message);
//            }
//            actions.MoveToElement(element).DoubleClick().Perform();
//        }


//        #region GetElements

//        /// <summary>
//        /// This is the core method to identify the element on the web page/DOM 
//        /// and returns the IWebElement associated with that DOM element.
//        /// Using this element you can perform any action you want.
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns> IWebElement </returns>
//        public IWebElement GetElement(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            return elements[0];
//        }

//        /// <summary>
//        ///  Using this method we can find out all the elements on the web page having the identifiers defined in the ILocator 
//        ///  Example : If you want to find out all the web elements on the web page having class='required' we can use this method 
//        ///  which will return the list of all Web Elements with class='required'
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns>IList<IWebElement></returns>
//        public IList<IWebElement> GetElements(ILocator locator)
//        {
//            IList<IWebElement> elements = new List<IWebElement>();
//            /// If we want to search on a particualr webElement add it into locator object...
//            /// if (locator.)
//            elements = driver.FindElements(getByObject(locator));

//            if (elements.Count == 0)
//            {
//                String errMsg = "Couldn't find the WebElement on the DOM: " + locator.getIdentifier("value");
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }
//            else
//                return elements;
//        }

//        /// <summary>
//        ///     Using this method we can find out all the elements on the web page having the identifiers defined in the ILocator 
//        ///     Example : If you want to find out all the web elements on the web page having class='required' we can use this method 
//        ///     which will return the list of all Web Elements with class='required'
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns>IList<IWebElement></returns>
//        public IList<IWebElement> GetElementsWithOutError(ILocator locator)
//        {

//            IList<IWebElement> elements = driver.FindElements(getByObject(locator));
//            return elements;
//        }



//        /// <summary>
//        /// get the no of elemts with the given locator
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public int GetElementsCount(ILocator locator)
//        {
//            IList<IWebElement> elements = new List<IWebElement>();
//            /// If we want to search on a particualr webElement add it into locator object...
//            /// if (locator.)
//            elements = driver.FindElements(getByObject(locator));
//            return elements.Count;
//        }

//        #endregion

//        /// <summary>
//        /// check if the driver is active or closed and return true or false accordingly
//        /// </summary>
//        /// <returns></returns>
//        public bool isChildWindowClosed()
//        {
//            if (driver.WindowHandles.Count() == 1)
//                return true;
//            else
//                return false;
//        }

//        /// <summary>
//        ///     This method will return the inner text for the specified web element 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public override String GetElementText(ILocator locator)
//        {
//            IWebElement element = GetElement(locator);
//            scrollElement(element);
//            return element.Text;
//        }

//        public override void Doubleclick(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            Actions action = new Actions(driver);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                {
//                    action.DoubleClick(ele);
//                    action.Perform();
//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }
//        }


//        /// <summary>
//        ///     This method will return the Current page URL.
//        /// </summary>
//        /// <returns></returns>
//        public String GetCurrentPageURL()
//        {
//            return driver.Url;
//        }

//        #region ExecuteJavaScript

//        /// <summary>
//        ///     This method can execute the Java Script code and return String
//        /// </summary>
//        /// <param name="jsScript"></param>
//        public string ExecuteJavaScriptReturnString(String jsScript)
//        {
//            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
//            return (string)jsExecutor.ExecuteScript(jsScript);
//        }

//        public long ExecuteJavaScriptReturnInt(String jsScript)
//        {
//            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
//            return Convert.ToInt64(jsExecutor.ExecuteScript(jsScript));
//        }

//        #endregion


//        #region RightClick Operations
//        /// <summary>
//        /// perform right click on the element
//        /// </summary>
//        /// <param name="locator"></param>
//        public override void RightClick(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            Actions action = new Actions(driver);

//            foreach (IWebElement ele in elements)
//            {

//                // action.ContextClick(ele).Build().Perform();
//                // action.SendKeys(Keys.F10);
//                RightClickUsingJavascript(locator);
//            }
//        }


//        /// <summary>
//        /// right click on the element using JavaScript executor
//        /// </summary>
//        /// <param name="locator"></param>
//        public void RightClickUsingJavascript(ILocator locator)
//        {
//            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
//            IWebElement element = driver.FindElement(getByObject(locator));

//            String javaScript = "var evt = document.createEvent('MouseEvents');"
//                            + "var RIGHT_CLICK_BUTTON_CODE = 2;"
//                            + "evt.initMouseEvent('contextmenu', true, true, window, 1, 0, 0, 0, 0, false, false, false, false, RIGHT_CLICK_BUTTON_CODE, null);"
//                            + "arguments[0].dispatchEvent(evt)";

//            executor.ExecuteScript(javaScript, element);
//        }

//        public string RightClickOnSelectedHightlight(ILocator locator, string color, string code)
//        {
//            List<IWebElement> listOFWebElements = null;
//            string textValue = null;
//            IWebElement element = driver.FindElement(getByObject(locator));
//            listOFWebElements = new List<IWebElement>(driver.FindElements(By.TagName("span")));
//            foreach (IWebElement item in listOFWebElements)
//            {
//                textValue = item.GetAttribute("class");
//                if (textValue.Contains(color.ToLower()) || textValue.Contains(color.ToUpper()) && textValue.Contains(code))
//                {
//                    Actions action = new Actions(driver);
//                    action.ContextClick(item).Build().Perform();
//                    return textValue;
//                }
//            }
//            return textValue;

//        }

//        #endregion


//        #region WaitOperations
//        /// <summary>
//        ///     Modify the default implicit wait time.
//        /// </summary>
//        /// <param name="seconds"></param>
//        public void SetCustomImplicitWait(int seconds)
//        {

//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

//        }



//        /// <summary>
//        /// turning off the implicit waits
//        /// </summary>
//        public void turnOffImplicitWaits(int timeInSeconds = 2)
//        {
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);

//        }

//        /// <summary>
//        /// turning on the implict waits
//        /// </summary>
//        public void turnOnImplicitWaits()
//        {
//            int implicitWait = Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitWaitInSecs"]);
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);

//        }

//        /// <summary>
//        ///     Revert the implicit wait time to it's default value
//        /// </summary>
//        public void SetDefaultImplicitWait()
//        {
//            turnOnImplicitWaits();


//        }

//        #endregion

//        /// <summary>
//        ///     Close the current browser window.
//        /// </summary>
//        public void CloseBrowserWindow()
//        {
//            if (driver != null)
//                driver.Close();
//            //Quit();
//        }

//        /// <summary>
//        ///     Close all the browser windows.
//        /// </summary>
//        public override void Quit()
//        {

//            try
//            {
//                driver.Quit();

//            }
//            catch (Win32Exception e)
//            {
//                logger.Info("The process is terminating or could not be terminated." + e.Message);
//            }
//            catch (InvalidOperationException e)
//            {
//                logger.Info("The process has already exited." + e.Message);
//            }

//            catch (Exception e)  // some other exception
//            {
//                logger.Info("{0} Exception caught.", e);
//            }

//        }

//        public override void CloseDriverInstances()
//        {
//            try
//            {

//                foreach (var proc in Process.GetProcessesByName("IEDriverServer"))
//                {
//                    proc.Kill();
//                }
//            }
//            catch (Win32Exception e)
//            {
//                logger.Info("The process is terminating or could not be terminated." + e.Message);
//            }
//            catch (InvalidOperationException e)
//            {
//                logger.Info("The process has already exited." + e.Message);
//            }

//            catch (Exception e)  // some other exception
//            {
//                logger.Info("{0} Exception caught.", e);
//            }
//        }






//        /// <summary>
//        ///     Accepts parent element and returns list of strings consisting of text value of childrens
//        /// </summary>
//        /// <param name="locator"></param>
//        public override List<String> FindChildElementText(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            List<String> elementText = new List<String>();
//            foreach (IWebElement element in elements)
//            {
//                if (!element.Text.Equals(""))
//                {
//                    elementText.Add(element.Text);
//                }
//            }
//            return elementText;
//        }

//        /// <summary>
//        ///     Accepts parent element locator and returns Hashtablel having key as visible text of checkbox and its isEnabled property
//        /// </summary>
//        /// <param name="locator"></param>
//        public override Hashtable GetCheckboxEnabledProperty(ILocator locator)
//        {
//            Hashtable checkboxTable = new Hashtable();

//            IList<IWebElement> elements = GetElements(locator);
//            foreach (IWebElement element in elements)
//            {
//                if (!element.Text.Equals(""))
//                {
//                    checkboxTable.Add(element.Text, element.Enabled);
//                }
//            }
//            return checkboxTable;
//        }



//        public override void OpenURL(TestData testData)
//        {
//            if (testData.Browser != null)
//                browser = testData.Browser;
//            else
//            {
//                browser = ConfigurationManager.AppSettings["Browser"];
//            }
//            url = testData.URL;

//            // setDriver();
//            driver.Navigate().GoToUrl(url);
//            driver.Manage().Window.Maximize();
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(defaultWaitTime);

//        }



//        #region Switchwindows
//        public override void swithcToChildWindow()
//        {
//            SeleniumUtil sUtil = new SeleniumUtil();
//            Thread.Sleep(1000);
//            getParentAndChildWindowHandles();
//            driver.SwitchTo().Window(childWindow);
//            sUtil.maximizeBrowserWindow();
//            logger.Info("Switched to child Window.. ");
//        }

//        public override void swithcToParentWindow()
//        {
//            Thread.Sleep(1000);
//            driver.SwitchTo().Window(parentWindow);
//            logger.Info("Switched to Parent Window.. ");
//            whichWindow = "Last";
//        }

//        public override void SwitchWindow()
//        {

//            string ParentBrowserWindow = driver.CurrentWindowHandle;

//            var windowHandles = driver.WindowHandles;

//            System.Collections.ObjectModel.ReadOnlyCollection<string> windows =
//                new System.Collections.ObjectModel.ReadOnlyCollection<string>(windowHandles);

//            if (whichWindow.Equals("Last"))
//            {
//                driver.SwitchTo().Window(driver.WindowHandles.Last());
//                whichWindow = "First";
//                logger.Info("Switching to Active Window");

//            }
//            else
//            {
//                driver.SwitchTo().Window(driver.WindowHandles.First());
//                whichWindow = "Last";
//                logger.Info("Switching to Parent Window");
//            }

//        }

//        public override void getParentAndChildWindowHandles()
//        {
//            Thread.Sleep(2000);
//            parentWindow = driver.CurrentWindowHandle;
//            childWindow = driver.WindowHandles.Last();
//        }


//        public override void switchContext()
//        {
//            // This will be useful if you want to open two webapplications simultaneously in any case
//            tempDriver = driver;
//            driver = auxDriver;
//            auxDriver = tempDriver;
//        }

//        #endregion

//        public By getByObject(ILocator locator)
//        {

//            switch (locator.getIdentifier("type").ToString().ToLower())
//            {
//                case "xpath":
//                    return By.XPath(locator.getIdentifier("value"));
//                case "id":
//                    return By.Id(locator.getIdentifier("value"));
//                case "name":
//                    return By.Name(locator.getIdentifier("value"));
//                case "class":
//                    return By.ClassName(locator.getIdentifier("value"));
//                case "css":
//                    return By.CssSelector(locator.getIdentifier("value"));
//                case "link":
//                    return By.PartialLinkText(locator.getIdentifier("value"));
//                case "tagname":
//                    return By.TagName(locator.getIdentifier("value"));

//                default:
//                    return null;
//            }


//        }


//        /// <summary>
//        /// move to an element
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public override void MoveToElement(ILocator locator, TestData testData)
//        {

//            IList<IWebElement> elements = GetElements(locator);
//            Actions action = new Actions(driver);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                {
//                    action.MoveToElement(ele);
//                    action.Perform();
//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }
//        }

//        /// <summary>
//        /// select entire text that is present in an element
//        /// </summary>
//        /// <param name="locator"></param>
//        public void SelectEntireTextInElement(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            Actions action = new Actions(driver);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                {
//                    ele.Click();

//                    action.Click(ele).SendKeys(Keys.Control + "a").Build().Perform();

//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }
//        }

//        public void SelectTextInElement(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            Actions action = new Actions(driver);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                {
//                    ele.Click();
//                    action.MoveToElement(ele, 0, 0).ClickAndHold().MoveByOffset(50, 0).Release().Perform();


//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }

//        }

//        public void DragMouseByXY_Pixels(ILocator locator, int x, int y)
//        {
//            Thread.Sleep(3000);
//            IWebElement element = GetElement(locator);
//            if (element.Enabled)
//            {
//                Actions action = new Actions(driver);
//                action.MoveToElement(element).ClickAndHold().MoveByOffset(x, y).Release().Perform();
//                action.Click();
//                Thread.Sleep(2000);
//                //action.dragAndDropBy(element, 0, x).build().perform();
//            }
//            else
//            {
//                String errorMsg = "Element not found";
//                logger.Error(errorMsg);
//                throw new Exception(errorMsg);
//            }

//        }

//        public void DragAndDrop(ILocator srclocator, ILocator tarlocator)
//        {
//            IWebElement source = GetElement(srclocator);
//            IWebElement target = GetElement(tarlocator);

//            if (source.Enabled && target.Enabled)
//            {
//                Actions action = new Actions(driver);
//                action.DragAndDrop(source, target);
//            }
//            else
//            {
//                String errorMsg = "Element not found";
//                logger.Error(errorMsg);
//                throw new Exception(errorMsg);
//            }
//        }

//        public void ActionSendKeys(ILocator locator, string keytosend)
//        {
//            IWebElement source = GetElement(locator);
//            Actions action = new Actions(driver);
//            action.SendKeys(source, keytosend).Perform();
//            action.Click();
//        }

//        public void ActionClickOnElement(ILocator locator)
//        {
//            IWebElement source = GetElement(locator);
//            Actions action = new Actions(driver);
//            action.Click(source).Perform();
//        }

//        public float GetElementHeight(ILocator locator)
//        {
//            IWebElement element = GetElement(locator);
//            float height;
//            if (element.Enabled)
//            {
//                height = float.Parse(element.Size.Height.ToString());
//            }
//            else
//            {
//                String errorMsg = "Element not found";
//                logger.Error(errorMsg);
//                throw new Exception(errorMsg);
//            }
//            return height;
//        }

//        public float GetElementWidth(ILocator locator)
//        {
//            IWebElement element = GetElement(locator);
//            float width;
//            if (element.Enabled)
//            {
//                width = float.Parse(element.Size.Width.ToString());
//            }
//            else
//            {
//                String errorMsg = "Element not found";
//                logger.Error(errorMsg);
//                throw new Exception(errorMsg);
//            }
//            return width;
//        }

//        /// <summary>
//        /// Highlight element for 1 sec using red border
//        /// </summary>
//        /// <param name="locator"></param>
//        public override void highlightElement(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            foreach (IWebElement element in elements)
//            {
//                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

//                string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
//                jsExecutor.ExecuteScript(highlightJavascript, new object[] { element });

//                Thread.Sleep(1000);
//                jsExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");

//            }
//            /*
//             ////Other Ways of highlighting 

//            //jsExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",element, "color: red; border: 5px solid red;");

//            //jsExecutor.ExecuteScript("arguments[0].style.border='5px solid red'", element);

//            //Observable.Timer(new TimeSpan(0, 0, 3)).Subscribe(p =>
//            //{
//            //    var clear = @"arguments[0].style.cssText = ""border-width: 0px; border-style: solid; border-color: red""; ";
//            //    driver.ExecuteScript(clear, rc);
//            //});
            
//             */
//        }

//        public void ScrollIntoView(ILocator locator)
//        {
//            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
//            IWebElement elem = driver.FindElement(By.XPath(locator.getIdentifier("Value")));
//            jsExecutor.ExecuteScript("arguments[0].scrollIntoView();", elem);
//        }

//        /// <summary>
//        /// check whethers the element with the gicen locator is present
//        /// on the page
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public override bool isElementPresent(ILocator locator)
//        {
//            IList<IWebElement> elements = driver.FindElements(getByObject(locator));
//            if (elements.Count == 0)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }

//        /// <summary>
//        /// check whethers the element with the gicen locator is present
//        /// on the page
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public override bool isElementPresentNow(ILocator locator)
//        {
//            turnOffImplicitWaits();
//            IList<IWebElement> elements = GetElementsWithOutError(locator);
//            turnOnImplicitWaits();
//            if (elements.Count == 0)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }


//        }

//        /// <summary>
//        /// Checks whether the element with the given locator is visble on the page
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public override bool isElementVisible(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElementsWithOutError(locator);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Displayed)
//                    return true;
//                else
//                {
//                    return false;
//                }
//            }

//            return false;
//        }

//        /// <summary>
//        /// Checks whether the element with the given locator is visble on the page
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public override bool isElementVisibleNow(ILocator locator)
//        {
//            turnOffImplicitWaits(1);
//            IList<IWebElement> elements = GetElementsWithOutError(locator);
//            turnOnImplicitWaits();
//            foreach (IWebElement ele in elements)
//            {

//                try
//                {
//                    if (ele.Displayed)
//                        return true;
//                    else
//                    {
//                        return false;
//                    }
//                }
//                catch (Exception e)
//                {
//                    return false;
//                }


//            }
//            return false;
//        }

//        public override bool isElementEnabled(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElementsWithOutError(locator);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                    return true;
//                else
//                {
//                    return false;
//                }
//            }

//            return false;
//        }


//        #region WaitForElement
//        public override void WaitTillElementAppears(ILocator locator, int timeout)
//        {
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
//            try
//            {
//                logger.Info("Waiting for the element to be visible");
//                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(getByObject(locator)));
//                logger.Info("element is visible");
//            }
//            catch (Exception e)
//            {
//                logger.Error("No Element Found: ", e);
//                throw e;
//            }
//        }

//        public override void WaitTillElementDisappears(ILocator locator, int timeout)
//        {
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
//            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(getByObject(locator)));

//        }


//        public void WaitTillElementIsClickable(ILocator locator, int timeout)
//        {
//            logger.Info("Waiting for element to be clickable");
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
//            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(getByObject(locator)));
//            logger.Info("Done Waiting");
//        }


//        public void WaitUntilElementDisappears(ILocator locator, int timeout, string customMessage = "")
//        {
//            turnOffImplicitWaits();
//            try
//            {
//                Stopwatch sw = new Stopwatch();
//                sw.Start();
//                while (isElementVisible(locator) && sw.Elapsed.TotalSeconds < timeout)
//                {
//                    logger.Info("waiting for element to disappear.." + customMessage);
//                    Thread.Sleep(500);
//                }
//            }
//            catch (Exception e)
//            {
//                turnOnImplicitWaits();
//            }

//            turnOnImplicitWaits();

//        }

//        #endregion


//        #region ClickElements
//        /// <summary>
//        /// Perform click action on the element specified in the locator object
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>

//        public override void ClickElement(ILocator locator, TestData testData = null)
//        {
//            /// No Need of Test Data object here...
//            IList<IWebElement> elements = GetElements(locator);
//            IWebElement clickElement = null;
//            var isElementVisible = true;

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Displayed && ele.Enabled)
//                {
//                    clickElement = ele;
//                    isElementVisible = true;
//                    Thread.Sleep(1000);
//                    break;
//                }
//                else
//                {
//                    clickElement = ele;
//                    isElementVisible = false;
//                }
//            }
//            Thread.Sleep(2000);
//            if (isElementVisible == true)
//            {
//                clickElement.Click();

//            }
//            else
//            {
//                String errMsg = "Element is not enabled on the DOM with locator :" + clickElement.Text;
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public void ClickElementWithOutWait(ILocator locator, int timeout = 2)
//        {
//            turnOffImplicitWaits(timeout);
//            IList<IWebElement> elements = GetElements(locator);
//            turnOnImplicitWaits();

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Displayed && ele.Enabled)
//                {
//                    ele.Click();
//                    break;
//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }
//        }




//        /// <summary>
//        /// Perform click action on the element specified 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>

//        public void ClickElement(IWebElement ele)
//        {

//            if (ele.Displayed && ele.Enabled)
//            {
//                ele.Click();
//                Thread.Sleep(1000);
//            }
//            else
//            {
//                String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                logger.Error(errMsg);
//                throw new Exception(errMsg);

//            }
//        }


//        /// <summary>
//        /// Perform click action on the element specified in the locator object
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>

//        public void ClickElementUsingMoveTo(ILocator locator, TestData testData)
//        {
//            /// No Need of Test Data object here...
//            IList<IWebElement> elements = GetElements(locator);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Displayed && ele.Enabled)
//                {
//                    new Actions(driver).MoveToElement(ele).Click().Perform();
//                    Thread.Sleep(1000);
//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }
//        }

//        /// <summary>
//        ///     Perform click action on the element specified in the locator object
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>

//        public override void ClickFirstElement(ILocator locator, TestData testData)
//        {
//            /// No Need of Test Data object here...
//            IList<IWebElement> elements = GetElements(locator);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                    ele.Click();
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }

//                break;

//            }
//        }

//        /// <summary>
//        ///     Perform click using  sendkeys on the element specified 
//        ///     in the locator object
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public override void ClickElementWithSendKeys(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);

//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                {
//                    ele.SendKeys(Keys.Enter);

//                }

//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }

//        }


//        public void SendKeysEnter(ILocator locator)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                {
//                    ele.SendKeys(Keys.Enter);

//                }

//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }
//        }

//        #endregion

//        #region Dropdown Operations

//        /// <summary>
//        ///     Select a item from the drop down for the element specified in the locator object.
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>

//        public override void SelectItemFromDropdown(ILocator locator, TestData testData)
//        {
//            IWebElement selectEle = GetElement(locator);

//            SelectElement element = new SelectElement(selectEle);

//            element.SelectByText(testData.ListItemToSelect);



//        }

//        /// <summary>
//        ///     Select a item from the drop down for the element specified in the locator object.
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>

//        public string Get_SelectdItemFromDropdown(ILocator locator, TestData testData)
//        {
//            IWebElement selectEle = GetElement(locator);

//            SelectElement element = new SelectElement(selectEle);


//            return element.SelectedOption.Text;



//        }
//        /// <summary>
//        /// To select a value from drop down. Above methods were failing .
//        /// </summary>
//        /// <param name="element"></param>
//        /// <param name="elementToSelect"></param>
//        public void SetDropDownValue(IWebElement element, string elementToSelect)
//        {
//            var liItems = element.FindElements(By.ClassName("k-item"));

//            var javaScriptExecutor = (IJavaScriptExecutor)driver;
//            foreach (var item in liItems)
//            {
//                var dropDownText = javaScriptExecutor.ExecuteScript("return arguments[0].innerText;", item).ToString();
//                if (dropDownText.ToLower() == elementToSelect.ToLower())
//                {
//                    javaScriptExecutor.ExecuteScript("arguments[0].click()", item);
//                    break;
//                }
//            }
//        }
//        /// <summary>
//        /// get the list of all available item from the dropdown
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public IList<string> GetListItemsInDropdown(ILocator locator)
//        {
//            IWebElement selectEle = GetElement(locator);

//            SelectElement element = new SelectElement(selectEle);

//            IList<string> listItems = new List<string>();

//            //int elementCount =  element.Options.Count;

//            foreach (IWebElement ele in element.Options)
//            {
//                string text = ele.Text;
//                listItems.Add(text);

//            }

//            return listItems;

//        }


//        /// <summary>
//        /// select the item from List,where the list items are links and can be selected only by clicking the link items
//        /// loop through all the items and search with the linktext and click when found
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public void selectItemFromListByClicking(ILocator locator, TestData testData)
//        {
//            bool elementFound = false;
//            IList<IWebElement> elements = GetElements(locator);
//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Text == testData.ListItemToSelect)
//                {
//                    if (ele.Enabled)
//                    {
//                        ele.Click();
//                        elementFound = true;
//                        break;
//                    }
//                    else
//                    {
//                        String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                        logger.Error(errMsg);
//                        throw new Exception(errMsg);
//                    }

//                }
//                else
//                    elementFound = false;


//            }

//            if (elementFound == false)
//            {
//                String errMsg = "Element is not present on the DOM with locator :";
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }
//        }


//        // <summary>
//        /// select the item from List,where the list items are links and can be selected only by clicking the link items
//        /// loop through all the items and search with the linktext and click when found
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public void selectRandomItemFromListByClicking(ILocator locator)
//        {

//            IList<IWebElement> elements = GetElements(locator);

//            Random random = new Random();
//            int randomValue = random.Next(0, elements.Count);

//            IWebElement ele = elements[randomValue];

//            if (ele.Enabled)
//            {
//                ele.Click();

//            }
//            else
//            {
//                String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }


//        }


//        /// <summary>
//        /// select the item from List,where the list items are links and can be selected only by clicking the link items
//        /// loop through all the items and search with the linktext(only substring) and click when found
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public void selectItemFromListUisngContains(ILocator locator, TestData testData)
//        {
//            bool elementFound = false;
//            IList<IWebElement> elements = GetElements(locator);
//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Text.Contains(testData.ListItemToSelect))
//                {
//                    if (ele.Enabled)
//                    {
//                        ele.Click();
//                        elementFound = true;
//                        break;
//                    }
//                    else
//                    {
//                        String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                        logger.Error(errMsg);
//                        throw new Exception(errMsg);
//                    }

//                }
//                else
//                    elementFound = false;


//            }

//            if (elementFound == false)
//            {
//                String errMsg = "Element is not present on the DOM with locator :";
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }
//        }


//        /// <summary>
//        /// select the item from List,where the list items are links and can be selected only by clicking the link items
//        /// loop through all the items and search with the linktext and click when found
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        public void selectFirstItemFromListByClicking(ILocator locator, TestData testData)
//        {
//            bool elementFound = false;
//            IList<IWebElement> elements = GetElements(locator);
//            foreach (IWebElement ele in elements)
//            {
//                if (ele.Enabled)
//                {
//                    ele.Click();
//                    elementFound = true;
//                    break;
//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }

//            }

//            if (elementFound == false)
//            {
//                String errMsg = "Element is not present on the DOM with locator :";
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }
//        }



//        public override void SelectItemFromListBox(ILocator locator, TestData testData)
//        {

//            IWebElement selectElement = GetElement(locator);

//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            js.ExecuteScript("arguments[0].click()", selectElement);

//        }

//        #endregion
//        public override void SelectRadioButton(ILocator locator, TestData testData)
//        {
//            ClickElement(locator, testData);
//        }

//        public override void SelectSingleCheckbox(ILocator locator, TestData testData)
//        {
//            IWebElement element = GetElement(locator);
//            scrollElement(element);
//            if (!element.Selected)
//            {
//                if (element.Enabled)
//                    ClickingElementUsingJavascript(locator);
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + element.Text;
//                    logger.Error(errMsg);
//                    //throw new Exception(errMsg);
//                }
//            }

//        }


//        /// <summary>
//        /// check if the element is selected
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public bool isElementSelected(ILocator locator)
//        {
//            IWebElement element = GetElement(locator);
//            if (element.Selected)
//                return true;
//            else
//                return false;

//        }


//        //get the enabled and selected property for an element
//        public EnabledAndSelected IsElementSelectedAndEnabled(ILocator locator)
//        {

//            EnabledAndSelected enabledAndSelected = new EnabledAndSelected();

//            IWebElement element = GetElement(locator);

//            if (element.Selected)
//                enabledAndSelected.Selected = true;
//            if (element.Enabled)
//                enabledAndSelected.Enabled = true;

//            return enabledAndSelected;
//        }


//        public void SelectAllCheckboxes(ILocator locator, TestData testData)
//        {
//            IList<IWebElement> element = GetElements(locator);
//            for (int i = 0; i < element.Count; i++)
//            {
//                if (!element[i].Selected)
//                {
//                    if (element[i].Enabled)
//                        element[i].Click();
//                    else
//                    {
//                        String errMsg = "Element is not enabled on the DOM with locator :" + element[i].Text;
//                        logger.Error(errMsg);
//                        //throw new Exception(errMsg);
//                    }
//                }

//            }
//        }
//        public void EnterCommentsInTextBox(ILocator locator, TestData testData)
//        {
//            IList<IWebElement> element = GetElements(locator);
//            for (int i = 0; i < element.Count; i++)
//            {
//                if (!element[i].Selected)
//                {
//                    if (element[i].Enabled)
//                        element[i].SendKeys("OverrideEdit comment added");
//                    else
//                    {
//                        String errMsg = "Element is not enabled on the DOM with locator :" + element[i].Text;
//                        logger.Error(errMsg);
//                    }
//                }

//            }
//        }

//        public override void UnselectAllCheckboxes(ILocator locator, TestData testData)
//        {
//            IList<IWebElement> element = GetElements(locator);
//            for (int i = 0; i < element.Count; i++)
//            {
//                if (element[i].Selected & element[i].Enabled)
//                {
//                    element[i].Click();
//                    //ClickElement(locator, testData);
//                }
//            }
//        }


//        public override void UnselectSingleCheckbox(ILocator locator, TestData testData)
//        {
//            IWebElement element = GetElement(locator);
//            scrollElement(element);
//            if (element.Selected)
//            {
                

//                if (element.Enabled)
//                    ClickingElementUsingJavascript(locator);
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + element.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }

//        }

//        /// <summary>
//        ///     This method will return the attribute value of the specified Web element.
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns></returns>
//        public override string GetElementPropertyValue(ILocator locator, TestData testData)
//        {
//            string type = testData.ElementPropertyType;

//            IList<IWebElement> element = GetElements(locator);

//            string val = string.Empty;

//            foreach (IWebElement ele in element)
//            {
//                if (ele.Enabled && ele.Displayed)
//                    val = ele.GetAttribute(type);

//            }

//            return val;

//        }


//        public override string getCssProperty(ILocator locator, TestData testData)
//        {
//            string type = testData.ElementPropertyType;
//            IWebElement element = GetElement(locator);
//            return element.GetCssValue(type);

//        }



//        #region GetText
//        /// <summary>
//        /// get text of an element
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        /// <returns></returns>
//        public override string GetText(ILocator locator, TestData testData)
//        {
//            string type = testData.ElementPropertyType;

//            IWebElement element = GetElement(locator);
//            scrollElement(element);
//            string text = element.Text;
//            return text;

//        }


//        /// <summary>
//        /// get text of an element
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        /// <returns></returns>
//        public string GetText(IWebElement element)
//        {
//            string text = element.Text;
//            return text;

//        }

//        public IList<string> GetTextAsList(ILocator locator, string Tag)
//        {
//            IList<string> list = new List<string>();
//            IWebElement t = driver.FindElement(getByObject(locator));
//            List<IWebElement> elements = new List<IWebElement>(t.FindElements(By.TagName(Tag)));

//            foreach (IWebElement ele in elements)
//            {
//                list.Add(ele.Text.Trim());

//            }
//            return list;
//        }

//        /// <summary>
//        /// Get text of an element,if element is not available get null
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        /// <returns></returns>
//        public string GetTextAsNullIfNotFound(ILocator locator, TestData testData)
//        {
//            string type = testData.ElementPropertyType;
//            string text = string.Empty;

//            turnOffImplicitWaits(5);
//            IList<IWebElement> elements = GetElementsWithOutError(locator);
//            turnOnImplicitWaits();


//            if (elements.Count == 0)
//                return text;

//            text = elements[0].Text.Trim();


//            return text;

//        }

//        /// <summary>
//        /// get text as list
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        /// <returns></returns>
//        public override IList<string> GetTextAsList(ILocator locator, TestData testData)
//        {
//            IList<string> list = new List<string>();

//            IList<IWebElement> elements = GetElements(locator);

//            foreach (IWebElement ele in elements)
//            {
//                scrollElement(ele);
//                list.Add(ele.Text.Trim());

//            }
//            return list;


//        }


//        /// <summary>
//        /// get element at index
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        /// <returns></returns>
//        public IWebElement GetElementAtIndex(ILocator locator, int index)
//        {
//            IList<IWebElement> elements = GetElements(locator);
//            IWebElement ele = elements.ElementAt(index);

//            return ele;

//        }


//        /// <summary>
//        /// get text with null if not found
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        /// <returns></returns>
//        public IList<string> GetTextAsListWithNullIfNotFound(ILocator locator, TestData testData)
//        {
//            IList<string> list = new List<string>();

//            IList<IWebElement> elements = GetElementsWithOutError(locator);

//            if (elements.Count == 0)
//            {
//                list.Add(null);
//                return list;
//            }



//            foreach (IWebElement ele in elements)
//            {
//                try
//                {
//                    list.Add(ele.Text);
//                }
//                catch (Exception e)
//                {
//                    list.Add(null);

//                }


//            }
//            return list;


//        }



//        /// <summary>
//        /// get text with empty if not found
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="testData"></param>
//        /// <returns></returns>
//        public IList<string> GetTextAsListWithEmptyIfNotFound(ILocator locator, TestData testData)
//        {
//            IList<string> list = new List<string>();

//            IList<IWebElement> elements = GetElementsWithOutError(locator);

//            if (elements.Count == 0)
//            {
//                list.Add("");
//                return list;
//            }



//            foreach (IWebElement ele in elements)
//            {
//                try
//                {
//                    list.Add(ele.Text);
//                }
//                catch (Exception e)
//                {
//                    list.Add("");

//                }


//            }
//            return list;


//        }

//        #endregion

//        public override string GetCurrentPageTitle()
//        {
//            return driver.Title;
//        }

//        public override void ClickLink(ILocator locator, TestData testData)
//        {
//            ClickElement(locator, testData);
//        }

//        public override int getRowCountWebTable(ILocator locator, bool waitForElement = true)
//        {

//            if (waitForElement == false)
//            {
//                turnOffImplicitWaits();
//            }
//            ScrollPage("down");
//            IList<IWebElement> elements = GetElementsWithOutError(locator);
//            turnOnImplicitWaits();
//            return elements.Count;
//        }

//        /// <summary>
//        /// Scroll the page vertically up, down, right, left
//        /// based on the scrolloption..
//        /// </summary>
//        /// <param name="scrolloption">Type: "up", "down", "right", "left" </param>
//        public void ScrollPage(string scrolloption)
//        {
//            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
//            switch (scrolloption.ToLower())
//            {
//                case "up":
//                    js.ExecuteScript("window.scrollTo(document.body.scrollHeight,0)");
//                    break;
//                case "down":
//                    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
//                    break;
//                case "right":
//                    js.ExecuteScript("window.scrollBy(4000,0)");
//                    break;
//                case "left":
//                    js.ExecuteScript("window.scrollBy(-4000,0)");
//                    break;
//            }
//        }

//        public override void CloseBrowser()
//        {
//            if (driver != null)
//            {
//                driver.Quit();
//                logger.Info("Quit Browser");
//            }

//        }


//        public override void ClickMRN(ILocator locator, TestData testData, string mrn)
//        {
//            /// No Need of Test Data object here...
//            IList<IWebElement> elements = new List<IWebElement>();
//            IList<IWebElement> mrnrow = new List<IWebElement>();
//            elements = driver.FindElements(getByObject(locator));
//            foreach (var x in elements)
//            {
//                if (x.Text == mrn)
//                {
//                    mrnrow.Add(x);
//                    break;
//                }
//            }
//            foreach (IWebElement elem in mrnrow)
//            {
//                if (elem.Enabled)
//                {
//                    elem.Click();
//                    break;
//                }
//                else
//                { throw new Exception("Element is not enabled on the DOM with locator :"); }
//            }
//        }

//        public bool IsWindowOpened(string windowName)
//        {
//            //return (driver.WindowHandles.Last()==(windowName));
//            string currentHandle = driver.CurrentWindowHandle;
//            List<string> allOpenedTitle = new List<string>();
//            var allOpenedHandle = driver.WindowHandles;
//            foreach (string handle in allOpenedHandle)
//            {
//                driver.SwitchTo().Window(handle);
//                string curSwitchTitle = driver.Title;
//                allOpenedTitle.Add(curSwitchTitle);
//            }
//            driver.SwitchTo().Window(currentHandle);
//            return (allOpenedTitle.Contains(windowName));

//        }

//        public override string GetAttributeValueCodeSummarycodeTitleTooltip(ILocator locator)
//        {
//            IWebElement element = GetElement(locator);
//            Actions action = new Actions(driver);
//            action.MoveToElement(element).Perform();
//            scrollElement(element);
//            string codeToolTipTitle = element.GetAttribute("Title");         
//            return codeToolTipTitle;

//        }




//    }
//}
