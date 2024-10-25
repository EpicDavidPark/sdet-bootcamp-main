using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Examples
{
    [TestFixture]
    public class Examples01
    {
        [Test]
        public void GivenANewCalculator_WhenIAdd2and2_thenTheTotalIs4()
        {
            // Given - Arrange
            var calculator = new Calculator();

            // When - Act
            calculator.Add(2);
            calculator.Add(2);

            // Then - Assert
            Assert.That(calculator.Total, Is.EqualTo(4));
        }
    }
}
