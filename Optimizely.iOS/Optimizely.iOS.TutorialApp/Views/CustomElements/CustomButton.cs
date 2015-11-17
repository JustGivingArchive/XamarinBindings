using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;

namespace Optimizely.iOS.Xamarin.TutorialApp.Views.CustomElements
{
  public class CustomButton : UIButton
  {
    public string TitleText
    {
      set { SetTitle(value, UIControlState.Normal); }
    }

    public CustomButton()
    {
      Layer.CornerRadius = 5;
      BackgroundColor = Styling.Colors.ButtonBlue;
      ClipsToBounds = true;

      TitleLabel.TextColor = UIColor.White;
      TitleLabel.Font = UIFont.FromName("Gotham-Medium", 16);
      SetTitleShadowColor(UIColor.Black, UIControlState.Normal);
    }
  }
}