using NUnit.Framework;
using RestSharp;
using SdetBootcampDay3.Models;
using System.Net;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises03
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetDataForUser1_CheckName_ShouldEqualLeanneGraham()
        {
            /**
             * TODO: Create and execute a new GET request to '/users/1'
             * Deserialize the response body into a new object of type User
             * Verify that the Name property of the user is equal to Leanne Graham
             */

             RestRequest req = new RestRequest("/users/1", Method.Get);

             RestResponse<UserDto> res = await client.ExecuteAsync<UserDto>(req);

             UserDto? user = res.Data;

             Assert.That(user?.Name, Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public async Task PostNewPost_CheckStatusCode_ShouldBeHttpCreated()
        {
            /** 
             * TODO: Create a new Post object with UserId = 1 and a custom Title and Body
             * Create a new POST request to '/posts', add a JSON representation of the
             * Post object and execute the request
             * Verify that the response status code is equal to HttpStatusCode.Created (HTTP 201).
             */

            PostDto postObj = new PostDto
            {
                UserId = 1,
                Title = "title",
                Body= "body"

            };
             
             RestRequest req = new RestRequest("/posts", Method.Post);

             req.AddJsonBody(postObj);

             RestResponse res = await client.ExecuteAsync(req);

             Assert.That(res.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        }
    }
}
