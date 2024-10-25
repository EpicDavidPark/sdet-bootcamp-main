namespace SdetBootcampDay1.TestObjects
{
    public class Account
    {
        public AccountType AccountType { get; init; }
        public int Balance { get; private set; }

        public Account(AccountType accountType)
        {
            this.AccountType = accountType;
            this.Balance = 0;
        }

        public void Deposit(int amountToDeposit)
        {
            this.Balance += amountToDeposit;
        }

        public void Withdraw(int amountToWithdraw)
        {
            if (this.AccountType.Equals(AccountType.Savings) && amountToWithdraw > this.Balance)
            {
                throw new ArgumentException("You cannot overdraw on a savings account");
            }

            this.Balance -= amountToWithdraw;
        }
    }
}
