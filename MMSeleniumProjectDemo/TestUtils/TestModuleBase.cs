using ACSUTestAutomation.AutomationToolImpl;
using AventStack.ExtentReports;
using log4net;
using MMSeleniumProjectDemo.AutomationToolImpl;
using MMSeleniumProjectDemo.Reports;
using MMSeleniumProjectDemo.TestUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo
{
    public class TestModuleBase
    {
        public IWebDriver driver;
        public AutomationInterface wrapperFunctions;
       public static string browser = ConfigurationManager.AppSettings["Browser"];
       public static  string baseDir;
        public CommonUtils utils;


        public static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TestModuleBase()
        {
            driver = SetWebDriver(browser); 
            wrapperFunctions = new SeleniumToolImpl(driver);
            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            utils = new CommonUtils();

        }

        private IWebDriver SetWebDriver(string browser)
        {
            switch (browser.ToString().ToLower())
            {
                case "ff":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.IgnoreZoomLevel = true;
                    options.EnableNativeEvents = false;
                    driver = new InternetExplorerDriver(options);
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("disable-extensions");
                    driver = new ChromeDriver(chromeOptions);
                    break;

            }
            return driver;
        }


    }
}
