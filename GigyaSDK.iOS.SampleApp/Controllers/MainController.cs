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

    void SetStatus()
    {
      Console.WriteLine(new GSSession().Token);

      var request = GSRequest.RequestForMethod("socialize.setStatus");
      request.Parameters.SetValueForKey(new NSString("Posted via Gigya test app"), new NSString("status"));
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