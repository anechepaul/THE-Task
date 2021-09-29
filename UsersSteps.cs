using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;

namespace TimesHigherEducationSpecFlowProject1.Steps
{
    [Binding]
    public class UsersSteps
    {
        RestClient client;
        RestRequest request;
        IRestResponse response;
        ScenarioContext _scenarioContent;
        public UsersSteps(ScenarioContext scenarioContent)
        {
            _scenarioContent = scenarioContent;
        }

        [Given(@"I have a base url '(.*)' and endpoint '(.*)'")]
        public void GivenIHaveABaseUrlAndEndpoint(string url, string endpoint)
        {
            client = new RestClient(url+endpoint);
        }
        
        [When(@"I send a GET request")]
        public void WhenISendAGETRequest()
        {
            request = new RestRequest(Method.GET);
        }

        [When(@"I send a POST request")]
        public void WhenISendAPOSTRequest()
        {
            request = new RestRequest(Method.POST);
        }

        [Then(@"response code is (.*)")]
        public void ThenResponseCodeIs(int responseCode)
        {
            response = client.Execute<List<Users>>(request);
            Assert.AreEqual(responseCode, (int)response.StatusCode);
            _scenarioContent.Add("Users", response.Content);
        }
        
        [Then(@"response body are:")]
        public void ThenResponseBodyAre(Table table)
        {
            var tableDetails = table.CreateSet<tableDatas>();
            var myDeserializedClass =
               JsonConvert.DeserializeObject<List<Users>>(response.Content);
            List<string> Users = new List<string>();
            List<string> responsedata = new List<string>();
            foreach (tableDatas user in tableDetails)
            {
                Users.Add(user.id.ToString());
                Users.Add(user.userName);
                Users.Add(user.password);
            }

            foreach (var resp in myDeserializedClass)
            {
                responsedata.Add(resp.id.ToString());
                responsedata.Add(resp.userName);
                responsedata.Add(resp.password);
            }
            Assert.AreEqual(Users.ToList(), responsedata.ToList());
            Assert.AreEqual(Users.ToString(), responsedata.ToString());
        }

        [Then(@"response body is:")]
        public void ThenResponseBodyIs(Table table)
        {
            var tableDetails = table.CreateInstance<Users>();
            var myDeserializedClass =
               JsonConvert.DeserializeObject<Users>(response.Content);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(tableDetails.id, myDeserializedClass.id);
                Assert.AreEqual(tableDetails.userName, myDeserializedClass.userName);
                Assert.AreEqual(tableDetails.password, myDeserializedClass.password);
            });
        }

    }
}
