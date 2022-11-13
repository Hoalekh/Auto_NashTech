using System;
using System.Net;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework.Internal;
using Automation.Services;
using Automation.RestSharp;
using Automation;
using CoreFramework.Reporter;
using CoreFramework.Reporter.ExtentMarkup;

using CoreFramework.APICore;
using Automation.ProjectTestSetUp;

namespace TestCase
{
    [TestFixture]
    public class APITest : MockAPIService
    {
        
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void APIResquestTest()
        {
            APIResponse response = new MockAPIService().LoginRequest("HoaleKH", "Hoalekh13");
            Assert.AreEqual(response.responseStatusCode, "Successful");
        }
        [Test]
        public void APIRequestTest04()
        {
            APIResponse response = new MockAPIService().Request04();
            Assert.That(response.responseStatusCode, Is.EqualTo("NotFound"));
        }
        [Test]
        public void APIRequestTest05()
        {
            APIResponse response = new MockAPIService().Request05();
            Assert.That(response.responseStatusCode, Is.EqualTo("Successful"));
        }

        [Test]
        public void APIRequestTest08()
        {
            APIResponse response = new MockAPIService().Request08();
            Assert.That(response.responseStatusCode, Is.EqualTo("Successful"));
        }
      
        public void GetTestCase01()
        {
        }
        

    }
}