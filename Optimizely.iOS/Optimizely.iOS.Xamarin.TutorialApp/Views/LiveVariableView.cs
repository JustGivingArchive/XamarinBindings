using UIKit;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;

namespace Optimizely.iOS.Xamarin.TutorialApp.Views
{
  public class LiveVariableView : UIView
  {
    readonly UIImageView image;
    UILabel title, oldPrice, newPrice;

    public LiveVariableView(string image, string title, string oldPrice, string newPrice)
    {
      Layer.CornerRadius = 5;
      ClipsToBounds = true;
      BackgroundColor = UIColor.White;


      this.image = new UIImageView
      {
        Image = UIImage.FromBundle(image),
        ContentMode = UIViewContentMode.ScaleAspectFit,
      };

      this.title = new UILabel
      {
        Text = title,
        Font = UIFont.FromName("Gotham-Medium", 12),
        TextColor = Styling.Colors.TextLightBlue
      };

      this.oldPrice = new UILabel
      {
        Font = UIFont.FromName("Gotham-Light", 10),
        TextColor = Styling.Colors.TextLightBlue
      };
      var attributedString = new NSAttributedString(oldPrice, strikethroughStyle: NSUnderlineStyle.Single);
      this.oldPrice.AttributedText = attributedString;

      this.newPrice = new UILabel
      {
        Text = newPrice,
        Font = UIFont.FromName("Gotham-Medium", 12),
        TextColor = Styling.Colors.TextBlue
      };

      this.AddSubviews(this.image, this.title, this.oldPrice, this.newPrice);

      this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

      this.AddConstraints(
        this.oldPrice.WithSameBottom(this).Minus(20),
        this.oldPrice.WithSameCenterX(this).Minus(20),

        this.newPrice.WithSameCenterY(this.oldPrice),
        this.newPrice.ToRightOf(this.oldPrice).Plus(10),

        this.title.WithSameCenterX(this),
        this.title.Above(this.oldPrice).Minus(15),

        this.image.WithSameCenterX(this),
        this.image.WithSameTop(this).Plus(20),
        this.image.WithSameLeft(this),
        this.image.WithSameRight(this)
        //this.image.Above(this.title)
      );
    }
  }
}