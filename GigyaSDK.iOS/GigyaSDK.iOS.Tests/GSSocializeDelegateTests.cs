using NUnit.Framework;
using System;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GSSocializeDelegateTests
  {
    public GSSocializeDelegateTests()
    {
      Gigya.SetSocializeDelegate(new GSSocializeDelegate());
    }

    [Test]
    public void UserDidLogin()
    {
      try
      {
        Gigya.SocializeDelegate().UserDidLogin(null);
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void UserDidLogout()
    {
      try
      {
        Gigya.SocializeDelegate().UserDidLogout();
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void UserInfoDidChange()
    {
      try
      {
        Gigya.SocializeDelegate().UserInfoDidChange(null);
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}