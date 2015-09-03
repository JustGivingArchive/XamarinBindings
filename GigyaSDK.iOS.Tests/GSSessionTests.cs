using NUnit.Framework;
using System;
using Foundation;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GSSessionTests
  {
    readonly GSSession session = new GSSession("token", "secret");

    [Test]
    public void Constructor()
    {
      try 
      {
        var s = new GSSession("token", "secret");
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ConstructorWithDate()
    {
      try 
      {
        var s = new GSSession("token", "secret", new NSDate());
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void IsValid()
    {
      try 
      {
        var v = session.IsValid;
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Token()
    {
      try 
      {
        session.Token = "token";
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Secret()
    {
      string r = string.Empty;
      try 
      {
        r = session.Secret;
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass(r);
    }

    [Test]
    public void Expiration()
    {
      try 
      {
        var e = session.Expiration;
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void LastLoginProvider()
    {
      try 
      {
        session.LastLoginProvider = "last login provider";
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}