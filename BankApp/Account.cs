// accounts - Savings & Checking 

using System;
namespace BankApp
{
    public abstract class Account
    {
        // Static: shared by every Account object
        private static int nextAccountNumber = 1000;

        // Properties - encapsulation using getters/setters
        public int AccountNumber { get; private set; }  //Integer number for account number

        public string AccountType { get; protected set; } // accounts - Savings & Checking 


        public decimal Balance { get; protected set; } // decimal number for money

        // Constructor
        public Account(string accountType, decimal initialBalance)
        {
            AccountNumber = ++nextAccountNumber;
            AccountType = accountType;
            Balance = initialBalance;
        }

        // Abstract method - child classes MUST implement this
        public abstract bool Withdraw(decimal amount);

        // Regular method
        public void DisplayAccount()
        {
            Console.WriteLine(
                $"{AccountType} #{AccountNumber} - Balance: ${Balance:F2}"
            );
        }
    }
}