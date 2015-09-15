using System;
using Foundation;

namespace TrustDefenderSDK.iOS
{
  [Static]
  public partial interface Constants
  {
    // extern NSString *const TDMOrgID;
    [Field("TDMOrgID", "__Internal")]
    NSString TDMOrgID { get; }

    // extern NSString *const TDMApiKey;
    [Field("TDMApiKey", "__Internal")]
    NSString TDMApiKey { get; }

    // extern NSString *const TDMDelegate;
    [Field("TDMDelegate", "__Internal")]
    NSString TDMDelegate { get; }

    // extern NSString *const TDMTimeout;
    [Field("TDMTimeout", "__Internal")]
    NSString TDMTimeout { get; }
    
    // extern NSString *const TDMLocationServices;
    [Field("TDMLocationServices", "__Internal")]
    NSString TDMLocationServices { get; }
    
    // extern NSString *const TDMLocationServicesWithPrompt;
    [Field("TDMLocationServicesWithPrompt", "__Internal")]
    NSString TDMLocationServicesWithPrompt { get; }
    
    // extern NSString *const TDMDesiredLocationAccuracy;
    [Field("TDMDesiredLocationAccuracy", "__Internal")]
    NSString TDMDesiredLocationAccuracy { get; }
    
    // extern NSString *const TDMKeychainAccessGroup;
    [Field("TDMKeychainAccessGroup", "__Internal")]
    NSString TDMKeychainAccessGroup { get; }
    
    // extern NSString *const TDMOptions;
    [Field("TDMOptions", "__Internal")]
    NSString TDMOptions { get; }
    
    // extern NSString *const TDMFingerprintServer;
    [Field("TDMFingerprintServer", "__Internal")]
    NSString TDMFingerprintServer { get; }
    
    // extern NSString *const TDMProfileSourceURL;
    [Field("TDMProfileSourceURL", "__Internal")]
    NSString TDMProfileSourceURL { get; }
    
    // extern NSString *const TDMSessionID;
    [Field("TDMSessionID", "__Internal")]
    NSString TDMSessionID { get; }
    
    // extern NSString *const TDMCustomAttributes;
    [Field("TDMCustomAttributes", "__Internal")]
    NSString TDMCustomAttributes { get; }
    
    // extern NSString *const TDMLocation;
    [Field("TDMLocation", "__Internal")]
    NSString TDMLocation { get; }
    
    // extern NSString *const TDMProfileStatus;
    [Field("TDMProfileStatus", "__Internal")]
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
    //[Verify(MethodToProperty)]
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
