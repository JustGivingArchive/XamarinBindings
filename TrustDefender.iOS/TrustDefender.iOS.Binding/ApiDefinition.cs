using System;
using Foundation;

namespace TrustDefenderSDK.iOS
{
    [Static]
    public partial interface Constants
    {
        // extern NSString *const TDMOrgID __attribute__((visibility("default")));
        [Field("TDMOrgID", "__Internal")]
        NSString TDMOrgID { get; }

        // extern NSString *const TDMApiKey __attribute__((visibility("default")));
        [Field("TDMApiKey", "__Internal")]
        NSString TDMApiKey { get; }

        [Field("TDMDelegate", "__Internal")]
        NSString TDMDelegate { get; }

        // extern NSString *const TDMTimeout __attribute__((visibility("default")));
        [Field("TDMTimeout", "__Internal")]
        NSString TDMTimeout { get; }

        // extern NSString *const TDMLocationServices __attribute__((visibility("default")));
        [Field("TDMLocationServices", "__Internal")]
        NSString TDMLocationServices { get; }

        // extern NSString *const TDMLocationServicesWithPrompt __attribute__((visibility("default")));
        [Field("TDMLocationServicesWithPrompt", "__Internal")]
        NSString TDMLocationServicesWithPrompt { get; }

        // extern NSString *const TDMDesiredLocationAccuracy __attribute__((visibility("default")));
        [Field("TDMDesiredLocationAccuracy", "__Internal")]
        NSString TDMDesiredLocationAccuracy { get; }

        // extern NSString *const TDMKeychainAccessGroup __attribute__((visibility("default")));
        [Field("TDMKeychainAccessGroup", "__Internal")]
        NSString TDMKeychainAccessGroup { get; }

        // extern NSString *const TDMOptions __attribute__((visibility("default")));
        [Field("TDMOptions", "__Internal")]
        NSString TDMOptions { get; }

        // extern NSString *const TDMFingerprintServer __attribute__((visibility("default")));
        [Field("TDMFingerprintServer", "__Internal")]
        NSString TDMFingerprintServer { get; }

        // extern NSString *const TDMProfileSourceURL __attribute__((visibility("default")));
        [Field("TDMProfileSourceURL", "__Internal")]
        NSString TDMProfileSourceURL { get; }

        // extern NSString *const TDMSessionID __attribute__((visibility("default")));
        [Field("TDMSessionID", "__Internal")]
        NSString TDMSessionID { get; }

        // extern NSString *const TDMCustomAttributes __attribute__((visibility("default")));
        [Field("TDMCustomAttributes", "__Internal")]
        NSString TDMCustomAttributes { get; }

        // extern NSString *const TDMLocation __attribute__((visibility("default")));
        [Field("TDMLocation", "__Internal")]
        NSString TDMLocation { get; }

        // extern NSString *const TDMProfileStatus __attribute__((visibility("default")));
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
        //        [Verify (MethodToProperty)]
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
        //        [Verify (MethodToProperty)]
        NSDictionary Result { get; }

        // -(NSString *)version;
        [Export("version")]
        //        [Verify (MethodToProperty)]
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
