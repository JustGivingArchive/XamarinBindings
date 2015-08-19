using System;
using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Cirrious.FluentLayouts.Touch;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class CodeBlocksViewController : UIViewController
  {
    public CodeBlocksViewController()
    {
      View.BackgroundColor = Styling.Colors.BackgroundColor;

      var image = new UIImageView
      {
        Image = UIImage.FromBundle("Images/widgetCoLogo_red"),
      };

      var label = new UILabel
      {
        Text = "A company that helps you buy widgets.",
        TextColor = Styling.Colors.TextBlue,
        Font = UIFont.FromName("Gotham-Light", 12),
        TextAlignment = UITextAlignment.Center
      };

      var button = new CustomButton
      {
        TitleText = "Sign In"
      };

      button.TouchUpInside += Button_TouchUpInside;

      View.AddSubviews(image, label, button);

      View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

      View.AddConstraints(
        image.WithSameCenterX(View),
        image.WithSameTop(View).Plus(60),

        label.WithSameCenterX(View),
        label.Below(image).Plus(30),

        button.WithSameCenterX(View),
        button.WithSameBottom(View).Minus(150),
        button.Width().EqualTo(200),
        button.Height().EqualTo(50)
      );
    }

    void Button_TouchUpInside(object sender, EventArgs e)
    {
      var vc = new VisualEditorViewController();
      NavigationController.PushViewController(vc, true);
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);

      NavigationController.NavigationBarHidden = false;
      NavigationController.NavigationBar.TintColor = UIColor.White;

      Title = "Code Blocks";

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

    public override void ViewWillDisappear(bool animated)
    {
      base.ViewWillDisappear(animated);
      Title = "";
    }
  }
}