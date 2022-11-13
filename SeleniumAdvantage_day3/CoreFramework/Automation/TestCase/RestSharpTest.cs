using System;
using System.Net;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using Automation.Services;
using Automation.RestSharp;
using Automation;
using CoreFramework.Reporter;
using CoreFramework.Reporter.ExtentMarkup;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using CoreFramework.APICore;
using RestSharp;

namespace Automation.TestCase
{
    public class RestSharpTest
    {
        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;
        private const string BASE_URL = "https://apichallenges.herokuapp.com/todos";

        //RestSharp
        [DeploymentItem("Test Data")]
        [Test]
        public async Task CreateNewUserTest()
        {
            var payload = Content.ParseJson<CreateData>("CreateUser.json");

            var api = new RestSharpDemo();
            var response = await api.CreateNewUser(BASE_URL, payload);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(201, code);
            HtmlReport.LogToReport(status: Status.Pass, message: "201 response code is received");

            var userContent = Content.GetContent<CreateData>(response);
            Assert.AreEqual(payload.Title, userContent.Title);
        }
        [DeploymentItem("Test Data")]
        [Test]
        public async Task CreateNewUserFail()
        {
            var payload = Content.ParseJson<CreateData>("CreateUser.json");

            var api = new RestSharpDemo();
            RestResponse response = await api.CreateNewUser(BASE_URL, payload);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(404, code);
            HtmlReport.LogToReport(Status.Fail, "404 response code is received");

            var userContent = Content.GetContent<CreateData>(response);
            Assert.AreEqual(payload.Title, userContent.Title);
        }
    }
}
