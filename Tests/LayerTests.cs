using DesignPatterns;
using DesignPatterns.Layer;

namespace Tests;

public class LayerTests
{
    [Fact]
    public void TranscriptionScriptTest()
    {
        var accountDao = new AccountDao();
        accountDao.CreateBaseData();

        var service = new TransactionScriptService(accountDao);

        var account1 = accountDao.GetAccount(1)!;
        var account2 = accountDao.GetAccount(2)!;

        Assert.Equal(100, account1.Balance);
        Assert.Equal(200, account2.Balance);

        service.Transfer(1, 2, 50);

        Assert.Equal(50, account1.Balance);
        Assert.Equal(250, account2.Balance);

        Assert.Throws<ArgumentException>(() => service.Transfer(2, 1, 300));
    }

    [Fact]
    public void DomainModelTest()
    {
        var accountDao = new AccountDao();
        accountDao.CreateBaseData();

        var newAccount = new DopeAccount(3, 500);
        var account1 = accountDao.GetAccount(1)!;
        var account2 = accountDao.GetAccount(2)!;

        accountDao.AddAccount(newAccount);

        Assert.Equal(100, account1.Balance);
        Assert.Equal(200, account2.Balance);
        Assert.Equal(500, newAccount.Balance);

        newAccount.TransferTo(account2, 50, out bool success);

        Assert.Equal(450, newAccount.Balance);
        Assert.Equal(250, account2.Balance);
        Assert.True(success);

        newAccount.TransferTo(account1, 10000, out success);

        Assert.Equal(450, newAccount.Balance);
        Assert.Equal(100, account1.Balance);
        Assert.False(success);
    }
}