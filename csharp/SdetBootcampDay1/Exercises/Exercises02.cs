using System.Collections.Generic;
using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        /**
         * TODO: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */

        [Test, TestCaseSource("Solution")]
        public void SolutionTest(int deposit, int withdrawl, int balance)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(deposit);
            account.Withdraw(withdrawl);

            Assert.That(account.Balance, Is.EqualTo(balance));
        }

        private static IEnumerable<TestCaseData> Solution()
        {
            yield return new TestCaseData(100, 50, 50);
            yield return new TestCaseData(1000, 1000, 0);
            yield return new TestCaseData(250, 1, 249); 
        }


        [Test]
        public void CreateNewSavingsAccount_Deposit100Withdraw50_BalanceShouldBe50()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(100);
            account.Withdraw(50);

            Assert.That(account.Balance, Is.EqualTo(50));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit1000Withdraw1000_BalanceShouldBe0()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(1000);
            account.Withdraw(1000);

            Assert.That(account.Balance, Is.EqualTo(0));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit250Withdraw1_BalanceShouldBe249()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(250);
            account.Withdraw(1);

            Assert.That(account.Balance, Is.EqualTo(249));
        }
    }
}
