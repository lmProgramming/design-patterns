namespace DesignPatterns.Structural;

public interface IOldPaymentSystem
{
    public void TransferMoney(Account accountFrom, Account accountTo, float amount);
}

public class OldPaymentSystemImplementation : IOldPaymentSystem
{
    public void TransferMoney(Account accountFrom, Account accountTo, float amount)
    {
        if (accountFrom.Balance < (decimal)amount)
        {
            throw new ArgumentException("Insufficient funds");
        }
        
        accountFrom.Balance -= (decimal)amount;
        accountTo.Balance += (decimal)amount;
    }
}

public interface INewPaymentSystem
{
    public void TransferMoney(Account accountFrom, Account accountTo, decimal amount);
}

public class NewPaymentSystemAdapter(IOldPaymentSystem oldPaymentSystem) : INewPaymentSystem
{
    private readonly IOldPaymentSystem _oldPaymentSystem = oldPaymentSystem;

    public void TransferMoney(Account accountFrom, Account accountTo, decimal amount)
    {
        _oldPaymentSystem.TransferMoney(accountFrom, accountTo, (float)amount);
    }
}