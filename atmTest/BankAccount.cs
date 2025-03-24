namespace ATM;

class BankAccount
{
    private double balance;

    public bool hasSufficientFunds(double amount)
    {
        if (amount > balance) return false;

        return true;
    }

    public bool Withdraw(double amount)
    {
        balance -= amount;

        return true;
    }

    public double GetBalance()
    {
        return balance;
    }

    public BankAccount(double amount)
    {
        balance = amount;
    }
}