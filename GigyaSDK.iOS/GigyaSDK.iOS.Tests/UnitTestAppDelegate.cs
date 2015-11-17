using Foundation;
using UIKit;
using MonoTouch.NUnit.UI;

namespace GigyaSDK.iOS.Tests
{
  // The UIApplicationDelegate for the application. This class is responsible for launching the
  // User Interface of the application, as well as listening (and optionally responding) to
  // application events from iOS.
  [Register("UnitTestAppDelegate")]
  public class UnitTestAppDelegate : UIApplicationDelegate
  {
    // class-level declarations
    UIWindow window;
    TouchRunner runner;
    public static UINavigationController NavigationController;
    public static GSUser User;

    //
    // This method is invoked when the application has loaded and is ready to run. In this
    // method you should instantiate the window, load the UI into it and then make the window
    // visible.
    //
    // You have 17 seconds to return from this method, or iOS will terminate your application.
    //
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      // create a new window instance based on the screen size
      window = new UIWindow(UIScreen.MainScreen.Bounds);
      runner = new TouchRunner(window);

      // register every tests included in the main application/assembly
      runner.Add(System.Reflection.Assembly.GetExecutingAssembly());

      Gigya.InitWithAPIKey("3_Sh5iokMA9q0k5i8s5P4K3O8eYAax9Q0QPLPsXO0MRa4YXiETXRTTypmr8iYAlfRz", UIApplication.SharedApplication, new NSDictionary());

      NavigationController = new UINavigationController(runner.GetViewController());

      window.RootViewController = NavigationController;

      // make the window visible
      window.MakeKeyAndVisible();
			
      return Facebook.CoreKit.ApplicationDelegate.SharedInstance.FinishedLaunching(app, options);
    }

    public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
    {
      return Facebook.CoreKit.ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
    }

    public override void OnActivated(UIApplication application)
    {
      Facebook.CoreKit.AppEvents.ActivateApp();
      Gigya.HandleDidBecomeActive();
    }
  }
}