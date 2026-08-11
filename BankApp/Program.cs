
//user: neelapvennela_db_user
//pass: z7h2p4SGT5VNVBR0
// connection: mongodb+srv://neelapvennela_db_user:z7h2p4SGT5VNVBR0@cluster0.iq8d1ot.mongodb.net/

namespace BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("    WELCOME TO THE BANK");
            Console.WriteLine("==========================");

            // Create the bank
            Bank bank = new Bank("My Bank");

            // Get customer information
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter your email: ");
            string email = Console.ReadLine() ?? "";

            Customer customer = new Customer(name, email);
            bank.AddCustomer(customer);

            // Create initial accounts
            Console.Write("\nEnter initial checking balance: $");
            decimal checkingBalance = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter initial savings balance: $");
            decimal savingsBalance = Convert.ToDecimal(Console.ReadLine());

            CheckingAccount checking =
                new CheckingAccount(checkingBalance);

            SavingsAccount savings =
                new SavingsAccount(savingsBalance);

            customer.AddAccount(checking);
            customer.AddAccount(savings);

            Console.WriteLine("\nAccounts created successfully!");

            bool running = true;

            // Keep displaying the menu until user exits
            while (running)
            {
                Console.WriteLine("\n==========================");
                Console.WriteLine("        BANK MENU");
                Console.WriteLine("==========================");
                Console.WriteLine("1. See all my accounts");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        customer.DisplayAccounts();
                        break;

                    case "2":
                        Console.Write("Enter deposit amount: $");
                        decimal depositAmount =
                            Convert.ToDecimal(Console.ReadLine());

                        checking.Deposit(depositAmount);
                        break;

                    case "3":
                        Console.Write("Enter withdrawal amount: $");
                        decimal withdrawAmount =
                            Convert.ToDecimal(Console.ReadLine());

                        checking.Withdraw(withdrawAmount);
                        break;

                    case "4":
                        Console.WriteLine(
                            "Transfer feature will be implemented next."
                        );
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("\nThank you for banking with us!");
                        break;

                    default:
                        Console.WriteLine(
                            "Invalid option. Please try again."
                        );
                        break;
                }
            }
        }
    }
}