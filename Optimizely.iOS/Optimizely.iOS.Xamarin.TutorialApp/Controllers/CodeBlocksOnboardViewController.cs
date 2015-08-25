using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Optimizely.iOS.Xamarin.TutorialApp.Views.CustomElements;
using Cirrious.FluentLayouts.Touch;

namespace Optimizely.iOS.Xamarin.TutorialApp
{
  public class CodeBlocksOnboardViewController : UIViewController
  {
    public CodeBlocksOnboardViewController()
    {
      View.BackgroundColor = Styling.Colors.BackgroundColor;

      var image = new UIImageView
      {
        Image = UIImage.FromBundle("Images/widgetCoLogo_red"),
      };

      var label = new UILabel
      {
        Text = "We sell gears.",
        TextColor = Styling.Colors.TextBlue,
        Font = UIFont.FromName("Gotham-Light", 12),
        TextAlignment = UITextAlignment.Center
      };

      var button = new CustomButton
      {
        TitleText = "Start shopping now!"
      };
      
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
  }
}