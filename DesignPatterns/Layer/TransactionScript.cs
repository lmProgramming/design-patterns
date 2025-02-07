using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Layer;

public interface ITransactionScriptService
{
    public void Transfer(int fromAccountId, int toAccountId, decimal amount);
}

public class TransactionScriptService(AccountDao accountDao) : ITransactionScriptService
{
    public void Transfer(int fromAccountId, int toAccountId, decimal amount)
    {
        var accountFrom = accountDao.GetAccount(fromAccountId);

        if (accountFrom == null)
        {
            throw new ArgumentException("From account not found");
        }

        var accountTo = accountDao.GetAccount(toAccountId);
        if (accountTo == null)
        {
            throw new ArgumentException("To account not found");
        }

        if (accountFrom.Balance < amount)
        {
            throw new ArgumentException("Insufficient funds in from account");
        }

        accountFrom.Balance -= amount;
        accountTo.Balance += amount;
    }
}

