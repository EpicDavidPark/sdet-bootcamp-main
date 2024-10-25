using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace SdetBootcampDay3.Examples
{
    [TestFixture]
    public class Examples01
    {
        private const string BASE_URL = "https://icanhazdadjoke.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetRandomJoke_CheckStatusCode_ShouldBeHttpStatusCodeOK()
        {
            RestRequest request = new RestRequest("/", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetRandomJoke_CheckStatusCode_ShouldBe200()
        {
            RestRequest request = new RestRequest("/", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task GetJokeR7UfaahVfFd_CheckContentType_ShouldContainApplicationJson()
        {
            RestRequest request = new RestRequest("/j/R7UfaahVfFd", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.ContentType, Does.Contain("application/json"));
        }

        [Test]
        public async Task GetJokeR7UfaahVfFd_CheckCFCacheStatus_ShouldBeDynamic()
        {
            RestRequest request = new RestRequest("/j/R7UfaahVfFd", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            string serverHeaderValue = response.Headers
                .Where(x => x.Name.Equals("CF-Cache-Status"))
                .Select(x => x.Value.ToString())
                .FirstOrDefault();

            Assert.That(serverHeaderValue, Is.EqualTo("DYNAMIC"));
        }

        [Test]
        public async Task GetJokeR7UfaahVfFd_CheckJoke_ShouldBeBad()
        {
            string expectedJoke = "My dog used to chase people on a bike a lot. It got so bad I had to take his bike away.";

            RestRequest request = new RestRequest("/j/R7UfaahVfFd", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("joke")!.ToString(), Is.EqualTo(expectedJoke));
        }
    }
}
