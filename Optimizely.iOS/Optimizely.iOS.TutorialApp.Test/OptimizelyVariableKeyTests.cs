using NUnit.Framework;
using System;
using Foundation;
using OptimizelyiOS;

namespace Optimizely.iOS.Xamarin.TutorialApp.Test
{
  [TestFixture]
  public class OptimizelyVariableKeyTests
  {
    [Test]
    public void OptimizelyKeyWithKeyString()
    {
      try
      {
        OptimizelyVariableKey.OptimizelyKeyWithKey("string", "string");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void OptimizelyKeyWithKeyUIColor()
    {
      try
      {
        OptimizelyVariableKey.OptimizelyKeyWithKey("string", "string");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void OptimizelyKeyWithKeyNSNumber()
    {
      try
      {
        OptimizelyVariableKey.OptimizelyKeyWithKey("string", new NSNumber(1000));
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void OptimizelyKeyWithKeyCGPoint()
    {
      try
      {
        OptimizelyVariableKey.OptimizelyKeyWithKey("string", new CoreGraphics.CGPoint(1, 1));
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void OptimizelyKeyWithKeyCGSize()
    {
      try
      {
        OptimizelyVariableKey.OptimizelyKeyWithKey("string", new CoreGraphics.CGSize(100, 100));
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void OptimizelyKeyWithKeyCGRect()
    {
      try
      {
        OptimizelyVariableKey.OptimizelyKeyWithKey("string", new CoreGraphics.CGRect(0, 0, 100, 100));
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void OptimizelyKeyWithKeyBool()
    {
      try
      {
        OptimizelyVariableKey.OptimizelyKeyWithKey("string", true);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void IsEqualToOptimizelyVariableKey()
    {
      try
      {        
        var key = OptimizelyVariableKey.OptimizelyKeyWithKey("key", "defaultVaue");

        key.IsEqualToOptimizelyVariableKey(key);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}