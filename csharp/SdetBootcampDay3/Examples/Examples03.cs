using NUnit.Framework;
using RestSharp;
using SdetBootcampDay3.Models;
using System.Net;

namespace SdetBootcampDay3.Examples
{
    [TestFixture]
    public class Examples03
    {
        private const string BASE_URL = "https://icanhazdadjoke.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetDataForJokeR7UfaahVfFd_CheckJoke_ShouldEqualExpected()
        {
            RestRequest request = new RestRequest("/j/R7UfaahVfFd", Method.Get);

            RestResponse<JokeDto> response = await client.ExecuteAsync<JokeDto>(request);

            JokeDto user = response.Data;

            Assert.That(user.Joke, Is.EqualTo("My dog used to chase people on a bike a lot. It got so bad I had to take his bike away."));
        }

        [Test]
        public async Task PostNewJoke_CheckStatus_ShouldEqualHttpStatusCodeCreated()
        {
            JokeDto joke = new JokeDto
            {
                Id = "some_id",
                Joke = "The lamest joke I could think of",
                Status = 201
            };

            RestRequest request = new RestRequest("/", Method.Post);

            request.AddJsonBody(joke);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
