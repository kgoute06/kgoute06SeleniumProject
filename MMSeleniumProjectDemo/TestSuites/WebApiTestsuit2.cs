using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSeleniumProjectDemo.TestUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Assert = NUnit.Framework.Assert;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestFixture]
    public class WebApiTestsuit2
    {
        private IWebDriver _webDriver;
        string BaseUrl = "http://api.openweathermap.org/data/2.5/weather?q=";
        [SetUp]
        public void Setup()
        {
            SetDriver("ie");
            _webDriver.Manage().Window.Maximize();
        }
        [Test]
        public void TestCity1()
        {
            const string cityString = "London,uk";
            ApiResponse apiResponse = new ApiResponse();
            string expectedResult = apiResponse.GetResponse(cityString);
            Thread.Sleep(5000);
            Console.WriteLine("-------------------- Web Page Displayed ------------------");
            _webDriver.Navigate().GoToUrl(BaseUrl + cityString);
            IWebElement responseElement = _webDriver.FindElement(By.TagName("pre"));
            string displayedResponse = responseElement.Text;
            Console.WriteLine(displayedResponse);
            NUnit.Framework.Assert.IsTrue(expectedResult.Equals(displayedResponse));
        }
        [Test]
        public void TestCity2()
        {
            const string cityString = "Baltimore,usa";
            ApiResponse apiResponse = new ApiResponse();
            string expectedResult = apiResponse.GetResponse(cityString);
            Thread.Sleep(5000);
            Console.WriteLine("-------------------- Web Page Displayed ------------------");
            _webDriver.Navigate().GoToUrl(BaseUrl + cityString);
            IWebElement responseElement = _webDriver.FindElement(By.TagName("pre"));
            string displayedResponse = responseElement.Text;
            Console.WriteLine(displayedResponse);
            Assert.IsTrue(expectedResult.Equals(displayedResponse));
        }

        [TearDown]
        public void Teardown()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }

        private void SetDriver(string browerName)
        {
            switch (browerName.ToString().ToLower())
            {
                case "ff":
                    _webDriver = new FirefoxDriver();
                    break;
                case "ie":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.IgnoreZoomLevel = true;
                    options.EnableNativeEvents = false;
                    _webDriver = new InternetExplorerDriver(options);
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("disable-extensions");
                    _webDriver = new ChromeDriver(chromeOptions);
                    break;
            }
        }
    }
}
