using Automation.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CoreFramework.NUnitTestSetUp;
using NUnit.Framework;

using RestSharp;

using System.Collections.Generic;
using Automation.ProjectTestSetUp;
using System.Net;
using System.Net.Http.Json;
using Automation.RestSharp;

namespace Automation.Services
{
    public class RestSharpDemo
    {
        private Helper helper;

        public RestSharpDemo()
        {
            helper = new Helper();
        }
        public void DemoData()

        {
            RestClient client = new RestClient("https://apichallenges.herokuapp.com/todos");
            RestRequest request = new RestRequest("/api/users?page=2", Method.Get);
           
            request.AddHeader("Content-Type", "application/json"); 
            request.RequestFormat= DataFormat.Json;
            
            RestResponse response = client.Execute(request);
            var content = response.Content;
            //var list= JsonContent.DeserializeObject<ListOfData>(content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //return list;
        }
        public async Task<RestResponse> GetUsers(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<CreateData>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}
