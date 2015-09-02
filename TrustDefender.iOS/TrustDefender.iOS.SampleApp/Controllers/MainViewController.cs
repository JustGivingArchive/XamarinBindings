using System;
using MonoTouch.Dialog;

namespace TrustDefender.iOS.SampleApp
{
  public class MainViewController : DialogViewController
  {
    public MainViewController() : base(UIKit.UITableViewStyle.Plain, null)
    {
    }
  }
}