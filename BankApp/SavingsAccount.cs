namespace BankApp
{
    public class SavingsAccount : Account, ITransaction
    {
        public SavingsAccount(decimal initialBalance)
            : base("Savings", initialBalance)
        {
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"${amount:F2} deposited successfully.");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return false;
            }

            // Savings accounts do NOT allow overdraft.
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"${amount:F2} withdrawn successfully.");
                return true;
            }

            Console.WriteLine("Insufficient funds. Savings accounts cannot overdraft.");
            return false;
        }
    }
}