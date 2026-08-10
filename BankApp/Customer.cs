namespace BankApp
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }

        // One customer can have multiple accounts
        public List<Account> Accounts { get; set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
            Accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void DisplayAccounts()
        {
            Console.WriteLine($"\nAccounts for {Name}:");

            foreach (Account account in Accounts)
            {
                account.DisplayAccount();
            }
        }
    }
}