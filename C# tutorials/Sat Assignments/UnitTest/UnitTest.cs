using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(1000m);

        account.Deposit(500m);

        Assert.AreEqual(1500m, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000m);

        Assert.Throws<Exception>(() => account.Deposit(-100m));
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000m);

        account.Withdraw(400m);

        Assert.AreEqual(600m, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(300m);

        Assert.Throws<Exception>(() => account.Withdraw(500m));
    }
}
