using Moq;
using NUnit.Framework;
using SdetBootcampDay2.TestObjects.Examples;

namespace SdetBootcampDay2.Examples
{
    [TestFixture]
    public class Examples02
    {
        [Test]
        public void ExampleNotUsingAMock()
        {
            var whatsApp = new WhatsApp();
            var recipient = new Recipient();

            string messages = whatsApp.GetMessages(recipient);

            Assert.That(messages, Is.EqualTo("REAL messages"));
        }

        [Test]
        public void ExampleUsingAMock()
        {
            var whatsApp = new WhatsApp();
            var recipient = new Mock<Recipient>();

            recipient.Setup(o => o.GetMessages()).Returns("MOCKED messages");

            string messages = whatsApp.GetMessages(recipient.Object);

            // Let's see what happens when we run this test...
            Assert.That(messages, Is.EqualTo("MOCKED messages"));
        }
    }
}
