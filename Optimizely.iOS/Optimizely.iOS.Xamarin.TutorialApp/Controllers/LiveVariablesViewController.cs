using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Cirrious.FluentLayouts.Touch;
using Optimizely.iOS.Xamarin.TutorialApp.Views;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class LiveVariablesViewController : UIViewController
  {
    public LiveVariablesViewController()
    {
      View.BackgroundColor = Styling.Colors.BackgroundColor;

      var centerX = new UIView();
      var centerY = new UIView();

      var discountLabel = new UILabel
      {
        BackgroundColor = Styling.Colors.Green,
        Text = "10% OFF FROM NOW UNTIL 9/15",
        Font = UIFont.FromName("Gotham-Medium", 11),
        TextColor = UIColor.White,
        TextAlignment = UITextAlignment.Center
      };

      var view1 = new LiveVariableView("Images/Gear1", "Standard Widget", "3.99", "3.59");
      var view2 = new LiveVariableView("Images/Gear2", "Standard Widget Pack", "6.99", "6.29");
      var view3 = new LiveVariableView("Images/Gear3", "Deluxe Widget", "9.99", "8.99");
      var view4 = new LiveVariableView("Images/Gear4", "Deluxe Widget Pack", "12.99", "11.69");

      View.AddSubviews(centerX, centerY, discountLabel, view1, view2, view3, view4);
      View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
      View.AddConstraints(
        centerX.WithSameCenterX(View),
        centerY.WithSameCenterY(View),

        discountLabel.WithSameTop(View),
        discountLabel.WithSameLeft(View),
        discountLabel.WithSameRight(View),
        discountLabel.Height().EqualTo(30),

        view1.Below(discountLabel).Plus(10),
        view1.WithSameLeft(View).Plus(10),
        view1.WithSameRight(centerX).Minus(5),
        view1.Above(centerY).Minus(5),

        view2.Below(discountLabel).Plus(10),
        view2.WithSameLeft(centerX).Plus(5),
        view2.WithSameRight(View).Minus(10),
        view2.Above(centerY).Minus(5),

        view3.Below(centerY).Plus(5),
        view3.WithSameLeft(View).Plus(10),
        view3.WithSameRight(centerX).Minus(5),
        view3.WithSameHeight(view1),

        view4.Below(centerY).Plus(5),
        view4.WithSameLeft(centerX).Plus(5),
        view4.WithSameRight(View).Minus(10),
        view4.WithSameHeight(view1)
      );
    }

    public override void ViewWillAppear(bool animated)
    {      
      base.ViewWillAppear(animated);

      NavigationController.NavigationBarHidden = false;
      NavigationController.NavigationBar.TintColor = UIColor.White;

      Title = "Live Variables";

      this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
      {
        ForegroundColor = UIColor.White,
        Font = UIFont.FromName("Gotham-Light", 14)
      };
    }

    public override void ViewDidAppear(bool animated)
    {
      base.ViewDidAppear(animated);
    }
  }
}