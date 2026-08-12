using BankAppAPI.Models;
using MongoDB.Driver;

namespace BankAppAPI.Repositories
{
    public class CustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(IConfiguration configuration)
        {
            string connectionString =
                configuration["MongoDb:ConnectionString"]
                ?? throw new Exception("MongoDB connection string not found.");

            string databaseName =
                configuration["MongoDb:DatabaseName"]
                ?? throw new Exception("MongoDB database name not found.");

            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase database =
                client.GetDatabase(databaseName);

            _customers =
                database.GetCollection<Customer>("customers");
        }

        public List<Customer> GetAll()
        {
            return _customers
                .Find(customer => true)
                .ToList();
        }

        public Customer? GetById(int id)
        {
            return _customers
                .Find(customer => customer.Id == id)
                .FirstOrDefault();
        }

        public Customer Add(Customer customer)
        {
            _customers.InsertOne(customer);

            return customer;
        }

        public bool Delete(int id)
        {
            DeleteResult result =
                _customers.DeleteOne(customer => customer.Id == id);

            return result.DeletedCount > 0;
        }
        public bool Deposit(int id, decimal amount)
        {
            UpdateDefinition<Customer> update =
                Builders<Customer>.Update
                    .Inc(customer => customer.Balance, amount);

            UpdateResult result =
                _customers.UpdateOne(
                    customer => customer.Id == id,
                    update
                );

            return result.MatchedCount > 0;
        }
        public bool Update(int id, Customer updatedCustomer)
        {
            UpdateDefinition<Customer> update =
                Builders<Customer>.Update
                    .Set(customer => customer.Name, updatedCustomer.Name)
                    .Set(customer => customer.Email, updatedCustomer.Email)
                    .Set(customer => customer.Balance, updatedCustomer.Balance);

            UpdateResult result =
                _customers.UpdateOne(
                    customer => customer.Id == id,
                    update
                );

            return result.MatchedCount > 0;
        }
    }
}