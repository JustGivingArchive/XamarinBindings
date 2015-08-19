using UIKit;
using System.Collections.Generic;
using MonoTouch.Dialog;
using Cirrious.FluentLayouts.Touch;
using System.Linq;
using Optimizely.iOS.Xamarin.TutorialApp.Lib.Models;
using Optimizely.iOS.Xamarin.TutorialApp.Lib;

namespace Optimizely.iOS.Xamarin.TutorialApp.Controllers
{
  public class LandingTableViewController : DialogViewController
  {
    List<LandingTableModel> items = new List<LandingTableModel>();

    public LandingTableViewController()
      : base(UITableViewStyle.Plain, null)
    {
      TableView.RowHeight = 150;
      TableView.SeparatorColor = UIColor.Clear;
      LoadData();

      //View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("Images/backgroundImage"));
      TableView.BackgroundView = new UIView(View.Bounds);
      TableView.BackgroundView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("Images/backgroundImage"));
    }

    void LoadData()
    {     
      var model = new LandingTableModel
      {
        Title = "Visual Editor",
        Description = "Make changes, no code needed",
        Image = "Images/visualEditorIcon"
      };
      model.Selected += delegate
      {
        NavigationController.PushViewController(new VisualEditorViewController(), true);
      };
      items.Add(model);
      model = new LandingTableModel
      {
        Title = "Live Variables",
        Description = "Change your users' experience",
        Image = "Images/liveVariablesIcon"
      };
      model.Selected += delegate
      {
        NavigationController.PushViewController(new LiveVariablesViewController(), true);
      };
      items.Add(model);
      model = new LandingTableModel
      {
        Title = "Code Blocks",
        Description = "Test entirely custom features",
        Image = "Images/codeBlocksIcon"
      };
      model.Selected += delegate
      {
        NavigationController.PushViewController(new CodeBlocksViewController(), true);
      };
      items.Add(model);
      Root = new RootElement("")
      {
        new Section
        {
          from post in items
               select new LandingTableModelElement(post)
        }
      };
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);
      NavigationController.NavigationBarHidden = false;
      NavigationController.NavigationBar.BarTintColor = Styling.Colors.WelcomeBackgroundColor;
      NavigationItem.HidesBackButton = true;

      var info = new UIButton(UIButtonType.Custom);
      var img = UIImage.FromBundle("Images/Letter-I-inside-circle");
      info.SetImage(img, UIControlState.Normal);
      info.Frame = new CoreGraphics.CGRect(0, 0, img.Size.Width, img.Size.Height);
      info.TouchUpInside += Info_TouchUpInside;
      NavigationItem.RightBarButtonItem = new UIBarButtonItem(info);
    }

    public override void ViewDidAppear(bool animated)
    {
      base.ViewDidAppear(animated);
      Styling.SetLogo(this);
    }

    void Info_TouchUpInside(object sender, System.EventArgs e)
    {
      var vc = new InfoViewController();
      NavigationController.PushViewController(vc, true);
    }

    public class LandingTableModelElement : Element
    {
      readonly LandingTableModel model;

      public LandingTableModelElement(LandingTableModel model)
        : base(model.Title)
      {
        this.model = model;
      }

      public override UITableViewCell GetCell(UITableView tv)
      {
        const string reuseIdentifier = "landingtablemodelcell";

        var cell = tv.DequeueReusableCell(reuseIdentifier) as LandingTableModelCell ?? new LandingTableModelCell(reuseIdentifier);

        cell.SetTitle(model.Title);
        cell.SetDescription(model.Description);
        cell.SetImage(model.Image);

        return cell;
      }

      public override void Selected(DialogViewController dvc, UITableView tableView, Foundation.NSIndexPath path)
      {
        base.Selected(dvc, tableView, path);

        model.Selected.Invoke();
      }
    }

    public class LandingTableModelCell : UITableViewCell
    {
      UIImageView image;
      UILabel title;
      UILabel description;

      public LandingTableModelCell(string reuseIdentifier)
        : base(UITableViewCellStyle.Default, reuseIdentifier)
      {
        image = new UIImageView();
        title = new UILabel();
        description = new UILabel();

        title.TextColor = UIColor.White;
        title.Font = UIFont.FromName("Gotham-Medium", 20);
        description.TextColor = UIColor.White;
        description.Font = UIFont.FromName("Gotham-Light", 12);
        image.ContentMode = UIViewContentMode.ScaleAspectFit;

        BackgroundColor = UIColor.Clear;

        AddSubviews(image, title, description);

        this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

        this.AddConstraints(
          image.WithSameCenterY(this),
          image.WithSameLeft(this).Plus(20),
          image.Width().EqualTo(80),
          image.Height().EqualTo(80),

          title.WithSameTop(image),
          title.ToRightOf(image).Plus(20),

          description.WithSameLeft(title),
          description.Below(title).Plus(20)
        );
      }

      public void SetTitle(string title)
      {
        this.title.Text = title;
      }

      public void SetDescription(string description)
      {
        this.description.Text = description;
      }

      public void SetImage(string image)
      {
        this.image.Image = UIImage.FromBundle(image);
      }
    }
  }
}