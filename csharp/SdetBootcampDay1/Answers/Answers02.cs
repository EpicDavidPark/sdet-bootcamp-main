using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Answers
{
    [TestFixture]
    public class Answers02
    {
        /**
         * TODO: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */
        [TestCase(100, 50, 50, TestName = "Deposit 100 and withdraw 50 leaves 50")]
        [TestCase(1000, 1000, 0, TestName = "Deposit 1000 and withdraw 1000 leaves 0")]
        [TestCase(250, 1, 249, TestName = "Deposit 250 and withdraw 1 leaves 249")]
        public void SavingsAccount_DepositThenWithdraw_BalanceShouldBeUpdatedAccordingly
            (int amountToDeposit, int amountToWithdraw, int expectedBalance)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(amountToDeposit);
            account.Withdraw(amountToWithdraw);

            Assert.That(account.Balance, Is.EqualTo(expectedBalance));
        }

        [Test, TestCaseSource("WithdrawTestData")]
        public void SavingsAccount_DepositThenWithdraw_BalanceShouldBeUpdatedAccordingly_UsingTestCaseSource
            (int amountToDeposit, int amountToWithdraw, int expectedBalance)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(amountToDeposit);
            account.Withdraw(amountToWithdraw);

            Assert.That(account.Balance, Is.EqualTo(expectedBalance));

        }

        private static IEnumerable<TestCaseData> WithdrawTestData()
        {
            yield return new TestCaseData(100, 50, 50).
                SetName("Deposit 100 and withdraw 50 should leave 50");
            yield return new TestCaseData(1000, 1000, 0).
                SetName("Deposit 1000 and withdraw 1000 should leave 0");
            yield return new TestCaseData(250, 1, 249).
                SetName("Deposit 250 and withdraw 1 should leave 249");
        }
    }
}
