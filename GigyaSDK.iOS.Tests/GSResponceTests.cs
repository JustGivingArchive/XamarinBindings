using NUnit.Framework;
using System;
using Foundation;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GSResponceTests
  {
    readonly GSResponse response = GSResponse.ResponseForMethod("method", new NSData());
    readonly GSSession session = new GSSession("token", "secret");

    [Test]
    public void ResponseForMethod()
    {
      try
      {
        var r = GSResponse.ResponseForMethod("method", new NSData());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ResponseWithError()
    {
      try
      {
        var r = GSResponse.ResponseWithError(new NSError(new NSString("123"), 1));
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Method()
    {
      try
      {
        var m = response.Method;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ErrorCode()
    {
      try
      {
        var c = response.ErrorCode;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void CallId()
    {
      try
      {
        var c = response.CallId;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AllKeys()
    {
      try
      {
        var keys = response.AllKeys;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ObjectForKey()
    {
      try
      {
        var obj = response.ObjectForKey("key");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ObjectForKeyedSubscript()
    {
      try
      {
        var obj = response.ObjectForKeyedSubscript("key");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void JSONString()
    {
      try
      {
        var json = response.JSONString;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}