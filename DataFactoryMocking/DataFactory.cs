using DataFactoryMocking.Interfaces;

namespace DataFactoryMocking;

public class DataFactory : IDataFactory
{
    public IAccountStore GetDataStore(string dataStoreType)
    {
        switch (dataStoreType)
        {
            case "Backup":
                return new BackupAccountDataStore();
            case "Live":
                return new AccountDataStore();
            default:
                throw new ArgumentException("Unknown data store type");
        }
    }
}

