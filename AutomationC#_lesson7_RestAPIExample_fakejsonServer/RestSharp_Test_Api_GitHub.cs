using RestSharp;
using System.Text.Json;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AutomationC__lesson7_RestAPIExample_fakejsonServer
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CheckThatExpectedLoginIsEqualRepsonseLogin()
        {
            RestClient client = new RestClient("https://api.github.com/");
            ResRequest request = new RestRequest("users/Nelyskov", Method.Get);

            RestResponse response = client.Execute(request);

            // JSON приходит строкой
            var result = JsonSerializer.Deserialize<Dictionary<string, object>>(response.Content);

            Assert.That(result["login"].ToString(), Is.EqualTo("Nelyskov"));
        }

        [Test]
        public void CheckPresposeStatuc_WhenGetUsersRepos()
        {
            RestClient client = new RestClient("https://api.github.com/");
            RestRequest request = new RestRequest("users/Nelyskov/repos", Method.Get);

            RestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));

        }

    }
}
