using Foundation;

namespace KissMetrics.iOS.Binding
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

  [BaseType(typeof(NSObject))]
  interface KISSmetricsAPI
  {
    // +(KISSmetricsAPI *)sharedAPIWithKey:(NSString *)apiKey;
    [Static]
    [Export("sharedAPIWithKey:")]
    KISSmetricsAPI SharedAPIWithKey(string apiKey);

    // +(KISSmetricsAPI *)sharedAPI;
    [Static]
    [Export("sharedAPI")]
    //[Verify (MethodToProperty)]
    KISSmetricsAPI SharedAPI { get; }

    // -(void)identify:(NSString *)identity;
    [Export("identify:")]
    void Identify(string identity);

    // -(NSString *)identity;
    [Export("identity")]
    //[Verify (MethodToProperty)]
    string Identity { get; }

    // -(void)clearIdentity;
    [Export("clearIdentity")]
    void ClearIdentity();

    // -(void)alias:(NSString *)firstIdentity withIdentity:(NSString *)secondIdentity;
    [Export("alias:withIdentity:")]
    void Alias(string firstIdentity, string secondIdentity);

    // -(void)record:(NSString *)eventName withProperties:(NSDictionary *)properties;
    [Export("record:withProperties:")]
    void Record(string eventName, NSDictionary properties);

    // -(void)record:(NSString *)eventName;
    [Export("record:")]
    void Record(string eventName);

    // -(void)recordEvent:(NSString *)eventName withProperties:(NSDictionary *)properties __attribute__((deprecated("use method record:withProperties: instead")));
    [Export("recordEvent:withProperties:")]
    void RecordEvent(string eventName, NSDictionary properties);

    // -(void)record:(NSString *)eventName withProperties:(NSDictionary *)properties onCondition:(KMARecordCondition)condition;
    [Export("record:withProperties:onCondition:")]
    void Record(string eventName, NSDictionary properties, KMARecordCondition condition);

    // -(void)record:(NSString *)eventName onCondition:(KMARecordCondition)condition;
    [Export("record:onCondition:")]
    void Record(string eventName, KMARecordCondition condition);

    // -(void)recordOnce:(NSString *)eventName __attribute__((deprecated("use method record:onCondition: instead")));
    [Export("recordOnce:")]
    void RecordOnce(string eventName);

    // -(void)set:(NSDictionary *)properties;
    [Export("set:")]
    void Set(NSDictionary properties);

    // -(void)setProperties:(NSDictionary *)properties __attribute__((deprecated("use method set: instead")));
    [Export("setProperties:")]
    void SetProperties(NSDictionary properties);

    // -(void)setDistinct:(NSObject *)propertyValue forKey:(NSString *)propertyKey;
    [Export("setDistinct:forKey:")]
    void SetDistinct(NSObject propertyValue, string propertyKey);

    // -(void)autoRecordAppLifecycle;
    [Export("autoRecordAppLifecycle")]
    void AutoRecordAppLifecycle();

    // -(void)autoRecordInstalls;
    [Export("autoRecordInstalls")]
    void AutoRecordInstalls();

    // -(void)autoSetHardwareProperties;
    [Export("autoSetHardwareProperties")]
    void AutoSetHardwareProperties();

    // -(void)autoSetAppProperties;
    [Export("autoSetAppProperties")]
    void AutoSetAppProperties();
  }
}