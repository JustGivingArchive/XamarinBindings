using UIKit;
using Cirrious.FluentLayouts.Touch;

namespace Optimizely.iOS.Xamarin.TutorialApp.Lib
{
  public static class Styling
  {
    public static void SetLogo(UIViewController vc)
    {
      var image = UIImage.FromBundle("Images/smallWhiteLogoforStatusBar");
      var title = new UIImageView(image);
      title.ContentMode = UIViewContentMode.ScaleAspectFit;
      vc.NavigationItem.TitleView = title;
      vc.NavigationItem.TitleView.CenterX();
    }

    public static class Colors
    {
      public static readonly UIColor Green = UIColor.FromRGB(119, 163, 26);
      public static readonly UIColor Blue = UIColor.FromRGB(7, 37, 84);
      public static readonly UIColor BlueLight = UIColor.FromRGB(203, 216, 229);
      public static readonly UIColor Gray = UIColor.FromRGB(199, 208, 215);

      public static readonly UIColor WelcomeBackgroundColor = Blue;
      public static readonly UIColor ButtonGreen = Green;
      public static readonly UIColor BackgroundColor = BlueLight;
      public static readonly UIColor TextBlue = Blue;
      public static readonly UIColor ButtonBlue = Blue;
      public static readonly UIColor BorderColor = Gray;
    }
  }
}