using System;
using NUnit.Framework;
using TrustDefenderSDK.iOS;
using Foundation;

namespace TrustDefender.iOS.Tests
{
  [TestFixture]
  public class TrustDefenderMobileTests
  {
    TrustDefenderMobile instance = new TrustDefenderMobile();

    [Test]
    public void Contructor()
    {
      try
      {
        var s = new TrustDefenderMobile();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void DoProfileRequest()
    {
      try
      {
        var r = instance.DoProfileRequest();
        r = instance.DoProfileRequest(new NSDictionary());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void DoProfileRequestWithCallback()
    {
      try
      {
        var s = instance.DoProfileRequestWithCallback((obj) => { Console.WriteLine("Callback"); });
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void DoProfileRequestWithOptions()
    {
      try
      {
        var s = instance.DoProfileRequestWithOptions(new NSDictionary(), (obj) => { Console.WriteLine("Callback"); });
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void PauseLocationServices()
    {
      try
      {
        instance.PauseLocationServices(true);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Result()
    {
      try
      {
        var s = instance.Result;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Version()
    {
      try
      {
        var s = instance.Version;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Cancel()
    {
      try
      {
        instance.Cancel();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}