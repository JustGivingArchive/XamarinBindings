using NUnit.Framework;
using System;
using Foundation;
using OptimizelyiOS;

namespace Optimizely.iOS.Xamarin.TutorialApp.Test
{
  [TestFixture]
  public class OptimizelyCodeBlocksKeyTests
  {
    [Test]
    public void GetOptimizelyCodeBlocksKey()
    {
      try
      {
        OptimizelyCodeBlocksKey.GetOptimizelyCodeBlocksKey("string", new NSObject [] {});
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}