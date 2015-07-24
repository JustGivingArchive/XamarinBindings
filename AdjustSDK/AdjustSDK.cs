using System;
using MonoTouch.Foundation;

// @protocol ADJLogger
using MonoTouch.ObjCRuntime;


[Protocol, Model]
interface ADJLogger {

	// @required -(void)setLogLevel:(ADJLogLevel)logLevel;
	[Export ("setLogLevel:")]
	[Abstract]
    void SetLogLevel (ADJLoggingLevel logLevel);

	// @required -(void)verbose:(NSString *)message, ...;
	[Export ("verbose:")]
	[Abstract]
	void Verbose (string message);

	// @required -(void)debug:(NSString *)message, ...;
	[Export ("debug:")]
	[Abstract]
	void Debug (string message);

	// @required -(void)info:(NSString *)message, ...;
	[Export ("info:")]
	[Abstract]
	void Info (string message);

	// @required -(void)warn:(NSString *)message, ...;
	[Export ("warn:")]
	[Abstract]
	void Warn (string message);

	// @required -(void)error:(NSString *)message, ...;
	[Export ("error:")]
	[Abstract]
	void Error (string message);

	// @required -(void)assert:(NSString *)message, ...;
	[Export ("assert:")]
	[Abstract]
	void Assert (string message);
}

// @interface ADJLogger : NSObject <ADJLogger>
[BaseType (typeof (NSObject))]
interface ADJLogger : ADJLogger {

	// +(ADJLogLevel)LogLevelFromString:(NSString *)logLevelString;
	[Static, Export ("LogLevelFromString:")]
    ADJLoggingLevel LogLevelFromString (string logLevelString);
}

// @interface ADJEvent : NSObject <NSCopying>
[BaseType (typeof (NSObject))]
interface ADJEvent : NSCopying {

	// -(id)initWithEventToken:(NSString *)eventToken;
	[Export ("initWithEventToken:")]
	IntPtr Constructor (string eventToken);

	// @property (readonly, copy, nonatomic) NSString * eventToken;
	[Export ("eventToken")]
	string EventToken { get; }

	// @property (readonly, copy, nonatomic) NSNumber * revenue;
	[Export ("revenue", ArgumentSemantic.Copy)]
	NSNumber Revenue { get; }

	// @property (readonly, nonatomic) NSDictionary * callbackParameters;
	[Export ("callbackParameters")]
	NSDictionary CallbackParameters { get; }

	// @property (readonly, nonatomic) NSDictionary * partnerParameters;
	[Export ("partnerParameters")]
	NSDictionary PartnerParameters { get; }

	// @property (copy, nonatomic) NSString * transactionId;
	[Export ("transactionId")]
	string TransactionId { get; set; }

	// @property (readonly, copy, nonatomic) NSString * currency;
	[Export ("currency")]
	string Currency { get; }

	// +(ADJEvent *)eventWithEventToken:(NSString *)eventToken;
	[Static, Export ("eventWithEventToken:")]
	ADJEvent EventWithEventToken (string eventToken);

	// -(void)addCallbackParameter:(NSString *)key value:(NSString *)value;
	[Export ("addCallbackParameter:value:")]
	void AddCallbackParameter (string key, string value);

	// -(void)addPartnerParameter:(NSString *)key value:(NSString *)value;
	[Export ("addPartnerParameter:value:")]
	void AddPartnerParameter (string key, string value);

	// -(void)setRevenue:(double)amount currency:(NSString *)currency;
	[Export ("setRevenue:currency:")]
	void SetRevenue (double amount, string currency);

	// -(BOOL)isValid;
	[Export ("isValid")]
	bool IsValid ();
}

// @interface ADJAttribution : NSObject <NSCoding, NSCopying>
[BaseType (typeof (NSObject))]
interface ADJAttribution : NSCoding, NSCopying {

	// -(id)initWithJsonDict:(NSDictionary *)jsonDict;
	[Export ("initWithJsonDict:")]
	IntPtr Constructor (NSDictionary jsonDict);

	// @property (copy, nonatomic) NSString * trackerToken;
	[Export ("trackerToken")]
	string TrackerToken { get; set; }

	// @property (copy, nonatomic) NSString * trackerName;
	[Export ("trackerName")]
	string TrackerName { get; set; }

	// @property (copy, nonatomic) NSString * network;
	[Export ("network")]
	string Network { get; set; }

	// @property (copy, nonatomic) NSString * campaign;
	[Export ("campaign")]
	string Campaign { get; set; }

	// @property (copy, nonatomic) NSString * adgroup;
	[Export ("adgroup")]
	string Adgroup { get; set; }

	// @property (copy, nonatomic) NSString * creative;
	[Export ("creative")]
	string Creative { get; set; }

	// -(BOOL)isEqualToAttribution:(ADJAttribution *)attribution;
	[Export ("isEqualToAttribution:")]
	bool IsEqualToAttribution (ADJAttribution attribution);

	// +(ADJAttribution *)dataWithJsonDict:(NSDictionary *)jsonDict;
	[Static, Export ("dataWithJsonDict:")]
	ADJAttribution DataWithJsonDict (NSDictionary jsonDict);

	// -(NSDictionary *)dictionary;
	[Export ("dictionary")]
	NSDictionary Dictionary ();
}

// @protocol AdjustDelegate
[Protocol, Model]
interface AdjustDelegate {

	// @optional -(void)adjustAttributionChanged:(ADJAttribution *)attribution;
	[Export ("adjustAttributionChanged:")]
	void AdjustAttributionChanged (ADJAttribution attribution);
}

// @interface ADJConfig : NSObject <NSCopying>
[BaseType (typeof (NSObject))]
interface ADJConfig : NSCopying {

	// -(id)initWithAppToken:(NSString *)appToken environment:(NSString *)environment;
	[Export ("initWithAppToken:environment:")]
	IntPtr Constructor (string appToken, string environment);

	// @property (readonly, copy, nonatomic) NSString * appToken;
	[Export ("appToken")]
	string AppToken { get; }

	// @property (assign, nonatomic) ADJLogLevel logLevel;
	[Export ("logLevel", ArgumentSemantic.UnsafeUnretained)]
    ADJLoggingLevel LogLevel { get; set; }

	// @property (readonly, copy, nonatomic) NSString * environment;
	[Export ("environment")]
	string Environment { get; }

	// @property (copy, nonatomic) NSString * sdkPrefix;
	[Export ("sdkPrefix")]
	string SdkPrefix { get; set; }

	// @property (assign, nonatomic) BOOL eventBufferingEnabled;
	[Export ("eventBufferingEnabled", ArgumentSemantic.UnsafeUnretained)]
	bool EventBufferingEnabled { get; set; }

	// @property (assign, nonatomic) BOOL macMd5TrackingEnabled;
	[Export ("macMd5TrackingEnabled", ArgumentSemantic.UnsafeUnretained)]
	bool MacMd5TrackingEnabled { get; set; }

	// @property (retain, nonatomic) NSObject<AdjustDelegate> * delegate;
	[Export ("delegate", ArgumentSemantic.Retain)]
	[NullAllowe
        d]
	NSObject WeakDelegate { get; set; }

	// @property (retain, nonatomic) NSObject<AdjustDelegate> * delegate;
	[Wrap ("WeakDelegate")]
	NSObject Delegate { get; set; }

	// @property (assign, nonatomic) BOOL hasDelegate;
	[Export ("hasDelegate", ArgumentSemantic.UnsafeUnretained)]
	[NullAllowed]
	NSObject WeakHasDelegate { get; set; }

	// @property (assign, nonatomic) BOOL hasDelegate;
	[Wrap ("WeakHasDelegate")]
	bool HasDelegate { get; set; }

	// +(ADJConfig *)configWithAppToken:(NSString *)appToken environment:(NSString *)environment;
	[Static, Export ("configWithAppToken:environment:")]
	ADJConfig ConfigWithAppToken (string appToken, string environment);

	// -(BOOL)isValid;
	[Export ("isValid")]
	bool IsValid ();
}

// @interface Adjust : NSObject
[BaseType (typeof (NSObject))]
interface Adjust {

	// +(void)appDidLaunch:(ADJConfig *)adjustConfig;
	[Static, Export ("appDidLaunch:")]
	void AppDidLaunch (ADJConfig adjustConfig);

	// +(void)trackEvent:(ADJEvent *)event;
	[Static, Export ("trackEvent:")]
	void TrackEvent (ADJEvent event);

	// +(void)trackSubsessionStart;
	[Static, Export ("trackSubsessionStart")]
	void TrackSubsessionStart ();

	// +(void)trackSubsessionEnd;
	[Static, Export ("trackSubsessionEnd")]
	void TrackSubsessionEnd ();

	// +(void)setEnabled:(BOOL)enabled;
	[Static, Export ("setEnabled:")]
	void SetEnabled (bool enabled);

	// +(BOOL)isEnabled;
	[Static, Export ("isEnabled")]
	bool IsEnabled ();

	// +(void)appWillOpenUrl:(NSURL *)url;
	[Static, Export ("appWillOpenUrl:")]
	void AppWillOpenUrl (NSUrl url);

	// +(void)setDeviceToken:(NSData *)deviceToken;
	[Static, Export ("setDeviceToken:")]
	void SetDeviceToken (NSData deviceToken);

	// +(void)setOfflineMode:(BOOL)enabled;
	[Static, Export ("setOfflineMode:")]
	void SetOfflineMode (bool enabled);

	// +(id)getInstance;
	[Static, Export ("getInstance")]
	NSObject GetInstance ();

	// -(void)appDidLaunch:(ADJConfig *)adjustConfig;
	[Export ("appDidLaunch:")]
	void AppDidLaunch (ADJConfig adjustConfig);

	// -(void)trackEvent:(ADJEvent *)event;
	[Export ("trackEvent:")]
	void TrackEvent (ADJEvent event);

	// -(void)trackSubsessionStart;
	[Export ("trackSubsessionStart")]
	void TrackSubsessionStart ();

	// -(void)trackSubsessionEnd;
	[Export ("trackSubsessionEnd")]
	void TrackSubsessionEnd ();

	// -(void)setEnabled:(BOOL)enabled;
	[Export ("setEnabled:")]
	void SetEnabled (bool enabled);

	// -(BOOL)isEnabled;
	[Export ("isEnabled")]
	bool IsEnabled ();

	// -(void)appWillOpenUrl:(NSURL *)url;
	[Export ("appWillOpenUrl:")]
	void AppWillOpenUrl (NSUrl url);

	// -(void)setDeviceToken:(NSData *)deviceToken;
	[Export ("setDeviceToken:")]
	void SetDeviceToken (NSData deviceToken);

	// -(void)setOfflineMode:(BOOL)enabled;
	[Export ("setOfflineMode:")]
	void SetOfflineMode (bool enabled);
}
