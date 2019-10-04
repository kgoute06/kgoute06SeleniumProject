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

namespace MMSeleniumProjectDemo.AutomationToolImpl
{
    public class SeleniumToolImpl  : AutomationInterface
    {
        public  IWebDriver driver = null;
        string browser = null;

        public SeleniumToolImpl(IWebDriver driver)
        {
            this.driver = driver;
        }


        public override void EnterTextbyLocator(string locatorName,string pathFindlocator, string testData="")
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
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\ErrorScreenshots\\"  + screenshotName + screenTime+ ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;

        }

        private By GetLocator(string locatorName,string pathFindlocator)
        {
            switch(locatorName.ToString().ToLower())
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
            }

            return null;
        }

        

    }
}








