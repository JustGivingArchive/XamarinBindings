using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace OptimizelyiOS
{
  // @interface OptimizelyCodeBlocksKey : NSObject
  [BaseType(typeof(NSObject))]
  interface OptimizelyCodeBlocksKey
  {
    // @property (readonly) NSString * key;
    [Export("key")]
    string Key { get; }

    // @property (readonly) NSArray * blockNames;
    [Export("blockNames")]
    //[Verify (StronglyTypedNSArray)] //TODO: Verify
    NSObject[] BlockNames { get; }

    //commented out based on the following comment in OptimizelyCodeBlocksKey.h file:
    // Can be used to define an OptimizelyCodeBlocksKey inline
    // In general, this should not be called directly -- we recommend using OptimizelyCodeBlocksKeyWithBlockNames macro

    // +(OptimizelyCodeBlocksKey *)optimizelyCodeBlocksKey:(NSString *)key blockNames:(NSArray *)blockNames;
    [Static]
    [Export("optimizelyCodeBlocksKey:blockNames:")]
    //[Verify(StronglyTypedNSArray)]
    OptimizelyCodeBlocksKey OptimizelyCodeBlocksKeyS(string key, NSObject[] blockNames);
  }

  // @interface OptimizelyExperimentData : NSObject
  [BaseType(typeof(NSObject))]
  interface OptimizelyExperimentData
  {
    // @property (readonly, nonatomic, strong) NSString * audiences;
    [Export("audiences", ArgumentSemantic.Strong)]
    string Audiences { get; }

    // @property (readonly, nonatomic, strong) NSString * experimentId;
    [Export("experimentId", ArgumentSemantic.Strong)]
    string ExperimentId { get; }

    // @property (readonly, nonatomic, strong) NSString * experimentName;
    [Export("experimentName", ArgumentSemantic.Strong)]
    string ExperimentName { get; }

    // @property (readonly, nonatomic) BOOL locked;
    [Export("locked")]
    bool Locked { get; }

    // @property (readonly) OptimizelyExperimentDataState state;
    [Export("state")]
    OptimizelyExperimentDataState State { get; }

    // @property (readonly, nonatomic, strong) NSString * targetingConditions;
    [Export("targetingConditions", ArgumentSemantic.Strong)]
    string TargetingConditions { get; }

    // @property (readonly, nonatomic) BOOL targetingMet;
    [Export("targetingMet")]
    bool TargetingMet { get; }

    // @property (readonly, nonatomic, strong) NSString * variationId;
    [Export("variationId", ArgumentSemantic.Strong)]
    string VariationId { get; }

    // @property (readonly, nonatomic, strong) NSString * variationName;
    [Export("variationName", ArgumentSemantic.Strong)]
    string VariationName { get; }

    // @property (readonly, nonatomic) NSUInteger visitedCount;
    [Export("visitedCount")]
    nuint VisitedCount { get; }

    // @property (readonly, nonatomic) BOOL visitedEver;
    [Export("visitedEver")]
    bool VisitedEver { get; }

    // @property (readonly, nonatomic) BOOL visitedThisSession;
    [Export("visitedThisSession")]
    bool VisitedThisSession { get; }
  }

  // @interface OptimizelyVariableKey : NSObject
  [BaseType(typeof(NSObject))]
  interface OptimizelyVariableKey
  {
    // @property (readonly) NSString * key;
    [Export("key")]
    string Key { get; }

    // @property (readonly) id defaultValue;
    [Export("defaultValue")]
    NSObject DefaultValue { get; }

    // @property (readonly) NSString * type;
    [Export("type")]
    string Type { get; }

    // +(OptimizelyVariableKey *)optimizelyKeyWithKey:(NSString *)key defaultNSString:(NSString *)defaultValue;
    [Static]
    [Export("optimizelyKeyWithKey:defaultNSString:")]
    OptimizelyVariableKey OptimizelyKeyWithKey(string key, string defaultValue);

    // +(OptimizelyVariableKey *)optimizelyKeyWithKey:(NSString *)key defaultUIColor:(UIColor *)defaultValue;
    [Static]
    [Export("optimizelyKeyWithKey:defaultUIColor:")]
    OptimizelyVariableKey OptimizelyKeyWithKey(string key, UIColor defaultValue);

    // +(OptimizelyVariableKey *)optimizelyKeyWithKey:(NSString *)key defaultNSNumber:(NSNumber *)defaultValue;
    [Static]
    [Export("optimizelyKeyWithKey:defaultNSNumber:")]
    OptimizelyVariableKey OptimizelyKeyWithKey(string key, NSNumber defaultValue);

    // +(OptimizelyVariableKey *)optimizelyKeyWithKey:(NSString *)key defaultCGPoint:(CGPoint)defaultValue;
    [Static]
    [Export("optimizelyKeyWithKey:defaultCGPoint:")]
    OptimizelyVariableKey OptimizelyKeyWithKey(string key, CGPoint defaultValue);

    // +(OptimizelyVariableKey *)optimizelyKeyWithKey:(NSString *)key defaultCGSize:(CGSize)defaultValue;
    [Static]
    [Export("optimizelyKeyWithKey:defaultCGSize:")]
    OptimizelyVariableKey OptimizelyKeyWithKey(string key, CGSize defaultValue);

    // +(OptimizelyVariableKey *)optimizelyKeyWithKey:(NSString *)key defaultCGRect:(CGRect)defaultValue;
    [Static]
    [Export("optimizelyKeyWithKey:defaultCGRect:")]
    OptimizelyVariableKey OptimizelyKeyWithKey(string key, CGRect defaultValue);

    // +(OptimizelyVariableKey *)optimizelyKeyWithKey:(NSString *)key defaultBOOL:(BOOL)defaultValue;
    [Static]
    [Export("optimizelyKeyWithKey:defaultBOOL:")]
    OptimizelyVariableKey OptimizelyKeyWithKey(string key, bool defaultValue);

    // -(BOOL)isEqualToOptimizelyVariableKey:(OptimizelyVariableKey *)key;
    [Export("isEqualToOptimizelyVariableKey:")]
    bool IsEqualToOptimizelyVariableKey(OptimizelyVariableKey key);
  }

  // typedef void (^OptimizelySuccessBlock)(BOOLNSError *);
  delegate void OptimizelySuccessBlock(bool arg0,NSError arg1);

  // @interface Optimizely (UIView)
  [Category]
  [BaseType(typeof(UIView))]
  interface UIView_Optimizely
  {
    // @property (nonatomic, strong) NSString * optimizelyId;
    [Export("optimizelyId", ArgumentSemantic.Strong)]
    string GetOptimizelyId();
  }

  // @interface Optimizely : NSObject
  [BaseType(typeof(NSObject))]
  interface Optimizely
  {
    // +(instancetype)sharedInstance;
    [Static]
    [Export("sharedInstance")]
    Optimizely SharedInstance();

    // +(void)startOptimizelyWithAPIToken:(NSString *)apiToken launchOptions:(NSDictionary *)launchOptions;
    [Static]
    [Export("startOptimizelyWithAPIToken:launchOptions:")]
    void StartOptimizelyWithAPIToken(string apiToken, NSDictionary launchOptions);

    // +(void)startOptimizelyWithAPIToken:(NSString *)apiToken launchOptions:(NSDictionary *)launchOptions experimentsLoadedCallback:(OptimizelySuccessBlock)experimentsLoadedCallback;
    [Static]
    [Export("startOptimizelyWithAPIToken:launchOptions:experimentsLoadedCallback:")]
    void StartOptimizelyWithAPIToken(string apiToken, NSDictionary launchOptions, OptimizelySuccessBlock experimentsLoadedCallback);

    // +(void)setValue:(NSString *)tagValue forCustomTag:(NSString *)tagKey;
    [Static]
    [Export("setValue:forCustomTag:")]
    void SetValue(string tagValue, string tagKey);

    // +(BOOL)handleOpenURL:(NSURL *)url;
    [Static]
    [Export("handleOpenURL:")]
    bool HandleOpenURL(NSUrl url);

    // +(void)enableEditor;
    [Static]
    [Export("enableEditor")]
    void EnableEditor();

    // +(void)disableSwizzle;
    [Static]
    [Export("disableSwizzle")]
    void DisableSwizzle();

    // +(void)enableGestureInAppStoreApp;
    [Static]
    [Export("enableGestureInAppStoreApp")]
    void EnableGestureInAppStoreApp();

    // +(void)dispatch;
    [Static]
    [Export("dispatch")]
    void Dispatch();

    // +(void)dispatchEvents;
    [Static]
    [Export("dispatchEvents")]
    void DispatchEvents();

    // +(void)fetchNewDataFile;
    [Static]
    [Export("fetchNewDataFile")]
    void FetchNewDataFile();

    // +(void)trackEvent:(NSString *)description;
    [Static]
    [Export("trackEvent:")]
    void TrackEvent(string description);

    // +(void)trackRevenue:(int)revenueAmount;
    [Static]
    [Export("trackRevenue:")]
    void TrackRevenue(int revenueAmount);

    // +(void)registerCallbackForVariableWithKey:(OptimizelyVariableKey *)key callback:(void (^)(NSString *, id))callback;
    [Static]
    [Export("registerCallbackForVariableWithKey:callback:")]
    void RegisterCallbackForVariableWithKey(OptimizelyVariableKey key, Action<NSString, NSObject> callback);

    // +(void)refreshExperiments;
    [Static]
    [Export("refreshExperiments")]
    void RefreshExperiments();

    // +(NSString *)stringForKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("stringForKey:")]
    string StringForKey(OptimizelyVariableKey key);

    // +(UIColor *)colorForKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("colorForKey:")]
    UIColor ColorForKey(OptimizelyVariableKey key);

    // +(NSNumber *)numberForKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("numberForKey:")]
    NSNumber NumberForKey(OptimizelyVariableKey key);

    // +(CGPoint)pointForKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("pointForKey:")]
    CGPoint PointForKey(OptimizelyVariableKey key);

    // +(CGSize)sizeForKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("sizeForKey:")]
    CGSize SizeForKey(OptimizelyVariableKey key);

    // +(CGRect)rectForKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("rectForKey:")]
    CGRect RectForKey(OptimizelyVariableKey key);

    // +(BOOL)boolForKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("boolForKey:")]
    bool BoolForKey(OptimizelyVariableKey key);

    // +(void)codeBlocksWithKey:(OptimizelyCodeBlocksKey *)codeBlocksKey blockOne:(void (^)(void))blockOne defaultBlock:(void (^)(void))defaultBlock;
    [Static]
    [Export("codeBlocksWithKey:blockOne:defaultBlock:")]
    void CodeBlocksWithKey(OptimizelyCodeBlocksKey codeBlocksKey, Action blockOne, Action defaultBlock);

    // +(void)codeBlocksWithKey:(OptimizelyCodeBlocksKey *)codeBlocksKey blockOne:(void (^)(void))blockOne blockTwo:(void (^)(void))blockTwo defaultBlock:(void (^)(void))defaultBlock;
    [Static]
    [Export("codeBlocksWithKey:blockOne:blockTwo:defaultBlock:")]
    void CodeBlocksWithKey(OptimizelyCodeBlocksKey codeBlocksKey, Action blockOne, Action blockTwo, Action defaultBlock);

    // +(void)codeBlocksWithKey:(OptimizelyCodeBlocksKey *)codeBlocksKey blockOne:(void (^)(void))blockOne blockTwo:(void (^)(void))blockTwo blockThree:(void (^)(void))blockThree defaultBlock:(void (^)(void))defaultBlock;
    [Static]
    [Export("codeBlocksWithKey:blockOne:blockTwo:blockThree:defaultBlock:")]
    void CodeBlocksWithKey(OptimizelyCodeBlocksKey codeBlocksKey, Action blockOne, Action blockTwo, Action blockThree, Action defaultBlock);

    // +(void)codeBlocksWithKey:(OptimizelyCodeBlocksKey *)codeBlocksKey blockOne:(void (^)(void))blockOne blockTwo:(void (^)(void))blockTwo blockThree:(void (^)(void))blockThree blockFour:(void (^)(void))blockFour defaultBlock:(void (^)(void))defaultBlock;
    [Static]
    [Export("codeBlocksWithKey:blockOne:blockTwo:blockThree:blockFour:defaultBlock:")]
    void CodeBlocksWithKey(OptimizelyCodeBlocksKey codeBlocksKey, Action blockOne, Action blockTwo, Action blockThree, Action blockFour, Action defaultBlock);

    // +(void)preregisterVariableKey:(OptimizelyVariableKey *)key;
    [Static]
    [Export("preregisterVariableKey:")]
    void PreregisterVariableKey(OptimizelyVariableKey key);

    // +(void)preregisterBlockKey:(OptimizelyCodeBlocksKey *)key;
    [Static]
    [Export("preregisterBlockKey:")]
    void PreregisterBlockKey(OptimizelyCodeBlocksKey key);

    // +(void)ignoreUIViewSubclassesWithNames:(NSSet *)viewSubclassesToIgnoreForTagging;
    [Static]
    [Export("ignoreUIViewSubclassesWithNames:")]
    void IgnoreUIViewSubclassesWithNames(NSSet viewSubclassesToIgnoreForTagging);

    // @property (readonly, nonatomic, strong) NSArray * activeExperiments;
    [Export("activeExperiments", ArgumentSemantic.Strong)]
    OptimizelyExperimentData[] ActiveExperiments { get; }

    // @property (readonly, nonatomic, strong) NSArray * allExperiments;
    [Export("allExperiments", ArgumentSemantic.Strong)]
    OptimizelyExperimentData[] AllExperiments { get; }

    // @property (readonly, nonatomic, strong) NSArray * visitedExperiments;
    [Export("visitedExperiments", ArgumentSemantic.Strong)]
    OptimizelyExperimentData[] VisitedExperiments { get; }

    // @property (nonatomic) BOOL shouldNotGenerateDynamicIds;
    [Export("shouldNotGenerateDynamicIds")]
    bool ShouldNotGenerateDynamicIds { get; set; }

    // @property (readonly, strong) NSString * projectId;
    [Export("projectId", ArgumentSemantic.Strong)]
    string ProjectId { get; }

    // @property (readonly, strong) NSString * sdkVersion;
    [Export("sdkVersion", ArgumentSemantic.Strong)]
    string SdkVersion { get; }

    // @property (nonatomic, strong) NSString * userId;
    [Export("userId", ArgumentSemantic.Strong)]
    string UserId { get; set; }

    // @property (readwrite, nonatomic) BOOL verboseLogging;
    [Export("verboseLogging")]
    bool VerboseLogging { get; set; }

    // @property (readwrite, nonatomic) NSTimeInterval dispatchInterval;
    [Export("dispatchInterval")]
    double DispatchInterval { get; set; }

    // @property (readwrite, nonatomic) NSTimeInterval networkTimeout;
    [Export("networkTimeout")]
    double NetworkTimeout { get; set; }

    // @property (readwrite, nonatomic) BOOL shouldReloadExperimentsOnForegrounding;
    [Export("shouldReloadExperimentsOnForegrounding")]
    bool ShouldReloadExperimentsOnForegrounding { get; set; }

    // @property (readwrite, nonatomic) BOOL disableGesture;
    [Export("disableGesture")]
    bool DisableGesture { get; set; }

    // +(void)activateMixpanelIntegration;
    [Static]
    [Export("activateMixpanelIntegration")]
    void ActivateMixpanelIntegration();

    // +(void)activateAmplitudeIntegration;
    [Static]
    [Export("activateAmplitudeIntegration")]
    void ActivateAmplitudeIntegration();

    // -(void)codeTest:(NSString *)codeTestKey withBlocks:(NSDictionary *)blocks defaultBlock:(void (^)(void))defaultBlock __attribute__((deprecated("Use [Optimizely codeTestWithKey: blockOne:...]")));
    [Export("codeTest:withBlocks:defaultBlock:")]
    void CodeTest(string codeTestKey, NSDictionary blocks, Action defaultBlock);

    // extern NSString *const OptimizelyExperimentVisitedNotification;
    [Field("OptimizelyExperimentVisitedNotification", "__Internal")]
    NSString OptimizelyExperimentVisitedNotification { get; }

    // extern NSString *const OptimizelyNewDataFileLoadedNotification;
    [Field("OptimizelyNewDataFileLoadedNotification", "__Internal")]
    NSString OptimizelyNewDataFileLoadedNotification { get; }

    // extern NSString *const OptimizelyGoalTriggeredNotification;
    [Field("OptimizelyGoalTriggeredNotification", "__Internal")]
    NSString OptimizelyGoalTriggeredNotification { get; }
  }

  //[Verify (ConstantsInterfaceAssociation)] //TODO Verify/Refactor
  interface Constants
  {
    // extern NSString *const OptimizelyExperimentVisitedNotification;
    [Field("OptimizelyExperimentVisitedNotification")]
    NSString OptimizelyExperimentVisitedNotification { get; }

    // extern NSString *const OptimizelyNewDataFileLoadedNotification;
    [Field("OptimizelyNewDataFileLoadedNotification")]
    NSString OptimizelyNewDataFileLoadedNotification { get; }

    // extern NSString *const OptimizelyGoalTriggeredNotification;
    [Field("OptimizelyGoalTriggeredNotification")]
    NSString OptimizelyGoalTriggeredNotification { get; }
  }
}