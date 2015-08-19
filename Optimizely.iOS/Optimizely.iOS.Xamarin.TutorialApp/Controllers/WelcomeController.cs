using UIKit;
using Cirrious.FluentLayouts.Touch;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class WelcomeController : UIViewController
  {
    public WelcomeController()
    {
      View.BackgroundColor = Styling.Colors.WelcomeBackgroundColor;

      var welcomeView = new UIView
      {
        BackgroundColor = UIColor.White,
        ClipsToBounds = true,
      };
      welcomeView.Layer.CornerRadius = 8;

      var image = new UIImageView
      {
        Image = UIImage.FromBundle("Images/blueLogoWelcomeScreen"),
        ContentMode = UIViewContentMode.ScaleAspectFit
      };

      var welcomeLabel = new UILabel
      {
        Text = "Welcome to the\nOptimizely Tutorial App",
        Lines = 2,
        TextAlignment = UITextAlignment.Center,
      };
      welcomeLabel.Font = UIFont.FromName("Gotham-Light", 18);

      var textLabel = new UILabel
      {
        Text = "Please open your browser to\ndevelopers.optimizely.com/ios",
        Lines = 2,
        TextAlignment = UITextAlignment.Center,
      };
      textLabel.Font = UIFont.FromName("Gotham-Light", 14);

      var button = new CustomButton
      {
        BackgroundColor = Styling.Colors.ButtonGreen,
        TitleText = "Got it. Let's go!"       
      };
      button.TouchUpInside += Button_TouchUpInside;
      
      welcomeView.AddSubview(image);
      welcomeView.AddSubview(welcomeLabel);
      welcomeView.AddSubview(textLabel);
      welcomeView.AddSubview(button);

      welcomeView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
      welcomeView.AddConstraints(
        image.WithSameCenterX(welcomeView),
        image.WithSameTop(welcomeView).Plus(40),
        image.WithSameLeft(welcomeView).Plus(30),
        image.WithSameRight(welcomeView).Minus(30),

        welcomeView.WithSameCenterX(welcomeView),
        welcomeLabel.Below(image).Plus(50),
        welcomeLabel.WithSameLeft(welcomeView).Plus(15),
        welcomeLabel.WithSameRight(welcomeView).Minus(15),

        textLabel.WithSameCenterX(welcomeView),
        textLabel.Below(welcomeLabel).Plus(50),
        textLabel.WithSameWidth(welcomeLabel),

        button.WithSameCenterX(welcomeView),
        button.Below(textLabel).Plus(50),
        button.Width().EqualTo(200),
        button.Height().EqualTo(50)
      );

      View.AddSubview(welcomeView);
      View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

      View.AddConstraints(
        welcomeView.WithSameCenterX(View),
        welcomeView.WithSameCenterY(View),
        welcomeView.WithSameLeft(View).Plus(30),
        welcomeView.WithSameRight(View).Minus(30),
        welcomeView.Width().EqualTo(View.Bounds.Width - 60),
        welcomeView.WithSameTop(View).Plus(60),
        welcomeView.WithSameBottom(View).Minus(100)
      );
    }

    void Button_TouchUpInside(object sender, System.EventArgs e)
    {
      var vc = new LandingTableViewController();
      NavigationController.PushViewController(vc, true);
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);
      NavigationController.NavigationBarHidden = true;
    }
  }
}