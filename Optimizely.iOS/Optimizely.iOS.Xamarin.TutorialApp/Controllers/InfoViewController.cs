using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Cirrious.FluentLayouts.Touch;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class InfoViewController : UIViewController
  {
    public InfoViewController()
    {
      View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("Images/backgroundImage"));

      var text1 = new UILabel
      {
        TextColor = UIColor.White,
        Text = "Optimizely's iOS SDK enables you to makeyour iOS app more angaging",
        Lines = 0
      };
      text1.Font = UIFont.FromName("Gotham-Light", 16);

      var text2 = new UILabel
      {
        TextColor = UIColor.White,
        Text = "This sample app will take you through implementing and utilizing the core functionality of Optimizely. Feel free to take a look at the code for reference.",
        Lines = 0
      };
      text2.Font = UIFont.FromName("Gotham-Light", 16);

      var text3 = new UILabel
      {
        TextColor = UIColor.White,
        Text = "Please open your browser to developers.optimizely.com/ios to get started.",
        Lines = 0
      };
      text3.Font = UIFont.FromName("Gotham-Light", 16);

      View.AddSubview(text1);
      View.AddSubview(text2);
      View.AddSubview(text3);

      View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
      View.AddConstraints(
        text1.WithSameCenterX(View),
        text1.WithSameLeft(View).Plus(50),
        text1.WithSameRight(View).Minus(50),
        text1.WithSameTop(View).Plus(80),

        text2.WithSameCenterX(View),
        text2.WithSameWidth(text1),
        text2.Below(text1).Plus(20),

        text3.WithSameCenterX(View),
        text3.WithSameWidth(text1),
        text3.Below(text2).Plus(20)
      );
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);
      NavigationController.NavigationBarHidden = false;
      NavigationController.NavigationBar.TintColor = UIColor.White;
      Styling.SetLogo(this);
    }
  }
}