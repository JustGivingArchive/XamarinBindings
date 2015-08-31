using NUnit.Framework;
using GigyaSDK.iOS;
using Foundation;
using UIKit;
using System;

namespace GigyaSDK.iOS.Tests
{
  [TestFixture]
  public class GigyaTests
  {
    [Test]
    public void InitWithApiKey()
    {
      try
      {
        Gigya.InitWithAPIKey("3_Sh5iokMA9q0k5i8s5P4K3O8eYAax9Q0QPLPsXO0MRa4YXiETXRTTypmr8iYAlfRz", UIApplication.SharedApplication, new NSDictionary());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void InitWithApiKeyWithDomain()
    {
      try
      {
        Gigya.InitWithAPIKey("3_Sh5iokMA9q0k5i8s5P4K3O8eYAax9Q0QPLPsXO0MRa4YXiETXRTTypmr8iYAlfRz", UIApplication.SharedApplication, new NSDictionary(), "apiDomain");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void APIKey()
    {
      try
      {
        var key = Gigya.APIKey;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void APIDomain()
    {
      try
      {
        var domain = Gigya.APIDomain;
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
        var session = Gigya.Session;
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SessionDelegate()
    {
      try
      {
        var sessionDelegate = Gigya.SessionDelegate();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetSessionDelegate()
    {
      try
      {
        Gigya.SetSessionDelegate(null);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SocializeDelegate()
    {
      try
      {
        var socializeDelegate = Gigya.SocializeDelegate();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetSocializeDelegate()
    {
      try
      {
        Gigya.SetSocializeDelegate(Gigya.SocializeDelegate());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AccountsDelegate()
    {
      try
      {
        var accountDelegate = Gigya.AccountsDelegate();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetAccountsDelegate()
    {
      try
      {
        Gigya.SetAccountsDelegate(Gigya.AccountsDelegate());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void LoginToProvider()
    {
      try
      {        
        Gigya.LoginToProvider("provider");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowLoginDialogOver()
    {
      try
      {
        Gigya.ShowLoginDialogOver(UnitTestAppDelegate.NavigationController, "provider");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void LoginToProviderWithParameters()
    {
      try
      {
        Gigya.LoginToProvider("provider", new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowLoginDialogOverWithParameters()
    {
      try
      {
        Gigya.ShowLoginDialogOver(UnitTestAppDelegate.NavigationController, "provider", new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void LoginToProviderWithVC()
    {
      try
      {
        Gigya.LoginToProvider("provider", new NSDictionary(), UnitTestAppDelegate.NavigationController, UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowLoginProvidersDialogOver()
    {
      try
      {
        Gigya.ShowLoginDialogOver(UnitTestAppDelegate.NavigationController, "provider");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowLoginProvidersPopoverFrom()
    {
      try
      {
        Gigya.ShowLoginProvidersPopoverFrom(UnitTestAppDelegate.NavigationController.View);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowLoginProvidersDialogOverWithProviders()
    {
      try
      {
        Gigya.ShowLoginProvidersDialogOver(UnitTestAppDelegate.NavigationController, new [] { new NSObject() }, new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowLoginProvidersPopoverFromWithProveders()
    {
      try
      {
        Gigya.ShowLoginProvidersPopoverFrom(UnitTestAppDelegate.NavigationController.View, new [] { new NSObject() }, new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void Logout()
    {
      try
      {
        Gigya.Logout();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void LogoutWithCompletionHandler()
    {
      try
      {
        Gigya.LogoutWithCompletionHandler(ResponseHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    void ResponseHandler(GSResponse arg0, NSError arg1)
    {
      
    }

    [Test]
    public void AddConnectionToProvider()
    {
      try
      {
        Gigya.AddConnectionToProvider("provider");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowAddConnectionDialogOver()
    {
      try
      {
        Gigya.ShowAddConnectionDialogOver(UnitTestAppDelegate.NavigationController, "provider");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AddConnectionToProviderWithParameters()
    {
      try
      {
        Gigya.AddConnectionToProvider("provider", new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    void UserInfoHandler(GSUser arg0, NSError arg1)
    {
      
    }

    [Test]
    public void ShowAddConnectionDialogOverWithParameters()
    {
      try
      {
        Gigya.ShowAddConnectionDialogOver(UnitTestAppDelegate.NavigationController, "provider", new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void AddConnectionToProviderWithVC()
    {
      try
      {
        Gigya.AddConnectionToProvider("provider", new NSDictionary(), UnitTestAppDelegate.NavigationController, UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowAddConnectionProvidersDialogOver()
    {
      try
      {
        Gigya.ShowAddConnectionProvidersDialogOver(UnitTestAppDelegate.NavigationController);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowAddConnectionProvidersPopoverFrom()
    {
      try
      {
        Gigya.ShowAddConnectionProvidersPopoverFrom(UnitTestAppDelegate.NavigationController.View);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowAddConnectionProvidersDialogOverWithProveders()
    {
      try
      {
        Gigya.ShowAddConnectionProvidersDialogOver(UnitTestAppDelegate.NavigationController, new NSObject[] { }, new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowAddConnectionProvidersPopoverFromWithProviders()
    {
      try
      {
        Gigya.ShowAddConnectionProvidersPopoverFrom(UnitTestAppDelegate.NavigationController.View, new NSObject[] { }, new NSDictionary(), UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RemoveConnectionToProvider()
    {
      try
      {
        Gigya.RemoveConnectionToProvider("provider");
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RemoveConnectionToProviderWithHandler()
    {
      try
      {
        Gigya.RemoveConnectionToProvider("provider", UserInfoHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowPluginDialogOver()
    {
      try
      {
        Gigya.ShowPluginDialogOver(UnitTestAppDelegate.NavigationController, "plugin", new NSDictionary());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void ShowPluginDialogOverWithHandler()
    {
      try
      {
        Gigya.ShowPluginDialogOver(UnitTestAppDelegate.NavigationController, "plugin", new NSDictionary(), PluginCompletionHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    void PluginCompletionHandler(bool arg0, NSError arg1)
    {
      
    }

    [Test]
    public void ShowPluginDialogOverWithDelegate()
    {
      try
      {
        Gigya.ShowPluginDialogOver(UnitTestAppDelegate.NavigationController, "plugin", new NSDictionary(), PluginCompletionHandler, null);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void RequestNewFacebookPublishPermissions()
    {
      try
      {
        Gigya.RequestNewFacebookPublishPermissions("permission", PermissionRequestResultHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    void PermissionRequestResultHandler(bool arg0, NSError arg1, NSObject[] arg2)
    {
      
    }

    [Test]
    public void RequestNewFacebookReadPermissions()
    {
      try
      {
        Gigya.RequestNewFacebookReadPermissions("permissions", PermissionRequestResultHandler);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void HandleOpenURL()
    {
      try
      {
        Gigya.HandleOpenURL(new NSUrl("http://google.com"), UIApplication.SharedApplication, "sourceApplication", new NSObject());
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void HandleDidBecomeActive()
    {
      try
      {
        Gigya.HandleDidBecomeActive();
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
        var s = Gigya.UseHTTPS();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetUseHTTPS()
    {
      try
      {
        Gigya.SetUseHTTPS(false);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void NetworkActivityIndicatorEnabled()
    {
      try
      {
        var n = Gigya.NetworkActivityIndicatorEnabled();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetNetworkActivityIndicatorEnabled()
    {
      try
      {
        Gigya.SetNetworkActivityIndicatorEnabled(true);
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
        var r = Gigya.RequestTimeout();
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }

    [Test]
    public void SetRequestTimeout()
    {
      try
      {
        Gigya.SetRequestTimeout(100);
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message);
      }
      Assert.Pass();
    }
  }
}