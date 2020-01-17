using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSeleniumProjectDemo.TestUtils;
using NUnit.Framework;

namespace MMSeleniumProjectDemo.TestSuites
{
    [TestClass]
    public class WeatherApiTestSuite : TestModuleBase
    {
        string webAPIUrl = ConfigurationManager.AppSettings["WebApiURl"];


        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestCity1()
        {
            const string cityString = "London,uk";

            string actaulURl = webAPIUrl + cityString;

            wrapperFunctions.OpenURL(actaulURl);

            ApiResponse apiResponse = new ApiResponse();
            string expectedResult = apiResponse.GetResponse(cityString);
            Thread.Sleep(5000);
            Console.WriteLine("-------------------- Web Page Displayed ------------------");
            string displayedResponse = wrapperFunctions.GettextByUsingTagName("pre");
            Console.WriteLine(displayedResponse);
            NUnit.Framework.Assert.IsTrue(expectedResult.Equals(displayedResponse));
        }
        [Test]
        public void TestCity2()
        {
            const string cityString = "Baltimore,usa";
            wrapperFunctions.OpenURL(webAPIUrl + cityString);
            ApiResponse apiResponse = new ApiResponse();
            string expectedResult = apiResponse.GetResponse(cityString);
            Thread.Sleep(5000);
            Console.WriteLine("-------------------- Web Page Displayed ------------------");
            string displayedResponse = wrapperFunctions.GettextByUsingTagName("pre");
            Console.WriteLine(displayedResponse);
            NUnit.Framework.Assert.IsTrue(expectedResult.Equals(displayedResponse));
        }

        [TearDown]
        public void Teardown()
        {
            wrapperFunctions.CloseandQuitApp();
        }
    }
}
