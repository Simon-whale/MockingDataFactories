namespace DataFactoryMocking.Interfaces;

public interface IDataFactory
{
    IAccountStore GetDataStore(string dataStoreType);
}