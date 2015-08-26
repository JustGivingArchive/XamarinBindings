using System;
using NUnit.Framework;
using Foundation;
using KissMetrics.iOS.Binding;

namespace KissMetrics.iOS.Tests
{
  [TestFixture]
  public class KissMetricsSDKTests
  {
    [Test]
    public void SharedApi()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey");
        var api = KISSmetricsAPI.SharedAPI;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SharedAPIWithKey()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Identify()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").Identify("identity");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Identity()
    {
      try
      {
        var identity = KISSmetricsAPI.SharedAPIWithKey("apiKey").Identity;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass(KISSmetricsAPI.SharedAPIWithKey("apiKey").Identity);
    }

    [Test]
    public void ClearIdentity()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").ClearIdentity();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Alias()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").Alias("Fidentity", "Sidentity");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Record()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").Record("name");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RecordWithProperties()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").Record("name", new NSDictionary());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RecordEvent()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").RecordEvent("name", new NSDictionary());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RecordWithPropertiesAndCondition()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").Record("name", new NSDictionary(), KMARecordCondition.Always);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RecordWithCondition()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").Record("name", KMARecordCondition.Always);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RecordOnce()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").RecordOnce("name");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Set()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").Set(new NSDictionary());
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetProperties()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").SetProperties(new NSDictionary());
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetDistinct()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").SetDistinct(new NSObject(), "propertyKey");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AutoRecordAppLifecycle()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").AutoRecordAppLifecycle();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AutoRecordInstalls()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").AutoRecordInstalls();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AutoSetHardwareProperties()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").AutoSetHardwareProperties();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AutoSetAppProperties()
    {
      try
      {
        KISSmetricsAPI.SharedAPIWithKey("apiKey").AutoSetAppProperties();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}