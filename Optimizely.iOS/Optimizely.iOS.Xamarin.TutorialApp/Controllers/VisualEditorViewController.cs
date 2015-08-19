using System;
using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Cirrious.FluentLayouts.Touch;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class VisualEditorViewController : UIViewController
  {
    public VisualEditorViewController()
    {
      View.BackgroundColor = Styling.Colors.BackgroundColor;

      View.AddGestureRecognizer(new UITapGestureRecognizer(ViewTap));

      var discountLabel = new UILabel
      {
        BackgroundColor = Styling.Colors.Green,
        Text = "25% OFF YOUR FIRST ORDER IF YOU SIGN UP BY 9/1",
        Font = UIFont.FromName("Gotham-Medium", 11),
        TextColor = UIColor.White,
        TextAlignment = UITextAlignment.Center
      };

      var image = new UIImageView
      {
        Image = UIImage.FromBundle("Images/widgetCoLogo_red"),
      };

      var emailLabel = new UILabel
      {
        Text = "Email",
        Font = UIFont.FromName("Gotham-Light", 10)
      };
      var emailField = new CustomTextField
      {
        Placeholder = "alice@acmewidgetsco.com"
      };

      var phoneLabel = new UILabel
      {
        Text = "Phone Number:",
        Font = UIFont.FromName("Gotham-Light", 10)
      };
      
      var phoneField = new CustomTextField
      {
        Placeholder = "(555)-555-5555"
      };

      var passwordLabel = new UILabel
      {
        Text = "Password",
        Font = UIFont.FromName("Gotham-Light", 10)
      };

      var passwordField = new CustomTextField
      {
        SecureTextEntry = true,
      };

      var button = new CustomButton
      {
        TitleText = "Take me to the widgets"
      };

      View.AddSubviews(emailLabel, emailField, phoneLabel, phoneField, passwordLabel, passwordField, button, discountLabel, image);

      View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

      View.AddConstraints(
        discountLabel.WithSameTop(View),
        discountLabel.WithSameLeft(View),
        discountLabel.WithSameRight(View),
        discountLabel.Height().EqualTo(30),

        image.WithSameCenterX(View),
        image.WithSameTop(discountLabel).Plus(100),

        emailField.WithSameCenterX(View),
        emailField.Height().EqualTo(30),
        emailField.Width().EqualTo(200),
        emailField.Below(image).Plus(40),

        emailLabel.WithSameLeft(emailField),
        emailLabel.Above(emailField).Minus(5),

        phoneLabel.WithSameLeft(emailField),
        phoneLabel.Below(emailField).Plus(20),

        phoneField.WithSameLeft(emailField),
        phoneField.WithSameWidth(emailField),
        phoneField.WithSameHeight(emailField),
        phoneField.Below(phoneLabel).Plus(5),

        passwordLabel.WithSameLeft(emailField),
        passwordLabel.Below(phoneField).Plus(20),

        passwordField.WithSameLeft(emailField),
        passwordField.WithSameWidth(emailField),
        passwordField.WithSameHeight(emailField),
        passwordField.Below(passwordLabel).Plus(5),

        button.Below(passwordField).Plus(30),
        button.WithSameCenterX(View),
        button.WithSameWidth(emailField),
        button.Height().EqualTo(50)
      );
    }

    public override void ViewDidAppear(bool animated)
    {
      base.ViewDidAppear(animated);

      NavigationController.NavigationBarHidden = false;
      NavigationController.NavigationBar.TintColor = UIColor.White;

      Title = "Visual Editor";

      this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
      {
        ForegroundColor = UIColor.White,
        Font = UIFont.FromName("Gotham-Light", 14)
      };
    }

    void ViewTap()
    {
      View.EndEditing(true);
    }
  }
}