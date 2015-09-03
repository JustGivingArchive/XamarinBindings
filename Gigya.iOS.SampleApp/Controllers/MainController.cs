using System;
using UIKit;
using MonoTouch.Dialog;

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
        }
      };
    }

    void LoginViaFacebook()
    {
      Console.WriteLine("Trying to login via Facebook");
      GigyaSDK.iOS.Gigya.LoginToProvider("facebook", null, this, (user, error) =>
        {
          if (error != null)
          {
          
          }
          else
          {
          
          }
        });
    }
  }
}