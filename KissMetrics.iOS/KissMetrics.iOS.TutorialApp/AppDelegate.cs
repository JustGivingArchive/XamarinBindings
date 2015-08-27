using Foundation;
using UIKit;
using KissMetrics.iOS.Binding;

namespace KissMetrics.iOS.TutorialApp
{
  // The UIApplicationDelegate for the application. This class is responsible for launching the
  // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
  [Register("AppDelegate")]
  public class AppDelegate : UIApplicationDelegate
  {
    // class-level declarations

    public override UIWindow Window
    {
      get;
      set;
    }

    MainController root;
    UINavigationController nav;

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
      // create a new window instance based on the screen size
      Window = new UIWindow(UIScreen.MainScreen.Bounds);

      // [KISSmetrics] Initialize KissMetrics API
      KISSmetricsAPI.SharedAPIWithKey("90e9f5b6ee03267f70692818443db3fc433d938d");

      root = new MainController();
      nav = new UINavigationController(root);
      nav.NavigationBar.Translucent = false;

      Window.RootViewController = nav;

      // If you have defined a root view controller, set it here:
      // Window.RootViewController = myViewController;

      // make the window visible
      Window.MakeKeyAndVisible();

      // [KISSmetrics] Calling this records two events: 
      // Installed App
      // Updated App
      KISSmetricsAPI.SharedAPI.AutoRecordInstalls();

      // [KISSmetrics] Calling this sets the following properties:
      // App Version : 1.0.0
      // App Build : 101
      KISSmetricsAPI.SharedAPI.AutoSetAppProperties();

      // [KISSmetrics] Calling this sets the following properties:
      // Device Manufacturer: Apple
      // Device Platform: iPhone
      // Device Model: iPhone 5s
      // System Name: iOS
      // System Version: 7.0.4
      KISSmetricsAPI.SharedAPI.AutoSetHardwareProperties();

      // [KISSmetrics] Automatically records the following events:
      // "Launched Application"
      // "Application moved to background"
      // "Application became active"
      // "Application Terminated"
      KISSmetricsAPI.SharedAPI.AutoRecordAppLifecycle();

      return true;
    }

    public override void OnResignActivation(UIApplication application)
    {
      // Invoked when the application is about to move from active to inactive state.
      // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
      // or when the user quits the application and it begins the transition to the background state.
      // Games should use this method to pause the game.
    }

    public override void DidEnterBackground(UIApplication application)
    {
      // Use this method to release shared resources, save user data, invalidate timers and store the application state.
      // If your application supports background exection this method is called instead of WillTerminate when the user quits.
    }

    public override void WillEnterForeground(UIApplication application)
    {
      // Called as part of the transiton from background to active state.
      // Here you can undo many of the changes made on entering the background.
    }

    public override void OnActivated(UIApplication application)
    {
      // Restart any tasks that were paused (or not yet started) while the application was inactive. 
      // If the application was previously in the background, optionally refresh the user interface.
    }

    public override void WillTerminate(UIApplication application)
    {
      // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
    }
  }
}