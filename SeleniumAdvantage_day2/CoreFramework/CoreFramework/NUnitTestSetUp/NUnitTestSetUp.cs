using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CoreFramework.CoreDriver;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using CoreFramework.Reporter;

namespace CoreFramework.NUnitTestSetUp
{
    [TestFixture]
    public class NUnitTestSetUp
    {
        protected IWebDriver? _driver;
        public WebDriverAction? driverBaseAction;
        protected ExtentReports? _extentReport;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            HtmlReport.createReport();
            HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName);

        }
        [SetUp]
        public void SetUp()
        {
            HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
            
        }
        [TearDown]
        public void TearDown()
        {
            //_driver?.Quit();
             
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
               // TestContext.WriteLine("Passed");
            }else if (testStatus.Equals(TestStatus.Failed))
            {
               // TestContext.WriteLine("Failed");
            }
            HtmlReport.flush();
        }
    }
}
