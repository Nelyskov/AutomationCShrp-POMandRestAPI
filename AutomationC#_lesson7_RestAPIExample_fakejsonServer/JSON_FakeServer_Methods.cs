using RestSharp;
using System.Text.Json;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AutomationC__lesson7_RestAPIExample_fakejsonServer
{
    public class JSON_FakeServer_Methods
    {
        [Test]
        public void CheckAvailableEndpoints()
        {
            RestClient client = new RestClient("http://localhost:3000/");

            // Попробуйте разные пути
            var endpoints = new[] { "posts", "post", "data", "users", "items" };

            foreach (var endpoint in endpoints)
            {
                var request = new RestRequest(endpoint, Method.Get);
                var response = client.Execute(request);
                Console.WriteLine($"{endpoint}: {response.StatusCode}");

                if (response.IsSuccessful)
                {
                    Console.WriteLine($"Response: {response.Content}");
                }
            }
        }

        [Test]
        public void CheckContent_WheGetUser()
        { 
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("/0", Method.Get);

            RestResponse response = client.Execute(request);

            var jsonDate = JsonSerializer.Deserialize<Dictionary<string, object>>(response.Content);

            Assert.That(jsonDate["alphanumeric"].ToString(), Is.EqualTo("NYY74USZ3OC"));
        }
        [Test]
        public void POST_CreateNewPOSTItem()
        {
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("POST", Method.Post);

            PostObject post = new PostObject()
            {
                name = "Nikita Lyskov",
                phone = "926 425 0250",
                email = "nlyskv12@gmail.com",
                alphanumeric = "XYU",
                currency = "$10 000.00",
                numberrange = 100,
                text = "Tomething bio text",
                country = "Russia",
                region = "Moscow"
            };

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(post);

            var response = client.Execute<PostObject>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            //Assert.That(response.Data.name, Is.EqualTo("Nikita Lyskov"));
        }

        [Test]
        public void DELETE_DeleteItem()
        {
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("/posts/1", Method.Delete);
        }

    }
}
