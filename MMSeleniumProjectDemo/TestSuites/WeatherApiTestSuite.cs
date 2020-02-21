using System;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSeleniumProjectDemo.TestUtils;
using NUnit.Framework;
using RestSharp;
using Assert = NUnit.Framework.Assert;

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

        [TestMethod]
        public void Test_GetWeatherInfo()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Guntur", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            string response = restResponse.Content;

            // Verifiying reponse
            if (!response.Contains("Guntur"))
      
                      Assert.Fail("Whether information is not displayed");
        }



        [TearDown]
        public void Teardown()
        {
            wrapperFunctions.CloseandQuitApp();
        }


    }
}
