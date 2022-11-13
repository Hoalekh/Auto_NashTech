using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.APICore;
using Microsoft.VisualBasic;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Automation.Services
{
    public class MockAPIService
    {
        private const string BASE_URL = "https://apichallenges.herokuapp.com";
        public string userLoginPath = "/login";

        public APIResponse LoginRequest(string username, string password)
        {
            APIResponse response = new APIRequest()
                .SetUrl("https://apichallenges.herokuapp.com" + "/login")
                .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                .AddFormData("username", username)
                .AddFormData("password", password)
                .SendRequest();
            return response;
        }
        public string pathRequest04 = "/todo";

        public APIResponse Request04()
        {
            APIResponse response = new APIRequest()
                   .SetUrl(BASE_URL + pathRequest04)
                   .SendRequest();

            return response;


        }
        public string pathRequest05 = "/todos/112";
        public APIResponse Request05()
        {
            APIResponse response = new APIRequest().
                   SetUrl(BASE_URL + pathRequest05)
                   .SendRequest();
            return response;


        }
 
        public string pathRequest08 = "/todos";
        public APIResponse Request08()
        {
            var reqObj = new Todo();
            reqObj.Title = "create new todo";
            reqObj.DoneStatus = true;

            string requestBody = JsonConvert.SerializeObject(reqObj);


            APIResponse response = new APIRequest().
                   SetUrl(BASE_URL + pathRequest08)
                   .SetBody(requestBody)
                   .SendRequest();
            return response;


        }
    }
}