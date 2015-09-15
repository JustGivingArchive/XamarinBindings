using System;

namespace Optimizely.iOS.Xamarin.TutorialApp.Lib.Models
{
  public class LandingTableModel
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public Action Selected = delegate
    {
    };
  }
}