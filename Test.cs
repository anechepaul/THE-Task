using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimesHigherEducationSpecFlowProject1
{
    public class Test
    {
        [Test]
        public void UserTest()
        {
            var client = new RestClient("https://fakerestapi.azurewebsites.net/api/v1/Users");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute<List<Users>>(request);
            Console.WriteLine(response.Content);
        }
    }
}
