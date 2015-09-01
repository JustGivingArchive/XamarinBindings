using System;
using UIKit;
using MonoTouch.Dialog;

namespace Gigya.iOS.SampleApp
{
  public class MainController : DialogViewController
  {
    public MainController() : base(UITableViewStyle.Plain, null)
    {
      Root = new RootElement("Gigya")
      {
          new Section("Login")
          {
            new StringElement("Login via Facebook", () => { Console.WriteLine("Login via Facebook"); })
          }
      };
    }
  }
}