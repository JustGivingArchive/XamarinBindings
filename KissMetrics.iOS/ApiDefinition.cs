using Foundation;

namespace KissMetricsiOS
{
    [BaseType (typeof (NSObject))]
    interface KISSmetricsAPI {
        [Static, Export ("sharedAPIWithKey:")]
        KISSmetricsAPI SharedAPIWithKey (string apiKey);

        [Static, Export ("sharedAPI")]
        KISSmetricsAPI SharedAPI { get; }

        [Export ("identify:")]
        void Identify (string identity);

        [Export ("identity")]
        string Identity { get; }

        [Export ("clearIdentity")]
        void ClearIdentity ();

        [Export ("alias:withIdentity:")]
        void Alias (string firstIdentity, string secondIdentity);

        [Export ("record:")]
        void Record (string name);

        [Export ("record:withProperties:")]
        void Record (string name, NSDictionary properties);

        [Export ("recordEvent:withProperties:")]
        void RecordEvent (string name, NSDictionary properties);

        [Export ("recordOnce:")]
        void RecordOnce (string name);

        [Export ("properties")]
        NSDictionary Properties { set; }

        [Export ("setDistinct:forKey:")]
        void SetDistinct (NSObject propertyValue, string propertyKey);

        [Export ("autoRecordAppLifecycle")]
        void AutoRecordAppLifecycle ();

        [Export ("autoRecordInstalls")]
        void AutoRecordInstalls ();

        [Export ("autoSetHardwareProperties")]
        void AutoSetHardwareProperties ();

        [Export ("autoSetAppProperties")]
        void AutoSetAppProperties ();
    }
}