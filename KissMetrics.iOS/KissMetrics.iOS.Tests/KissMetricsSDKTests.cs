//using System;
//using NUnit.Framework;
//using Foundation;
//using KissMetricsiOS;
//
//namespace KissMetrics.iOS.Tests
//{
//  [TestFixture]
//  public class KissMetricsSDKTests
//  {
//    readonly KISSmetricsAPI instance = KISSmetricsAPI.SharedAPI;
//
//    [Test]
//    public void SharedAPIWithKey()
//    {
//      try
//      {
//        KISSmetricsAPI.SharedAPIWithKey("apiKey");
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void Identify()
//    {
//      try
//      {
//        instance.Identify("identity");
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void ClearIdentity()
//    {
//      try
//      {
//        instance.ClearIdentity();
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void Alias()
//    {
//      try
//      {
//        instance.Alias("Fidentity", "Sidentity");
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void Record()
//    {
//      try
//      {
//        instance.Record("name");
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void RecordWithProperties()
//    {
//      try
//      {
//        instance.Record("name", new NSDictionary());
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void RecordEvent()
//    {
//      try
//      {
//        instance.RecordEvent("name", new NSDictionary());
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void RecordOnce()
//    {
//      try
//      {
//        instance.RecordOnce("name");
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void SetDistinct()
//    {
//      try
//      {
//        instance.SetDistinct(new NSObject(), "propertyKey");
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void AutoRecordAppLifecycle()
//    {
//      try
//      {
//        instance.AutoRecordAppLifecycle();
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void AutoRecordInstalls()
//    {
//      try
//      {
//        instance.AutoRecordInstalls();
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void AutoSetHardwareProperties()
//    {
//      try
//      {
//        instance.AutoSetHardwareProperties();
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//
//    [Test]
//    public void AutoSetAppProperties()
//    {
//      try
//      {
//        instance.AutoSetAppProperties();
//      }
//      catch (Exception e)
//      {
//        Assert.Fail(e.Message);
//      }
//      Assert.Pass();
//    }
//  }
//}