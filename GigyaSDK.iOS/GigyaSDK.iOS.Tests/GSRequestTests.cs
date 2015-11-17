using NUnit.Framework;
using System;
using Foundation;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GSRequestTests
  {
    readonly GSRequest request = GSRequest.RequestForMethod("method");
    readonly GSSession session = new GSSession("token", "secret");

    [Test]
    public void RequestForMethod()
    {
      try
      {
        var r = GSRequest.RequestForMethod("method");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RequestForMethodWithParamethers()
    {
      try
      {
        var r = GSRequest.RequestForMethod("method", new NSDictionary());
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
        var m = request.Method;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Parameters()
    {
      try
      {
        var d = request.Parameters;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void UseHTTPS()
    {
      try
      {
        request.UseHTTPS = true;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RequestTimeout()
    {
      try
      {
        var t = request.RequestTimeout;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SendWithResponseHandler()
    {
      try
      {
        // GSResponse.ResponseForMethod("method", new NSData()), new NSError(new NSString("qw"), 1)
        var h = new GSResponseHandler(Method);
        request.SendWithResponseHandler(h);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    void Method(GSResponse arg0, NSError arg1)
    {
      
    }

    [Test]
    public void SendSynchronouslyWithError()
    {
      try
      {
        NSError error;
        var s = request.SendSynchronouslyWithError(out error);
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
        request.Cancel();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Session()
    {
      try
      {
        var s = request.Session;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RequestID()
    {
      try
      {
        var id = request.RequestID;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void IncludeAuthInfo()
    {
      try
      {
        request.IncludeAuthInfo = true;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Source()
    {
      try
      {
        var s = request.Source;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}