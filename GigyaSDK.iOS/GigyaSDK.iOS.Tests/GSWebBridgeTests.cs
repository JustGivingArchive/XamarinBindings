using NUnit.Framework;
using System;
using GigyaSDK.iOS;
using Foundation;
using UIKit;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GSWebBridgeTests
  {
    readonly GSSession session = new GSSession("token", "secret");

    [Test]
    public void RegisterWebView()
    {
      try
      {
        GSWebBridge.RegisterWebView(new UIWebView(), new GSWebBridgeDelegate());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RegisterWebViewWithSettings()
    {
      try
      {
        GSWebBridge.RegisterWebView(new UIWebView(), new GSWebBridgeDelegate(), new NSDictionary());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void UnregisterWebView()
    {
      try
      {
        GSWebBridge.UnregisterWebView(new NSObject());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void WebViewDidStartLoad()
    {
      try
      {
        GSWebBridge.WebViewDidStartLoad(new UIWebView());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void HandleRequest()
    {
      try
      {
        GSWebBridge.HandleRequest(new NSUrlRequest(), new NSObject());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}