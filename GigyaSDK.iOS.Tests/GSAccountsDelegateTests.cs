using NUnit.Framework;
using System;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GSAccountsDelegateTests
  {
    [Test]
    public void AccountDidLogin()
    {
      Gigya.SetAccountsDelegate(new GSAccountsDelegate());
      var acc = Gigya.AccountsDelegate();
      try
      {        
        acc.AccountDidLogin(new GSAccount());
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AccountDidLogout()
    {
      Gigya.SetAccountsDelegate(new GSAccountsDelegate());
      var acc = Gigya.AccountsDelegate();
      try
      {
        acc.AccountDidLogout();
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}