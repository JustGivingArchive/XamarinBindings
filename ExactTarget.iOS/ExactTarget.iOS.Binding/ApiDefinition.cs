using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreLocation;

namespace ExactTarget.iOS
{
    // @protocol ETGenericUpdateObjectProtocol <NSObject>
//    [Protocol, Model]
//    [BaseType (typeof(NSObject))]
//    interface ETGenericUpdateObjectProtocol
//    {
//        // @required +(instancetype)alloc;
//        [Static, Abstract]
//        [Export ("alloc")]
//        ETGenericUpdateObjectProtocol Alloc ();
//
//        // @required -(instancetype)initFromDictionary:(NSDictionary *)dict;
//        //[Abstract]
////        [Export ("initFromDictionary:")]
////        IntPtr Constructor (NSDictionary dict);
//
//        // @required +(NSString *)remoteRoutePath;
//        [Static, Abstract]
//        [Export ("remoteRoutePath")]
//        string RemoteRoutePathStatic { get; }
//
//        // @required -(NSString *)remoteRoutePath;
//        [Abstract]
//        [Export ("remoteRoutePath")]
//        string RemoteRoutePath { get; }
//
//        // @required +(NSString *)tableName;
//        [Static, Abstract]
//        [Export ("tableName")]
//        string TableName { get; }
//
//        // @required -(NSString *)tableName;
//        [Abstract]
//        [Export ("tableName")]
//        string TableNameStatic { get; }
//
//        // @required -(NSString *)jsonPayloadAsString;
//        [Abstract]
//        [Export ("jsonPayloadAsString")]
//        string JsonPayloadAsString { get; }
//
//        // @required -(NSDictionary *)jsonPayloadAsDictionary;
//        [Abstract]
//        [Export ("jsonPayloadAsDictionary")]
//        NSDictionary JsonPayloadAsDictionary { get; }
//
//        // @required -(GenericUpdateSendMethod)sendMethod;
//        [Abstract]
//        [Export ("sendMethod")]
//        GenericUpdateSendMethod SendMethod { get; }
//    }

    // @interface ETGenericUpdate : NSObject
    [BaseType (typeof(NSObject))]
    interface ETGenericUpdate
    {
        // @property (nonatomic) int tag;
        [Export ("tag")]
        int Tag { get; set; }

        // @property (nonatomic) NSInteger databaseIdentifier;
        [Export ("databaseIdentifier", ArgumentSemantic.Assign)]
        nint DatabaseIdentifier { get; set; }

        // @property (nonatomic, strong) NSMutableData * responseData;
        [Export ("responseData", ArgumentSemantic.Strong)]
        NSMutableData ResponseData { get; set; }

        // @property (nonatomic, strong) NSHTTPURLResponse * responseCode;
        [Export ("responseCode", ArgumentSemantic.Strong)]
        NSHttpUrlResponse ResponseCode { get; set; }

        // @property (assign, nonatomic) UIBackgroundTaskIdentifier backgroundTaskID;
        [Export ("backgroundTaskID", ArgumentSemantic.Assign)]
        nuint BackgroundTaskID { get; set; }

        // -(GenericUpdateSendMethod)sendMethod;
        [Export ("sendMethod")]
        GenericUpdateSendMethod SendMethod { get; }

        // -(NSString *)remoteRoutePath;
        [Export ("remoteRoutePath")]
        string RemoteRoutePath { get; }

        // -(NSString *)jsonPayloadAsString;
        [Export ("jsonPayloadAsString")]
        string JsonPayloadAsString { get; }

        // -(NSDictionary *)jsonPayloadAsDictionary;
        [Export ("jsonPayloadAsDictionary")]
        NSDictionary JsonPayloadAsDictionary { get; }

        // -(void)processResults;
        [Export ("processResults")]
        void ProcessResults ();

        // -(void)handleDataFailure;
        [Export ("handleDataFailure")]
        void HandleDataFailure ();

        // -(BOOL)shouldSaveSelfToDatabase;
        [Export ("shouldSaveSelfToDatabase")]
        bool ShouldSaveSelfToDatabase { get; }

        // -(int)dbVersionNumber;
        [Export ("dbVersionNumber")]
        int DbVersionNumber { get; }

        // -(NSString *)databaseVersionKey;
        [Export ("databaseVersionKey")]
        string DatabaseVersionKey { get; }

        // -(BOOL)generatePersistentDataSchemaInDatabase;
        [Export ("generatePersistentDataSchemaInDatabase")]
        bool GeneratePersistentDataSchemaInDatabase { get; }

        // -(NSArray *)insertQueryArguments;
        [Export ("insertQueryArguments")]
        NSObject[] InsertQueryArguments { get; }

        // -(NSArray *)updateQueryArguments;
        [Export ("updateQueryArguments")]
        NSObject[] UpdateQueryArguments { get; }

        // -(NSString *)insertQuerySyntax;
        [Export ("insertQuerySyntax")]
        string InsertQuerySyntax { get; }

        // -(NSString *)updateQuerySyntax;
        [Export ("updateQuerySyntax")]
        string UpdateQuerySyntax { get; }

        // -(BOOL)insertSelfIntoDatabase;
        [Export ("insertSelfIntoDatabase")]
        bool InsertSelfIntoDatabase();

        // -(NSString *)tableName;
        [Export ("tableName")]
        string TableName { get; }

        // +(NSString *)tableName;
        [Static]
        [Export ("tableName")]
        string TableNameStatic { get; }

        // +(NSDateFormatter *)formatterOfCorrectFormat;
        [Static]
        [Export ("formatterOfCorrectFormat")]
        NSDateFormatter FormatterOfCorrectFormat { get; }

        // +(NSDateFormatter *)alternativeFormatterOfCorrectFormat;
        [Static]
        [Export ("alternativeFormatterOfCorrectFormat")]
        NSDateFormatter AlternativeFormatterOfCorrectFormat { get; }

        // +(NSDate *)dateFromString:(NSString *)dateAsString;
        [Static]
        [Export ("dateFromString:")]
        NSDate DateFromString (string dateAsString);

        // +(NSString *)stringFromDate:(NSDate *)date;
        [Static]
        [Export ("stringFromDate:")]
        string StringFromDate (NSDate date);

        // +(NSNumberFormatter *)numberFormatterOfCorrectFormatForDouble;
        [Static]
        [Export ("numberFormatterOfCorrectFormatForDouble")]
        NSNumberFormatter NumberFormatterOfCorrectFormatForDouble { get; }
    }

    // @interface ETLocationUpdate : ETGenericUpdate
    [BaseType (typeof(ETGenericUpdate))]
    interface ETLocationUpdate
    {
        // @property (nonatomic) CLLocation * location;
        [Export ("location", ArgumentSemantic.Assign)]
        CLLocation Location { get; set; }

        // @property (nonatomic, strong) NSDate * eventDateTime;
        [Export ("eventDateTime", ArgumentSemantic.Strong)]
        NSDate EventDateTime { get; set; }

        // @property (nonatomic) NSNumber * latitude;
        [Export ("latitude", ArgumentSemantic.Assign)]
        NSNumber Latitude { get; set; }

        // @property (nonatomic) NSNumber * longitude;
        [Export ("longitude", ArgumentSemantic.Assign)]
        NSNumber Longitude { get; set; }

        // @property (nonatomic) NSNumber * accuracy;
        [Export ("accuracy", ArgumentSemantic.Assign)]
        NSNumber Accuracy { get; set; }

        // @property (nonatomic) LocationUpdateAppState appState;
        [Export ("appState", ArgumentSemantic.Assign)]
        LocationUpdateAppState AppState { get; set; }

        // +(BOOL)generatePersistentDataSchemaInDatabase;
        [Static]
        [Export ("generatePersistentDataSchemaInDatabase")]
        bool GeneratePersistentDataSchemaInDatabase();

        // -(NSString *)tableName;
        [Export ("tableName")]
        string TableName { get; }

        // +(NSString *)tableName;
        [Static]
        [Export ("tableName")]
        string TableNameStatic { get; }

        // -(id)initWithLocation:(CLLocation *)location forAppState:(LocationUpdateAppState)state;
        [Export ("initWithLocation:forAppState:")]
        IntPtr Constructor (CLLocation location, LocationUpdateAppState state);

        // -(NSString *)remoteRoutePath;
        [Export ("remoteRoutePath")]
        string RemoteRoutePath { get; }

        // -(NSString *)formattedDate;
        [Export ("formattedDate")]
        string FormattedDate { get; }

        // -(NSString *)jsonPayloadAsString;
        [Export ("jsonPayloadAsString")]
        string JsonPayloadAsString { get; }
    }

    // @interface ETRegion : ETGenericUpdate
    [BaseType (typeof(ETGenericUpdate))]
    interface ETRegion
    {
        // @property (nonatomic, strong) NSString * fenceIdentifier;
        [Export ("fenceIdentifier", ArgumentSemantic.Strong)]
        string FenceIdentifier { get; set; }

        // @property (nonatomic, strong) NSNumber * latitude;
        [Export ("latitude", ArgumentSemantic.Strong)]
        NSNumber Latitude { get; set; }

        // @property (nonatomic, strong) NSNumber * longitude;
        [Export ("longitude", ArgumentSemantic.Strong)]
        NSNumber Longitude { get; set; }

        // @property (nonatomic, strong) NSNumber * radius;
        [Export ("radius", ArgumentSemantic.Strong)]
        NSNumber Radius { get; set; }

        // @property (nonatomic, strong) NSMutableArray * messages;
        [Export ("messages", ArgumentSemantic.Strong)]
        NSMutableArray Messages { get; set; }

        // @property (nonatomic, strong) NSString * proximityUUID;
        [Export ("proximityUUID", ArgumentSemantic.Strong)]
        string ProximityUUID { get; set; }

        // @property (nonatomic, strong) NSNumber * majorNumber;
        [Export ("majorNumber", ArgumentSemantic.Strong)]
        NSNumber MajorNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * minorNumber;
        [Export ("minorNumber", ArgumentSemantic.Strong)]
        NSNumber MinorNumber { get; set; }

        // @property (nonatomic, strong) NSNumber * entryCount;
        [Export ("entryCount", ArgumentSemantic.Strong)]
        NSNumber EntryCount { get; set; }

        // @property (nonatomic, strong) NSNumber * exitCount;
        [Export ("exitCount", ArgumentSemantic.Strong)]
        NSNumber ExitCount { get; set; }

        // @property (nonatomic, strong) NSString * regionName;
        [Export ("regionName", ArgumentSemantic.Strong)]
        string RegionName { get; set; }

        // @property (assign, nonatomic) MobilePushGeofenceType locationType;
        [Export ("locationType", ArgumentSemantic.Assign)]
        MobilePushGeofenceType LocationType { get; set; }

        // @property (nonatomic) ETRegionRequestType requestType;
        [Export ("requestType", ArgumentSemantic.Assign)]
        ETRegionRequestType RequestType { get; set; }

        // -(id)initFromDictionary:(NSDictionary *)dict;
        [Export ("initFromDictionary:")]
        IntPtr Constructor (NSDictionary dict);

        // -(BOOL)isEqualToRegion:(ETRegion *)region;
        [Export ("isEqualToRegion:")]
        bool IsEqualToRegion (ETRegion region);

        // -(CLLocation *)regionAsLocation;
        [Export ("regionAsLocation")]
        CLLocation RegionAsLocation { get; }

        // -(CLRegion *)regionAsCLRegion;
        [Export ("regionAsCLRegion")]
        CLRegion RegionAsCLRegion { get; }

        // -(CLBeaconRegion *)regionAsBeaconRegion;
        [Export ("regionAsBeaconRegion")]
        CLBeaconRegion RegionAsBeaconRegion { get; }

        // -(BOOL)isGeofenceRegion;
        [Export ("isGeofenceRegion")]
        bool IsGeofenceRegion { get; }

        // -(BOOL)isBeaconRegion;
        [Export ("isBeaconRegion")]
        bool IsBeaconRegion { get; }

        // +(ETRegion *)getRegionByIdentifier:(NSString *)identifier;
        [Static]
        [Export ("getRegionByIdentifier:")]
        ETRegion GetRegionByIdentifier (string identifier);

        // +(ETRegion *)getBeaconRegionForRegionWithProximityUUID:(NSString *)proximityUUID andMajorNumber:(NSNumber *)majorNumber andMinorNumber:(NSNumber *)minorNumber;
        [Static]
        [Export ("getBeaconRegionForRegionWithProximityUUID:andMajorNumber:andMinorNumber:")]
        ETRegion GetBeaconRegionForRegionWithProximityUUID (string proximityUUID, NSNumber majorNumber, NSNumber minorNumber);

        // +(ETRegion *)getBeaconRegionForRegionWithProximityUUID:(NSString *)proximityUUID;
        [Static]
        [Export ("getBeaconRegionForRegionWithProximityUUID:")]
        ETRegion GetBeaconRegionForRegionWithProximityUUID (string proximityUUID);

        // +(NSSet *)getFencesFromCache;
        [Static]
        [Export ("getFencesFromCache")]
        NSSet FencesFromCache { get; }

        // +(NSSet *)getFencesFromCacheIncludingInactive:(BOOL)getInactive;
        [Static]
        [Export ("getFencesFromCacheIncludingInactive:")]
        NSSet GetFencesFromCacheIncludingInactive (bool getInactive);

        // +(BOOL)invalidateAllRegionsForRequestType:(ETRegionRequestType)requestType;
        [Static]
        [Export ("invalidateAllRegionsForRequestType:")]
        bool InvalidateAllRegionsForRequestType (ETRegionRequestType requestType);

        // +(BOOL)invalidateAllRegions;
        [Static]
        [Export ("invalidateAllRegions")]
        bool InvalidateAllRegions();

        // +(void)retrieveGeofencesFromET;
        [Static]
        [Export ("retrieveGeofencesFromET")]
        void RetrieveGeofencesFromET ();

        // +(void)retrieveProximityFromET;
        [Static]
        [Export ("retrieveProximityFromET")]
        void RetrieveProximityFromET ();

        // +(BOOL)generatePersistentDataSchemaInDatabase;
        [Static]
        [Export ("generatePersistentDataSchemaInDatabase")]
        bool GeneratePersistentDataSchemaInDatabase();
    }

    // @interface ETMessage : ETGenericUpdate
    [BaseType (typeof(ETGenericUpdate))]
    interface ETMessage
    {
        // @property (readonly, nonatomic, strong) NSString * messageIdentifier;
        [Export ("messageIdentifier", ArgumentSemantic.Strong)]
        string MessageIdentifier { get; }

        // @property (nonatomic, strong) NSString * messageName;
        [Export ("messageName", ArgumentSemantic.Strong)]
        string MessageName { get; set; }

        // @property (readonly, nonatomic) MobilePushMessageType messageType;
        [Export ("messageType")]
        MobilePushMessageType MessageType { get; }

        // @property (readonly, nonatomic) MobilePushContentType contentType;
        [Export ("contentType")]
        MobilePushContentType ContentType { get; }

        // @property (readonly, nonatomic, strong) NSString * alert;
        [Export ("alert", ArgumentSemantic.Strong)]
        string Alert { get; }

        // @property (readonly, nonatomic, strong) NSString * sound;
        [Export ("sound", ArgumentSemantic.Strong)]
        string Sound { get; }

        // @property (readonly, nonatomic, strong) NSString * badge;
        [Export ("badge", ArgumentSemantic.Strong)]
        string Badge { get; }

        // @property (readonly, nonatomic, strong) NSString * category;
        [Export ("category", ArgumentSemantic.Strong)]
        string Category { get; }

        // @property (readonly, nonatomic, strong) NSArray * keyValuePairs;
        [Export ("keyValuePairs", ArgumentSemantic.Strong)]
        NSObject[] KeyValuePairs { get; }

        // @property (readonly, nonatomic, strong) NSDate * startDate;
        [Export ("startDate", ArgumentSemantic.Strong)]
        NSDate StartDate { get; }

        // @property (readonly, nonatomic, strong) NSDate * endDate;
        [Export ("endDate", ArgumentSemantic.Strong)]
        NSDate EndDate { get; }

        // @property (readonly, nonatomic, strong) NSString * siteIdentifier;
        [Export ("siteIdentifier", ArgumentSemantic.Strong)]
        string SiteIdentifier { get; }

        // @property (readonly, nonatomic, strong) NSString * siteUrlAsString;
        [Export ("siteUrlAsString", ArgumentSemantic.Strong)]
        string SiteUrlAsString { get; }

        // @property (readonly, nonatomic, strong) NSString * openDirectPayload;
        [Export ("openDirectPayload", ArgumentSemantic.Strong)]
        string OpenDirectPayload { get; }

        // @property (readonly, nonatomic, strong) ETRegion * relatedFence;
        [Export ("relatedFence", ArgumentSemantic.Strong)]
        ETRegion RelatedFence { get; }

        // @property (readonly, nonatomic, strong) NSNumber * messageLimit;
        [Export ("messageLimit", ArgumentSemantic.Strong)]
        NSNumber MessageLimit { get; }

        // @property (readonly, nonatomic, strong) NSNumber * messagesPerPeriod;
        [Export ("messagesPerPeriod", ArgumentSemantic.Strong)]
        NSNumber MessagesPerPeriod { get; }

        // @property (readonly, nonatomic, strong) NSNumber * numberOfPeriods;
        [Export ("numberOfPeriods", ArgumentSemantic.Strong)]
        NSNumber NumberOfPeriods { get; }

        // @property (readonly, nonatomic) MobilePushMessageFrequencyUnit periodType;
        [Export ("periodType")]
        MobilePushMessageFrequencyUnit PeriodType { get; }

        // @property (readonly, getter = isRollingPeriod, nonatomic) BOOL rollingPeriod;
        [Export ("rollingPeriod")]
        bool RollingPeriod { [Bind ("isRollingPeriod")] get; }

        // @property (readonly, nonatomic, strong) NSNumber * minTripped;
        [Export ("minTripped", ArgumentSemantic.Strong)]
        NSNumber MinTripped { get; }

        // @property (readonly, getter = isEphemeralMessage, nonatomic) BOOL ephemeralMessage;
        [Export ("ephemeralMessage")]
        bool EphemeralMessage { [Bind ("isEphemeralMessage")] get; }

        // @property (readonly, nonatomic) CLProximity proximity;
        [Export ("proximity")]
        CLProximity Proximity { get; }

        // @property (readonly, nonatomic) NSInteger loiteringSeconds;
        [Export ("loiteringSeconds")]
        nint LoiteringSeconds { get; }

        // @property (readonly, getter = isRead, nonatomic) BOOL read;
        [Export ("read")]
        bool Read { [Bind ("isRead")] get; }

        // @property (readonly, getter = isActive, nonatomic) BOOL active;
        [Export ("active")]
        bool Active { [Bind ("isActive")] get; }

        // @property (nonatomic, strong) UILocalNotification * notification;
        [Export ("notification", ArgumentSemantic.Strong)]
        UILocalNotification Notification { get; set; }

        // @property (nonatomic) BOOL hasShownForBeacon;
        [Export ("hasShownForBeacon")]
        bool HasShownForBeacon { get; set; }

        // -(instancetype)initFromDictionary:(NSDictionary *)dict;
        [Export ("initFromDictionary:")]
        IntPtr Constructor (NSDictionary dict);

        // -(instancetype)initFromDictionary:(NSDictionary *)dict forFence:(ETRegion *)region;
        [Export ("initFromDictionary:forFence:")]
        IntPtr Constructor (NSDictionary dict, ETRegion region);

        // -(NSString *)subject;
        [Export ("subject")]
        string Subject { get; }

        // -(NSURL *)siteURL;
        [Export ("siteURL")]
        NSUrl SiteURL { get; }

        // -(BOOL)markAsRead;
        [Export ("markAsRead")]
        bool MarkAsRead();

        // -(BOOL)messageScheduledForDisplay;
        [Export ("messageScheduledForDisplay")]
        bool MessageScheduledForDisplay { get; }

        // -(BOOL)markAsUnread;
        [Export ("markAsUnread")]
        bool MarkAsUnread();

        // -(BOOL)markAsDeleted;
        [Export ("markAsDeleted")]
        bool MarkAsDeleted();

        // -(NSDate *)getLastShownDate;
        [Export ("getLastShownDate")]
        NSDate LastShownDate { get; }

        // -(int)getShowCount;
        [Export ("getShowCount")]
        int ShowCount { get; }

        // +(NSArray *)getMessagesByContentType:(MobilePushContentType)contentType;
        [Static]
        [Export ("getMessagesByContentType:")]
        NSObject[] GetMessagesByContentType (MobilePushContentType contentType);

        // +(ETMessage *)getMessageByIdentifier:(NSString *)identifier;
        [Static]
        [Export ("getMessageByIdentifier:")]
        ETMessage GetMessageByIdentifier (string identifier);

        // +(NSArray *)getMessagesByType:(MobilePushMessageType)type;
        [Static]
        [Export ("getMessagesByType:")]
        NSObject[] GetMessagesByType (MobilePushMessageType type);

        // +(NSArray *)getMessagesForGeofence:(ETRegion *)fence;
        [Static]
        [Export ("getMessagesForGeofence:")]
        NSObject[] GetMessagesForGeofence (ETRegion fence);

        // +(NSArray *)getMessagesForGeofence:(ETRegion *)fence andMessageType:(MobilePushMessageType)type;
        [Static]
        [Export ("getMessagesForGeofence:andMessageType:")]
        NSObject[] GetMessagesForGeofence (ETRegion fence, MobilePushMessageType type);

        // +(NSArray *)getProximityMessagesForRegion:(ETRegion *)region;
        [Static]
        [Export ("getProximityMessagesForRegion:")]
        NSObject[] GetProximityMessagesForRegion (ETRegion region);

        // +(void)getMessagesFromExactTargetOfMessageType:(MobilePushMessageType)messageType andContentType:(MobilePushContentType)contentType;
        [Static]
        [Export ("getMessagesFromExactTargetOfMessageType:andContentType:")]
        void GetMessagesFromExactTargetOfMessageType (MobilePushMessageType messageType, MobilePushContentType contentType);

        // +(BOOL)invalidateAllMessagesForType:(MobilePushMessageType)type;
        [Static]
        [Export ("invalidateAllMessagesForType:")]
        bool InvalidateAllMessagesForType (MobilePushMessageType type);

        // -(BOOL)isEqualToMessage:(ETMessage *)message;
        [Export ("isEqualToMessage:")]
        bool IsEqualToMessage (ETMessage message);
    }

    // @interface ETLocationManager : NSObject <CLLocationManagerDelegate>
    //[BaseType(typeof(NSObject), Delegates = new[] { "Delegate" }, Events = new[] { typeof(CLLocationManagerDelegate) })]
    [BaseType(typeof(CLLocationManagerDelegate))]
    interface ETLocationManager
    {
        // @property (getter = isUpdatingGeofences, nonatomic) BOOL updatingGeofences;
        [Export ("updatingGeofences")]
        bool UpdatingGeofences { [Bind ("isUpdatingGeofences")] get; set; }

        // +(ETLocationManager *)locationManager;
        [Static]
        [Export ("locationManager")]
        ETLocationManager LocationManager { get; }

        // -(BOOL)locationEnabled;
        [Export ("locationEnabled")]
        bool LocationEnabled { get; }

        // -(void)startWatchingLocation;
        [Export ("startWatchingLocation")]
        void StartWatchingLocation ();

        // -(void)stopWatchingLocation;
        [Export ("stopWatchingLocation")]
        void StopWatchingLocation ();

        // -(void)appInForeground;
        [Export ("appInForeground")]
        void AppInForeground ();

        // -(void)appInBackground;
        [Export ("appInBackground")]
        void AppInBackground ();

        // -(void)updateLocationServerWithLocation:(CLLocation *)loc forAppState:(LocationUpdateAppState)state;
        [Export ("updateLocationServerWithLocation:forAppState:")]
        void UpdateLocationServerWithLocation (CLLocation loc, LocationUpdateAppState state);

        // -(void)monitorRegions:(NSSet *)fences;
        [Export ("monitorRegions:")]
        void MonitorRegions (NSSet fences);

        // -(void)stopMonitoringRegions;
        [Export ("stopMonitoringRegions")]
        void StopMonitoringRegions ();

        // -(void)getAndScheduleAlertsForRegion:(ETRegion *)region andMessageType:(MobilePushMessageType)type;
        [Export ("getAndScheduleAlertsForRegion:andMessageType:")]
        void GetAndScheduleAlertsForRegion (ETRegion region, MobilePushMessageType type);

        // -(NSSet *)monitoredRegions;
        [Export ("monitoredRegions")]
        NSSet MonitoredRegions { get; }

        // -(NSDictionary *)lastKnownLocation;
        [Export ("lastKnownLocation")]
        NSDictionary LastKnownLocation { get; }

        // -(BOOL)getWatchingLocation;
        [Export ("getWatchingLocation")]
        bool WatchingLocation { get; }
    }

    // @protocol ExactTargetOpenDirectDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface ExactTargetOpenDirectDelegate
    {
        // @required -(void)didReceiveOpenDirectMessageWithContents:(NSString *)payload;
        [Abstract]
        [Export ("didReceiveOpenDirectMessageWithContents:")]
        void DidReceiveOpenDirectMessageWithContents (string payload);

        // @optional -(BOOL)shouldDeliverOpenDirectMessageIfAppIsRunning;
        [Export ("shouldDeliverOpenDirectMessageIfAppIsRunning")]
        bool ShouldDeliverOpenDirectMessageIfAppIsRunning { get; }
    }

    // @interface ETPush : NSObject
    [BaseType (typeof(NSObject))]
    interface ETPush
    {
//        NSDate _sessionStart;
//
//        string _messageID;
//
//        bool _showLocalAlert;
//
//        ExactTargetOpenDirectDelegate _openDirectDelegate;

        // +(ETPush *)pushManager;
        [Static]
        [Export ("pushManager")]
        ETPush PushManager { get; }

        // -(void)configureSDKWithAppID:(NSString *)etAppID andAccessToken:(NSString *)accessToken;
        [Export ("configureSDKWithAppID:andAccessToken:")]
        void ConfigureSDKWithAppID (string etAppID, string accessToken);

        // -(void)configureSDKWithAppID:(NSString *)etAppID andAccessToken:(NSString *)accessToken withAnalytics:(BOOL)analyticsState andLocationServices:(BOOL)locState andCloudPages:(BOOL)cpState;
        [Export ("configureSDKWithAppID:andAccessToken:withAnalytics:andLocationServices:andCloudPages:")]
        void ConfigureSDKWithAppID (string etAppID, string accessToken, bool analyticsState, bool locState, bool cpState);

        // -(id<ExactTargetOpenDirectDelegate>)openDirectDelegate;
        // -(void)setOpenDirectDelegate:(id<ExactTargetOpenDirectDelegate>)delegate;
        [Export ("openDirectDelegate")]
        ExactTargetOpenDirectDelegate OpenDirectDelegate { get; set; }

        // -(void)updateET;
        [Export ("updateET")]
        void UpdateET ();

        // -(void)registerForRemoteNotifications;
        [Export ("registerForRemoteNotifications")]
        void RegisterForRemoteNotifications ();

        // -(BOOL)isRegisteredForRemoteNotifications;
        [Export ("isRegisteredForRemoteNotifications")]
        bool IsRegisteredForRemoteNotifications { get; }

        // -(void)registerUserNotificationSettings:(UIUserNotificationSettings *)notificationSettings;
        [Export ("registerUserNotificationSettings:")]
        void RegisterUserNotificationSettings (UIUserNotificationSettings notificationSettings);

        // -(UIUserNotificationSettings *)currentUserNotificationSettings;
        [Export ("currentUserNotificationSettings")]
        UIUserNotificationSettings CurrentUserNotificationSettings { get; }

        // -(void)didRegisterUserNotificationSettings:(UIUserNotificationSettings *)notificationSettings;
        [Export ("didRegisterUserNotificationSettings:")]
        void DidRegisterUserNotificationSettings (UIUserNotificationSettings notificationSettings);

        // -(void)registerDeviceToken:(NSData *)deviceToken;
        [Export ("registerDeviceToken:")]
        void RegisterDeviceToken (NSData deviceToken);

        // -(NSString *)deviceToken;
        [Export ("deviceToken")]
        string DeviceToken { get; }

        // -(void)applicationDidFailToRegisterForRemoteNotificationsWithError:(NSError *)error;
        [Export ("applicationDidFailToRegisterForRemoteNotificationsWithError:")]
        void ApplicationDidFailToRegisterForRemoteNotificationsWithError (NSError error);

        // -(void)resetBadgeCount;
        [Export ("resetBadgeCount")]
        void ResetBadgeCount ();

        // -(void)shouldDisplayAlertViewIfPushReceived:(BOOL)desiredState;
        [Export ("shouldDisplayAlertViewIfPushReceived:")]
        void ShouldDisplayAlertViewIfPushReceived (bool desiredState);

        // -(void)applicationLaunchedWithOptions:(NSDictionary *)launchOptions;
        [Export ("applicationLaunchedWithOptions:")]
        void ApplicationLaunchedWithOptions (NSDictionary launchOptions);

        // -(void)applicationTerminated;
        [Export ("applicationTerminated")]
        void ApplicationTerminated ();

        // -(void)handleNotification:(NSDictionary *)userInfo forApplicationState:(UIApplicationState)applicationState;
        [Export ("handleNotification:forApplicationState:")]
        void HandleNotification (NSDictionary userInfo, UIApplicationState applicationState);

        // -(void)handleLocalNotification:(UILocalNotification *)notification;
        [Export ("handleLocalNotification:")]
        void HandleLocalNotification (UILocalNotification notification);

        // -(void)setSubscriberKey:(NSString *)subscriberKey;
        [Export ("setSubscriberKey:")]
        void SetSubscriberKey (string subscriberKey);

        // -(NSString *)getSubscriberKey;
        [Export ("getSubscriberKey")]
        string SubscriberKey { get; }

        // -(void)addTag:(NSString *)tag;
        [Export ("addTag:")]
        void AddTag (string tag);

        // -(NSString *)removeTag:(NSString *)tag;
        [Export ("removeTag:")]
        string RemoveTag (string tag);

        // -(NSSet *)allTags;
        [Export ("allTags")]
        NSSet AllTags { get; }

        // -(void)addAttributeNamed:(NSString *)name value:(NSString *)value;
        [Export ("addAttributeNamed:value:")]
        void AddAttributeNamed (string name, string value);

        // -(NSString *)removeAttributeNamed:(NSString *)name;
        [Export ("removeAttributeNamed:")]
        string RemoveAttributeNamed (string name);

        // -(NSDictionary *)allAttributes;
        [Export ("allAttributes")]
        NSDictionary AllAttributes { get; }

        // +(NSString *)safeDeviceIdentifier;
        [Static]
        [Export ("safeDeviceIdentifier")]
        string SafeDeviceIdentifier { get; }

        // +(NSString *)hardwareIdentifier;
        [Static]
        [Export ("hardwareIdentifier")]
        string HardwareIdentifier { get; }

        // +(BOOL)isPushEnabled;
        [Static]
        [Export ("isPushEnabled")]
        bool IsPushEnabled { get; }

        // -(void)startListeningForApplicationNotifications;
        [Export ("startListeningForApplicationNotifications")]
        void StartListeningForApplicationNotifications ();

        // -(void)stopListeningForApplicationNotifications;
        [Export ("stopListeningForApplicationNotifications")]
        void StopListeningForApplicationNotifications ();

        // -(void)applicationDidBecomeActiveNotificationReceived;
        [Export ("applicationDidBecomeActiveNotificationReceived")]
        void ApplicationDidBecomeActiveNotificationReceived ();

        // -(void)applicationDidEnterBackgroundNotificationReceived;
        [Export ("applicationDidEnterBackgroundNotificationReceived")]
        void ApplicationDidEnterBackgroundNotificationReceived ();

        // +(void)setETLoggerToRequiredState:(BOOL)state;
        [Static]
        [Export ("setETLoggerToRequiredState:")]
        void SetETLoggerToRequiredState (bool state);

        // +(void)ETLogger:(NSString *)stringToBeLogged;
        [Static]
        [Export ("ETLogger:")]
        void ETLogger (string stringToBeLogged);
    }

    // @interface ETPhoneHome : NSObject <NSURLConnectionDataDelegate>
    //[BaseType(typeof(NSUrlConnectionDelegate), Delegates = new[] { "Delegate" }, Events = new[] { typeof(NSUrlConnectionDataDelegate) })]
//    [DisableDefaultCtor]
    [BaseType(typeof(NSUrlConnectionDelegate))]
    interface ETPhoneHome
    {
        // -(NSTimeInterval)phoneHomeTest:(void (^)(int))callBackBlock;
        [Export ("phoneHomeTest:")]
        double PhoneHomeTest (Action<int> callBackBlock);

        // +(ETPhoneHome *)magicBicycle;
        [Static]
        [Export ("magicBicycle")]
        ETPhoneHome MagicBicycle { get; }

        // -(BOOL)phoneHome:(ETGenericUpdate *)updateObject;
        [Export ("phoneHome:")]
        bool PhoneHome (ETGenericUpdate updateObject);

        // -(BOOL)phoneHomeInBulkForGenericUpdateType:(Class)updateClass;
        [Export ("phoneHomeInBulkForGenericUpdateType:")]
        bool PhoneHomeInBulkForGenericUpdateType (Class updateClass);

        // -(BOOL)saveToDatabaseInstead:(ETGenericUpdate *)updateObject;
        [Export ("saveToDatabaseInstead:")]
        bool SaveToDatabaseInstead (ETGenericUpdate updateObject);

        // -(void)checkForAndSendBackCachedData;
        [Export ("checkForAndSendBackCachedData")]
        void CheckForAndSendBackCachedData ();

        // -(int)getNumberOfActiveConnections;
        [Export ("getNumberOfActiveConnections")]
        int NumberOfActiveConnections { get; }
    }

}

