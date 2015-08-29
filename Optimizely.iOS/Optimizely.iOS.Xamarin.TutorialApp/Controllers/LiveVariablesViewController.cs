using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;
using Cirrious.FluentLayouts.Touch;
using Optimizely.iOS.Xamarin.TutorialApp.Views;
using OptimizelyiOS;
using Foundation;
using System;
using System.Collections.Generic;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class LiveVariablesViewController : UIViewController
  {
    OptimizelyVariableKey liveVariableNumberofItems;
    OptimizelyVariableKey liveVariableDiscount;
    OptimizelyVariableKey liveVariableBool;

    readonly List<LiveVariableView> storeItems;

    readonly UILabel discountLabel;

    public LiveVariablesViewController()
    {
      // [OPTIMIZELY] Examples of how to declare live variables (Part 1 of 2)
      liveVariableNumberofItems = OptimizelyVariableKey.OptimizelyKeyWithKey("liveVariableNumberofItems", 4);
      OptimizelyiOS.Optimizely.PreregisterVariableKey(liveVariableNumberofItems);
      liveVariableDiscount = OptimizelyVariableKey.OptimizelyKeyWithKey("liveVariableDiscount", 0.10);
      OptimizelyiOS.Optimizely.PreregisterVariableKey(liveVariableDiscount);
      liveVariableBool = OptimizelyVariableKey.OptimizelyKeyWithKey("liveVariableBool", false);
      OptimizelyiOS.Optimizely.PreregisterVariableKey(liveVariableBool);

      // create list of objects
      storeItems = new List<LiveVariableView>();

      View.BackgroundColor = Styling.Colors.BackgroundColor;

      var centerX = new UIView();
      var centerY = new UIView();

      // [OPTIMIZELY] Examples of how to use live variable values (Part 2 of 2)
      double discount = (double)OptimizelyiOS.Optimizely.NumberForKey(liveVariableDiscount);

      discountLabel = new UILabel
      {
        BackgroundColor = Styling.Colors.Green,
        Text = string.Format("TAKE {0}% OFF FROM NOW UNTIL 9/15", discount * 100),
        Font = UIFont.FromName("Gotham-Medium", 11),
        TextColor = UIColor.White,
        TextAlignment = UITextAlignment.Center
      };

      OptimizelyiOS.Optimizely.RegisterCallbackForVariableWithKey(liveVariableDiscount, OnDiscountChanged);

      var view1 = new LiveVariableView("Images/Gear1", "Standard Widget", 3.99, discount);
      var view2 = new LiveVariableView("Images/Gear2", "Standard Widget Pack", 6.99, discount);
      var view3 = new LiveVariableView("Images/Gear3", "Deluxe Widget", 9.99, discount);
      var view4 = new LiveVariableView("Images/Gear4", "Deluxe Widget Pack", 12.99, discount);
      var view5 = new LiveVariableView("Images/Gear5", "Premium Widget", 15.99, discount);
      var view6 = new LiveVariableView("Images/Gear6", "Premium Widget Pack", 18.99, discount);

      storeItems.AddRange(new [] { view1, view2, view3, view4, view5, view6 });

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

      this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes
      {
        ForegroundColor = UIColor.White,
        Font = UIFont.FromName("Gotham-Light", 14)
      };
    }

    void OnDiscountChanged(NSString key, NSObject value)
    {
      Console.WriteLine(string.Format("The order of sales items has changed: {0} is now {1}", key, value));
      float d = (float)OptimizelyiOS.Optimizely.NumberForKey(liveVariableDiscount);
      discountLabel.Text = string.Format("TAKE {0}% OFF FROM NOW UNTIL 9/15", d * 100);

      foreach (var item in storeItems)
      {
        item.ChangePrices(d);
      }
    }
  }
}