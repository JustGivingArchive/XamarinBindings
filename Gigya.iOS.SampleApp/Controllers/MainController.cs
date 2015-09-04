using System;
using UIKit;
using MonoTouch.Dialog;
using Foundation;
using GigyaSDK.iOS;

namespace Gigya.iOS.SampleApp
{
  public class MainController : DialogViewController
  {
    public MainController()
      : base(UITableViewStyle.Plain, null)
    {
      Root = new RootElement("Gigya")
      {
        new Section("Login")
        {
          new StringElement("Login via Facebook", LoginViaFacebook),
          new StringElement("Logout", Logout),          
        },
        new Section("Requests")
        {
          new StringElement("Request permissions", RequestPermissions),
          new StringElement("Set status", SetStatus),
          new StringElement("Get user info", GetUserInfo)
        }
      };
    }

    void Logout()
    {
      GigyaSDK.iOS.Gigya.LogoutWithCompletionHandler((responce, error) =>
        {
          if (error == null)
          {
          
          }
          else
          {
          
          }
        });
    }

    void LoginViaFacebook()
    {
      Console.WriteLine("Trying to login via Facebook");
      GigyaSDK.iOS.Gigya.LoginToProvider("facebook", null, this, (user, error) =>
        {
          if (error != null)
          {
            Console.WriteLine(error.LocalizedDescription);
          }
          else
          {
            Console.WriteLine(user.Email);
          }
        });
    }

    void RequestPermissions()
    {
      // [Facebook SDK] Here you can check that token has all needed permissions
      var t = Facebook.CoreKit.AccessToken.CurrentAccessToken;

      GigyaSDK.iOS.Gigya.RequestNewFacebookPublishPermissions("publish_actions,publish_pages,manage_pages", (arg0, arg1, arg2) =>
        {
          if (arg0)
          {
            
          }
          else
          {
            
          }
        });
      GigyaSDK.iOS.Gigya.RequestNewFacebookReadPermissions("email,user_status,contact_email,user_likes,user_location,user_friends,user_birthday,public_profile", (arg0, arg1, arg2) =>
        {
          if (arg0)
          {

          }
          else
          {

          }
        });      
    }

    void SetStatus()
    {
      Console.WriteLine(new GSSession().Token);

      var request = GSRequest.RequestForMethod("socialize.setStatus");
      request.Parameters.SetValueForKey(new NSString("I feel great"), new NSString("status"));
      request.SendWithResponseHandler((responce, error) =>
        {
          if (error == null)
          {
            // Request was successful
          }
          else
          {
            // Handle error
          }
        });
    }

    void GetUserInfo()
    {
      var request = GSRequest.RequestForMethod("socialize.getUserInfo");
      request.SendWithResponseHandler((responce, error) =>
        {
          if (error == null)
          {
            
          }
          else
          {
            
          }
        });
    }
  }
}