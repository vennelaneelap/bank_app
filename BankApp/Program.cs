namespace BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("   WELCOME TO THE BANK");
            Console.WriteLine("==========================");

            // Get customer information
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter your email: ");
            string email = Console.ReadLine() ?? "";

            Customer customer = new Customer(name, email);

            // Create checking account
            Console.Write("\nEnter initial checking balance: $");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

            CheckingAccount checking =
                new CheckingAccount(balance);

            customer.AddAccount(checking);

            Console.WriteLine("\nAccount created successfully!");

            customer.DisplayAccounts();

            // Simple transaction test
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");

            Console.Write("\nEnter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter amount: $");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (choice == 1)
            {
                checking.Deposit(amount);
            }
            else if (choice == 2)
            {
                checking.Withdraw(amount);
            }

            Console.WriteLine("\nUpdated Account:");
            checking.DisplayAccount();
        }
    }
}