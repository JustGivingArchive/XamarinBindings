using NUnit.Framework;
using System;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GSUserTests
  {
    [Test]
    public void ObjectForKey()
    {
      try
      {
        UnitTestAppDelegate.User.ObjectForKey("key");
      }
      catch(Exception e)
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
        UnitTestAppDelegate.User.ObjectForKeyedSubscript("key");
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}