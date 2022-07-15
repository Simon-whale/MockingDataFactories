using DataFactoryMocking;
using DataFactoryMocking.Interfaces;
using DataFactoryMocking.Models;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace DataFactoryMockingTests;

public class MockDataResponseTests
{
    private Account _account;

    [SetUp]
    public void CreateData()
    {
        _account = new Account()
        {
            AccountNumber = "SW1",
            Balance = 12,
            Status = 1,
            AllowedPaymentSchemes = 2
        };
    }
    
    /// <summary>
    /// This test is used so that I can see how I can return test data from an object that is
    /// built from calling a factory
    /// </summary>
    [Test]
    public void Should_Return_Mocked_Data()
    {
        Mock<IDataFactory> dataStoreFactory = new Mock<IDataFactory>();
        Mock<IAccountStore> accountStore = new Mock<IAccountStore>();
        
        dataStoreFactory
            .Setup(p => p.GetDataStore(It.IsAny<string>()))
            .Returns(accountStore.Object);

        accountStore
            .Setup(p => p.GetAccount(It.IsAny<string>()))
            .Returns(_account);

        var store = dataStoreFactory.Object.GetDataStore("backup");
        var account = store.GetAccount("SW1");
        account.ShouldNotBe(null);
        account.ShouldBeOfType<Account>();
        account.Balance.ShouldBe(12);
        account.Status.ShouldBe(1);
    }

    [Test]
    public void Should_Return_Nothing()
    {
        Mock<IDataFactory> dataStoreFactory = new Mock<IDataFactory>();
        Mock<IAccountStore> accountStore = new Mock<IAccountStore>();
        
        dataStoreFactory
            .Setup(p => p.GetDataStore(It.IsAny<string>()))
            .Returns(accountStore.Object);

        accountStore
            .Setup(p => p.GetAccount(It.IsAny<string>()))
            .Returns(new Account());

        var store = dataStoreFactory.Object.GetDataStore("backup");
        var account = store.GetAccount("SW13");
        account.ShouldNotBe(null);
        account.Balance.ShouldBe(0);
    }
}