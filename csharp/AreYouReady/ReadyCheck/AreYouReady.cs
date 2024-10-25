using NUnit.Framework;

namespace AreYouReady.ReadyCheck
{
    [TestFixture]
    public class AreYouReady
    {
        [Test]
        public void AreYouReadyTest()
        {
            int first = 2;
            int second = 2;

            int result = first + second;

            Assert.That(result, Is.EqualTo(4));
        }
    }
}
