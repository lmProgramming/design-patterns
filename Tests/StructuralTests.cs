using DesignPatterns;
using DesignPatterns.Structural;

namespace Tests;

public class StructuralTests
{
    [Fact]
    public void DecoratorTests()
    {
        var simple = new UserInfo();
        
        Assert.Equal("mikołaj kubś, pwr", simple.Operation());

        var decoratedA = new Capitalizer(simple);
        
        Assert.Equal("Mikołaj Kubś, Pwr", decoratedA.Operation());
        
        var decoratedB = new Introductor(decoratedA);
        
        Assert.Equal("Yep, that's me: Mikołaj Kubś, Pwr", decoratedB.Operation());
    }

    [Fact]
    public void AdapterTests()
    {
        var accountDao = new AccountDao();
        accountDao.CreateBaseData();
        
        var oldPaymentSystem = new OldPaymentSystemImplementation();
        
        var newPaymentSystem = new NewPaymentSystemAdapter(oldPaymentSystem);
        
        var account1 = accountDao.GetAccount(1)!;
        var account2 = accountDao.GetAccount(2)!;

        Assert.Equal(100, account1.Balance);
        Assert.Equal(200, account2.Balance);
        
        newPaymentSystem.TransferMoney(account1, account2, 95.5m);
        
        Assert.Equal(4.5m, account1.Balance);
        Assert.Equal(295.5m, account2.Balance);
    }

    [Fact]
    public void FacadeTests()
    {
        Assert.False(PasswordVerifier.IsPasswordValid("password"));
        
        Assert.False(PasswordVerifier.IsPasswordValid("password123@"));
        
        Assert.False(PasswordVerifier.IsPasswordValid("461274127#@!&^#!"));
        
        Assert.False(PasswordVerifier.IsPasswordValid("aA1@"));
        
        Assert.True(PasswordVerifier.IsPasswordValid("Pa$$w0rd123"));
    }
}