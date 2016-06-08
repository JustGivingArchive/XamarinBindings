using System;
using Foundation;
using ObjCRuntime;

namespace MixpaneliOS
{
	// @interface Mixpanel : NSObject
	[BaseType (typeof(NSObject))]
	interface Mixpanel
	{
		// @property (readonly, atomic, strong) MixpanelPeople * people;
		[Export ("people", ArgumentSemantic.Strong)]
		MixpanelPeople People { get; }

		// @property (readonly, copy, atomic) NSString * distinctId;
		[Export ("distinctId")]
		string DistinctId { get; }

		// @property (copy, atomic) NSString * nameTag;
		[Export ("nameTag")]
		string NameTag { get; set; }

		// @property (copy, atomic) NSString * serverURL;
		[Export ("serverURL")]
		string ServerURL { get; set; }

		// @property (atomic) NSUInteger flushInterval;
		[Export ("flushInterval", ArgumentSemantic.Assign)]
		nuint FlushInterval { get; set; }

		// @property (atomic) BOOL flushOnBackground;
		[Export ("flushOnBackground")]
		bool FlushOnBackground { get; set; }

		// @property (atomic) BOOL showNetworkActivityIndicator;
		[Export ("showNetworkActivityIndicator")]
		bool ShowNetworkActivityIndicator { get; set; }

		// @property (atomic) BOOL checkForSurveysOnActive;
		[Export ("checkForSurveysOnActive")]
		bool CheckForSurveysOnActive { get; set; }

		// @property (atomic) BOOL showSurveyOnActive;
		[Export ("showSurveyOnActive")]
		bool ShowSurveyOnActive { get; set; }

		// @property (atomic) BOOL checkForNotificationsOnActive;
		[Export ("checkForNotificationsOnActive")]
		bool CheckForNotificationsOnActive { get; set; }

		// @property (atomic) BOOL checkForVariantsOnActive;
		[Export ("checkForVariantsOnActive")]
		bool CheckForVariantsOnActive { get; set; }

		// @property (atomic) BOOL showNotificationOnActive;
		[Export ("showNotificationOnActive")]
		bool ShowNotificationOnActive { get; set; }

		// @property (atomic) CGFloat miniNotificationPresentationTime;
		[Export ("miniNotificationPresentationTime", ArgumentSemantic.Assign)]
		nfloat MiniNotificationPresentationTime { get; set; }

		[Wrap ("WeakDelegate")]
		MixpanelDelegate Delegate { get; set; }

		// @property (atomic, weak) id<MixpanelDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(Mixpanel *)sharedInstanceWithToken:(NSString *)apiToken;
		[Static]
		[Export ("sharedInstanceWithToken:")]
		Mixpanel SharedInstanceWithToken (string apiToken);

		// +(Mixpanel *)sharedInstanceWithToken:(NSString *)apiToken launchOptions:(NSDictionary *)launchOptions;
		[Static]
		[Export ("sharedInstanceWithToken:launchOptions:")]
		Mixpanel SharedInstanceWithToken (string apiToken, NSDictionary launchOptions);

		// +(Mixpanel *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		Mixpanel SharedInstance { get; }

		// -(instancetype)initWithToken:(NSString *)apiToken launchOptions:(NSDictionary *)launchOptions andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:launchOptions:andFlushInterval:")]
		IntPtr Constructor (string apiToken, NSDictionary launchOptions, nuint flushInterval);

		// -(instancetype)initWithToken:(NSString *)apiToken andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:andFlushInterval:")]
		IntPtr Constructor (string apiToken, nuint flushInterval);

		// -(void)identify:(NSString *)distinctId;
		[Export ("identify:")]
		void Identify (string distinctId);

		// -(void)track:(NSString *)event;
		[Export ("track:")]
		void Track (string eventName);

		// -(void)track:(NSString *)event properties:(NSDictionary *)properties;
		[Export ("track:properties:")]
		void Track (string eventName, NSDictionary properties);

		// -(void)trackPushNotification:(NSDictionary *)userInfo;
		[Export ("trackPushNotification:")]
		void TrackPushNotification (NSDictionary userInfo);

		// -(void)registerSuperProperties:(NSDictionary *)properties;
		[Export ("registerSuperProperties:")]
		void RegisterSuperProperties (NSDictionary properties);

		// -(void)registerSuperPropertiesOnce:(NSDictionary *)properties;
		[Export ("registerSuperPropertiesOnce:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties);

		// -(void)registerSuperPropertiesOnce:(NSDictionary *)properties defaultValue:(id)defaultValue;
		[Export ("registerSuperPropertiesOnce:defaultValue:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties, NSObject defaultValue);

		// -(void)unregisterSuperProperty:(NSString *)propertyName;
		[Export ("unregisterSuperProperty:")]
		void UnregisterSuperProperty (string propertyName);

		// -(void)clearSuperProperties;
		[Export ("clearSuperProperties")]
		void ClearSuperProperties ();

		// -(NSDictionary *)currentSuperProperties;
		[Export ("currentSuperProperties")]
		NSDictionary CurrentSuperProperties { get; }

		// -(void)timeEvent:(NSString *)event;
		[Export ("timeEvent:")]
		void TimeEvent (string eventName);

		// -(void)clearTimedEvents;
		[Export ("clearTimedEvents")]
		void ClearTimedEvents ();

		// -(void)reset;
		[Export ("reset")]
		void Reset ();

		// -(void)flush;
		[Export ("flush")]
		void Flush ();

		// -(void)archive;
		[Export ("archive")]
		void Archive ();

		// -(void)showSurveyWithID:(NSUInteger)ID;
		[Export ("showSurveyWithID:")]
		void ShowSurveyWithID (nuint ID);

		// -(void)showSurvey;
		[Export ("showSurvey")]
		void ShowSurvey ();

		// -(void)showNotificationWithID:(NSUInteger)ID;
		[Export ("showNotificationWithID:")]
		void ShowNotificationWithID (nuint ID);

		// -(void)showNotificationWithType:(NSString *)type;
		[Export ("showNotificationWithType:")]
		void ShowNotificationWithType (string type);

		// -(void)showNotification;
		[Export ("showNotification")]
		void ShowNotification ();

		// -(void)joinExperiments;
		[Export ("joinExperiments")]
		void JoinExperiments ();

		// -(void)joinExperimentsWithCallback:(void (^)())experimentsLoadedCallback;
		[Export ("joinExperimentsWithCallback:")]
		void JoinExperimentsWithCallback (Action experimentsLoadedCallback);

		// -(void)createAlias:(NSString *)alias forDistinctID:(NSString *)distinctID;
		[Export ("createAlias:forDistinctID:")]
		void CreateAlias (string alias, string distinctID);

		// -(NSString *)libVersion;
		[Export ("libVersion")]
		string LibVersion { get; }
	}

	// @interface MixpanelPeople : NSObject
	[BaseType (typeof(NSObject))]
	interface MixpanelPeople
	{
		// -(void)addPushDeviceToken:(NSData *)deviceToken;
		[Export ("addPushDeviceToken:")]
		void AddPushDeviceToken (NSData deviceToken);

		// -(void)set:(NSDictionary *)properties;
		[Export ("set:")]
		void Set (NSDictionary properties);

		// -(void)set:(NSString *)property to:(id)object;
		[Export ("set:to:")]
		void Set (string property, NSObject obj);

		// -(void)setOnce:(NSDictionary *)properties;
		[Export ("setOnce:")]
		void SetOnce (NSDictionary properties);

		// -(void)increment:(NSDictionary *)properties;
		[Export ("increment:")]
		void Increment (NSDictionary properties);

		// -(void)increment:(NSString *)property by:(NSNumber *)amount;
		[Export ("increment:by:")]
		void Increment (string property, NSNumber amount);

		// -(void)append:(NSDictionary *)properties;
		[Export ("append:")]
		void Append (NSDictionary properties);

		// -(void)union:(NSDictionary *)properties;
		[Export ("union:")]
		void Union (NSDictionary properties);

		// -(void)trackCharge:(NSNumber *)amount;
		[Export ("trackCharge:")]
		void TrackCharge (NSNumber amount);

		// -(void)trackCharge:(NSNumber *)amount withProperties:(NSDictionary *)properties;
		[Export ("trackCharge:withProperties:")]
		void TrackCharge (NSNumber amount, NSDictionary properties);

		// -(void)clearCharges;
		[Export ("clearCharges")]
		void ClearCharges ();

		// -(void)deleteUser;
		[Export ("deleteUser")]
		void DeleteUser ();
	}

	// @protocol MixpanelDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MixpanelDelegate
	{
		// @optional -(BOOL)mixpanelWillFlush:(Mixpanel *)mixpanel;
		[Export ("mixpanelWillFlush:")]
		bool MixpanelWillFlush (Mixpanel mixpanel);
	}
}
