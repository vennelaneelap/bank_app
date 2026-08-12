using BankAppAPI.Models;
using BankAppAPI.Repositories;

namespace BankAppAPI.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        // Constructor injection
        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }
        public bool Deposit(int id, decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            return _repository.Deposit(id, amount);
        }
        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        public Customer? GetCustomerById(int id)
        {
            return _repository.GetById(id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _repository.Add(customer);
        }

        public bool UpdateCustomer(int id, Customer customer)
        {
            return _repository.Update(id, customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _repository.Delete(id);
        }
    }
}