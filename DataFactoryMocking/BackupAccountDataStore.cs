using DataFactoryMocking.Interfaces;
using DataFactoryMocking.Models;

namespace DataFactoryMocking;

public class BackupAccountDataStore : IAccountStore
{
    public Account GetAccount(string accountNumber)
    {
        return new Account();
    }
}