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
      public static readonly UIColor BackgroundColor = UIColor.FromRGB(7, 37, 84);
      public static readonly UIColor ButtonColor = UIColor.FromRGB(119, 163, 26);
    }
  }
}