using System;
using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Cirrious.FluentLayouts.Touch;
using Optimizely.iOS.Xamarin.TutorialApp.Views.CustomElements;
using OptimizelyiOS;
using Foundation;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class CodeBlocksViewController : UIViewController
  {
    OptimizelyCodeBlocksKey OnboardingFunnel;

    public CodeBlocksViewController()
    {
      // [OPTIMIZELY] Example how to declare a code block
      OnboardingFunnel = OptimizelyCodeBlocksKey.GetOptimizelyCodeBlocksKey("OnboardingFunnel", new NSObject[] { new NSString("Add Onboarding Stage") });
      OptimizelyiOS.Optimizely.PreregisterBlockKey(OnboardingFunnel);

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
      // [OPTIMIZELY] Examples of how to implement code blocks (different flow)
      OptimizelyiOS.Optimizely.CodeBlocksWithKey(OnboardingFunnel,
        () =>
        {
          var vc = new CodeBlocksOnboardViewController();
          NavigationController.PushViewController(vc, true);
        },
        () =>
        {
          var vc = new VisualEditorViewController();
          NavigationController.PushViewController(vc, true);
        }
      );
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);

      NavigationController.NavigationBarHidden = false;
      NavigationController.NavigationBar.TintColor = UIColor.White;

      Title = "Code Blocks";

      this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes
      {
        ForegroundColor = UIColor.White,
        Font = UIFont.FromName("Gotham-Light", 14)
      };
    }

    public override void ViewWillDisappear(bool animated)
    {
      base.ViewWillDisappear(animated);
      Title = "";
    }
  }
}