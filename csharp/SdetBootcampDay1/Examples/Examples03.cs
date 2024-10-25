using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Examples
{
    [TestFixture]
    public class Examples03
    {
        [Test]
        public void CheckThatDividingByZeroThrowsDivideByZeroException()
        {
            var calculator = new Calculator();

            calculator.Add(5);

            Assert.Throws<DivideByZeroException>(() =>
            {
                calculator.Divide(0);
            });
        }

        [Test]
        public void YouCanAlsoVerifyTheExceptionMessage()
        {
            var calculator = new Calculator();

            calculator.Add(5);

            var dbze = Assert.Throws<DivideByZeroException>(() =>
            {
                calculator.Divide(0);
            });

            Assert.That(dbze.Message, Is.EqualTo("Attempted to divide by zero."));
        }

        [Test]
        public void CheckingForADifferentExceptionFailsTheTest()
        {
            var calculator = new Calculator();

            calculator.Add(5);

            Assert.Throws<ArgumentException>(() =>
            {
                calculator.Divide(0);
            });
        }
    }
}
