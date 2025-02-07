using DesignPatterns;
using DesignPatterns.Layer;

namespace Tests;

public class LayerTests
{
    [Fact]
    public void Test1()
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
}