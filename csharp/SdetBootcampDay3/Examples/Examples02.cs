using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SdetBootcampDay3.Examples
{
    [TestFixture]
    public class Examples02
    {
        private const string BASE_URL = "https://icanhazdadjoke.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [TestCase("R7UfaahVfFd", "My dog used to chase people on a bike a lot. It got so bad I had to take his bike away.")]
        [TestCase("MRZ0LJtHQCd", "What do you call a fly without wings? A walk.")]
        [TestCase("M7wPC5wPKBd", "Did you hear the one about the guy with the broken hearing aid? Neither did he.")]
        public async Task GetJoke_CheckJoke_ShouldBeBad(string jokeId, string expectedJoke)
        {
            RestRequest request = new RestRequest($"/j/{jokeId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("joke")!.ToString(), Is.EqualTo(expectedJoke));
        }

        [Test, TestCaseSource("JokeData")]
        public async Task GetJoke_CheckJoke_ShouldBeBad_UsingTestCaseSource(string jokeId, string expectedJoke)
        {
            RestRequest request = new RestRequest($"/j/{jokeId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("joke")!.ToString(), Is.EqualTo(expectedJoke));
        }

        private static IEnumerable<TestCaseData> JokeData()
        {
            yield return new TestCaseData("R7UfaahVfFd", "My dog used to chase people on a bike a lot. It got so bad I had to take his bike away.");
            yield return new TestCaseData("MRZ0LJtHQCd", "What do you call a fly without wings? A walk.");
            yield return new TestCaseData("M7wPC5wPKBd", "Did you hear the one about the guy with the broken hearing aid? Neither did he.");
        }
    }
}
