//using eCACAutomationTests.WebDriverImpl;
//using eCACWebAutomationTests.ReusableModules;
//using eCACWebAutomationTests.Utils;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
//using OptumAutomationFramework.Reportings;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading;
//using System.Web.UI.WebControls;
//using OptumAutomationFramework.FrameworkComponents.Interface;
//using OptumAutomationFramework.FrameworkComponents.TestDataManagement;

//namespace eCACWebAutomationTests
//{
//    public class SeleniumUtil
//    {

//        public int numberofRows = 0;
//        IWebDriver driver
//        {
//            get
//            {
//                return sel.GetDriver();
//            }
//        }

//        Logger logger = new Logger();
//        SeleniumWrapperImpl sel = new SeleniumWrapperImpl();
//        CommonUtils cUtils = new CommonUtils();

//        /// <summary>
//        /// maximizes the Browser Window.
//        /// </summary>
//        public void maximizeBrowserWindow()
//        {
//            try
//            {
//                driver.Manage().Window.Maximize();
//            }catch(Exception e)
//            {

//            }
            
//        }

//        //Closes the Browsers. 
//        public void closeBrowsers()
//        {
//            if(driver!=null)
//            driver.Quit();
//        }

//        public void TwoClickEvents(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            element.Click();
//            element.Click();
//            logger.Info("Clicked twice on the Element..TwoClickEvents()");
//        }

//        public void Click(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            element.Click();
//            logger.Info("clicked");
//        }

//        public string GetElementText(ILocator locator, bool waitForElement = true)
//        {
//            string text = string.Empty;
//            IList<IWebElement> elements = new List<IWebElement>();

//            if (!waitForElement)
//                sel.turnOffImplicitWaits();
//            elements = driver.FindElements(sel.getByObject(locator));
//            sel.turnOnImplicitWaits();

//            if (elements.Count == 0)
//            {
//                string errMsg = "Couldn't find the WebElement on the DOM: " + locator.getIdentifier("value");
//                logger.Error(errMsg);
//            }
//            else
//                text = elements[0].Text;
//            return text;
//        }

//        public List<string> GetElementsText(ILocator locator, bool waitForElement = true)
//        {
//            IList<IWebElement> elements = new List<IWebElement>();
//            var textitems = new List<string>();
//            string text = null;
//            if (!waitForElement)
//                sel.turnOffImplicitWaits();
//            elements = driver.FindElements(sel.getByObject(locator));
//            sel.turnOnImplicitWaits();

//            foreach(IWebElement ele in elements)
//            {
//                text = ele.Text.ToString();
//                textitems.Add(text);
//            }

//           return textitems;
//        }

//        //Click Element using Action library
//        public void clickElement_ActionClass(ILocator locator)
//        {
//            List<IWebElement> lst = new List<IWebElement>(driver.FindElements(sel.getByObject(locator)));
//            foreach (IWebElement web in lst)
//            {
//                Actions action = new Actions(driver);
//                action.MoveToElement(web).Click().Perform();
//                //logger.Info("Clicked on the element..");
//            }
//        }

//        public void clickCodeElement_ActionClass(ILocator locator, string code)
//        {
//            List<IWebElement> lst = new List<IWebElement>(driver.FindElements(sel.getByObject(locator)));
//            foreach (IWebElement web in lst)
//            {
//                if (web.Text == code)
//                {
//                    Actions action = new Actions(driver);
//                    action.MoveToElement(web).Click().Build().Perform();
//                }
//                logger.Info("Clicked on the code.." + code);
//            }
//        }

//        public void dragSplitBar()
//        {
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            string width = (string)js.ExecuteScript("document.getElementById('docTreeSplitterContainer').setAttribute('style', 'width:320px')");
//        }

//        //Click Element using Action library
//        public void clickElement_ActionClass1(ILocator locator)
//        {
//            List<IWebElement> lst = new List<IWebElement>(driver.FindElements(sel.getByObject(locator)));
//            foreach (IWebElement web in lst)
//            {

//                Actions action = new Actions(driver);
//                action.MoveToElement(web).ClickAndHold().Perform();
//                action.Release().Perform();
//            }
//        }

//        /// <summary>
//        /// Ikhutail (11.22.2016)
//        /// Switches between different window based on the window Title.. 
//        /// </summary>
//        /// <param name="windowTitle">title of the window ex. "Comments" etc.. </param>
//        public void SwitchBetweenDifferentWindows(string windowTitle,int timeout=90)
//        {
            
//            try
//            {
//                bool windowFound = false;

//                sel.turnOffImplicitWaits();
            
//            string currwintitle = string.Empty;
//            Stopwatch sw = new Stopwatch();
//            sw.Start();

//            while (!windowFound && sw.Elapsed.TotalSeconds < timeout)
//            {
//                    var windowHandles = driver.WindowHandles;

//                    foreach(var window in windowHandles)
//                    {
//                        currwintitle = driver.SwitchTo().Window(window).Title;
//                        if (currwintitle.Equals(windowTitle))
//                        {
//                            windowFound = true;
//                            break;
//                        }   

//                    }
                
//                Thread.Sleep(500);
//                logger.Info("waiting for pop up window to appear..");

//            }

//                if (!windowFound)
//                    driver.SwitchTo().DefaultContent();

//            }
//            catch (Exception e)
//            {
//                sel.turnOnImplicitWaits();
//            }

//            sel.turnOnImplicitWaits();    
//        }
//        /// <summary>
//        /// Ikhutail (11.23.2016)
//        /// Switches to the last window or modal window.
//        /// </summary>
//        public void SwitchToModalWindow()
//        {
//            Thread.Sleep(1000);
//            try
//            {
//                driver.SwitchTo().ActiveElement();
//                cUtils.killProcess("WerFault");
//            }
//            catch (Exception e)
//            {
//                cUtils.killProcess("WerFault");
//                logger.Error("Exception Occured :" + e.Message);
//            }
//        }


//        /// <summary>
//        /// Switch the foucs to the frame identified by it's name
//        /// </summary>
//        /// <param name="frameName"></param>
//        public void SwitchToFrame(string frameName)
//        {
//            driver.SwitchTo().Frame(frameName);
//        }

//        // Switches to the iFrame based on the locator (xpath, css, id etc..)
//        public void SwitchToFrame(ILocator locator)
//        {
//            IWebElement element = sel.GetElement(locator);
//            driver.SwitchTo().Frame(element);
//            logger.Info("Switched frames.. ");
//        }

//        /// <summary>
//        /// Switch the focus to the browser window with it's index.
//        /// </summary>
//        /// <param name="index"></param>
//        public void SwitchToWindow(int index)
//        {
//            IList<string> windows = new List<string>(driver.WindowHandles);

//            driver.SwitchTo().Window(windows[index]);
//        }

//        /// <summary>
//        ///     switch the focus to the default browser window.
//        /// </summary>
//        public  void SwitchToDefaultWindow()
//        {
//            driver.SwitchTo().DefaultContent();
//        }


//        //Get the count of open windows
//        public int getCountOFOpenWindows()
//        {
//            return driver.WindowHandles.Count;
//        }

        
        

//        /// <summary>
//        /// Ikhutail (12.02.2016)
//        /// Clicks on the Alert based on the option - accept or dismiss
//        /// </summary>
//        public void AcceptOrDismissAlert(string option)
//        {
//            try
//            {
//                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
//                wait.Until(ExpectedConditions.AlertIsPresent());
//                if (driver.SwitchTo().Alert() != null)
//                {
//                    IAlert alert = driver.SwitchTo().Alert();
//                    string text = alert.Text;
//                    logger.Info("Alert is present");
//                    switch (option.ToLower())
//                    {
//                        case "accept":
//                            alert.Accept();
//                            logger.Info("Accepted the Alert..");
//                            break;
//                        case "dismiss":
//                            alert.Dismiss();
//                            logger.Info("Dismissed the Alert..");
//                            break;
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                logger.Info("Alert is not present.." + e.Message);
//            }
//        }


//        /// <summary>
//        /// get the text on the alert
//        /// </summary>
//        public string GetTextOnAlert()
//        {

//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
//            wait.Until(ExpectedConditions.AlertIsPresent());
//            string modalText = string.Empty;
//            if (driver.SwitchTo().Alert() != null)
//            {
//                IAlert modalwindowhandle = driver.SwitchTo().Alert();
              
//                    modalText = modalwindowhandle.Text;
//                    modalwindowhandle.Accept();
                
//            }else
//            {
//                logger.Info("Alert is not present.." );
                
//            }

//            return modalText;

//        }

//        public string GetAttributeValue(ILocator locator, string property)
//        {
//            string value = null;
//            var element = driver.FindElements(sel.getByObject(locator));
//            foreach (IWebElement item in element)
//            {
//                value = item.GetAttribute(property);
//                logger.Info("The attribute value is : " + value);
//            }
//            return value;
//        }

//        /// <summary>
//        /// Clicks On the value of the Element based on the Property
//        /// Example, for the Div Tag, Property would be - "innerHTML"
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="list"></param>
//        /// <returns>string</returns>
//        public void ClicksonAttributeValues(ILocator locator, string tagname, string property, string valuetoClickon, bool ispropertyneeded = true, bool isTagnamePresent = true)
//        {
//            List<IWebElement> listOFelements = getTheListofElements(locator, tagname, isTagnamePresent);
//            if (listOFelements.Count != 0)
//            {
//                for (int i = 0; i < listOFelements.Count; i++)
//                {
//                    if (ispropertyneeded == true)
//                    {
//                        if (!(property == null || property == string.Empty))
//                        {
//                            string attributevalue = listOFelements[i].GetAttribute(property);
//                            //string text = listOFelements[i].Text.ToString();
//                            if (attributevalue.Contains(valuetoClickon))
//                            {
//                                listOFelements[i].Click();
//                                break;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        string attributevalue = listOFelements[i].Text;
//                        if (attributevalue.Contains(valuetoClickon))
//                        {
//                            listOFelements[i].Click();
//                            break;
//                        }
//                    }

//                }
//            }
//            else
//            {
//                logger.Error("There are no elements present with this locator");
//            }
//        }


//        /// <summary>
//        /// Clicks On the value of the Element based on the Property
//        /// Example, for the Div Tag, Property would be - "innerHTML"
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="list"></param>
//        /// <returns>string</returns>
//        public void ContextClickOnElementWithAttributeValues(ILocator locator, string tagname, string property, string valuetoClickon, bool ispropertyneeded = true, bool isTagnamePresent = true)
//        {
//            List<IWebElement> listOFelements = getTheListofElements(locator, tagname, isTagnamePresent);
//            if (listOFelements.Count != 0)
//            {
//                for (int i = 0; i < listOFelements.Count; i++)
//                {
//                    if (ispropertyneeded == true)
//                    {
//                        if (!(property == null || property == string.Empty))
//                        {
//                            string attributevalue = listOFelements[i].GetAttribute(property);
//                            //string text = listOFelements[i].Text.ToString();
//                            if (attributevalue.Contains(valuetoClickon))
//                            {
//                                IWebElement ele = listOFelements[i];
//                                Actions action = new Actions(driver);
//                                action.ContextClick(ele).Build().Perform();
//                                break;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        string attributevalue = listOFelements[i].Text;
//                        if (attributevalue.Contains(valuetoClickon))
//                        {
//                            IWebElement ele = listOFelements[i];
//                            Actions action = new Actions(driver);
//                            action.ContextClick(ele).Build().Perform();                            
//                            break;
//                        }
//                    }

//                }
//            }
//            else
//            {
//                logger.Error("There are no elements present with this locator");
//            }
//        }

//        /// <summary>
//        /// set the width of an elemnt using css
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="propertyValue"></param>
//        public  void SetCssWidthProperty(ILocator locator,string propertyValue)
//        {
            
//            IWebElement element = sel.GetElement(locator);
//            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
//            js.ExecuteScript("arguments[0].style.width = arguments[1]", element,propertyValue);         
           

//        }

//        /// <summary>
//        /// set the height of an elemnt using css
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="propertyValue"></param>
//        public void SetCssHeightProperty(ILocator locator, string propertyValue)
//        {

//            IWebElement element = sel.GetElement(locator);
//            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
//            js.ExecuteScript("arguments[0].style.height = arguments[1]", element, propertyValue);

//            Thread.Sleep(500);
//        }


//        /// <summary>
//        /// Gets the value of the Element based on the Property
//        /// Example, for the Div Tag, Property would be - "innerHTML"
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="property"></param>
//        /// <returns>string</returns>
//        public List<string> GetListOfAttributeValues(ILocator locator, string tagname, List<string> property, bool istagnamePresent = true)
//        {

//            List<IWebElement> listOFelements = getTheListofElements(locator, tagname, istagnamePresent);

//            var listofattributeValues = new List<string>();
//            if (listOFelements.Count != 0)
//            {
//                string data = null;
//                for (int i = 0; i < listOFelements.Count; i++)
//                {
//                    string _data = null;
//                    if (property.Count != 0)
//                    {
//                        for (int j = 0; j < property.Count; j++)
//                        {
//                            string text = property[j].ToString().Trim();
//                            if (j < property.Count - 1)
//                            {
//                                if (text.Contains("color"))
//                                {
//                                    string colorvalue = listOFelements[i].GetCssValue(text);
//                                    if (colorvalue.Contains("rgb"))
//                                    {
//                                        string color = ConvertRGBAColorValuetoHexValue(colorvalue);
//                                        _data = _data + color + ",";
//                                    }
//                                    else
//                                    {
//                                        _data = _data + colorvalue + ",";
//                                    }
//                                }
//                                else
//                                {
//                                    _data = _data + listOFelements[i].GetAttribute(text) + ",";
//                                }
//                            }
//                            else
//                            {
//                                if (text.Contains("color"))
//                                {
//                                    string colorval = listOFelements[i].GetCssValue(text);
//                                    if (colorval.Contains("rgb"))
//                                    {
//                                        string color = ConvertRGBAColorValuetoHexValue(colorval);
//                                        _data = _data + color;
//                                    }
//                                    else
//                                    {
//                                        _data = _data + colorval;
//                                    }
//                                }
//                                else
//                                    _data = _data + listOFelements[i].GetCssValue(text);
//                            }
//                        }
//                        data = _data;
//                    }
//                    listofattributeValues.Add(data);
//                }
//            }
//            return listofattributeValues;
//        }

//        public List<string> GetListOFElements(ILocator locator, string property)
//        {
//            //IWebElement element = driver.FindElement(sel.getByObject(locator));
//            List<IWebElement> listOFWebElements = new List<IWebElement>(driver.FindElements(sel.getByObject(locator)));
//            var listofattributeValues = new List<string>();
//            if (listOFWebElements.Count != 0)
//            {
//                string data = null;
//                for (int i = 0; i < listOFWebElements.Count; i++)
//                {
//                    string attributevalue = listOFWebElements[i].GetAttribute(property);
//                    string text = listOFWebElements[i].Text.ToString();
//                    data = data + attributevalue + "," + text;
//                    listofattributeValues.Add(data);
//                }
//            }
//            return listofattributeValues;
//        }

//        #region Get List OF Attribute values And its Text
//        public List<string> GetListOFElementText(ILocator locator, string tagname, string property, bool istagnamenotNull = true)
//        {
//            List<IWebElement> listOFelements = getTheListofElements(locator, tagname, istagnamenotNull);
//            var listofattributeValues = new List<string>();
//            if (listOFelements.Count != 0)
//            {
//                string data = null;
//                for (int i = 0; i < listOFelements.Count; i++)
//                {
//                    string attributevalue = listOFelements[i].GetAttribute(property);
//                    string text = listOFelements[i].Text.ToString();
//                    data = data + attributevalue + "," + text;
//                    listofattributeValues.Add(data);
//                }
//            }
//            return listofattributeValues;
//        }
//        #endregion

//        //Converts the RGBA value to Hex Value
//        public string ConvertRGBAColorValuetoHexValue(string colorvalue)
//        {
//            string[] hexValue = colorvalue.Replace("rgba(", "").Replace(")", "").Split(',');

//            int hexValue1 = Int32.Parse(hexValue[0]);
//            hexValue[1] = hexValue[1].Trim();
//            int hexValue2 = Int32.Parse(hexValue[1]);
//            hexValue[2] = hexValue[2].Trim();
//            int hexValue3 = Int32.Parse(hexValue[2]);

//            string actualColor = string.Format("#{0:X2}{1:X2}{2:X2}", hexValue1, hexValue2, hexValue3);
//            logger.Info("The Color of the Icon is : " + actualColor);
//            return actualColor;
//        }

//        public List<IWebElement> getTheListofElements(ILocator locator, string tagname, bool istagnameNotnull)
//        {
//            List<IWebElement> listOFWebElements = null;
//            if (istagnameNotnull == true)
//            {
//                IWebElement element = driver.FindElement(sel.getByObject(locator));
//                listOFWebElements = new List<IWebElement>(element.FindElements(By.TagName(tagname)));
//            }
//            else
//            {
//                listOFWebElements = new List<IWebElement>(driver.FindElements(sel.getByObject(locator)));
//            }
//            return listOFWebElements;
//        }

//        public void rightclickDeleteHighlight(IWebElement element)
//        {

//        }

//        public string GetInnerHTMLText(ILocator locator)
//        {
//            string innerHtml = string.Empty;
//            var element = driver.FindElement(sel.getByObject(locator));
//            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
//            if (js != null)
//            {
//                innerHtml = (string)js.ExecuteScript("return arguments[0].innerHTML;", element);
//            }
//            return innerHtml;
//        }

//        /// <summary>
//        /// Enters the value to the Div tag with tooltip trigger - mouseenter etc.. 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="texttoEnter"></param>
//        public void EnterToInnerHTML(ILocator locator, string texttoEnter)
//        {
//            Actions action = new Actions(driver);
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            sel.scrollElement(element);
//            if (element.Displayed && element.Enabled)
//            {
//                if (sel.Browser().ToLower() == "chrome")
//                {
//                    element.Click();
//                    IWebElement parent = element.FindElement(By.XPath(".."));
//                    action.SendKeys(parent, texttoEnter).Build().Perform();
//                    Thread.Sleep(200);
//                    Actions action1 = new Actions(driver);
//                    action1.SendKeys(Keys.Return).Build().Perform();
//                    Thread.Sleep(1000);
//                    action1.SendKeys(Keys.Escape).Build().Perform();

//                }
//                else
//                {
//                    //element.Click();
//                    //element.SendKeys(texttoEnter);
//                    //action.SendKeys(element, texttoEnter);
//                    action.SendKeys(element, texttoEnter).SendKeys(Keys.Tab).Build().Perform();
//                    //element.SendKeys(Keys.Return);
//                    //action.SendKeys(Keys.Return).Build().Perform();
//                    Thread.Sleep(1000);
                  
                  
//                }

               
//            }
//            else
//            {
//                String errMsg = "Element is not enabled or displayed on the DOM with locator :" + element.Text;
//                logger.Error(errMsg);
//                throw new Exception(errMsg);
//            }
//        }

//        /// <summary>
//        /// Enters the value to the Div tag with tooltip trigger - mouseenter etc.. 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="texttoEnter"></param>
//        public void EnterToInnerHTML_Tab(ILocator locator, string texttoEnter)
//        {
//            Actions action = new Actions(driver);
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            action.SendKeys(element, texttoEnter).SendKeys(Keys.Tab).Perform();
//            Thread.Sleep(4000);
//        }

//        /// <summary>
//        /// Enters the value to the Div tag with tooltip trigger - mouseenter etc.. 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="texttoEnter"></param>
//        public void EnterToInnerHTML_WihOutTab(ILocator locator, string texttoEnter)
//        {
//            Actions action = new Actions(driver);
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            action.SendKeys(element, texttoEnter).Build().Perform();
//            Thread.Sleep(4000);
//        }

//        /// <summary>
//        /// clicks on Keyboard Enter .. 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="texttoEnter"></param>
//        public void ClickEnterKey(ILocator locator)
//        {
//            Actions action = new Actions(driver);
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            action.SendKeys(Keys.Enter).Build().Perform();
//            Thread.Sleep(4000);
//        }

//        public string GetElementColor(ILocator locator, string colorvalueforElement)
//        {
//            string color = driver.FindElement(sel.getByObject(locator)).GetCssValue(colorvalueforElement);
//            return color;
//        }

//        /// <summary>
//        /// Gets the Value of Color for the element in RGB 
//        /// Converts the value to Hex
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns>Hex Value of color</returns>
//        public string GetElementColorInHexValue(ILocator locator, string colorvalueforElement)
//        {
//            string color = GetElementColor(locator, colorvalueforElement);
//            string[] hexValue = color.Replace("rgba(", "").Replace(")", "").Split(',');

//            int hexValue1 = Int32.Parse(hexValue[0]);
//            hexValue[1] = hexValue[1].Trim();
//            int hexValue2 = Int32.Parse(hexValue[1]);
//            hexValue[2] = hexValue[2].Trim();
//            int hexValue3 = Int32.Parse(hexValue[2]);

//            string actualColor = string.Format("#{0:X2}{1:X2}{2:X2}", hexValue1, hexValue2, hexValue3);
//            logger.Info("The Color of the Icon is : " + actualColor);
//            return actualColor;
//        }

//        /// <summary>
//        /// Gets the checkbox value if checked or not.. 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns>value of the checkbox</returns>
//        public string GetCheckBoxAttribute(ILocator locator)
//        {
//            string value = "";
//            var allcheckboxes = driver.FindElements(sel.getByObject(locator));

            
//            foreach (IWebElement checkbox in allcheckboxes)
//            {
//                value = checkbox.GetAttribute("checked");
//             }
//            return value;
//        }

//        public bool GetCheckBoxStatus(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            if (element.Enabled)
//            {
//                if (element.Selected)
//                    return true;
//                else
//                    return false;
//            }
//            return false;
//        }
//        public void SelectCheckbox(ILocator locator, string message = "")
//        {
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            if (element.Enabled)
//            {
//                if (!element.Selected)
//                {
//                    element.Click();
//                    logger.Info("selected the checkbox " + message);
//                }
//                else
//                {
//                    logger.Info("check is already Selected " + message);
//                }

//            }
//            else
//            {
//                string errMsg = "Element is not enabled on the DOM with locator :" + element.Text;
//                logger.Error(errMsg);
//            }
//        }


//        public void SelectMultipleCheckbox(ILocator locator, int count, string message = "")
//        {
//            IList<IWebElement> elements = driver.FindElements(sel.getByObject(locator));

//            int checkCount = 0;
//            foreach (IWebElement ele in elements)
//            {
//                if (checkCount >= count)
//                    break;

//                if (ele.Displayed && ele.Enabled && !ele.Selected)
//                {
//                    ele.Click();
//                    Thread.Sleep(1000);
//                    checkCount++;

//                }
//                else
//                {
//                    String errMsg = "Element is not enabled on the DOM with locator :" + ele.Text;
//                    logger.Error(errMsg);
//                    throw new Exception(errMsg);
//                }
//            }

//        }


//        public void UnSelectCheckbox(ILocator locator, string message = "")
//        {
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            if (element.Enabled)
//            {
//                if (element.Selected)
//                {
//                    element.Click();
//                    logger.Info("UnSelected the checkbox " + message);
//                }
//                else
//                {
//                    logger.Info("checkbox is already UnSelected " + message);
//                }

//            }
//            else
//            {
//                string errMsg = "Element is not enabled on the DOM with locator :" + element.Text;
//                logger.Error(errMsg);
//            }
//        }

//        public int CountUnSelectCheckbox(ILocator locator)
//        {
//            int i = 0;
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            if (element.Enabled)
//            {

//                if (element.Selected)
//                {
                    
//                     i++;
//                }
                
//            }
//            return i;
//        }


//        //Checks if Checkbox is selected.. if not, checks that checkbox..
//        public void SelectCheckboxfromTable(ILocator tablelocator, string panelID, string checkboxpropertyvalue, int rowindexNottobeConsidered)
//        {
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            if (allRows.Count != 0)
//            {
//                string data = string.Empty;
//                for (int row = 0; row < allRows.Count - rowindexNottobeConsidered; row++)
//                {
//                    List<IWebElement> allCells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//                    if (allCells.Count != 0)
//                    {
//                        var checkbox = driver.FindElement(By.XPath("//*[@id='" + panelID + "']/ng-include/div/table/tbody/tr[" + (row + 1) + "]//input[@type='checkbox' and @ng-change='" + checkboxpropertyvalue + "']"));
//                        if (!checkbox.Selected)
//                        {
//                            checkbox.Click();
//                            logger.Info("Checked the checkbox, not previously selected from the Table..");
//                            break;
//                        }
//                        else
//                        {
//                            logger.Info("Checkbox is already selected..");
//                        }
//                    }
//                    else
//                    {
//                        logger.Error("There are Zero Columns in the table..");
//                    }
//                }
//            }
//            else
//            {
//                logger.Error("Number of Rows in the table are '0'");
//            }
//        }

//        /// <summary>
//        /// Finds the button that need to be clicked based on the selection - buttonname 
//        /// clicks on the button 
//        /// </summary>
//        /// <param name="buttonname"></param>
//        public void ClickOnButtonBasedonButtonname(string buttonname)
//        {
//            IList<IWebElement> button1 = driver.FindElements(By.TagName("button"));
//            logger.Info("Total buttons available is : " + button1.Count);
//            if (button1.Count != 0)
//            {
//                foreach (IWebElement i in button1)
//                {
//                    if (i.Text.Equals(buttonname))
//                    {
//                        i.Click();
//                        logger.Info("Clicked on the button - " + buttonname);
//                        break;
//                    }
//                }
//            }
//            else
//                logger.Error("There is no element present.. ");
//        }

//        /// <summary>
//        /// Gets the text of the selected item from dropdown
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns>text of selected item</returns>
//        public string GetSelectedtextfromDropdown(ILocator locator)
//        {
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            SelectElement selectedElement = new SelectElement(element);
//            string selectedText = selectedElement.SelectedOption.Text;
//            return selectedText;
//        }

//        /// <summary>
//        /// Gets the text of the selected item from dropdown / Search element by tagname
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <returns>text of selected item</returns>
//        public void SelecttextfromDropdown_Without_tagName_Select(string tagname, int index)
//        {
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(By.TagName(tagname)));
//            int count = elements.Count;
//            if (count != 0)
//            {
//                Actions action = new Actions(driver);
//                action.MoveToElement(elements[index]).Click().Perform();
//            }
//            else
//            {
//                logger.Error("There are no elements present..SelecttextfromDropdown_Without_tagName_Select()..");
//            }
//        }

//        //select random value from dropdown without select tag
//        public void SelectRandomValueFromList_WithoutTagnameSelect(ILocator locator)
//        {
//            IList<IWebElement> elements = sel.GetElements(locator);
//            int elecount = elements.Count;
//            int index = GeneralModule.GetRandomNumber(1, elecount - 1);
//            sel.ClickElement(elements[index]);

//        }




//        //Gets the text of the selected item from dropdown / Search element by locator (xpath, id etc.. )
//        public void Selecttext_WithoutTagname_Select(ILocator locator, int index)
//        {
//            IWebElement element = getWebElementbasedOnIndex(locator, index);
           
//            Actions action = new Actions(driver);
//            action.MoveToElement(element).Click().Perform();
//        }

//        public string getSelectedtext_WithoutTagname_Select(ILocator locator, int index)
//        {
//            IWebElement element = getWebElementbasedOnIndex(locator, index);
//            return element.Text;
//        }

//        //Gets the WebElement based on the Index
//        private IWebElement getWebElementbasedOnIndex(ILocator locator, int index)
//        {
//            IWebElement ele = null;
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(sel.getByObject(locator)));
//            int count = elements.Count;
//            if (count != 0)
//            {
//                ele = elements[index];
//            }
//            else
//            {
//                logger.Error("There are no elements present..SelecttextfromDropdown_Without_tagName_Select()..");
//            }
//            return ele;
//        }

//        //Gets the total no. of elements present
//        public int getElementCount(ILocator locator)
//        {
//            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(sel.getByObject(locator)));
//            return elements.Count;
//        }

//        /// <summary>
//        /// Selects the Value from Dropdown based on entering text or random
//        /// If Boolean randomselection is True - selects the Value randomly  else selection is based on the Text
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="texttoSelect"></param>
//        /// <param name="randomselection"></param>
//        public void SelecttextFromDropdown(ILocator locator, string texttoSelect = null, bool randomselection = false, int minvalueforRandomselection = 0)
//        {
//            if (randomselection == true)
//            {
//                string existingText = GetSelectedtextfromDropdown(locator);
//                SelectOptionsfromDropdownRandomly(locator, existingText, minvalueforRandomselection);
//            }
//            else
//            {
//                IWebElement element = driver.FindElement(sel.getByObject(locator));
//                element.Click();
//                SelectElement selectedElement = new SelectElement(element);
//                selectedElement.SelectByText(texttoSelect);
//                logger.Info("Selected the Element from the dropdown: " + texttoSelect);
//            }
//        }

//        public void SelectOptionsfromDropdownRandomly(ILocator locator, string existingTexttoExcludefromSelection, int minvalueforRandomselection = 0)
//        {
//            string option = null;
//            IWebElement element = driver.FindElement(sel.getByObject(locator));
//            SelectElement selectedElement = new SelectElement(element);
//            int itemCount = selectedElement.Options.Count;
//            logger.Info("Total number of Options in Dropdown is: " + itemCount);
//            if (itemCount != 0)
//            {
//                int tries = 0;
//                do
//                {
//                    Random r = new Random();
//                    int rnd = r.Next(minvalueforRandomselection, itemCount);
//                    selectedElement.SelectByIndex(rnd);
//                    AcceptOrDismissAlert("Accept");
//                    option = selectedElement.SelectedOption.Text;
//                    tries++;
//                }
//                while (option.Equals(existingTexttoExcludefromSelection) && tries < 2);
//                logger.Info("Selected the Element from the dropdown.. " + option);
//            }
//            else
//                logger.Error("There are 0 options to select from Dropdown..");
//        }

//        /// <summary>
//        /// Gets the CellValue from Table in Particular Row.. 
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <param name="row"></param>
//        /// <param name="objectToFindInTable"></param>
//        /// <returns>cell Text</returns>
//        public string getValuefromTable(ILocator tablelocator, string Objecttofind)
//        {
//            IWebElement element = FindValuefromtable(tablelocator, Objecttofind);
//            return element.Text;
//        }

//        /// <summary>
//        /// Finds the Object in the table (Checks in all rows)
//        /// Clicks the object once it finds the Object.. 
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <param name="objectToFiindInTable"></param>
//        public void FindandClickValuefromtable(ILocator tablelocator, string Objecttofind)
//        {
//            IWebElement element = FindValuefromtable(tablelocator, Objecttofind);
//            element.Click();
//        }

//        /// <summary>
//        /// Finds the webelement from the table
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <param name="objectToFiindInTable"></param>
//        /// <returns>webelement</returns>
//        public IWebElement FindValuefromtable(ILocator tablelocator, string objectToFind)
//        {
//            IWebElement element = null;
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            if (allRows.Count != 0)
//            {
//                for (int row = 0; row < allRows.Count; row++)
//                {
//                    List<IWebElement> cells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//                    if (cells.Count != 0)
//                    {
//                        element = driver.FindElement(By.XPath("//tr[" + (row + 1) + "]" + objectToFind));
//                        if (!element.Displayed)
//                        {
//                            logger.Error("The Element is not Present in the cell : " + objectToFind);
//                            element = null;
//                            //return element;
//                        }
//                        else
//                        {
//                            return element;
//                            //logger.Error("The Element is not Present in the cell : " + objectToFind);
//                            //element = null;
//                        }
//                    }
//                    else
//                    {
//                        logger.Error("There are '0' columns in the table");
//                        break;
//                    }
//                }
//            }
//            else
//            {
//                logger.Info("The total no. of rows in the table are '0'");
//            }
//            return element;
//        }

//        /// <summary>
//        /// finds the element in the table and returns boolean
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <param name="objectToFiindInTable"></param>
//        /// <returns>boolean</returns>
//        public bool IsElementPresentInTable(ILocator tablelocator, ILocator objectToFiindInTable)
//        {
//            bool isElementPresent = false;
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            if (allRows.Count != 0)
//            {
//                foreach (var row in allRows)
//                {
//                    //List<IWebElement> cells = new List<IWebElement>(row.FindElements(By.TagName("td")));
//                    //if (cells.Count != 0)
//                    //{
//                    //    for (int cell = 0; cell < cells.Count; cell++)
//                    //    {
//                    if (sel.isElementPresentNow(objectToFiindInTable))
//                    //if (sel.isElementVisibleNow(objectToFiindInTable))
//                    {
//                        isElementPresent = true;
//                        logger.Info("The Element is present in the Table at Row # : " + row.Text);
//                        return isElementPresent;
//                    }
//                    else
//                    {
//                        logger.Info("The Element is not present in the Table at Row # : " + row.Text);
//                        isElementPresent = false;
//                    }
//                    //    }
//                    //}
//                    //else
//                    //    logger.Error("There are '0' columns in the table");
//                }
//            }
//            else
//            {
//                logger.Info("The total no. of rows in the table are '0'");
//            }
//            return isElementPresent;
//        }


//        /// <summary>
//        /// Compares 2 list objects and retuns true if same, else false
//        /// </summary>
//        /// <param name="list1"></param>
//        /// <param name="list2"></param>
//        /// <returns></returns>
//        public bool CompareTwoLists(IList<string> list1, IList<string> list2)
//        {
//            IQueryable<string> list1_trimmed = list1.AsQueryable<string>().Select(s => s.Trim());
//            IQueryable<string> list2_trimmed = list2.AsQueryable<string>().Select(s => s.Trim());
//            var firstNotSecond = list1_trimmed.Except(list2_trimmed).ToList();
//            var secondNotFirst = list2_trimmed.Except(list1_trimmed).ToList();
//            return !firstNotSecond.Any() && !secondNotFirst.Any();
//        }

//        /// <summary>
//        /// TODO: Make it more generic.. 
//        /// Created this to support the Multiphysician Table in abstraction window and DRG History table.. 
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <returns></returns>
//        public List<string> getAllValuesfromAbstractionPhysicianTable(ILocator tablelocator)
//        {
//            var rowText = new List<string>();
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            //sel.scrollElement(table);
//            sel.turnOffImplicitWaits();
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            sel.turnOnImplicitWaits();
//            sel.ScrollPage("down");
//            if (allRows.Count != 0)
//            {
//                string data = string.Empty;
//                for (int row = 0; row < allRows.Count; row++)
//                {
//                    List<IWebElement> allCells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//                    if (allCells.Count != 0)
//                    {
//                        if (allCells[3].Text != string.Empty)
//                        {
//                            data = allCells[0].Text + ", " + allCells[1].Text + ", "
//                                + allCells[2].Text + " " + allCells[3].Text + ", " + allCells[4].Text;
//                        }
//                        else
//                        {
//                            data = allCells[0].Text + ", " + allCells[1].Text + ", " + allCells[2].Text + ", " + allCells[4].Text;
//                        }
//                    }
//                    else
//                    {
//                        logger.Error("There are Zero Columns in the table..");
//                    }
//                    rowText.Add(data);
//                }
//            }
//            else
//            {
//                logger.Error("Number of Rows in the table are '0'");
//            }
//            return rowText;
//        }//end of method  

//        public void ClickOnElementExistsinTablebasedonCellValue(ILocator tablelocator, string columnTagname, string cellValue, bool isAnotherElementInEachRow = false, string xpathtoOtherElement = "")
//        {
//            IWebElement element = getCellElementfromtheTableBasedonCellValue(tablelocator, columnTagname, cellValue, isAnotherElementInEachRow, xpathtoOtherElement);
//            element.Click();
//        }

//        /// <summary>
//        /// Finds and returns element based on CellValue
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="CellValue"></param>
//        private IWebElement getCellElementfromtheTableBasedonCellValue(ILocator tablelocator, string columnTagname, string cellValue, bool isAnotherElementInEachRow, string xpathtoOtherElement)
//        {
//            IWebElement element = null;
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            int rows = allRows.Count;
//            if (rows != 0)
//            {
//                foreach (var r in allRows)
//                {
//                    List<IWebElement> cells = new List<IWebElement>(r.FindElements(By.TagName(columnTagname)));
//                    if (cells.Count != 0)
//                    {
//                        foreach (var c in cells)
//                        {
//                            logger.Info("The cell Value is : " + c.Text);
//                            string txt = c.Text;
//                            if (txt.Contains(cellValue.Trim()))
//                            {
//                                logger.Info("Found the Value in  the table" + c.Text);
//                                if (isAnotherElementInEachRow == true)
//                                {
//                                    IWebElement otherElement = driver.FindElement(By.XPath(xpathtoOtherElement));
//                                    element = otherElement;
//                                }
//                                else
//                                    element = c;
//                                return element;
//                            }
//                        }
//                    }
//                    else
//                        logger.Error("getCellElementfromtheTableBasedonCellValue().. Number of Column Count is '0'");
//                }
//            }
//            else
//            {
//                logger.Error("getCellElementfromtheTableBasedonCellValue().. Number of Row Count is '0'");
//            }
//            return element;
//        }


//        /// <summary>
//        /// Gets all the Webtable from UI into the Datatable object 
//        /// user can also specify the specific columns to be retrieved
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <returns></returns>
//        public DataTable GetWebtableIntoDatatable(ILocator tablelocator, List<string> columnNames)
//        {
//            var rowText = new List<string>();
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            List<IWebElement> allHeaders = new List<IWebElement>(table.FindElements(By.TagName("th")));
//            DataTable dt = new DataTable();
        
//            //add column names for the datatable
//            for (int i = 0; i < columnNames.Count; i++)
//            {
//                string columnName = columnNames[i].Trim();                
//                 dt.Columns.Add(columnName);
                
//            }

//                if (allRows.Count != 0)
//            {
               
//                //first row is alwats the table headers ,so start from second row
//                for (int row = 1; row < allRows.Count ; row++)
//                {
//                    List<IWebElement> allCells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//                    if (allCells.Count != 0)
//                    {
//                        DataRow dr = dt.NewRow();
                                    
//                        for (int i = 0; i < allCells.Count; i++)
//                        {
//                            string columnName = allHeaders[i].Text.Trim();

//                            if (columnNames.Contains(columnName))
//                            {                               
//                                dr[columnName] =  allCells[i].Text.Trim();                               

//                            }        
                            
//                        }
//                        dt.Rows.Add(dr);

//                    }
//                    else
//                    {
//                        logger.Error("There are Zero Columns in the table..");
//                    }
                  
//                }
//            }
//            else
//            {
//                logger.Error("Number of Rows in the table are '0'");
//            }
//            return dt;
//        }


//        /// <summary>
//        /// Gets all the Webtable from UI into the Datatable object 
//        /// user can also specify the specific columns to be retrieved
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <returns></returns>
//        public int Get_RowNumberFrom_Webtable_BasedOnCellValue(ILocator tablelocator, string cellValue)
//        {
//            var rowText = new List<string>();
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            List<IWebElement> allHeaders = new List<IWebElement>(table.FindElements(By.TagName("th")));
                     

//            if (allRows.Count != 0)
//            {

//                //first row is alwats the table headers ,so start from second row
//                for (int row = 1; row < allRows.Count; row++)
//                {
//                    List<IWebElement> allCells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//                    if (allCells.Count != 0)
//                    {

//                        for (int i = 0; i < allCells.Count; i++)
//                        {

//                             string  cellValue_UI = allCells[i].Text.Trim();

//                            if (cellValue_UI.Trim().Equals(cellValue.Trim()))
//                                return i;
                            
//                        }
                       

//                    }
//                    else
//                    {
//                        logger.Error("There are Zero Columns in the table..");
//                    }

//                }
//            }
//            else
//            {
//                logger.Error("Number of Rows in the table are '0'");
//            }

//            return -1;
          
//        }

//        #region getSpecificColumnValuesInList
//        /// <summary>
//        /// Returns the list of string based on columnindexes.. 
//        /// Created this to support DRG History, APRDRG tables etc..
//        /// </summary>
//        /// <param name="tablelocator"></param>
//        /// <returns></returns>
//        public List<string> getSpecificColumnsValuesfromTable(ILocator tablelocator, int NumberOfRowsNottobeConsidered, List<int> columnindexes, char[] characterToTrimIfAny)
//        {
//            var rowText = new List<string>();
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            if (allRows.Count != NumberOfRowsNottobeConsidered)
//            {
//                string data = string.Empty;
//                for (int row = 0; row < allRows.Count - NumberOfRowsNottobeConsidered; row++)
//                {
//                    List<IWebElement> allCells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//                    if (allCells.Count != 0)
//                    {
//                        string rowdata = string.Empty;
//                        for (int i = 1; i < columnindexes.Count + 1; i++)
//                        {
//                            if (i < columnindexes.Count)
//                                rowdata = rowdata + allCells[i].Text.Trim() + ",";
//                            else
//                            {
//                                char[] delimiter = { ',' };
//                                string text = getTheValueafterSplitandConcatenateAll(delimiter, allCells[i].Text);
//                                rowdata = rowdata + text.TrimStart(characterToTrimIfAny);
//                            }
//                        }
//                        data = rowdata;
//                    }
//                    else
//                    {
//                        logger.Error("There are Zero Columns in the table..");
//                    }
//                    logger.Info("Data found from UI Table: " + data);
//                    rowText.Add(data);
//                }
//            }
//            else
//            {
//                logger.Error("Number of Rows in the table are '0'");
//            }
//            return rowText;
//        }
//        #endregion

//        #region get Values from Table when the checkbox is selected(For DRG/APR DRG History) 
//        public List<string> getColumnsValuesfromTableWhenCheckBoxIsSelected(ILocator tablelocator, string checkboxpropertyvalue, int rowsNottobeConsidered, List<int> columnindexes, char[] characterToTrimIfAny)
//        {
//            var rowText = new List<string>();
//            IWebElement table = driver.FindElement(sel.getByObject(tablelocator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            if (allRows.Count != rowsNottobeConsidered)
//            {
//                if ((allRows.Count == 2) && (checkboxpropertyvalue == "UpdateDRGInitials(drgHistory)"))
//                {
//                    checkboxpropertyvalue = "UpdateDRGInitials(drgCurrent)";
//                }

//                string data = string.Empty;
//                for (int row = 0; row < allRows.Count - rowsNottobeConsidered; row++)
//                {
//                    List<IWebElement> allCells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//                    if (allCells.Count != 0)
//                    {
//                        IWebElement checkbox = null;
//                        bool chkbxSelected = false;
//                        try
//                        {
//                            checkbox = driver.FindElement(By.XPath("//tr[" + (row + 1) + "]//input[@type='checkbox' and @ng-change='" + checkboxpropertyvalue + "']"));
//                            chkbxSelected=checkbox.Selected;

//                        }
//                        catch(Exception e)
//                        {
                           
//                        }

                      

//                        if (chkbxSelected)
//                        {
//                            for (int i = 1; i < columnindexes.Count + 1; i++)
//                            {
//                                if (i < columnindexes.Count)
//                                    data = data + allCells[i].Text.Trim() + ",";
//                                else
//                                {
//                                    char[] delimiter = { ',' };
//                                    string text = getTheValueafterSplitandConcatenateAll(delimiter, allCells[i].Text);
//                                    data = data + text.TrimStart(characterToTrimIfAny);
//                                }
//                            }
//                            logger.Info("Data found from UI Table: " + data);
//                            rowText.Add(data);
//                            return rowText;
//                        }
//                    }
//                    else
//                    {
//                        logger.Error("There are Zero Columns in the table..");
//                    }
//                }
//            }
//            else
//            {
//                logger.Error("Number of Rows in the table are '0'");
//            }
//            return rowText;
//        }
//        #endregion

//        //Gets the text after splitting string
//        private string getTheValueafterSplitandConcatenateAll(char[] delimiter, string valuetosplit)
//        {
//            string text = "";
//            string[] token = valuetosplit.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
//            logger.Info("Total Count of texts after splitting the string is: " + token.Length);
//            int index = token.Length;
//            if (index != 0)
//            {
//                for (int i = 0; i < index; i++)
//                {
//                    text = text + token[i].ToString();
//                }
//            }
//            else
//            {
//                logger.Error("There is no Values to split.. ");
//            }
//            logger.Info("The text is: " + text);
//            return text;
//        }

//        /// <summary>
//        /// Ikhutail: Clicks the Cell from the Workflow table or grid
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="urlcase"></param>
//        public void ClickCellValuefromTableWorkflow(ILocator locator, string urlcase, bool needfirstrowAccount = true)
//        {
//             int numberofRows = 0;
//            int row = 0;
//            IWebElement table = driver.FindElement(sel.getByObject(locator));
//            List<IWebElement> allRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
//            logger.Info("Total no. of Rows in the workqueue are: " + allRows.Count);
//            numberofRows = allRows.Count;
//            if (needfirstrowAccount == false)
//            {
//                Random r = new Random();
//                row = r.Next(0, numberofRows);
//            }
//            else
//            {
//                row = 0;
//            }
//            List<IWebElement> cells = new List<IWebElement>(allRows[row].FindElements(By.TagName("td")));
//            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
//            executor.ExecuteScript("arguments[0].scrollIntoView(true);", cells[2]);
//            Actions action = new Actions(driver);
//            action.MoveToElement(cells[2]).Perform();
//            DoubleClickAndCheckUrl(cells[2], action, urlcase);
//        }


//        /// <summary>
//        /// Finds and Clicks the Cell based on the CellValue
//        /// This method is for the Workflow - non-cdi
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="CellValue"></param>
//        public void ClickCellValuefromtheWorkflowTable(ILocator locator, string CellValue)
//        {
//            try
//            {
//                //IWebElement tab = driver.FindElement(getByObject(locator));
//                //driver.Navigate().Refresh();
//                sel.WaitTillElementAppears(locator, 20);
//                IWebElement t = driver.FindElement(sel.getByObject(locator));
//                List<IWebElement> allRows = new List<IWebElement>(t.FindElements(By.TagName("tr")));

//                int rows = allRows.Count;

//                if (rows != 0)
//                {
//                    foreach (var r in allRows)
//                    {
//                        List<IWebElement> cells = new List<IWebElement>(r.FindElements(By.TagName("td")));
//                        if (cells.Count != 0)
//                        {
//                            foreach (var c in cells)
//                            {
//                                string txt = c.Text;
//                                if (txt.Contains(CellValue.Trim()))
//                                {
//                                    logger.Info("Found the element - The cell Value is : " + c.Text);
//                                    Actions action = new Actions(driver);
//                                    action.MoveToElement(c).Perform();
//                                    Thread.Sleep(1000);
//                                    action.DoubleClick(c).Perform();
//                                    Thread.Sleep(1000);
//                                    return;
//                                }
//                            }
//                            Thread.Sleep(1000);
//                        }
//                        else
//                            logger.Error("Number of Column Count is '0'");
//                    }
//                }
//                else
//                    logger.Error("Number of Row Count is '0'");
//            }
//            catch (Exception e)
//            {
//                logger.Error("Exception occured: " + e.ToString());

//            }
//        }



//        int recursivebreak = 0; //Recursive Variable
//        /// <summary>
//        /// Double clicks the elements and 
//        /// checks for the URL if Changed or not after the Double Click
//        /// Recursive
//        /// </summary>
//        /// <param name="webElement">webelement to double click on</param>
//        /// <param name="action">action</param>
//        /// <param name="url">url to validate if it changed on double click or not</param>
//        public void DoubleClickAndCheckUrl(IWebElement webElement, Actions action, string url)
//        {
//            action.DoubleClick(webElement).Perform();
//            Thread.Sleep(2000);
//            if (!string.IsNullOrEmpty(url))
//            {
//                if (!sel.GetCurrentPageURL().Contains(url) && recursivebreak <= 4)
//                {
//                    recursivebreak++;
//                    Thread.Sleep(1000);
//                    DoubleClickAndCheckUrl(webElement, action, url);
//                    logger.Info("Clicked on the element: " + webElement);
//                }
//            }
//        }



//        /// <summary>
//        /// Gets the Child Object Value.. 
//        /// </summary>
//        /// <param name="locator"></param>
//        /// <param name="tagname"></param>
//        /// <param name="objectToFind">child object</param>
//        /// <returns></returns>
//        public string GetChildWebElementUnderParent(ILocator locator, string tagname, ILocator objectToFind)
//        {
//            string elementText = "";
//            IWebElement elements = driver.FindElement(sel.getByObject(locator));
//            List<IWebElement> childElements = new List<IWebElement>(elements.FindElements(By.TagName(tagname)));
//            logger.Info("GetChildWebElementUnderParent() : The Count of Child Elements are : " + childElements.Count);
//            if (childElements.Count != 0)
//            {
//                foreach (var ele in childElements)
//                {
//                    IWebElement elementToFind;
//                    if (sel.isElementPresent(objectToFind))
//                    {
//                        elementToFind = ele.FindElement(sel.getByObject(objectToFind));
//                        elementText = elementToFind.Text;
//                        logger.Info("The Element is : " + elementText);
//                    }
//                    else
//                    {
//                        logger.Error("GetChildWebElementUnderParent(): The Element is not Present");
//                    }
//                    break;
//                }
//            }
//            else
//            {
//                logger.Error("GetChildWebElementUnderParent() : There are no child Elements, Count return is '0'");
//            }
//            return elementText;

//        }




//    }//class
//}//namespace