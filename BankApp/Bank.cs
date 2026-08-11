namespace BankApp
{
    public class Bank
    {
        public string BankName { get; set; }

        // Bank has multiple customers
        public List<Customer> Customers { get; set; }

        public Bank(string bankName)
        {
            BankName = bankName;
            Customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void DisplayCustomers()
        {
            Console.WriteLine($"\nCustomers of {BankName}:");

            foreach (Customer customer in Customers)
            {
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine($"Email: {customer.Email}");
            }
        }
    }
}