using DataFactoryMocking;
using NUnit.Framework;
using Shouldly;

namespace DataFactoryMockingTests;

public class Tests
{
    [Test]
    public void Should_Return_Backup_DataStore()
    {
        var accountStore = new DataFactory().GetDataStore("Backup");
        accountStore.GetType().ShouldBeEquivalentTo(typeof(BackupAccountDataStore));
    }

    [Test]
    public void Should_Return_Account_DataStore()
    {
        var accountStore = new DataFactory().GetDataStore("Live");
        accountStore.GetType().ShouldBeEquivalentTo(typeof(AccountDataStore));
    }
}