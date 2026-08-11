using BankAppAPI.Models;

namespace BankAppAPI.Repositories
{
    public class CustomerRepository
    {
        private static readonly List<Customer> customers = new()
        {
            new Customer
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@example.com"
            },

            new Customer
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane@example.com"
            },

            new Customer
            {
                Id = 3,
                Name = "Bob Johnson",
                Email = "bob@example.com"
            }
        };

        public List<Customer> GetAll()
        {
            return customers;
        }

        public Customer? GetById(int id)
        {
            return customers.FirstOrDefault(customer => customer.Id == id);
        }

        public Customer Add(Customer customer)
        {
            customer.Id = customers.Max(c => c.Id) + 1;

            customers.Add(customer);

            return customer;
        }

        public bool Update(int id, Customer updatedCustomer)
        {
            Customer? customer = GetById(id);

            if (customer == null)
                return false;

            customer.Name = updatedCustomer.Name;
            customer.Email = updatedCustomer.Email;

            return true;
        }

        public bool Delete(int id)
        {
            Customer? customer = GetById(id);

            if (customer == null)
                return false;

            customers.Remove(customer);

            return true;
        }
    }
}