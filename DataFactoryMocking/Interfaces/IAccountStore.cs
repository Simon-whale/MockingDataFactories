using DataFactoryMocking.Models;

namespace DataFactoryMocking.Interfaces;

public interface IAccountStore
{  
        Account GetAccount(string accountNumber);
}