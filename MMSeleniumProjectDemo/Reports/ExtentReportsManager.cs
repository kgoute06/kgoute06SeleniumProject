using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
namespace MMSeleniumProjectDemo.Reports
{

    class ExtentReportsManager
    {
        //Instance of extents reports       
        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;

        public ExtentReportsManager()
        {

        }

        public static ExtentReports GetExtentInstanceReport()
        {
            if (extent == null)
            {
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;

                string reportPath = projectPath + "Reports\\TestRunReport.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("Host Name", "Laptop1");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("UserName", "Krishnagoute");

                string extentConfigPath = projectPath + "\\extent-config.xml";
                htmlReporter.LoadConfig(extentConfigPath);

            }

            return extent;


        }
    }
}
