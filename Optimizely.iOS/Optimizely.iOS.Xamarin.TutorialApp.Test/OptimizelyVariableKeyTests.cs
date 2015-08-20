using NUnit.Framework;
using System;
using Foundation;

namespace Optimizely.iOS.Xamarin.TutorialApp.Test
{
  [TestFixture]
  public class OptimizelyVariableKeyTests
  {
    [Test]
    public void Pass()
    {
      Assert.True(true);
    }

    [Test]
    public void Fail()
    {
      Assert.False(true);
    }

    [Test]
    [Ignore("another time")]
    public void Ignore()
    {
      Assert.True(false);
    }

    [Test]
    public void OptimizelyKeyWithKeyString()
    {
      try
      {
        OptimizelyiOS.OptimizelyVariableKey.OptimizelyKeyWithKey("string", "string");
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
        OptimizelyiOS.OptimizelyVariableKey.OptimizelyKeyWithKey("string", "string");
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
        OptimizelyiOS.OptimizelyVariableKey.OptimizelyKeyWithKey("string", new NSNumber(1000));
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
        OptimizelyiOS.OptimizelyVariableKey.OptimizelyKeyWithKey("string", new CoreGraphics.CGPoint(1, 1));
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
        OptimizelyiOS.OptimizelyVariableKey.OptimizelyKeyWithKey("string", new CoreGraphics.CGSize(100, 100));
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
        OptimizelyiOS.OptimizelyVariableKey.OptimizelyKeyWithKey("string", new CoreGraphics.CGRect(0, 0, 100, 100));
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
        OptimizelyiOS.OptimizelyVariableKey.OptimizelyKeyWithKey("string", true);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

//    [Test]
//    public void IsEqualToOptimizelyVariableKey()
//    {
//      try
//      {
//        OptimizelyiOS.OptimizelyVariableKey.IsEqualToOptimizelyVariableKey(new OptimizelyiOS.OptimizelyVariableKey());
//      }
//      catch (Exception e)
//      {
//        Assert.Catch(e);
//      }
//      Assert.Pass();
//    }
  }
}