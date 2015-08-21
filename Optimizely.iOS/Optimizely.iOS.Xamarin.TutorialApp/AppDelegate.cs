using Foundation;
using UIKit;
using Optimizely.iOS.Xamarin.TutorialApp.Controllers;
using System;

namespace Optimizely.iOS.Xamarin.TutorialApp
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

    WelcomeController root;
    UINavigationController nav;

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
      // create a new window instance based on the screen size
      Window = new UIWindow(UIScreen.MainScreen.Bounds);
      root = new WelcomeController();
      nav = new UINavigationController(root);

      nav.NavigationBar.Translucent = false;

      var defaultNavBar = new UINavigationBar();
      defaultNavBar.TintColor = UIColor.FromRGBA(0, 51, 102, 1f);

      // If you have defined a root view controller, set it here:
      Window.RootViewController = nav;

      // make the window visible
      Window.MakeKeyAndVisible();

      // Below are instructions for initial setup, lines marked as optional
      // are options, lines marked as required are required
      // Throughout the code, you can search for [OPTIMIZELY] to find reference code
      // related to Optimizely
      // All lines that say [OPTIMIZELY] (REQUIRED) are necessary for you to
      // get started!

      // [OPTIMIZELY] (OPTIONAL) Add this line of code to debug issues.  Please note that this line of code
      // should not be included when your app is in production
      OptimizelyiOS.Optimizely.SharedInstance().VerboseLogging = true;

      // [OPTIMIZELY] (OPTIONAL) Add this line of code if you would like to enable "Edit Mode" in your live app
      // Please note that adding this line will allow anyone to edit your app with
      // Optimizely in the app store
      // OptimizelyiOS.Optimizely.EnableGestureInAppStoreApp();

      // [OPTIMIZELY] (OPTIONAL) Customize network call timing (By default network calls are made every 2 minutes)
      // OptimizelyiOS.Optimizely.SharedInstance().DispatchInterval = 120;

      // [OPTIMIZELY] (REQUIRED) Replace this line with your API token, and don't forget to go to
      // your target (i.e. the blue icon at the top that says TutorialApp) > Info > URL Types
      // Paste your Project ID there (e.g. it should look like optly123456, replace 123456 with your project id)
      // Replace @"AAMseu0A6cJKXYL7RiH_TgxkvTRMOCvS~123456" with your API Token from your Optimizely Dashboard
      // optimizely.com/dashboard

      // [OPTIMIZELY] (OPTIONAL) Google Analytics Example
      // https://help.optimizely.com/hc/en-us/articles/204628347
      // Initialize Google Analytics prior to startOptimizely e.g.
      // id<GAITracker> tracker = [[GAI sharedInstance] trackerWithTrackingId:@"YOUR_GA_TRACKING_ID"];
      var options = launchOptions ?? new NSDictionary();
      //OptimizelyiOS.Optimizely.StartOptimizelyWithAPIToken(@"AAMseu0A6cJKXYL7RiH_TgxkvTRMOCvS~123456", options);

      // [OPTIMIZELY] (OPTIONAL) Mixpanel Integration Instructions and order
      // Optimizely Mixpanel Integration goes here
      // Mixpanel Activation goes here

      // [OPTIMIZELY] (DEBUG) Subscribe to the OptimizelyExperimentVisitedNotification to know when an experiment
      // is visited, which means the visitor has see the experience you created
      NSNotificationCenter.DefaultCenter.AddObserver(this, new ObjCRuntime.Selector("ExperimentReceivedNotification"), OptimizelyiOS.Optimizely.OptimizelyExperimentVisitedNotification, null);

      // [OPTIMIZELY] (DEBUG) Subscribe to the OptimizelyNewDataFileLoadedNotification to know when
      // a new Optimizely data file has been updated
      NSNotificationCenter.DefaultCenter.AddObserver(this, new ObjCRuntime.Selector("DataFileReceivedNotification"), OptimizelyiOS.Optimizely.OptimizelyNewDataFileLoadedNotification, null);

      // [OPTIMIZELY] (DEBUG) Subscribe to the OptimizelyGoalTriggeredNotification to know when
      // a goal has triggered
      NSNotificationCenter.DefaultCenter.AddObserver(this, new ObjCRuntime.Selector("GoalReceivedNotification"), OptimizelyiOS.Optimizely.OptimizelyGoalTriggeredNotification, null);

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

    public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
    {
      // [OPTIMIZELY] (REQUIRED) Be sure to add this entire method.
      // If you use other tools such as AdX, you will need to make sure that
      // Optimizely's handleOpenURL is called first.  This allows you to connect
      // the app with Optimizely's editor.
      return OptimizelyiOS.Optimizely.HandleOpenURL(url);
    }

    public void DataFileReceivedNotification(NSNotification notification)
    {
      // This notification will be triggered once the new data file has been loaded
      Console.WriteLine(string.Format("Data viewed {0}", notification.Name));

      foreach (var data in OptimizelyiOS.Optimizely.SharedInstance().AllExperiments)
      {
        Console.WriteLine(string.Format("All Experiments: {0}, {1}, {2}, {3}, visitedEVER: {4}, visitedCount: {5}",
            data.ExperimentName, data.ExperimentId, data.VariationName, data.State, data.VisitedEver, data.VisitedCount));
      }
    }

    public void ExperimentReceivedNotification(NSNotification notification)
    {
      // An experiment is marked as visited when a user as viewed the experience you have created
      Console.WriteLine(string.Format("experiment visited {0}", notification.Name));

      foreach (var data in OptimizelyiOS.Optimizely.SharedInstance().VisitedExperiments)
      {
        Console.WriteLine(string.Format("All Experiments: {0}, {1}, {2}, {3}, visitedEVER: {4}, visitedCount: {5}",
            data.ExperimentName, data.ExperimentId, data.VariationName, data.State, data.VisitedEver, data.VisitedCount));
      }
    }

    public void GoalReceivedNotification(NSNotification notification)
    {
      Console.WriteLine(string.Format("Goal viewed {0}!", notification.Name));
    }
  }
}