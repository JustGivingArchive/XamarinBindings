using System;
using Foundation;

namespace TrustDefender.iOS
{
  // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
  // to the project by right-clicking (or Control-clicking) the folder containing this source
  // file and clicking "Add files..." and then simply select the native library (or libraries)
  // that you want to bind.
  //
  // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
  // native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
  // architectures that the native library supports and fills in that information for you,
  // however, it cannot auto-detect any Frameworks or other system libraries that the
  // native library may depend on, so you'll need to fill in that information yourself.
  //
  // Once you've done that, you're ready to move on to binding the API...
  //
  //
  // Here is where you'd define your API definition for the native Objective-C library.
  //
  // For example, to bind the following Objective-C class:
  //
  //     @interface Widget : NSObject {
  //     }
  //
  // The C# binding would look like this:
  //
  //     [BaseType (typeof (NSObject))]
  //     interface Widget {
  //     }
  //
  // To bind Objective-C properties, such as:
  //
  //     @property (nonatomic, readwrite, assign) CGPoint center;
  //
  // You would add a property definition in the C# interface like so:
  //
  //     [Export ("center")]
  //     CGPoint Center { get; set; }
  //
  // To bind an Objective-C method, such as:
  //
  //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
  //
  // You would add a method definition to the C# interface like so:
  //
  //     [Export ("doSomething:atIndex:")]
  //     void DoSomething (NSObject object, int index);
  //
  // Objective-C "constructors" such as:
  //
  //     -(id)initWithElmo:(ElmoMuppet *)elmo;
  //
  // Can be bound as:
  //
  //     [Export ("initWithElmo:")]
  //     IntPtr Constructor (ElmoMuppet elmo);
  //
  // For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
  //

  //[Verify (ConstantsInterfaceAssociation)]
  partial interface Constants
  {
    // extern NSString *const TDMOrgID;
    [Field("TDMOrgID")]
    NSString TDMOrgID { get; }

    // extern NSString *const TDMApiKey;
    [Field("TDMApiKey")]
    NSString TDMApiKey { get; }

    [Wrap("WeakTDMDelegate"), Field("TDMDelegate")]
    NSString TDMDelegate { get; }

    // extern NSString *const TDMDelegate;
    [Field("TDMDelegate")]
    [NullAllowed]
    NSObject WeakTDMDelegate { get; }

    // extern NSString *const TDMTimeout;
    [Field("TDMTimeout")]
    NSString TDMTimeout { get; }

    // extern NSString *const TDMLocationServices;
    [Field("TDMLocationServices")]
    NSString TDMLocationServices { get; }

    // extern NSString *const TDMLocationServicesWithPrompt;
    [Field("TDMLocationServicesWithPrompt")]
    NSString TDMLocationServicesWithPrompt { get; }

    // extern NSString *const TDMDesiredLocationAccuracy;
    [Field("TDMDesiredLocationAccuracy")]
    NSString TDMDesiredLocationAccuracy { get; }

    // extern NSString *const TDMKeychainAccessGroup;
    [Field("TDMKeychainAccessGroup")]
    NSString TDMKeychainAccessGroup { get; }

    // extern NSString *const TDMOptions;
    [Field("TDMOptions")]
    NSString TDMOptions { get; }

    // extern NSString *const TDMFingerprintServer;
    [Field("TDMFingerprintServer")]
    NSString TDMFingerprintServer { get; }

    // extern NSString *const TDMProfileSourceURL;
    [Field("TDMProfileSourceURL")]
    NSString TDMProfileSourceURL { get; }

    // extern NSString *const TDMSessionID;
    [Field("TDMSessionID")]
    NSString TDMSessionID { get; }

    // extern NSString *const TDMCustomAttributes;
    [Field("TDMCustomAttributes")]
    NSString TDMCustomAttributes { get; }

    // extern NSString *const TDMLocation;
    [Field("TDMLocation")]
    NSString TDMLocation { get; }

    // extern NSString *const TDMProfileStatus;
    [Field("TDMProfileStatus")]
    NSString TDMProfileStatus { get; }
  }

  // @interface TrustDefenderMobile : NSObject
  [BaseType(typeof(NSObject))]
  interface TrustDefenderMobile
  {
    // -(id)initWithConfig:(NSDictionary *)config;
    [Export("initWithConfig:")]
    IntPtr Constructor(NSDictionary config);

    // -(THMStatusCode)doProfileRequest;
    [Export("doProfileRequest")]
    //[Verify (MethodToProperty)]
    THMStatusCode DoProfileRequest();

    // -(THMStatusCode)doProfileRequest:(NSDictionary *)options;
    [Export("doProfileRequest:")]
    THMStatusCode DoProfileRequest(NSDictionary options);

    // -(THMStatusCode)doProfileRequestWithCallback:(void (^)(NSDictionary *))callbackBlock;
    [Export("doProfileRequestWithCallback:")]
    THMStatusCode DoProfileRequestWithCallback(Action<NSDictionary> callbackBlock);

    // -(THMStatusCode)doProfileRequestWithOptions:(NSDictionary *)profileOptions andCallbackBlock:(void (^)(NSDictionary *))callbackBlock;
    [Export("doProfileRequestWithOptions:andCallbackBlock:")]
    THMStatusCode DoProfileRequestWithOptions(NSDictionary profileOptions, Action<NSDictionary> callbackBlock);

    // -(void)pauseLocationServices:(BOOL)pause;
    [Export("pauseLocationServices:")]
    void PauseLocationServices(bool pause);

    // -(NSDictionary *)getResult;
    [Export("getResult")]
    //[Verify(MethodToProperty)]
    NSDictionary Result { get; }

    // -(NSString *)version;
    [Export("version")]
    //[Verify(MethodToProperty)]
    string Version { get; }

    // -(void)cancel;
    [Export("cancel")]
    void Cancel();
  }

  // @protocol TrustDefenderMobileDelegate
  [Protocol, Model]
  interface TrustDefenderMobileDelegate
  {
    // @required -(void)profileComplete:(NSDictionary *)profileResults;
    [Abstract]
    [Export("profileComplete:")]
    void ProfileComplete(NSDictionary profileResults);
  }
}