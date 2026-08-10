namespace BankApp
{
    public interface ITransaction
    {
        void Deposit(decimal amount); //methods to deposit and withdraw money from the account

        bool Withdraw(decimal amount);
    }
}