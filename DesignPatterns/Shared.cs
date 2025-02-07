namespace DesignPatterns;

public class Account
{
    public int Id { get; private set; }
    public decimal Balance { get; set; }

    public Account(int _id, decimal _balance)
    {
        Id = _id;
        Balance = _balance;
    }
}

public class AccountDao
{
    private List<Account> accounts = new List<Account>();

    public void CreateBaseData()
    {
        accounts.Add(new Account(1, 100));
        accounts.Add(new Account(2, 200));
    }

    public Account? GetAccount(int id)
    {
        return accounts.FirstOrDefault(a => a.Id == id);
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }
}
