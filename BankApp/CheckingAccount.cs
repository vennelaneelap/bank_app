namespace BankApp
{
    public class CheckingAccount : Account, ITransaction
    {
        private const decimal OverdraftLimit = 500m;

        public CheckingAccount(decimal initialBalance)
            : base("Checking", initialBalance)
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

            // Checking accounts can overdraft up to $500.
            if (Balance - amount >= -OverdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine($"${amount:F2} withdrawn successfully.");
                return true;
            }

            Console.WriteLine("Withdrawal exceeds overdraft limit.");
            return false;
        }
    }
}