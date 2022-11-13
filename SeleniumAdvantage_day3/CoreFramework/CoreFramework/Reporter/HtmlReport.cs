using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using CoreFramework.APICore;
using CoreFramework.Reporter.ExtentMarkup;
using NUnit.Framework;

namespace CoreFramework.Reporter
{
    public class HtmlReport
    {
        private static int testCaseIndex;
        private static ExtentReports extentReport;
        private static ExtentReports? _report;
        private static ExtentTest? extentTestSuite;
        private static ExtentTest? extentTestCase;
        private static ExtentTest extentTest;
        public static ExtentReports createReport()
        {
            if(_report== null)
            {
                _report = createInstance();

            }
            return _report;
        }
        private static ExtentReports createInstance()
        {
            HtmlReportDirectory.InitReportDirection();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(HtmlReportDirectory.REPORT_FILE_PATH);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;

        }
        public static void flush()
        {
            if(_report != null)
            {
                _report.Flush();
            }
        }
        public static void LogToReport(Status status, string message)
        {
            extentTest.Log(status, message);
        }
        public static void CreateTest(string testName)
        {
            extentTest = _report.CreateTest(testName);
        }
        public static ExtentTest createTest(string className, string classDescription = "")
        {
            if (_report != null)
            {
                _report= createInstance();
            }
            extentTestSuite = _report.CreateTest(className, classDescription);

            return extentTestSuite;

        }
        public static ExtentTest createNode(string className,string testcase, string Description = "")
        {
           
            if(extentTestSuite == null)
            {
                extentTestSuite = createTest(className);

            }
           
            extentTestCase= extentTestSuite.CreateNode(testcase, Description);
            
            return extentTestCase;
        }
    
        public static ExtentTest GetParent()
        {
            
            return extentTestSuite;
        }
        public static ExtentTest GetNode()
        {

            return extentTestCase;
        }
        public static ExtentTest GetTest()
        {

            if (GetNode() == null)
            {
                return GetParent();
            }
            return GetNode();
        }
        public static void Pass(string des)
        {
           
            GetTest().Pass(des);
            TestContext.WriteLine(des);

        }
        public static void Fail(string des)
        {
            GetTest().Fail(des);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des, string path)
        {
            GetTest().Fail(des).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);

        }
        public static void Fail(string des,string ex, string path)
        {
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        public static void Info(string des)
        {
            GetTest().Info(des);
            TestContext.WriteLine(des);
        }
        public static void Warning(string des)
        {
            GetTest().Warning(des);
            TestContext.WriteLine(des);
        }
        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                extentTest.Pass("Test case passed");
            }
            else
            {
                extentTest.Fail("Test case failed");
            }
        }
        public static void Skip(string des)
        {
            GetTest().Skip(des);
            TestContext.WriteLine(des);
        }
        
        public static void MarkUpHtml()
        {
          var htmlMarkUp = HtmlInjector.CreateHtml();
          var m = MarkupHelper.CreateLabel((string)htmlMarkUp, ExtentColor.Transparent);
       
         GetTest().Info(m);
        }
        public static void MarkupPassJson()
        {
            var json = "{'foo':'bar':'foos':['b','a','r'], 'bar':{'foo':'bar', 'bar':false, 'foobar':1234}}";
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }
        public static void MarkupTable()
        {
            string[][] someInts = new string[][] {
                new string[] {
                    "<label> HAHAHA </label>"}
            };
            var m = MarkupHelper.CreateTable(someInts);
            GetTest().Info(m);
        }
        public static void MarkupPassLabel()
        {
            var text = "Passed";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Green);
            GetTest().Pass(m);
        }
        public static void MarkupFailLabel()
        {
            var text = "Failed";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Red);
            GetTest().Fail(m);
        }
        public static void MarkupWarningLabel()
        {
            var text = "Warning";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Orange);
            GetTest().Warning(m);
        }
        public static void MarkupSkipLabel()
        {
            var text = "Skipped";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Blue);
            GetTest().Skip(m);
        }
        public static void MarkupXML()
        {
            string code = "<root>" +
                    "\n    <Person>" +
                    "\n        <Name>Le Hoa</Name>" +
                    "\n        <StartDate>2022-11-11</StartDate>" +
                    "\n        <EndDate>2022-12-12</EndDate>" +
                    "\n        <Location>London</Location>" +
               
            "\n</root>";
            var m = MarkupHelper.CreateCodeBlock(code, CodeLanguage.Xml);
            GetTest().Pass(m);
        }
        public static void CreateAPIRequestLog(APIRequest request, APIResponse response)
        {
        

            GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
        }

    }
}
