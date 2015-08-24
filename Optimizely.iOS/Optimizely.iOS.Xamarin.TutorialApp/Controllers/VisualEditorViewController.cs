using System;
using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Cirrious.FluentLayouts.Touch;
using Optimizely.iOS.Xamarin.TutorialApp.Views.CustomElements;
using Foundation;

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

        phoneLabel.WithSameLeft(phoneField),
        phoneLabel.WithSameCenterY(View),

        phoneField.WithSameCenterX(View),
        phoneField.Height().EqualTo(30),
        phoneField.Width().EqualTo(200),
        phoneField.Below(phoneLabel).Plus(5),

        emailField.WithSameLeft(phoneField),
        emailField.WithSameWidth(phoneField),
        emailField.WithSameHeight(phoneField),
        emailField.Above(phoneLabel).Minus(15),

        emailLabel.WithSameLeft(phoneField),
        emailLabel.Above(emailField).Minus(5),

        image.WithSameCenterX(View),
        image.Above(emailLabel).Minus(15),

        passwordLabel.WithSameLeft(phoneField),
        passwordLabel.Below(phoneField).Plus(15),

        passwordField.WithSameLeft(phoneField),
        passwordField.WithSameWidth(phoneField),
        passwordField.WithSameHeight(phoneField),
        passwordField.Below(passwordLabel).Plus(5),

        button.Below(passwordField).Plus(20),
        button.WithSameCenterX(View),
        button.WithSameWidth(phoneField),
        button.Height().EqualTo(50)
      );
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);

      NavigationController.NavigationBarHidden = false;
      NavigationController.NavigationBar.TintColor = UIColor.White;

      Title = "Visual Editor";

      this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
      {
        ForegroundColor = UIColor.White,
        Font = UIFont.FromName("Gotham-Light", 14)
      };

      NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, KeyboardWillShow);
      NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyboardWillHide);
    }

    public override void ViewWillDisappear(bool animated)
    {
      base.ViewWillDisappear(animated);

      NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.WillHideNotification, null);
      NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.WillShowNotification, null);
    }

    public override void ViewDidAppear(bool animated)
    {
      base.ViewDidAppear(animated);
    }

    void ViewTap()
    {
      View.EndEditing(true);
    }

    void KeyboardWillShow(NSNotification notification)
    {
      UIView.AnimateAsync(0.3, () => {
        var f = this.View.Frame;
        f.Y = -150.0f;
        this.View.Frame = f;
      });
    }

    void KeyboardWillHide(NSNotification notification)
    {
      UIView.AnimateAsync(0.3, () => {
        var f = this.View.Frame;
        f.Y = 0.0f;
        this.View.Frame = f;
      });
    }

//    - (IBAction)emailActive:(id)sender {
//      [self.optlyEmailField canBecomeFirstResponder];
//    }
//    - (IBAction)phoneActive:(id)sender {
//      [self.optlyPhoneField canBecomeFirstResponder];
//    }
//    - (IBAction)passActive:(id)sender {
//      [self.optlyPassField canBecomeFirstResponder];
//    }
  }
}