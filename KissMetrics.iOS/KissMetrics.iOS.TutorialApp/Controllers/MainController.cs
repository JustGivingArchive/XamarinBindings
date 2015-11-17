using UIKit;
using KissMetrics.iOS.Binding;
using MonoTouch.Dialog;
using System;
using Foundation;

namespace KissMetrics.iOS.TutorialApp
{
  public class MainController : DialogViewController
  {
    // [KISSmetrics] The singleton KISSmetricsAPI instance.
    KISSmetricsAPI api = KISSmetricsAPI.SharedAPI;

    public MainController()
      : base(UITableViewStyle.Plain, null)
    {
      Root = new RootElement("Commands")
      {
        new Section("Identity")
        {
          // [KISSmetrics] Get current identity
          // Returns the last set identity
          new StringElement("Show Identity", () => ShowAlert("Identity", api.Identity)),
          new StringElement("Identify", () => SetIdentity(api.Identity, obj =>
              {
                // [KISSmetrics] Identifying Users
                // Associates an identity (such as an email address) with a user.
                api.Identify(obj);
                ShowAlert("Identity", "Identity set");
              })),
          new StringElement("Clear Identity", () =>
            {
              // [KISSmetrics] Clear current identity
              // should be call when a user sings out.
              // Clears the last set identity.
              api.ClearIdentity();
              ShowAlert("Identity", "Identity cleared");
            }),
          // [KISSmetrics] Should be called if there are 2 or more known identities of a user
          // Associates two identities (such as an email address and a name) with a user.
          new StringElement("Alias", () => api.Alias(api.Identity, "Name"))
        },
        // [KISSmetrics] Records an event with an optional set of properties.
        new Section("Records")
        {
          // [KISSmetrics] Track Event
          // RecordEvent() is being deprecated
          new StringElement("Track event", () =>
            {
              api.Record("Track event");
              ShowAlert("Track event", "Event tracked");
            }),
          new StringElement("Track event with properties", () =>
            {
              api.Record("Track event with properties", new NSDictionary(new NSString("Value"), new NSString("My property")));
              ShowAlert("Track event", "Event tracked with properties");
            }),
          new StringElement("Track event per set identity", () =>
            {
              // [KISSmetrics] Track an event only once per set identity. 
              // After an identity is cleared or a new identity is set, the condition will pass once again.
              api.Record("Event per set identity", KMARecordCondition.OncePerIdentity);
              ShowAlert("Track event", "This event track only once per identity");
            }),
          new StringElement("Track event per install", () =>
            {
              // [KISSmetrics] Track an event only once per install
              api.Record("Event per install", KMARecordCondition.OncePerInstall);
              ShowAlert("Track event", "This event track only once per install");
            }),
          new StringElement("Track event per install with properties", () =>
            {
              // [KISSmetrics] Track an event only once per install with properties
              api.Record("Track event per install with properties", new NSDictionary(new NSString("Value"), new NSString("My property")), KMARecordCondition.OncePerInstall);
              ShowAlert("Track event", "This event track only once per install");
            }),
          new StringElement("Track event per set identity with properties", () =>
            {
              // [KISSmetrics] Track an event only once per set identity with properties
              api.Record("Track event per set identity with properties", new NSDictionary(new NSString("Value"), new NSString("My property")), KMARecordCondition.OncePerIdentity);
              ShowAlert("Track event", "This event track only once per identity");
            }),
        },
        new Section("Properties")
        {
          new StringElement("Set distinct", () =>
            {
              // [KISSmetrics] Set user properties only if they have changed on the device
              // Sets one property on a user per identity only if the provided value is different
              // than the previously set value or if a value has not yet been set for the property. If an identity is
              // cleared via clearIdentity, these properties may again be set for the next identity.
              api.SetDistinct(new NSString("7.1"), "OS version");
              ShowAlert("Properies", "Distinct set");
            }),          
          new StringElement("Set properties", () =>
            {
              // [KISSmetrics] Set Properties
              // Sets one or more properties on a user.
              api.Set(new NSDictionary());
              ShowAlert("Properies", "Properties set");
            })
        }
      };      
    }

    static void ShowAlert(string title, string message)
    {
      new UIAlertView(title, message, null, "OK", null).Show();
    }

    static void SetIdentity(string currentIdentity, Action<string> callback)
    {
      var alert = new UIAlertView("Idetify", "Identify user", null, "OK", null);
      alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
      alert.GetTextField(0).Text = currentIdentity;
      alert.Clicked += delegate
      {
        callback(alert.GetTextField(0).Text);
      };
      alert.Show();
    }
  }
}