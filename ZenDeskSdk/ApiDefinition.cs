using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace ZenDeskSdk
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
    // For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
    //

    // @interface ZDKAccount : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKAccount {

        // @property (nonatomic, strong) NSString * zendeskUrl;
        [Export ("zendeskUrl", ArgumentSemantic.Retain)]
        string ZendeskUrl { get; set; }

        // @property (nonatomic, strong) NSString * applicationId;
        [Export ("applicationId", ArgumentSemantic.Retain)]
        string ApplicationId { get; set; }

        // @property (nonatomic, strong) NSString * oAuthClientId;
        [Export ("oAuthClientId", ArgumentSemantic.Retain)]
        string OAuthClientId { get; set; }

        // @property (nonatomic, strong) NSString * oauthToken;
        [Export ("oauthToken", ArgumentSemantic.Retain)]
        string OauthToken { get; set; }

        // @property (assign) ZDKAccountState state;
        [Export ("state", ArgumentSemantic.UnsafeUnretained)]
        ZDKAccountState State { get; set; }
    }

    // @interface ZDKCoding : NSObject <NSCoding>
    [BaseType (typeof (NSObject))]
    interface ZDKCoding : INSCoding {

    }

    // @interface ZDKAccountSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKAccountSettings {

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) ZDKAttachmentSettings * attachmentSettings;
        [Export ("attachmentSettings")]
        ZDKAttachmentSettings AttachmentSettings { get; }
    }

    // @protocol ZDKIdentity
    [Protocol, Model]
    interface ZDKIdentity {

        // @required -(NSDictionary *)toJson;
        [Export ("toJson")]
        [Abstract]
        NSDictionary ToJson ();
    }

    // @interface ZDKAnonymousIdentity : ZDKCoding <ZDKIdentity>
    [BaseType (typeof (ZDKCoding))]
    interface ZDKAnonymousIdentity : ZDKIdentity {

        // @property (nonatomic, strong) NSString * name;
        [Export ("name", ArgumentSemantic.Retain)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * email;
        [Export ("email", ArgumentSemantic.Retain)]
        string Email { get; set; }

        // @property (nonatomic, strong) NSString * externalId;
        [Export ("externalId", ArgumentSemantic.Retain)]
        string ExternalId { get; set; }
    }

    // @interface ZDKDeviceInfo : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKDeviceInfo {

        // +(NSString *)deviceType;
        [Static, Export ("deviceType")]
        string DeviceType ();

        // +(double)totalDeviceMemory;
        [Static, Export ("totalDeviceMemory")]
        double TotalDeviceMemory ();

        // +(double)freeDiskspace;
        [Static, Export ("freeDiskspace")]
        double FreeDiskspace ();

        // +(double)totalDiskspace;
        [Static, Export ("totalDiskspace")]
        double TotalDiskspace ();

        // +(CGFloat)batteryLevel;
        [Static, Export ("batteryLevel")]
        nfloat BatteryLevel ();

        // +(NSString *)region;
        [Static, Export ("region")]
        string Region ();

        // +(NSString *)language;
        [Static, Export ("language")]
        string Language ();

        // +(NSString *)deviceInfoString;
        [Static, Export ("deviceInfoString")]
        string DeviceInfoString ();

        // +(NSDictionary *)deviceInfoDictionary;
        [Static, Export ("deviceInfoDictionary")]
        NSDictionary DeviceInfoDictionary ();
    }

    // @interface ZDKDispatcherResponse : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKDispatcherResponse {

        // -(instancetype)initWithResponse:(NSHTTPURLResponse *)response andData:(NSData *)data;
        [Export ("initWithResponse:andData:")]
        IntPtr Constructor (NSHttpUrlResponse response, NSData data);

        // @property (nonatomic, strong) NSHTTPURLResponse * response;
        [Export ("response", ArgumentSemantic.Retain)]
        NSHttpUrlResponse Response { get; set; }

        // @property (nonatomic, strong) NSData * data;
        [Export ("data", ArgumentSemantic.Retain)]
        NSData Data { get; set; }
    }

    // @protocol ZDKDispatcherDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKDispatcherDelegate {

        // @required -(BOOL)validAccount:(BOOL)authRequired;
        [Export ("validAccount:")]
        [Abstract]
        bool ValidAccount (bool authRequired);

        // @required -(NSError *)accountError;
        [Export ("accountError")]
        [Abstract]
        NSError AccountError ();

        // @optional -(BOOL)needToLogin;
        [Export ("needToLogin")]
        bool NeedToLogin ();

        // @optional -(NSMutableURLRequest *)createLoginRequest;
        [Export ("createLoginRequest")]
        NSMutableUrlRequest CreateLoginRequest ();

        // @optional -(BOOL)handleLoginResponse:(ZDKDispatcherResponse *)responseData;
        [Export ("handleLoginResponse:")]
        bool HandleLoginResponse (ZDKDispatcherResponse responseData);

        // @optional -(void)addAuthToRequest:(NSMutableURLRequest *)request;
        [Export ("addAuthToRequest:")]
        void AddAuthToRequest (NSMutableUrlRequest request);

        // @optional -(void)invalidateToken;
        [Export ("invalidateToken")]
        void InvalidateToken ();

        // @optional -(void)invalidateIdentity;
        [Export ("invalidateIdentity")]
        void InvalidateIdentity ();
    }

    // @interface ZDKDispatcher : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKDispatcher {

        // @property (nonatomic, weak) id<ZDKDispatcherDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.Weak)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, weak) id<ZDKDispatcherDelegate> delegate;
        [Wrap ("WeakDelegate")]
        ZDKDispatcherDelegate Delegate { get; set; }

        // +(void)setDebugLogging:(BOOL)enabled;
        [Static, Export ("setDebugLogging:")]
        void SetDebugLogging (bool enabled);

        // -(void)executeRequest:(NSMutableURLRequest *(^)(void))requestBlock onSuccess:(ZDKAPISuccess)successBlock onError:(ZDKAPIError)errorBlock requiresAuth:(BOOL)requiresAuth;
        [Export ("executeRequest:onSuccess:onError:requiresAuth:")]
        void ExecuteRequest (Func<NSMutableUrlRequest> requestBlock, Action<NSObject> successBlock, Action<NSError> errorBlock, bool requiresAuth);
    }

    // @interface ZDKRequest : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRequest {

        // -(instancetype)initWithDict:(NSDictionary *)dict;
        [Export ("initWithDict:")]
        IntPtr Constructor (NSDictionary dict);

        // @property (nonatomic, strong) NSString * requestId;
        [Export ("requestId", ArgumentSemantic.Retain)]
        string RequestId { get; set; }

        // @property (nonatomic, strong) NSNumber * requesterId;
        [Export ("requesterId", ArgumentSemantic.Retain)]
        NSNumber RequesterId { get; set; }

        // @property (nonatomic, strong) NSString * status;
        [Export ("status", ArgumentSemantic.Retain)]
        string Status { get; set; }

        // @property (nonatomic, strong) NSString * subject;
        [Export ("subject", ArgumentSemantic.Retain)]
        string Subject { get; set; }

        // @property (nonatomic, strong) NSString * requestDescription;
        [Export ("requestDescription", ArgumentSemantic.Retain)]
        string RequestDescription { get; set; }

        // @property (nonatomic, strong) NSDate * createdAt;
        [Export ("createdAt", ArgumentSemantic.Retain)]
        NSDate CreatedAt { get; set; }

        // @property (nonatomic, strong) NSDate * updateAt;
        [Export ("updateAt", ArgumentSemantic.Retain)]
        NSDate UpdateAt { get; set; }

        // @property (nonatomic, strong) NSDate * publicUpdatedAt;
        [Export ("publicUpdatedAt", ArgumentSemantic.Retain)]
        NSDate PublicUpdatedAt { get; set; }

        // @property (nonatomic, strong) NSDate * lastViewed;
        [Export ("lastViewed", ArgumentSemantic.Retain)]
        NSDate LastViewed { get; set; }
    }

    // @interface ZDKComment : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKComment {

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) NSNumber * commentId;
        [Export ("commentId")]
        NSNumber CommentId { get; }

        // @property (nonatomic, strong) NSString * body;
        [Export ("body", ArgumentSemantic.Retain)]
        string Body { get; set; }

        // @property (nonatomic, strong) NSNumber * authorId;
        [Export ("authorId", ArgumentSemantic.Retain)]
        NSNumber AuthorId { get; set; }

        // @property (nonatomic, strong) NSDate * createdAt;
        [Export ("createdAt", ArgumentSemantic.Retain)]
        NSDate CreatedAt { get; set; }

        // @property (nonatomic, strong) NSArray * attachments;
        [Export ("attachments", ArgumentSemantic.Retain)]
        NSObject [] Attachments { get; set; }
    }

    // @interface ZDKAPIDispatcher : ZDKDispatcher <ZDKDispatcherDelegate>
    [BaseType (typeof (ZDKDispatcher))]
    interface ZDKAPIDispatcher : ZDKDispatcherDelegate {

        // +(instancetype)instance;
        [Static, Export ("instance")]
        ZDKAPIDispatcher Instance ();

        // +(NSMutableDictionary *)getSharedHeaders;
        [Static, Export ("getSharedHeaders")]
        NSMutableDictionary GetSharedHeaders ();
    }

    // @interface ZDKAppSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKAppSettings {

        // -(id)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) ZDKRateMyAppSettings * rateMyAappSettings;
        [Export ("rateMyAappSettings")]
        ZDKRateMyAppSettings RateMyAappSettings { get; }

        // @property (readonly, nonatomic) ZDKConversationsSettings * conversationsSettings;
        [Export ("conversationsSettings")]
        ZDKConversationsSettings ConversationsSettings { get; }

        // @property (readonly, nonatomic) ZDKContactUsSettings * contactUsSettings;
        [Export ("contactUsSettings")]
        ZDKContactUsSettings ContactUsSettings { get; }

        // @property (readonly, nonatomic) ZDKHelpCenterSettings * helpCenterSettings;
        [Export ("helpCenterSettings")]
        ZDKHelpCenterSettings HelpCenterSettings { get; }

        // @property (readonly, nonatomic) NSString * authentication;
        [Export ("authentication")]
        string Authentication { get; }
    }

    // @interface ZDKArticleView : UIView
    [BaseType (typeof (UIView))]
    interface ZDKArticleView {

        // -(instancetype)initWithArticle:(ZDKHelpCenterArticle *)article;
        [Export ("initWithArticle:")]
        IntPtr Constructor (ZDKHelpCenterArticle article);

        // @property (nonatomic, strong) UIScrollView * article;
        [Export ("article", ArgumentSemantic.Retain)]
        UIScrollView Article { get; set; }

        // @property (nonatomic, strong) UIWebView * articleWebView;
        [Export ("articleWebView", ArgumentSemantic.Retain)]
        UIWebView ArticleWebView { get; set; }

        // @property (nonatomic, strong) UITableView * attachments;
        [Export ("attachments", ArgumentSemantic.Retain)]
        UITableView Attachments { get; set; }

        // @property (readonly, assign, nonatomic, getter = isLoading) BOOL loading;
        [Export ("loading", ArgumentSemantic.UnsafeUnretained)]
        bool Loading { [Bind ("isLoading")] get; }

        // -(void)reloadArticleForRotation;
        [Export ("reloadArticleForRotation")]
        void ReloadArticleForRotation ();
    }

    // @interface ZDKUIViewController : UIViewController
    [BaseType (typeof (UIViewController))]
    interface ZDKUIViewController {

        // @property (assign, nonatomic) ZDKLayoutGuide layoutGuide;
        [Export ("layoutGuide", ArgumentSemantic.UnsafeUnretained)]
        ZDKLayoutGuide LayoutGuide { get; set; }

        // @property (assign, nonatomic) BOOL requiresNavBar;
        [Export ("requiresNavBar", ArgumentSemantic.UnsafeUnretained)]
        bool RequiresNavBar { get; set; }

        // @property (nonatomic, strong) UIView * contentView;
        [Export ("contentView", ArgumentSemantic.Retain)]
        UIView ContentView { get; set; }

        // @property (nonatomic, strong) ZDKToastView * toastView;
        [Export ("toastView", ArgumentSemantic.Retain)]
        ZDKToastView ToastView { get; set; }

        // @property (readonly, nonatomic, strong) ZDKReachability * reachable;
        [Export ("reachable", ArgumentSemantic.Retain)]
        ZDKReachability Reachable { get; }

        // -(void)registerForKeyboardNotifications;
        [Export ("registerForKeyboardNotifications")]
        void RegisterForKeyboardNotifications ();

        // -(void)keyboardWillBeShown:(NSNotification *)aNotification;
        [Export ("keyboardWillBeShown:")]
        void KeyboardWillBeShown (NSNotification aNotification);

        // -(void)keyboardDidShow:(NSNotification *)aNotification;
        [Export ("keyboardDidShow:")]
        void KeyboardDidShow (NSNotification aNotification);

        // -(void)keyboardWillBeHidden:(NSNotification *)aNotification;
        [Export ("keyboardWillBeHidden:")]
        void KeyboardWillBeHidden (NSNotification aNotification);

        // -(void)keyboardDidHide:(NSNotification *)aNotification;
        [Export ("keyboardDidHide:")]
        void KeyboardDidHide (NSNotification aNotification);

        // -(void)updateAnimationValuesFromUserInfo:(NSDictionary *)userInfo;
        [Export ("updateAnimationValuesFromUserInfo:")]
        void UpdateAnimationValuesFromUserInfo (NSDictionary userInfo);

        // -(void)layoutContent;
        [Export ("layoutContent")]
        void LayoutContent ();

        // -(CGFloat)topViewOffset;
        [Export ("topViewOffset")]
        nfloat TopViewOffset ();

        // -(CGFloat)bottomViewOffset;
        [Export ("bottomViewOffset")]
        nfloat BottomViewOffset ();

        // +(UIViewController *)topViewController;
        [Static, Export ("topViewController")]
        UIViewController TopViewController ();

        // +(UIViewController *)topViewControllerWithRootViewController:(UIViewController *)rootViewController;
        [Static, Export ("topViewControllerWithRootViewController:")]
        UIViewController TopViewControllerWithRootViewController (UIViewController rootViewController);

        // +(void)presentViewController:(UIViewController *)viewController requiresNavController:(BOOL)requiresNav;
        [Static, Export ("presentViewController:requiresNavController:")]
        void PresentViewController (UIViewController viewController, bool requiresNav);
    }

    // @interface ZDKArticleViewController : ZDKUIViewController
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKArticleViewController {

        // -(instancetype)initWithArticle:(ZDKHelpCenterArticle *)article;
        [Export ("initWithArticle:")]
        IntPtr Constructor (ZDKHelpCenterArticle article);

        // @property (nonatomic, strong) ZDKArticleView * articleView;
        [Export ("articleView", ArgumentSemantic.Retain)]
        ZDKArticleView ArticleView { get; set; }
    }

    // @interface ZDKAttachment : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKAttachment {

        // -(instancetype)initWithDict:(NSDictionary *)dict;
        [Export ("initWithDict:")]
        IntPtr Constructor (NSDictionary dict);

        // @property (nonatomic, strong) NSNumber * attachmentId;
        [Export ("attachmentId", ArgumentSemantic.Retain)]
        NSNumber AttachmentId { get; set; }

        // @property (nonatomic, strong) NSString * filename;
        [Export ("filename", ArgumentSemantic.Retain)]
        string Filename { get; set; }

        // @property (nonatomic, strong) NSString * contentURLString;
        [Export ("contentURLString", ArgumentSemantic.Retain)]
        string ContentURLString { get; set; }

        // @property (nonatomic, strong) NSString * contentType;
        [Export ("contentType", ArgumentSemantic.Retain)]
        string ContentType { get; set; }

        // @property (nonatomic, strong) NSNumber * size;
        [Export ("size", ArgumentSemantic.Retain)]
        NSNumber Size { get; set; }

        // @property (nonatomic, strong) NSArray * thumbnails;
        [Export ("thumbnails", ArgumentSemantic.Retain)]
        NSObject [] Thumbnails { get; set; }
    }

    // @interface ZDKAttachmentCache : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKAttachmentCache {

        // +(UIImage *)imageWithFilename:(NSString *)filename;
        [Static, Export ("imageWithFilename:")]
        UIImage ImageWithFilename (string filename);

        // +(void)cacheImage:(UIImage *)image withFilename:(NSString *)filename;
        [Static, Export ("cacheImage:withFilename:")]
        void CacheImage (UIImage image, string filename);

        // +(void)clearCache;
        [Static, Export ("clearCache")]
        void ClearCache ();
    }

    // @interface ZDKAttachmentCollectionViewCell : UICollectionViewCell
    [BaseType (typeof (UICollectionViewCell))]
    interface ZDKAttachmentCollectionViewCell {

        // -(void)prepareWithImage:(UIImage *)image;
        [Export ("prepareWithImage:")]
        void PrepareWithImage (UIImage image);

        // +(NSString *)reuseIdentifier;
        [Static, Export ("reuseIdentifier")]
        string ReuseIdentifier ();

        // +(CGSize)preferedSize;
        [Static, Export ("preferedSize")]
        CGSize PreferedSize ();
    }

    // @interface ZDKAttachmentSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKAttachmentSettings {

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) BOOL enabled;
        [Export ("enabled")]
        bool Enabled { get; }

        // @property (readonly, nonatomic) NSNumber * maxAttachmentSize;
        [Export ("maxAttachmentSize")]
        NSNumber MaxAttachmentSize { get; }
    }

    // @interface ZDKAttachmentView : UIView
    [BaseType (typeof (UIView))]
    interface ZDKAttachmentView {

        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export ("backgroundColor", ArgumentSemantic.Retain)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * closeButtonBackgroundColor;
        [Export ("closeButtonBackgroundColor", ArgumentSemantic.Retain)]
        UIColor CloseButtonBackgroundColor { get; set; }

        // @property (readonly, nonatomic) UICollectionView * attachmentsCollectionView;
        [Export ("attachmentsCollectionView")]
        UICollectionView AttachmentsCollectionView { get; }

        // -(void)addTarget:(id)target forCloseAction:(SEL)action;
        [Export ("addTarget:forCloseAction:")]
        void AddTarget (NSObject target, Selector action);
    }

    // @protocol ZDKAttachmentViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKAttachmentViewControllerDelegate {

        // @required -(void)didCloseAttachmentView;
        [Export ("didCloseAttachmentView")]
        [Abstract]
        void DidCloseAttachmentView ();

        // @required -(void)attachmentTooLarge:(NSData *)data;
        [Export ("attachmentTooLarge:")]
        [Abstract]
        void AttachmentTooLarge (NSData data);

        // @required -(void)attachmentsView:(ZDKAttachmentView *)attachmentView didSelectAttachment:(NSString *)attachment data:(NSData *)data;
        [Export ("attachmentsView:didSelectAttachment:data:")]
        [Abstract]
        void AttachmentsView (ZDKAttachmentView attachmentView, string attachment, NSData data);

        // @required -(void)attachmentsView:(ZDKAttachmentView *)attachmentView didRemoveAttachment:(NSString *)attachment;
        [Export ("attachmentsView:didRemoveAttachment:")]
        [Abstract]
        void AttachmentsView (ZDKAttachmentView attachmentView, string attachment);
    }

    // @interface ZDKAttachmentViewController : UIViewController
    [BaseType (typeof (UIViewController))]
    interface ZDKAttachmentViewController {

        // @property (nonatomic, weak) id<ZDKAttachmentViewControllerDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.Weak)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, weak) id<ZDKAttachmentViewControllerDelegate> delegate;
        [Wrap ("WeakDelegate")]
        ZDKAttachmentViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic) ZDKAttachmentView * attachmentView;
        [Export ("attachmentView")]
        ZDKAttachmentView AttachmentView { get; set; }

        // @property (readonly, nonatomic) ZDKAttachmentViewDataSource * datasource;
        [Export ("datasource")]
        ZDKAttachmentViewDataSource Datasource { get; }

        // -(void)resetAttachmentsView;
        [Export ("resetAttachmentsView")]
        void ResetAttachmentsView ();
    }

    // @interface ZDKAttachmentViewDataSource : NSObject <UICollectionViewDataSource>
    [BaseType (typeof (NSObject))]
    interface ZDKAttachmentViewDataSource {

        // @property (nonatomic, strong) NSMutableArray * data;
        [Export ("data", ArgumentSemantic.Retain)]
        NSMutableArray Data { get; set; }
    }

    // @interface ZDKAvatarProvider : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKAvatarProvider {

        // -(void)getAvatarForUrl:(NSString *)avatarUrl withCallback:(ZDKAvatarCallback)callback;
        [Export ("getAvatarForUrl:withCallback:")]
        void GetAvatarForUrl (string avatarUrl, Action<UIImage, NSError> callback);
    }

    // @interface ZDKBundleUtils : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKBundleUtils {

        // +(NSBundle *)frameworkResourceBundle;
        [Static, Export ("frameworkResourceBundle")]
        NSBundle FrameworkResourceBundle ();

        // +(NSBundle *)frameworkStringsBundle;
        [Static, Export ("frameworkStringsBundle")]
        NSBundle FrameworkStringsBundle ();

        // +(NSString *)pathForFrameworkResource:(NSString *)name ofType:(NSString *)extension;
        [Static, Export ("pathForFrameworkResource:ofType:")]
        string PathForFrameworkResource (string name, string extension);

        // +(NSString *)helpCenterCss;
        [Static, Export ("helpCenterCss")]
        string HelpCenterCss ();

        // +(NSString *)userDefinedHelpCenterCss;
        [Static, Export ("userDefinedHelpCenterCss")]
        string UserDefinedHelpCenterCss ();

        // +(NSDictionary *)deviceModelIdentifier;
        [Static, Export ("deviceModelIdentifier")]
        NSDictionary DeviceModelIdentifier ();

        // +(NSString *)stringsTableName;
        [Static, Export ("stringsTableName")]
        string StringsTableName ();

        // +(UIImage *)conversationsImage;
        [Static, Export ("conversationsImage")]
        UIImage ConversationsImage ();

        // +(UIImage *)createRequestImage;
        [Static, Export ("createRequestImage")]
        UIImage CreateRequestImage ();

        // +(UIImage *)attachmentImage;
        [Static, Export ("attachmentImage")]
        UIImage AttachmentImage ();

        // +(UIImage *)imageNamed:(NSString *)name ofType:(NSString *)extension;
        [Static, Export ("imageNamed:ofType:")]
        UIImage ImageNamed (string name, string extension);
    }

    // @protocol ZDKUITextViewDelegate <UITextViewDelegate>
    [Protocol, Model]
    interface ZDKUITextViewDelegate : IUITextViewDelegate {

        // @required -(void)caretPosition:(CGRect)caret;
        [Export ("caretPosition:")]
        [Abstract]
        void CaretPosition (CGRect caret);

        // @optional -(void)updateLayout:(ZDKUITextView *)textView;
        [Export ("updateLayout:")]
        void UpdateLayout (ZDKUITextView textView);
    }

    // @interface ZDKUITextView : UITextView
    [BaseType (typeof (UITextView))]
    interface ZDKUITextView {

        // -(instancetype)initWithFrame:(CGRect)frame andPlaceholder:(NSString *)placeholderText;
        [Export ("initWithFrame:andPlaceholder:")]
        IntPtr Constructor (CGRect frame, string placeholderText);

        // @property (retain, nonatomic) NSString * placeholderText;
        [Export ("placeholderText", ArgumentSemantic.Retain)]
        string PlaceholderText { get; set; }

        // @property (retain, nonatomic) UIColor * placeholderTextColor;
        [Export ("placeholderTextColor", ArgumentSemantic.Retain)]
        UIColor PlaceholderTextColor { get; set; }

        // -(void)scrollToVisibleCaretAnimated:(BOOL)animated;
        [Export ("scrollToVisibleCaretAnimated:")]
        void ScrollToVisibleCaretAnimated (bool animated);
    }

    // @interface ZDKCommentEntryView : UIView
    [BaseType (typeof (UIView))]
    interface ZDKCommentEntryView {

        // -(instancetype)initWithFrame:(CGRect)frame andRequest:(ZDKRequest *)request;
        [Export ("initWithFrame:andRequest:")]
        IntPtr Constructor (CGRect frame, ZDKRequest request);

        // @property (nonatomic, strong) ZDKRequest * request;
        [Export ("request", ArgumentSemantic.Retain)]
        ZDKRequest Request { get; set; }

        // @property (nonatomic, strong) UIView * topBorder;
        [Export ("topBorder", ArgumentSemantic.Retain)]
        UIView TopBorder { get; set; }

        // @property (nonatomic, strong) UIView * textViewBackground;
        [Export ("textViewBackground", ArgumentSemantic.Retain)]
        UIView TextViewBackground { get; set; }

        // @property (nonatomic, strong) ZDKUITextView * textView;
        [Export ("textView", ArgumentSemantic.Retain)]
        ZDKUITextView TextView { get; set; }

        // @property (nonatomic, strong) UIButton * sendButton;
        [Export ("sendButton", ArgumentSemantic.Retain)]
        UIButton SendButton { get; set; }

        // @property (assign, nonatomic) BOOL sending;
        [Export ("sending", ArgumentSemantic.UnsafeUnretained)]
        bool Sending { get; set; }

        // @property (nonatomic, strong) UIColor * topBorderColor;
        [Export ("topBorderColor", ArgumentSemantic.Retain)]
        UIColor TopBorderColor { get; set; }

        // @property (nonatomic, strong) UIFont * textEntryFont;
        [Export ("textEntryFont", ArgumentSemantic.Retain)]
        UIFont TextEntryFont { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryColor;
        [Export ("textEntryColor", ArgumentSemantic.Retain)]
        UIColor TextEntryColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryBackgroundColor;
        [Export ("textEntryBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TextEntryBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryBorderColor;
        [Export ("textEntryBorderColor", ArgumentSemantic.Retain)]
        UIColor TextEntryBorderColor { get; set; }

        // @property (nonatomic, strong) UIFont * sendButtonFont;
        [Export ("sendButtonFont", ArgumentSemantic.Retain)]
        UIFont SendButtonFont { get; set; }

        // @property (nonatomic, strong) UIColor * sendButtonColor;
        [Export ("sendButtonColor", ArgumentSemantic.Retain)]
        UIColor SendButtonColor { get; set; }

        // @property (nonatomic, strong) UIColor * areaBackgroundColor;
        [Export ("areaBackgroundColor", ArgumentSemantic.Retain)]
        UIColor AreaBackgroundColor { get; set; }

        // -(CGFloat)preferredHeight;
        [Export ("preferredHeight")]
        nfloat PreferredHeight ();
    }

    // @protocol ZDKCommentInputViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKCommentInputViewDelegate {

        // @optional -(BOOL)shouldSelectSend;
        [Export ("shouldSelectSend")]
        bool ShouldSelectSend ();

        // @optional -(void)didSelectSend:(NSString *)commentBody;
        [Export ("didSelectSend:")]
        void DidSelectSend (string commentBody);

        // @optional -(BOOL)shouldSelectAttachment;
        [Export ("shouldSelectAttachment")]
        bool ShouldSelectAttachment ();

        // @optional -(void)didSelectAttachment;
        [Export ("didSelectAttachment")]
        void DidSelectAttachment ();
    }

    // @interface ZDKCommentInputView : UIView
    [BaseType (typeof (UIView))]
    interface ZDKCommentInputView {

        // @property (readonly, nonatomic) ZDKUITextView * textView;
        [Export ("textView")]
        ZDKUITextView TextView { get; }

        // @property (readonly, nonatomic) UIButton * sendButton;
        [Export ("sendButton")]
        UIButton SendButton { get; }

        // @property (assign, nonatomic) id<ZDKCommentInputViewDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) id<ZDKCommentInputViewDelegate> delegate;
        [Wrap ("WeakDelegate")]
        ZDKCommentInputViewDelegate Delegate { get; set; }

        // @property (nonatomic, strong) UIColor * topBorderColor;
        [Export ("topBorderColor", ArgumentSemantic.Retain)]
        UIColor TopBorderColor { get; set; }

        // @property (nonatomic, strong) UIFont * textEntryFont;
        [Export ("textEntryFont", ArgumentSemantic.Retain)]
        UIFont TextEntryFont { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryColor;
        [Export ("textEntryColor", ArgumentSemantic.Retain)]
        UIColor TextEntryColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryBackgroundColor;
        [Export ("textEntryBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TextEntryBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryBorderColor;
        [Export ("textEntryBorderColor", ArgumentSemantic.Retain)]
        UIColor TextEntryBorderColor { get; set; }

        // @property (nonatomic, strong) UIFont * sendButtonFont;
        [Export ("sendButtonFont", ArgumentSemantic.Retain)]
        UIFont SendButtonFont { get; set; }

        // @property (nonatomic, strong) UIColor * sendButtonColor;
        [Export ("sendButtonColor", ArgumentSemantic.Retain)]
        UIColor SendButtonColor { get; set; }

        // @property (nonatomic, strong) UIColor * areaBackgroundColor;
        [Export ("areaBackgroundColor", ArgumentSemantic.Retain)]
        UIColor AreaBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * attachmentButtonBackgroundColor;
        [Export ("attachmentButtonBackgroundColor", ArgumentSemantic.Retain)]
        UIColor AttachmentButtonBackgroundColor { get; set; }

        // -(CGFloat)preferredHeight;
        [Export ("preferredHeight")]
        nfloat PreferredHeight ();
    }

    // @interface ZDKCommentInputViewController : UIViewController
    [BaseType (typeof (UIViewController))]
    interface ZDKCommentInputViewController {

        // -(instancetype)initWithRequest:(ZDKRequest *)request;
        [Export ("initWithRequest:")]
        IntPtr Constructor (ZDKRequest request);

        // @property (nonatomic) ZDKCommentInputView * commentInputView;
        [Export ("commentInputView")]
        ZDKCommentInputView CommentInputView { get; set; }

        // -(CGFloat)preferredHeight;
        [Export ("preferredHeight")]
        nfloat PreferredHeight ();
    }

    // @interface ZDKCommentsResponse : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKCommentsResponse {

        // @property (readonly, nonatomic) NSArray * commmentsWithUsers;
        [Export ("commmentsWithUsers")]
        NSObject [] CommmentsWithUsers { get; }

        // +(NSArray *)parseData:(NSDictionary *)dictionary;
        [Static, Export ("parseData:")]
        NSObject [] ParseData (NSDictionary dictionary);
    }

    // @interface ZDKCommentsTableViewController : UIViewController
    [BaseType (typeof (UIViewController))]
    interface ZDKCommentsTableViewController {

        // -(instancetype)initWithRequest:(ZDKRequest *)request;
        [Export ("initWithRequest:")]
        IntPtr Constructor (ZDKRequest request);

        // @property (readonly, nonatomic) ZDKCommentsTableViewDataSource * datasource;
        [Export ("datasource")]
        ZDKCommentsTableViewDataSource Datasource { get; }

        // @property (readonly, nonatomic) UITableView * commentsView;
        [Export ("commentsView")]
        UITableView CommentsView { get; }
    }

    // @interface ZDKCommentsTableViewDataSource : NSObject <UITableViewDataSource>
    [BaseType (typeof (NSObject))]
    interface ZDKCommentsTableViewDataSource : IUITableViewDataSource {

        // -(instancetype)initWithRequest:(ZDKRequest *)request;
        [Export ("initWithRequest:")]
        IntPtr Constructor (ZDKRequest request);

        // @property (readonly, assign, nonatomic) BOOL loadingInProgress;
        [Export ("loadingInProgress", ArgumentSemantic.UnsafeUnretained)]
        bool LoadingInProgress { get; }

        // @property (readonly, copy, nonatomic) NSArray * items;
        [Export ("items", ArgumentSemantic.Copy)]
        NSObject [] Items { get; }

        // -(id)itemAtIndexPath:(NSIndexPath *)indexPath;
        [Export ("itemAtIndexPath:")]
        NSObject ItemAtIndexPath (NSIndexPath indexPath);

        // -(void)reloadData;
        [Export ("reloadData")]
        void ReloadData ();
    }

    // @interface ZDKCommentsTableViewDelegate : NSObject <UITableViewDelegate>
    [BaseType (typeof (NSObject))]
    interface ZDKCommentsTableViewDelegate : IUITableViewDelegate {

    }

    // @interface ZDKCommentsViewController : ZDKUIViewController
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKCommentsViewController {

        // -(instancetype)initWithRequest:(ZDKRequest *)aRequest;
        [Export ("initWithRequest:")]
        IntPtr Constructor (ZDKRequest aRequest);
    }

    // @interface ZDKCommentWithUser : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKCommentWithUser {

        // @property (readonly, nonatomic) ZDKComment * comment;
        [Export ("comment")]
        ZDKComment Comment { get; }

        // @property (readonly, nonatomic) ZDKUser * user;
        [Export ("user")]
        ZDKUser User { get; }

        // +(instancetype)buildCommentWithUser:(ZDKComment *)comment withUsers:(NSArray *)users;
        [Static, Export ("buildCommentWithUser:withUsers:")]
        ZDKCommentWithUser BuildCommentWithUser (ZDKComment comment, NSObject [] users);
    }

    // @interface ZDKConfig : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKConfig {

        // @property (readonly, nonatomic) ZDKAccount * account;
        [Export ("account")]
        ZDKAccount Account { get; }

        // @property (nonatomic, strong) NSArray * customTicketFields;
        [Export ("customTicketFields", ArgumentSemantic.Retain)]
        NSObject [] CustomTicketFields { get; set; }

        // @property (nonatomic, strong) NSNumber * ticketFormId;
        [Export ("ticketFormId", ArgumentSemantic.Retain)]
        NSNumber TicketFormId { get; set; }

        // @property (readonly) BOOL isAnonymousAuth;
        [Export ("isAnonymousAuth")]
        bool IsAnonymousAuth { get; }

        // @property (copy, nonatomic) NSString * userLocale;
        [Export ("userLocale")]
        string UserLocale { get; set; }

        // @property (assign, nonatomic) BOOL coppaEnabled;
        [Export ("coppaEnabled", ArgumentSemantic.UnsafeUnretained)]
        bool CoppaEnabled { get; set; }

        // +(instancetype)instance;
        [Static, Export ("instance")]
        ZDKConfig Instance ();

        // -(void)initializeWithAppId:(NSString *)applicationId zendeskUrl:(NSString *)zendeskUrl andClientId:(NSString *)oAuthClientId;
        [Export ("initializeWithAppId:zendeskUrl:andClientId:")]
        void InitializeWithAppId (string applicationId, string zendeskUrl, string oAuthClientId);

        // -(void)reload;
        [Export ("reload")]
        void Reload ();

        // -(NSTimeInterval)reloadInterval;
        [Export ("reloadInterval")]
        double ReloadInterval ();

        // -(void)setReloadInterval:(NSTimeInterval)interval;
        [Export ("setReloadInterval:")]
        void SetReloadInterval (double interval);

        // -(void)setUserIdentity:(NSObject<ZDKIdentity> *)aUserIdentity;
        [Export ("setUserIdentity:")]
        void SetUserIdentity (NSObject aUserIdentity);
    }

    // @interface ZDKContactUsSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKContactUsSettings {

        // -(id)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) NSArray * tags;
        [Export ("tags")]
        NSObject [] Tags { get; }
    }

    // @interface ZDKConversationsSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKConversationsSettings {

        // -(id)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) BOOL enabled;
        [Export ("enabled")]
        bool Enabled { get; }
    }

    // @protocol ZDKCreateRequestUIDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKCreateRequestUIDelegate {

        // @required -(ZDKNavBarCreateRequestUIType)navBarCreateRequestUIType;
        [Export ("navBarCreateRequestUIType")]
        [Abstract]
        ZDKNavBarCreateRequestUIType NavBarCreateRequestUIType ();

        // @required -(UIImage *)createRequestBarButtonImage;
        [Export ("createRequestBarButtonImage")]
        [Abstract]
        UIImage CreateRequestBarButtonImage ();

        // @required -(NSString *)createRequestBarButtonLocalizedLabel;
        [Export ("createRequestBarButtonLocalizedLabel")]
        [Abstract]
        string CreateRequestBarButtonLocalizedLabel ();
    }

    // @protocol ZDKSpinnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKSpinnerDelegate {

        // @property (nonatomic) CGRect frame;
        [Export ("frame")]
        CGRect Frame { get; set; }

        // @property (nonatomic) BOOL hidden;
        [Export ("hidden")]
        bool Hidden { get; set; }

        // @property (nonatomic) CGPoint center;
        [Export ("center")]
        CGPoint Center { get; set; }

        // @required -(void)startAnimating;
        [Export ("startAnimating")]
        [Abstract]
        void StartAnimating ();

        // @required -(void)stopAnimating;
        [Export ("stopAnimating")]
        [Abstract]
        void StopAnimating ();
    }

    // @interface ZDKCreateRequestView : UIView <UIAppearanceContainer>
    [BaseType (typeof (UIView))]
    interface ZDKCreateRequestView : IUIAppearanceContainer {

        // @property (nonatomic, strong) ZDKUITextView * textView;
        [Export ("textView", ArgumentSemantic.Retain)]
        ZDKUITextView TextView { get; set; }

        // @property (nonatomic, strong) UIButton * attachImageButton;
        [Export ("attachImageButton", ArgumentSemantic.Retain)]
        UIButton AttachImageButton { get; set; }

        // @property (nonatomic, strong) UIActionSheet * attachmentSourceSelectSheet;
        [Export ("attachmentSourceSelectSheet", ArgumentSemantic.Retain)]
        UIActionSheet AttachmentSourceSelectSheet { get; set; }

        // @property (nonatomic, strong) UIActionSheet * attachmentOptionsSelectSheet;
        [Export ("attachmentOptionsSelectSheet", ArgumentSemantic.Retain)]
        UIActionSheet AttachmentOptionsSelectSheet { get; set; }

        // @property (nonatomic, strong) UIColor * placeholderTextColor;
        [Export ("placeholderTextColor", ArgumentSemantic.Retain)]
        UIColor PlaceholderTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryColor;
        [Export ("textEntryColor", ArgumentSemantic.Retain)]
        UIColor TextEntryColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryBackgroundColor;
        [Export ("textEntryBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TextEntryBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * viewBackgroundColor;
        [Export ("viewBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ViewBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIFont * textEntryFont;
        [Export ("textEntryFont", ArgumentSemantic.Retain)]
        UIFont TextEntryFont { get; set; }

        // @property (nonatomic, strong) UIImage * attachmentButtonImage;
        [Export ("attachmentButtonImage", ArgumentSemantic.Retain)]
        UIImage AttachmentButtonImage { get; set; }

        // @property (nonatomic, strong) UIColor * attachmentButtonBorderColor;
        [Export ("attachmentButtonBorderColor", ArgumentSemantic.Retain)]
        UIColor AttachmentButtonBorderColor { get; set; }

        // @property (nonatomic, strong) NSNumber * attachmentButtonCornerRadius;
        [Export ("attachmentButtonCornerRadius", ArgumentSemantic.Retain)]
        NSNumber AttachmentButtonCornerRadius { get; set; }

        // @property (nonatomic, strong) NSNumber * attachmentButtonBorderWidth;
        [Export ("attachmentButtonBorderWidth", ArgumentSemantic.Retain)]
        NSNumber AttachmentButtonBorderWidth { get; set; }

        // @property (nonatomic, strong) UIColor * attachmentButtonBackground;
        [Export ("attachmentButtonBackground", ArgumentSemantic.Retain)]
        UIColor AttachmentButtonBackground { get; set; }

        // @property (nonatomic, strong) NSNumber * attachmentActionSheetStyle;
        [Export ("attachmentActionSheetStyle", ArgumentSemantic.Retain)]
        NSNumber AttachmentActionSheetStyle { get; set; }

        // @property (nonatomic, strong) id<ZDKSpinnerDelegate> spinner;
        [Export ("spinner", ArgumentSemantic.Retain)]
        ZDKSpinnerDelegate Spinner { get; set; }

        // @property (nonatomic, strong) NSNumber * automaticallyHideNavBarOnLandscape;
        [Export ("automaticallyHideNavBarOnLandscape", ArgumentSemantic.Retain)]
        NSNumber AutomaticallyHideNavBarOnLandscape { get; set; }

        // @property (readonly, assign, nonatomic) NSInteger textViewHeight;
        [Export ("textViewHeight", ArgumentSemantic.UnsafeUnretained)]
        nint TextViewHeight { get; }

        // -(void)initAttachmentSourceSheet;
        [Export ("initAttachmentSourceSheet")]
        void InitAttachmentSourceSheet ();
    }

    // @interface ZDKCreateRequestViewController : ZDKUIViewController <ZDKUITextViewDelegate, UITextFieldDelegate, UIActionSheetDelegate, UIImagePickerControllerDelegate, UINavigationControllerDelegate, UITableViewDelegate, UITableViewDataSource>
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKCreateRequestViewController : ZDKUITextViewDelegate, IUITextFieldDelegate, IUIActionSheetDelegate, IUIImagePickerControllerDelegate, IUINavigationControllerDelegate, IUITableViewDelegate, IUITableViewDataSource {

        // -(instancetype)initWithSuccess:(ZDKAPISuccess)success andError:(ZDKAPIError)error;
        [Export ("initWithSuccess:andError:")]
        IntPtr Constructor (Action<NSObject> success, Action<NSError> error);

        // @property (copy, nonatomic) ZDKAPISuccess onSuccess;
        [Export ("onSuccess", ArgumentSemantic.Copy)]
        Action<NSObject> OnSuccess { get; set; }

        // @property (copy, nonatomic) ZDKAPIError onError;
        [Export ("onError", ArgumentSemantic.Copy)]
        Action<NSError> OnError { get; set; }

        // @property (nonatomic, strong) ZDKCreateRequestView * createRequestView;
        [Export ("createRequestView", ArgumentSemantic.Retain)]
        ZDKCreateRequestView CreateRequestView { get; set; }
    }

    // @interface ZDKCustomField : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKCustomField {

        // -(instancetype)initWithFieldId:(NSNumber *)aFieldId andValue:(NSString *)aValue;
        [Export ("initWithFieldId:andValue:")]
        IntPtr Constructor (NSNumber aFieldId, string aValue);

        // @property (readonly, nonatomic) NSNumber * fieldId;
        [Export ("fieldId")]
        NSNumber FieldId { get; }

        // @property (readonly, nonatomic) NSString * value;
        [Export ("value")]
        string Value { get; }

        // -(NSDictionary *)dictionaryValue;
        [Export ("dictionaryValue")]
        NSDictionary DictionaryValue ();
    }

    // @interface ZDKDateUtil : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKDateUtil {

        // +(NSDate *)dateForJsonString:(NSString *)string;
        [Static, Export ("dateForJsonString:")]
        NSDate DateForJsonString (string jsonString);

        // +(NSNumber *)dateAsNumber:(NSDate *)date;
        [Static, Export ("dateAsNumber:")]
        NSNumber DateAsNumber (NSDate date);

        // +(NSDate *)dateFromNumber:(NSNumber *)date;
        [Static, Export ("dateFromNumber:")]
        NSDate DateFromNumber (NSNumber date);

        // +(NSDate *)dateFromString:(NSString *)string usingFormat:(NSString *)format;
        [Static, Export ("dateFromString:usingFormat:")]
        NSDate DateFromString (string dateString, string format);

        // +(NSString *)stringFromDate:(NSDate *)date usingFormat:(NSString *)format;
        [Static, Export ("stringFromDate:usingFormat:")]
        string StringFromDate (NSDate date, string format);

        // +(NSDateFormatter *)formatterForFormat:(NSString *)format;
        [Static, Export ("formatterForFormat:")]
        NSDateFormatter FormatterForFormat (string format);
    }

    // @interface ZDKETag : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKETag {

        // +(void)addEtagToRequest:(NSMutableURLRequest *)request;
        [Static, Export ("addEtagToRequest:")]
        void AddEtagToRequest (NSMutableUrlRequest request);

        // +(BOOL)unmodified:(ZDKDispatcherResponse *)response;
        [Static, Export ("unmodified:")]
        bool Unmodified (ZDKDispatcherResponse response);

        // +(NSString *)eTagForURL:(NSURL *)url;
        [Static, Export ("eTagForURL:")]
        string ETagForURL (NSUrl url);
    }

    // @protocol ZDKHelpCenterConversationsUIDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterConversationsUIDelegate {

        // @required -(ZDKNavBarConversationsUIType)navBarConversationsUIType;
        [Export ("navBarConversationsUIType")]
        [Abstract]
        ZDKNavBarConversationsUIType NavBarConversationsUIType ();

        // @required -(UIImage *)conversationsBarButtonImage;
        [Export ("conversationsBarButtonImage")]
        [Abstract]
        UIImage ConversationsBarButtonImage ();

        // @required -(NSString *)conversationsBarButtonLocalizedLabel;
        [Export ("conversationsBarButtonLocalizedLabel")]
        [Abstract]
        string ConversationsBarButtonLocalizedLabel ();
    }

    // @interface ZDKHelpCenter : NSObject <ZDKHelpCenterConversationsUIDelegate>
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenter : ZDKHelpCenterConversationsUIDelegate {

        // +(void)showHelpCenterWithNavController:(UINavigationController *)navController;
        [Static, Export ("showHelpCenterWithNavController:")]
        void ShowHelpCenterWithNavController (UINavigationController navController);

        // +(void)showHelpCenterWithNavController:(UINavigationController *)navController layoutGudie:(ZDKLayoutGuide)aGuide;
        [Static, Export ("showHelpCenterWithNavController:layoutGudie:")]
        void ShowHelpCenterWithNavController (UINavigationController navController, ZDKLayoutGuide aGuide);

        // +(void)presentHelpCenterWithNavController:(UINavigationController *)navController;
        [Static, Export ("presentHelpCenterWithNavController:")]
        void PresentHelpCenterWithNavController (UINavigationController navController);

        // +(void)showHelpCenterWithNavController:(UINavigationController *)navController filterByArticleLabels:(NSArray *)labels;
        [Static, Export ("showHelpCenterWithNavController:filterByArticleLabels:")]
        void ShowHelpCenterWithNavController (UINavigationController navController, NSObject [] labels);

        // +(void)showHelpCenterWithNavController:(UINavigationController *)navController filterByArticleLabels:(NSArray *)labels layoutGudie:(ZDKLayoutGuide)aGuide;
        [Static, Export ("showHelpCenterWithNavController:filterByArticleLabels:layoutGudie:")]
        void ShowHelpCenterWithNavController (UINavigationController navController, NSObject [] labels, ZDKLayoutGuide aGuide);

        // +(void)presentHelpCenterWithNavController:(UINavigationController *)navController filterByArticleLabels:(NSArray *)labels;
        [Static, Export ("presentHelpCenterWithNavController:filterByArticleLabels:")]
        void PresentHelpCenterWithNavController (UINavigationController navController, NSObject [] labels);

        // +(void)setConversationsBarButtonImage:(NSString *)name;
        [Static, Export ("setConversationsBarButtonImage:")]
        void SetConversationsBarButtonImage (string name);

        // +(void)setNavBarConversationsUIType:(ZDKNavBarConversationsUIType)uiType;
        [Static, Export ("setNavBarConversationsUIType:")]
        void SetNavBarConversationsUIType (ZDKNavBarConversationsUIType uiType);
    }

    // @interface ZDKHelpCenterArticle : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterArticle {

        // @property (nonatomic, strong) NSString * sid;
        [Export ("sid", ArgumentSemantic.Retain)]
        string Sid { get; set; }

        // @property (nonatomic, strong) NSString * section_id;
        [Export ("section_id", ArgumentSemantic.Retain)]
        string Section_id { get; set; }

        // @property (nonatomic, strong) NSString * title;
        [Export ("title", ArgumentSemantic.Retain)]
        string Title { get; set; }

        // @property (nonatomic, strong) NSString * body;
        [Export ("body", ArgumentSemantic.Retain)]
        string Body { get; set; }

        // @property (nonatomic, strong) NSString * author_name;
        [Export ("author_name", ArgumentSemantic.Retain)]
        string Author_name { get; set; }

        // @property (nonatomic, strong) NSString * author_id;
        [Export ("author_id", ArgumentSemantic.Retain)]
        string Author_id { get; set; }

        // @property (nonatomic, strong) NSString * article_details;
        [Export ("article_details", ArgumentSemantic.Retain)]
        string Article_details { get; set; }

        // @property (nonatomic, strong) NSString * articleParents;
        [Export ("articleParents", ArgumentSemantic.Retain)]
        string ArticleParents { get; set; }

        // @property (nonatomic, strong) NSDate * created_at;
        [Export ("created_at", ArgumentSemantic.Retain)]
        NSDate Created_at { get; set; }

        // @property (assign, nonatomic) NSInteger position;
        [Export ("position", ArgumentSemantic.UnsafeUnretained)]
        nint Position { get; set; }

        // @property (assign, nonatomic) BOOL outdated;
        [Export ("outdated", ArgumentSemantic.UnsafeUnretained)]
        bool Outdated { get; set; }

        // +(ZDKHelpCenterArticle *)parseArticle:(NSDictionary *)articleJson;
        [Static, Export ("parseArticle:")]
        ZDKHelpCenterArticle ParseArticle (NSDictionary articleJson);

        // +(NSArray *)parseArticles:(NSDictionary *)json;
        [Static, Export ("parseArticles:")]
        NSObject [] ParseArticles (NSDictionary json);

        // +(NSArray *)parseArticleSearchResults:(NSDictionary *)json;
        [Static, Export ("parseArticleSearchResults:")]
        NSObject [] ParseArticleSearchResults (NSDictionary json);

        // +(NSArray *)parseArticlesWithRootKey:(NSDictionary *)json withRootKey:(NSString *)root;
        [Static, Export ("parseArticlesWithRootKey:withRootKey:")]
        NSObject [] ParseArticlesWithRootKey (NSDictionary json, string root);
    }

    // @interface ZDKHelpCenterSearch : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterSearch {

        // @property (nonatomic) NSString * query;
        [Export ("query")]
        string Query { get; set; }

        // @property (nonatomic) NSMutableArray * labelNames;
        [Export ("labelNames")]
        NSMutableArray LabelNames { get; set; }

        // @property (nonatomic) NSString * locale;
        [Export ("locale")]
        string Locale { get; set; }

        // @property (nonatomic) NSMutableArray * sideLoads;
        [Export ("sideLoads")]
        NSMutableArray SideLoads { get; set; }

        // @property (nonatomic) NSNumber * categoryId;
        [Export ("categoryId")]
        NSNumber CategoryId { get; set; }

        // @property (nonatomic) NSNumber * sectionId;
        [Export ("sectionId")]
        NSNumber SectionId { get; set; }

        // @property (nonatomic) NSNumber * page;
        [Export ("page")]
        NSNumber Page { get; set; }

        // @property (nonatomic) NSNumber * resultsPerPage;
        [Export ("resultsPerPage")]
        NSNumber ResultsPerPage { get; set; }

        // -(NSString *)asQueryString;
        [Export ("asQueryString")]
        string AsQueryString ();
    }

    // @interface ZDKHelpCenterProvider : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterProvider {

        // -(void)getCategoriesWithCallback:(ZDKHelpCenterCallback)callback;
        [Export ("getCategoriesWithCallback:")]
        void GetCategoriesWithCallback (Action<NSArray, NSError> callback);

        // -(void)getSectionsForCategoryId:(NSString *)categoryId withCallback:(ZDKHelpCenterCallback)callback;
        [Export ("getSectionsForCategoryId:withCallback:")]
        void GetSectionsForCategoryId (string categoryId, Action<NSArray, NSError> callback);

        // -(void)getArticlesForSectionId:(NSString *)sectionId withCallback:(ZDKHelpCenterCallback)callback;
        [Export ("getArticlesForSectionId:withCallback:")]
        void GetArticlesForSectionId (string sectionId, Action<NSArray, NSError> callback);

        // -(void)searchForArticlesUsingQuery:(NSString *)query withCallback:(ZDKHelpCenterCallback)callback;
        [Export ("searchForArticlesUsingQuery:withCallback:")]
        void SearchForArticlesUsingQuery (string query, Action<NSArray, NSError> callback);

        // -(void)searchForArticlesUsingQuery:(NSString *)query andLabels:(NSArray *)labels withCallback:(ZDKHelpCenterCallback)callback;
        [Export ("searchForArticlesUsingQuery:andLabels:withCallback:")]
        void SearchForArticlesUsingQuery (string query, NSObject [] labels, Action<NSArray, NSError> callback);

        // -(void)searchArticles:(ZDKHelpCenterSearch *)search withCallback:(ZDKHelpCenterCallback)callback;
        [Export ("searchArticles:withCallback:")]
        void SearchArticles (ZDKHelpCenterSearch search, Action<NSArray, NSError> callback);

        // -(void)getAttachmentForArticleId:(NSString *)articleId withCallback:(ZDKHelpCenterCallback)callback;
        [Export ("getAttachmentForArticleId:withCallback:")]
        void GetAttachmentForArticleId (string articleId, Action<NSArray, NSError> callback);

        // -(void)getArticlesByLabels:(NSArray *)labels withCallback:(ZDKHelpCenterCallback)callback;
        [Export ("getArticlesByLabels:withCallback:")]
        void GetArticlesByLabels (NSObject [] labels, Action<NSArray, NSError> callback);
    }

    // @interface ZDKHelpCenterDataSource : NSObject <UITableViewDataSource>
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterDataSource : IUITableViewDataSource {

        // @property (readonly, nonatomic) BOOL hasItems;
        [Export ("hasItems")]
        bool HasItems { get; }

        // @property (readonly, copy, nonatomic) NSArray * items;
        [Export ("items", ArgumentSemantic.Copy)]
        NSObject [] Items { get; }

        // @property (readonly, nonatomic) ZDKHelpCenterProvider * provider;
        [Export ("provider")]
        ZDKHelpCenterProvider Provider { get; }

        // -(void)reloadData;
        [Export ("reloadData")]
        void ReloadData ();

        // -(id)itemAtIndexPath:(NSIndexPath *)indexPath;
        [Export ("itemAtIndexPath:")]
        NSObject ItemAtIndexPath (NSIndexPath indexPath);

        // +(NSString *)cellIdentifierForDataSource;
        [Static, Export ("cellIdentifierForDataSource")]
        string CellIdentifierForDataSource ();
    }

    // @interface ZDKHelpCenterArticlesByLabelDataSource : ZDKHelpCenterDataSource
    [BaseType (typeof (ZDKHelpCenterDataSource))]
    interface ZDKHelpCenterArticlesByLabelDataSource {

        // -(instancetype)initWithArticleLabels:(NSArray *)articleLabels;
        [Export ("initWithArticleLabels:")]
        IntPtr Constructor (NSObject [] articleLabels);
    }

    // @interface ZDKHelpCenterArticlesDataSource : ZDKHelpCenterDataSource
    [BaseType (typeof (ZDKHelpCenterDataSource))]
    interface ZDKHelpCenterArticlesDataSource {

        // -(instancetype)initWithSectionId:(NSString *)sectionId;
        [Export ("initWithSectionId:")]
        IntPtr Constructor (string sectionId);
    }

    // @interface ZDKHelpCenterAttachment : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterAttachment {

        // @property (nonatomic, strong) NSString * sid;
        [Export ("sid", ArgumentSemantic.Retain)]
        string Sid { get; set; }

        // @property (nonatomic, strong) NSString * url;
        [Export ("url", ArgumentSemantic.Retain)]
        string Url { get; set; }

        // @property (nonatomic, strong) NSString * article_id;
        [Export ("article_id", ArgumentSemantic.Retain)]
        string Article_id { get; set; }

        // @property (nonatomic, strong) NSString * file_name;
        [Export ("file_name", ArgumentSemantic.Retain)]
        string File_name { get; set; }

        // @property (nonatomic, strong) NSString * content_url;
        [Export ("content_url", ArgumentSemantic.Retain)]
        string Content_url { get; set; }

        // @property (nonatomic, strong) NSString * content_type;
        [Export ("content_type", ArgumentSemantic.Retain)]
        string Content_type { get; set; }

        // @property (assign, nonatomic) NSUInteger size;
        [Export ("size", ArgumentSemantic.UnsafeUnretained)]
        nuint Size { get; set; }

        // @property (assign, nonatomic) BOOL isInline;
        [Export ("isInline", ArgumentSemantic.UnsafeUnretained)]
        bool IsInline { get; set; }

        // +(ZDKHelpCenterAttachment *)parseAttachment:(NSDictionary *)attachmentJson;
        [Static, Export ("parseAttachment:")]
        ZDKHelpCenterAttachment ParseAttachment (NSDictionary attachmentJson);

        // +(NSArray *)parseAttachments:(NSDictionary *)json;
        [Static, Export ("parseAttachments:")]
        NSObject [] ParseAttachments (NSDictionary json);

        // -(NSString *)humanReadableFileSize;
        [Export ("humanReadableFileSize")]
        string HumanReadableFileSize ();
    }

    // @interface ZDKHelpCenterAttachmentsDataSource : ZDKHelpCenterDataSource
    [BaseType (typeof (ZDKHelpCenterDataSource))]
    interface ZDKHelpCenterAttachmentsDataSource {

        // -(instancetype)initWithArticleId:(NSString *)articleId;
        [Export ("initWithArticleId:")]
        IntPtr Constructor (string articleId);
    }

    // @interface ZDKHelpCenterCategoriesDataSource : ZDKHelpCenterDataSource
    [BaseType (typeof (ZDKHelpCenterDataSource))]
    interface ZDKHelpCenterCategoriesDataSource {

    }

    // @interface ZDKHelpCenterCategory : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterCategory {

        // @property (nonatomic, strong) NSString * sid;
        [Export ("sid", ArgumentSemantic.Retain)]
        string Sid { get; set; }

        // @property (nonatomic, strong) NSString * name;
        [Export ("name", ArgumentSemantic.Retain)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * categoryDescription;
        [Export ("categoryDescription", ArgumentSemantic.Retain)]
        string CategoryDescription { get; set; }

        // @property (assign, nonatomic) NSInteger position;
        [Export ("position", ArgumentSemantic.UnsafeUnretained)]
        nint Position { get; set; }

        // @property (assign, nonatomic) BOOL outdated;
        [Export ("outdated", ArgumentSemantic.UnsafeUnretained)]
        bool Outdated { get; set; }

        // +(ZDKHelpCenterCategory *)parseCategory:(NSDictionary *)categoryJson;
        [Static, Export ("parseCategory:")]
        ZDKHelpCenterCategory ParseCategory (NSDictionary categoryJson);

        // +(NSArray *)parseCategories:(NSDictionary *)json;
        [Static, Export ("parseCategories:")]
        NSObject [] ParseCategories (NSDictionary json);
    }

    // @interface ZDKHelpCenterSearchDataSource : ZDKHelpCenterDataSource
    [BaseType (typeof (ZDKHelpCenterDataSource))]
    interface ZDKHelpCenterSearchDataSource {

        // -(instancetype)initWithQuery:(NSString *)query;
        [Export ("initWithQuery:")]
        IntPtr Constructor (string query);

        // -(instancetype)initWithQuery:(NSString *)query andLabels:(NSArray *)labels;
        [Export ("initWithQuery:andLabels:")]
        IntPtr Constructor (string query, NSObject [] labels);
    }

    // @interface ZDKHelpCenterSection : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterSection {

        // @property (nonatomic, strong) NSString * sid;
        [Export ("sid", ArgumentSemantic.Retain)]
        string Sid { get; set; }

        // @property (nonatomic, strong) NSString * category_id;
        [Export ("category_id", ArgumentSemantic.Retain)]
        string Category_id { get; set; }

        // @property (nonatomic, strong) NSString * name;
        [Export ("name", ArgumentSemantic.Retain)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * sectionDescription;
        [Export ("sectionDescription", ArgumentSemantic.Retain)]
        string SectionDescription { get; set; }

        // @property (assign, nonatomic) NSInteger position;
        [Export ("position", ArgumentSemantic.UnsafeUnretained)]
        nint Position { get; set; }

        // @property (assign, nonatomic) BOOL outdated;
        [Export ("outdated", ArgumentSemantic.UnsafeUnretained)]
        bool Outdated { get; set; }

        // +(ZDKHelpCenterSection *)parseSection:(NSDictionary *)sectionJson;
        [Static, Export ("parseSection:")]
        ZDKHelpCenterSection ParseSection (NSDictionary sectionJson);

        // +(NSArray *)parseSections:(NSDictionary *)json;
        [Static, Export ("parseSections:")]
        NSObject [] ParseSections (NSDictionary json);
    }

    // @interface ZDKHelpCenterSectionsDataSource : ZDKHelpCenterDataSource
    [BaseType (typeof (ZDKHelpCenterDataSource))]
    interface ZDKHelpCenterSectionsDataSource {

        // -(instancetype)initWithCategoryId:(NSString *)categoryId;
        [Export ("initWithCategoryId:")]
        IntPtr Constructor (string categoryId);
    }

    // @interface ZDKHelpCenterSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKHelpCenterSettings {

        // -(id)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) BOOL enabled;
        [Export ("enabled")]
        bool Enabled { get; }

        // @property (readonly, nonatomic) NSString * locale;
        [Export ("locale")]
        string Locale { get; }
    }

    // @interface ZDKHelpCenterTableDelegate : NSObject <UITableViewDelegate>
    [BaseType (typeof (NSObject))]
    interface ZDKHelpCenterTableDelegate : IUITableViewDelegate {

        // @property (readonly, assign, nonatomic) BOOL blockTouches;
        [Export ("blockTouches", ArgumentSemantic.UnsafeUnretained)]
        bool BlockTouches { get; }
    }

    // @interface ZDKHelpCenterSearchResultTableDelegate : ZDKHelpCenterTableDelegate
    [BaseType (typeof (ZDKHelpCenterTableDelegate))]
    interface ZDKHelpCenterSearchResultTableDelegate {

    }

    // @interface ZDKIdentityStorage : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKIdentityStorage {

//        // @property (nonatomic, strong, getter = storedIdentity, setter = storeIdentity:) id<ZDKIdentity> identity;
//        [Export ("identity", ArgumentSemantic.Retain)]
//        ZDKIdentity Identity { [Bind ("storedIdentity")] get; [Bind ("storeIdentity:")] set; }

        // -(NSString *)getUUID;
        [Export ("getUUID")]
        string GetUUID ();

        // -(NSString *)storedOAuthToken;
        [Export ("storedOAuthToken")]
        string StoredOAuthToken ();

        // -(void)storeOAuthToken:(NSString *)oAuthToken;
        [Export ("storeOAuthToken:")]
        void StoreOAuthToken (string oAuthToken);

        // -(void)deleteStoredData;
        [Export ("deleteStoredData")]
        void DeleteStoredData ();
    }

    // @interface ZDKImageViewerViewController : ZDKUIViewController <UIScrollViewDelegate>
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKImageViewerViewController : IUIScrollViewDelegate {

        // -(instancetype)initWithImage:(UIImage *)image;
        [Export ("initWithImage:")]
        IntPtr Constructor (UIImage image);

        // -(void)dismiss;
        [Export ("dismiss")]
        void Dismiss ();
    }

    // @interface ZDKJsonUtil : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKJsonUtil {

        // +(id)cleanJSONVal:(NSDictionary *)json key:(NSString *)key;
        [Static, Export ("cleanJSONVal:key:")]
        NSObject CleanJSONVal (NSDictionary json, string key);

        // +(id)cleanJSONVal:(id)val;
        [Static, Export ("cleanJSONVal:")]
        NSObject CleanJSONVal (NSObject val);

        // +(id)convertJsonObject:(NSDictionary *)json toObjectOfType:(Class)classToMap;
        [Static, Export ("convertJsonObject:toObjectOfType:")]
        NSObject ConvertJsonObject (NSDictionary json, Class classToMap);

        // +(NSMutableArray *)convertArrayOfJsonObjects:(NSArray *)jsonArray toArrayOfType:(Class)classToMap;
        [Static, Export ("convertArrayOfJsonObjects:toArrayOfType:")]
        NSMutableArray ConvertArrayOfJsonObjects (NSObject [] jsonArray, Class classToMap);

        // +(NSDictionary *)convertObjectToDictionary:(id)objectToConvert forClass:(Class)aClass;
        [Static, Export ("convertObjectToDictionary:forClass:")]
        NSDictionary ConvertObjectToDictionary (NSObject objectToConvert, Class aClass);

        // +(NSMutableArray *)arrayWithPropertiesOfObject:(Class)aClass;
        [Static, Export ("arrayWithPropertiesOfObject:")]
        NSMutableArray ArrayWithPropertiesOfObject (Class aClass);
    }

    // @interface ZDKJwtIdentity : ZDKCoding <ZDKIdentity>
    [BaseType (typeof (ZDKCoding))]
    interface ZDKJwtIdentity : ZDKIdentity {

        // -(instancetype)initWithJwtUserIdentifier:(NSString *)jwtUserIdentifier;
        [Export ("initWithJwtUserIdentifier:")]
        IntPtr Constructor (string jwtUserIdentifier);
    }

    // @interface ZDKKeychainWrapper : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKKeychainWrapper {

        // -(id)initWithIdentifier:(NSString *)identifier accessGroup:(NSString *)accessGroup;
        [Export ("initWithIdentifier:accessGroup:")]
        IntPtr Constructor (string identifier, string accessGroup);

        // @property (retain, nonatomic) NSMutableDictionary * keychainItemData;
        [Export ("keychainItemData", ArgumentSemantic.Retain)]
        NSMutableDictionary KeychainItemData { get; set; }

        // @property (retain, nonatomic) NSMutableDictionary * genericPasswordQuery;
        [Export ("genericPasswordQuery", ArgumentSemantic.Retain)]
        NSMutableDictionary GenericPasswordQuery { get; set; }

        // -(void)setObject:(id)inObject forKey:(id)key;
        [Export ("setObject:forKey:")]
        void SetObject (NSObject inObject, NSObject key);

        // -(id)objectForKey:(id)key;
        [Export ("objectForKey:")]
        NSObject ObjectForKey (NSObject key);

        // -(void)resetKeychainItem;
        [Export ("resetKeychainItem")]
        void ResetKeychainItem ();
    }

    // @interface ZDKLogger : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKLogger {

        // +(void)log:(NSString *)format, ...;
        [Static, Export ("log:")]
        void Log (string format);

        // +(void)enable:(BOOL)enabled;
        [Static, Export ("enable:")]
        void Enable (bool enabled);
    }

    // @interface ZDKNSCodingUtil : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKNSCodingUtil {

        // +(void)encodeWithCoder:(NSCoder *)aCoder forInstance:(NSObject *)instance;
        [Static, Export ("encodeWithCoder:forInstance:")]
        void EncodeWithCoder (NSCoder aCoder, NSObject instance);

        // +(void)decodeWithCoder:(NSCoder *)aDecoder forInstance:(NSObject *)instance;
        [Static, Export ("decodeWithCoder:forInstance:")]
        void DecodeWithCoder (NSCoder aDecoder, NSObject instance);
    }

    // @interface ZDKRateMyAppSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKRateMyAppSettings {

        // -(id)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) BOOL enabled;
        [Export ("enabled")]
        bool Enabled { get; }

        // @property (readonly, nonatomic) NSNumber * visits;
        [Export ("visits")]
        NSNumber Visits { get; }

        // @property (readonly, nonatomic) NSNumber * duration;
        [Export ("duration")]
        NSNumber Duration { get; }

        // @property (readonly, nonatomic) NSNumber * delay;
        [Export ("delay")]
        NSNumber Delay { get; }

        // @property (readonly, nonatomic) NSArray * tags;
        [Export ("tags")]
        NSObject [] Tags { get; }

        // @property (readonly, nonatomic) NSString * appStoreUrl;
        [Export ("appStoreUrl")]
        string AppStoreUrl { get; }
    }

    // @interface ZDKReachability : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKReachability {

        // +(instancetype)reachabilityWithHostName:(NSString *)hostName;
        [Static, Export ("reachabilityWithHostName:")]
        ZDKReachability ReachabilityWithHostName (string hostName);

//        // +(instancetype)reachabilityWithAddress:(const struct sockaddr_in *)hostAddress;
//        [Static, Export ("reachabilityWithAddress:")]
//        ZDKReachability ReachabilityWithAddress (sockaddr_in hostAddress);

        // +(instancetype)reachabilityForInternetConnection;
        [Static, Export ("reachabilityForInternetConnection")]
        ZDKReachability ReachabilityForInternetConnection ();

        // +(instancetype)reachabilityForLocalWiFi;
        [Static, Export ("reachabilityForLocalWiFi")]
        ZDKReachability ReachabilityForLocalWiFi ();

        // -(BOOL)startNotifier;
        [Export ("startNotifier")]
        bool StartNotifier ();

        // -(void)stopNotifier;
        [Export ("stopNotifier")]
        void StopNotifier ();

        // -(ZDKNetworkStatus)currentReachabilityStatus;
        [Export ("currentReachabilityStatus")]
        ZDKNetworkStatus CurrentReachabilityStatus ();

        // -(BOOL)connectionRequired;
        [Export ("connectionRequired")]
        bool ConnectionRequired ();
    }

    // @interface ZDKRequestCommentTableCell : UITableViewCell
    [BaseType (typeof (UITableViewCell))]
    interface ZDKRequestCommentTableCell {

        // @property (nonatomic, strong) UILabel * body;
        [Export ("body", ArgumentSemantic.Retain)]
        UILabel Body { get; set; }

        // @property (nonatomic, strong) UILabel * timestamp;
        [Export ("timestamp", ArgumentSemantic.Retain)]
        UILabel Timestamp { get; set; }

        // -(void)prepareUsingCommentWithUser:(ZDKCommentWithUser *)commentWithUser;
        [Export ("prepareUsingCommentWithUser:")]
        void PrepareUsingCommentWithUser (ZDKCommentWithUser commentWithUser);

        // +(NSString *)reuseId;
        [Static, Export ("reuseId")]
        string ReuseId ();
    }

    // @interface ZDKAgentCommentTableCell : ZDKRequestCommentTableCell
    [BaseType (typeof (ZDKRequestCommentTableCell))]
    interface ZDKAgentCommentTableCell {

        // @property (nonatomic, strong) NSMutableDictionary * avatarCache;
        [Export ("avatarCache", ArgumentSemantic.Retain)]
        NSMutableDictionary AvatarCache { get; set; }

        // @property (nonatomic, strong) UIImageView * avatar;
        [Export ("avatar", ArgumentSemantic.Retain)]
        UIImageView Avatar { get; set; }

        // @property (nonatomic, strong) UILabel * author;
        [Export ("author", ArgumentSemantic.Retain)]
        UILabel Author { get; set; }

        // @property (nonatomic, strong) NSNumber * avatarSize;
        [Export ("avatarSize", ArgumentSemantic.Retain)]
        NSNumber AvatarSize { get; set; }

        // @property (nonatomic, strong) UIFont * agentNameFont;
        [Export ("agentNameFont", ArgumentSemantic.Retain)]
        UIFont AgentNameFont { get; set; }

        // @property (nonatomic, strong) UIColor * agentNameColor;
        [Export ("agentNameColor", ArgumentSemantic.Retain)]
        UIColor AgentNameColor { get; set; }

        // @property (nonatomic, strong) UIFont * bodyFont;
        [Export ("bodyFont", ArgumentSemantic.Retain)]
        UIFont BodyFont { get; set; }

        // @property (nonatomic, strong) UIColor * bodyColor;
        [Export ("bodyColor", ArgumentSemantic.Retain)]
        UIColor BodyColor { get; set; }

        // @property (nonatomic, strong) UIFont * timestampFont;
        [Export ("timestampFont", ArgumentSemantic.Retain)]
        UIFont TimestampFont { get; set; }

        // @property (nonatomic, strong) UIColor * timestampColor;
        [Export ("timestampColor", ArgumentSemantic.Retain)]
        UIColor TimestampColor { get; set; }

        // @property (nonatomic, strong) UIColor * cellBackground;
        [Export ("cellBackground", ArgumentSemantic.Retain)]
        UIColor CellBackground { get; set; }

        // +(CGFloat)cellHeightForCommentWithUser:(ZDKCommentWithUser *)commentWithUser inWidth:(CGFloat)width;
        [Static, Export ("cellHeightForCommentWithUser:inWidth:")]
        nfloat CellHeightForCommentWithUser (ZDKCommentWithUser commentWithUser, nfloat width);
    }

    // @interface ZDKEndUserCommentTableCell : ZDKRequestCommentTableCell
    [BaseType (typeof (ZDKRequestCommentTableCell))]
    interface ZDKEndUserCommentTableCell {

        // @property (nonatomic, strong) UIFont * bodyFont;
        [Export ("bodyFont", ArgumentSemantic.Retain)]
        UIFont BodyFont { get; set; }

        // @property (nonatomic, strong) UIColor * bodyColor;
        [Export ("bodyColor", ArgumentSemantic.Retain)]
        UIColor BodyColor { get; set; }

        // @property (nonatomic, strong) UIFont * timestampFont;
        [Export ("timestampFont", ArgumentSemantic.Retain)]
        UIFont TimestampFont { get; set; }

        // @property (nonatomic, strong) UIColor * timestampColor;
        [Export ("timestampColor", ArgumentSemantic.Retain)]
        UIColor TimestampColor { get; set; }

        // @property (nonatomic, strong) UIColor * cellBackground;
        [Export ("cellBackground", ArgumentSemantic.Retain)]
        UIColor CellBackground { get; set; }

        // +(CGFloat)cellHeightForCommentWithUser:(ZDKCommentWithUser *)commentWithUser inWidth:(CGFloat)width;
        [Static, Export ("cellHeightForCommentWithUser:inWidth:")]
        nfloat CellHeightForCommentWithUser (ZDKCommentWithUser commentWithUser, nfloat width);
    }

    // @protocol ZDKCommentListRetryDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKCommentListRetryDelegate {

        // @required -(void)refresh;
        [Export ("refresh")]
        [Abstract]
        void Refresh ();
    }

    // @interface ZDKCommentsListLoadingTableCell : UITableViewCell
    [BaseType (typeof (UITableViewCell))]
    interface ZDKCommentsListLoadingTableCell {

        // @property (nonatomic, strong) NSNumber * leftInset;
        [Export ("leftInset", ArgumentSemantic.Retain)]
        NSNumber LeftInset { get; set; }

        // @property (nonatomic, strong) id<ZDKSpinnerDelegate> spinner;
        [Export ("spinner", ArgumentSemantic.Retain)]
        ZDKSpinnerDelegate Spinner { get; set; }

        // @property (nonatomic, strong) UIColor * cellBackground;
        [Export ("cellBackground", ArgumentSemantic.Retain)]
        UIColor CellBackground { get; set; }
    }

    // @interface ZDKRequestCommentAttachmentLoadingTableCell : ZDKRequestCommentTableCell
    [BaseType (typeof (ZDKRequestCommentTableCell))]
    interface ZDKRequestCommentAttachmentLoadingTableCell {

        // +(CGFloat)cellHeightForCommentWithAttachment:(CGFloat)width;
        [Static, Export ("cellHeightForCommentWithAttachment:")]
        nfloat CellHeightForCommentWithAttachment (nfloat width);
    }

    // @interface ZDKRequestCommentAttachmentTableCell : ZDKRequestCommentTableCell
    [BaseType (typeof (ZDKRequestCommentTableCell))]
    interface ZDKRequestCommentAttachmentTableCell {

        // -(void)prepareWithImage:(UIImage *)attachment;
        [Export ("prepareWithImage:")]
        void PrepareWithImage (UIImage attachment);

        // +(CGFloat)virticlePadding;
        [Static, Export ("virticlePadding")]
        nfloat VirticlePadding ();
    }

    // @interface ZDKRequestCommentsTable : UITableView <UITableViewDataSource, UITableViewDelegate, ZDKCommentListRetryDelegate>
    [BaseType (typeof (UITableView))]
    interface ZDKRequestCommentsTable : IUITableViewDataSource, IUITableViewDelegate, ZDKCommentListRetryDelegate {

        // -(instancetype)initWithFrame:(CGRect)frame andRequest:(ZDKRequest *)theRequest;
        [Export ("initWithFrame:andRequest:")]
        IntPtr Constructor (CGRect frame, ZDKRequest theRequest);

        // @property (nonatomic, strong) NSMutableDictionary * avatarCache;
        [Export ("avatarCache", ArgumentSemantic.Retain)]
        NSMutableDictionary AvatarCache { get; set; }

        // @property (nonatomic, strong) ZDKRequest * request;
        [Export ("request", ArgumentSemantic.Retain)]
        ZDKRequest Request { get; set; }

        // @property (nonatomic, strong) NSMutableArray * comments;
        [Export ("comments", ArgumentSemantic.Retain)]
        NSMutableArray Comments { get; set; }

        // @property (assign, nonatomic) BOOL loadingInProgress;
        [Export ("loadingInProgress", ArgumentSemantic.UnsafeUnretained)]
        bool LoadingInProgress { get; set; }

        // @property (assign, nonatomic) BOOL fetchCommentsErrored;
        [Export ("fetchCommentsErrored", ArgumentSemantic.UnsafeUnretained)]
        bool FetchCommentsErrored { get; set; }

        // @property (retain, nonatomic) NSString * errorString;
        [Export ("errorString", ArgumentSemantic.Retain)]
        string ErrorString { get; set; }

        // @property (nonatomic, strong) UIColor * tableSeparatorColor;
        [Export ("tableSeparatorColor", ArgumentSemantic.Retain)]
        UIColor TableSeparatorColor { get; set; }

        // @property (nonatomic, strong) UIColor * viewBackgroundColor;
        [Export ("viewBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ViewBackgroundColor { get; set; }
    }

    // @interface ZDKRequestCommentsView : UIView <UITextViewDelegate>
    [BaseType (typeof (UIView))]
    interface ZDKRequestCommentsView : IUITextViewDelegate {

        // -(instancetype)initWithFrame:(CGRect)frame andRequest:(ZDKRequest *)theRequest;
        [Export ("initWithFrame:andRequest:")]
        IntPtr Constructor (CGRect frame, ZDKRequest theRequest);

        // @property (nonatomic, strong) ZDKRequest * request;
        [Export ("request", ArgumentSemantic.Retain)]
        ZDKRequest Request { get; set; }

        // @property (nonatomic, strong) ZDKRequestCommentsTable * commentsTable;
        [Export ("commentsTable", ArgumentSemantic.Retain)]
        ZDKRequestCommentsTable CommentsTable { get; set; }

        // @property (nonatomic, strong) ZDKCommentEntryView * commentEntryView;
        [Export ("commentEntryView", ArgumentSemantic.Retain)]
        ZDKCommentEntryView CommentEntryView { get; set; }
    }

    // @interface ZDKRequestCommentsViewController : ZDKUIViewController
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKRequestCommentsViewController {

        // -(instancetype)initWithRequest:(ZDKRequest *)request;
        [Export ("initWithRequest:")]
        IntPtr Constructor (ZDKRequest request);

        // @property (nonatomic, strong) ZDKRequest * request;
        [Export ("request", ArgumentSemantic.Retain)]
        ZDKRequest Request { get; set; }

        // @property (nonatomic, strong) ZDKRequestCommentsView * commentsView;
        [Export ("commentsView", ArgumentSemantic.Retain)]
        ZDKRequestCommentsView CommentsView { get; set; }
    }

    // @interface ZDKRequestListTableCell : UITableViewCell
    [BaseType (typeof (UITableViewCell))]
    interface ZDKRequestListTableCell {

        // @property (nonatomic, strong) UIView * unreadView;
        [Export ("unreadView", ArgumentSemantic.Retain)]
        UIView UnreadView { get; set; }

        // @property (nonatomic, strong) UILabel * requestDescription;
        [Export ("requestDescription", ArgumentSemantic.Retain)]
        UILabel RequestDescription { get; set; }

        // @property (nonatomic, strong) UILabel * createdAt;
        [Export ("createdAt", ArgumentSemantic.Retain)]
        UILabel CreatedAt { get; set; }

        // @property (nonatomic, strong) UIFont * descriptionFont;
        [Export ("descriptionFont", ArgumentSemantic.Retain)]
        UIFont DescriptionFont { get; set; }

        // @property (nonatomic, strong) UIFont * createdAtFont;
        [Export ("createdAtFont", ArgumentSemantic.Retain)]
        UIFont CreatedAtFont { get; set; }

        // @property (nonatomic, strong) UIColor * unreadColor;
        [Export ("unreadColor", ArgumentSemantic.Retain)]
        UIColor UnreadColor { get; set; }

        // @property (nonatomic, strong) UIColor * descriptionColor;
        [Export ("descriptionColor", ArgumentSemantic.Retain)]
        UIColor DescriptionColor { get; set; }

        // @property (nonatomic, strong) UIColor * createdAtColor;
        [Export ("createdAtColor", ArgumentSemantic.Retain)]
        UIColor CreatedAtColor { get; set; }

        // @property (nonatomic, strong) NSNumber * verticalMargin;
        [Export ("verticalMargin", ArgumentSemantic.Retain)]
        NSNumber VerticalMargin { get; set; }

        // @property (nonatomic, strong) NSNumber * descriptionTimestampMargin;
        [Export ("descriptionTimestampMargin", ArgumentSemantic.Retain)]
        NSNumber DescriptionTimestampMargin { get; set; }

        // @property (nonatomic, strong) NSNumber * leftInset;
        [Export ("leftInset", ArgumentSemantic.Retain)]
        NSNumber LeftInset { get; set; }

        // @property (nonatomic, strong) UIColor * cellBackgroundColor;
        [Export ("cellBackgroundColor", ArgumentSemantic.Retain)]
        UIColor CellBackgroundColor { get; set; }

        // -(void)prepareWithRequest:(ZDKRequest *)request;
        [Export ("prepareWithRequest:")]
        void PrepareWithRequest (ZDKRequest request);
    }

    // @interface ZDRequestListEmptyTableCell : UITableViewCell
    [BaseType (typeof (UITableViewCell))]
    interface ZDRequestListEmptyTableCell {

        // @property (nonatomic, strong) UILabel * messageLabel;
        [Export ("messageLabel", ArgumentSemantic.Retain)]
        UILabel MessageLabel { get; set; }

        // @property (nonatomic, strong) UIFont * messageFont;
        [Export ("messageFont", ArgumentSemantic.Retain)]
        UIFont MessageFont { get; set; }

        // @property (nonatomic, strong) UIColor * messageColor;
        [Export ("messageColor", ArgumentSemantic.Retain)]
        UIColor MessageColor { get; set; }
    }

    // @protocol ZDRequestListRetryDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDRequestListRetryDelegate {

        // @required -(void)refresh;
        [Export ("refresh")]
        [Abstract]
        void Refresh ();
    }

    // @interface ZDRequestListLoadingTableCell : UITableViewCell
    [BaseType (typeof (UITableViewCell))]
    interface ZDRequestListLoadingTableCell {

        // @property (nonatomic, strong) id<ZDKSpinnerDelegate> spinner;
        [Export ("spinner", ArgumentSemantic.Retain)]
        ZDKSpinnerDelegate Spinner { get; set; }
    }

    // @interface ZDKRequestListTable : UITableView <UITableViewDataSource, UITableViewDelegate, ZDRequestListRetryDelegate>
    [BaseType (typeof (UITableView))]
    interface ZDKRequestListTable : IUITableViewDataSource, IUITableViewDelegate, ZDRequestListRetryDelegate {

        // @property (nonatomic, strong) NSArray * requests;
        [Export ("requests", ArgumentSemantic.Retain)]
        NSObject [] Requests { get; set; }

        // @property (assign, nonatomic) BOOL refreshError;
        [Export ("refreshError", ArgumentSemantic.UnsafeUnretained)]
        bool RefreshError { get; set; }

        // @property (nonatomic, strong) NSString * errorString;
        [Export ("errorString", ArgumentSemantic.Retain)]
        string ErrorString { get; set; }

        // @property (assign, nonatomic) BOOL loadingInProgress;
        [Export ("loadingInProgress", ArgumentSemantic.UnsafeUnretained)]
        bool LoadingInProgress { get; set; }

        // @property (nonatomic, strong) UIColor * cellSeparatorColor;
        [Export ("cellSeparatorColor", ArgumentSemantic.Retain)]
        UIColor CellSeparatorColor { get; set; }

        // @property (nonatomic, strong) UIColor * tableBackgroundColor;
        [Export ("tableBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TableBackgroundColor { get; set; }

        // -(void)refresh;
        [Export ("refresh")]
        void Refresh ();

        // -(CGFloat)tableHeight;
        [Export ("tableHeight")]
        nfloat TableHeight ();

        // -(CGFloat)cellHeight;
        [Export ("cellHeight")]
        nfloat CellHeight ();

        // -(void)registerForEvents:(id)observer withSelector:(SEL)selector;
        [Export ("registerForEvents:withSelector:")]
        void RegisterForEvents (NSObject observer, Selector selector);

        // -(void)unregisterForEvents:(id)observer;
        [Export ("unregisterForEvents:")]
        void UnregisterForEvents (NSObject observer);
    }

//    // @protocol ZDKCreateRequestUIDelegate <NSObject>
//    [Protocol, Model]
//    [BaseType (typeof (NSObject))]
//    interface ZDKCreateRequestUIDelegate {
//
//    }

    // @interface ZDKRequestListViewController : ZDKUIViewController
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKRequestListViewController {

        // @property (nonatomic, strong) UIScrollView * requestListContainer;
        [Export ("requestListContainer", ArgumentSemantic.Retain)]
        UIScrollView RequestListContainer { get; set; }

        // @property (nonatomic, strong) ZDKRequestListTable * requestList;
        [Export ("requestList", ArgumentSemantic.Retain)]
        ZDKRequestListTable RequestList { get; set; }

        // @property (nonatomic, weak) id<ZDKCreateRequestUIDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.Weak)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, weak) id<ZDKCreateRequestUIDelegate> delegate;
        [Wrap ("WeakDelegate")]
        ZDKCreateRequestUIDelegate Delegate { get; set; }
    }

    // @interface ZDKRequestProvider : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRequestProvider {

        // -(void)createRequestWithSubject:(NSString *)subject andDescription:(NSString *)description andTags:(NSArray *)tags andCallback:(ZDKCreateRequestCallback)callback;
        [Export ("createRequestWithSubject:andDescription:andTags:andCallback:")]
        void CreateRequestWithSubject (string subject, string description, NSObject [] tags, Action<NSObject, NSError> callback);

        // -(void)createRequestWithSubject:(NSString *)subject description:(NSString *)description tags:(NSArray *)tags attachments:(NSArray *)attachments andCallback:(ZDKCreateRequestCallback)callback;
        [Export ("createRequestWithSubject:description:tags:attachments:andCallback:")]
        void CreateRequestWithSubject (string subject, string description, NSObject [] tags, NSObject [] attachments, Action<NSObject, NSError> callback);

        // -(void)getAllRequestsWithCallback:(ZDKRequestListCallback)callback;
        [Export ("getAllRequestsWithCallback:")]
        void GetAllRequestsWithCallback (Action<NSArray, NSError> callback);

        // -(void)getRequestsByStatus:(NSString *)status withCallback:(ZDKRequestListCallback)callback;
        [Export ("getRequestsByStatus:withCallback:")]
        void GetRequestsByStatus (string status, Action<NSArray, NSError> callback);

        // -(void)getCommentsWithRequestId:(NSString *)requestId withCallback:(ZDKRequestCommentListCallback)callback;
        [Export ("getCommentsWithRequestId:withCallback:")]
        void GetCommentsWithRequestId (string requestId, Action<NSArray, NSError> callback);

        // -(void)addComment:(NSString *)comment forRequestId:(NSString *)requestId withCallback:(ZDKRequestAddCommentCallback)callback;
        [Export ("addComment:forRequestId:withCallback:")]
        void AddComment (string comment, string requestId, Action<ZDKComment, NSError> callback);

        // -(void)addComment:(NSString *)comment forRequestId:(NSString *)requestId attachments:(NSArray *)attachments withCallback:(ZDKRequestAddCommentCallback)callback;
        [Export ("addComment:forRequestId:attachments:withCallback:")]
        void AddComment (string comment, string requestId, NSObject [] attachments, Action<ZDKComment, NSError> callback);
    }

    // @interface ZDKRequestCreationConfig : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRequestCreationConfig {

        // @property (strong) NSArray * tags;
        [Export ("tags", ArgumentSemantic.Retain)]
        NSObject [] Tags { get; set; }

        // @property (strong) NSString * additionalRequestInfo;
        [Export ("additionalRequestInfo", ArgumentSemantic.Retain)]
        string AdditionalRequestInfo { get; set; }

        // -(NSString *)contentSeperator;
        [Export ("contentSeperator")]
        string ContentSeperator ();
    }

    // @interface ZDKRequests : NSObject <ZDKCreateRequestUIDelegate>
    [BaseType (typeof (NSObject))]
    interface ZDKRequests : ZDKCreateRequestUIDelegate {

        // @property (strong) ZDKRequestCreationConfig * requestCreationConfig;
        [Export ("requestCreationConfig", ArgumentSemantic.Retain)]
        ZDKRequestCreationConfig RequestCreationConfig { get; set; }

        // +(instancetype)instance;
        [Static, Export ("instance")]
        ZDKRequests Instance ();

        // +(void)configure:(ZDSDKConfigBlock)config;
        [Static, Export ("configure:")]
        void Configure (Action<ZDKAccount, ZDKRequestCreationConfig> config);

        // +(void)showRequestCreationWithNavController:(UINavigationController *)navController;
        [Static, Export ("showRequestCreationWithNavController:")]
        void ShowRequestCreationWithNavController (UINavigationController navController);

        // +(void)showRequestCreationWithNavController:(UINavigationController *)navController withSuccess:(ZDKAPISuccess)success andError:(ZDKAPIError)error;
        [Static, Export ("showRequestCreationWithNavController:withSuccess:andError:")]
        void ShowRequestCreationWithNavController (UINavigationController navController, Action<NSObject> success, Action<NSError> error);

        // +(void)presentRequestListWithNavController:(UINavigationController *)navController;
        [Static, Export ("presentRequestListWithNavController:")]
        void PresentRequestListWithNavController (UINavigationController navController);

        // +(void)showRequestListWithNavController:(UINavigationController *)navController;
        [Static, Export ("showRequestListWithNavController:")]
        void ShowRequestListWithNavController (UINavigationController navController);

        // +(void)showRequestListWithNavController:(UINavigationController *)navController layoutGudie:(ZDKLayoutGuide)aGuide;
        [Static, Export ("showRequestListWithNavController:layoutGudie:")]
        void ShowRequestListWithNavController (UINavigationController navController, ZDKLayoutGuide aGuide);

        // +(ZDKRequestListTable *)newRequestListWith:(id)observer andSelector:(SEL)selector;
        [Static, Export ("newRequestListWith:andSelector:")]
        ZDKRequestListTable NewRequestListWith (NSObject observer, Selector selector);

        // +(void)setNewRequestBarButtonImage:(NSString *)name;
        [Static, Export ("setNewRequestBarButtonImage:")]
        void SetNewRequestBarButtonImage (string name);

        // +(void)setNavBarCreateRequestUIType:(ZDKNavBarCreateRequestUIType)uiType;
        [Static, Export ("setNavBarCreateRequestUIType:")]
        void SetNavBarCreateRequestUIType (ZDKNavBarCreateRequestUIType uiType);
    }

    // @interface ZDKRequestsResponse : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRequestsResponse {

        // +(NSArray *)parseRequestListWithDictionary:(NSDictionary *)dictionary;
        [Static, Export ("parseRequestListWithDictionary:")]
        NSObject [] ParseRequestListWithDictionary (NSDictionary dictionary);
    }

    // @interface ZDKRequestStorage : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRequestStorage {

        // -(void)storeRequestIdentifier:(NSString *)requestIdentifier;
        [Export ("storeRequestIdentifier:")]
        void StoreRequestIdentifier (string requestIdentifier);

        // -(NSArray *)getRequestIdentifiers;
        [Export ("getRequestIdentifiers")]
        NSObject [] GetRequestIdentifiers ();

        // -(NSDate *)lastReadDateUsingRequestId:(NSString *)requestId;
        [Export ("lastReadDateUsingRequestId:")]
        NSDate LastReadDateUsingRequestId (string requestId);

        // -(void)setLastReadDateUsingRequestId:(NSString *)requestId andDate:(NSDate *)date;
        [Export ("setLastReadDateUsingRequestId:andDate:")]
        void SetLastReadDateUsingRequestId (string requestId, NSDate date);

        // -(void)deleteStoredData;
        [Export ("deleteStoredData")]
        void DeleteStoredData ();
    }

    // @interface ZDKUploadResponse : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKUploadResponse {

        // -(instancetype)initWithDict:(NSDictionary *)dict;
        [Export ("initWithDict:")]
        IntPtr Constructor (NSDictionary dict);

        // @property (nonatomic, strong) NSString * uploadToken;
        [Export ("uploadToken", ArgumentSemantic.Retain)]
        string UploadToken { get; set; }

        // @property (nonatomic, strong) ZDKAttachment * attachment;
        [Export ("attachment", ArgumentSemantic.Retain)]
        ZDKAttachment Attachment { get; set; }
    }

    // @interface ZDKUploadProvider : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKUploadProvider {

        // -(void)uploadAttachment:(NSData *)attachment withFilename:(NSString *)filename andContentType:(NSString *)contentType callback:(ZDKUploadCallback)callback;
        [Export ("uploadAttachment:withFilename:andContentType:callback:")]
        void UploadAttachment (NSData attachment, string filename, string contentType, Action<ZDKUploadResponse, NSError> callback);

        // -(void)deleteUpload:(NSString *)uploadToken andCallback:(ZDKDeleteUploadCallback)callback;
        [Export ("deleteUpload:andCallback:")]
        void DeleteUpload (string uploadToken, Action<NSString, NSError> callback);
    }

    // @interface ZDKRequestWithAttachmentsUtil : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRequestWithAttachmentsUtil {

        // -(void)uploadAttachment:(NSData *)data withFilename:(NSString *)filename andContentType:(NSString *)contentType callback:(ZDKUploadCallback)callback;
        [Export ("uploadAttachment:withFilename:andContentType:callback:")]
        void UploadAttachment (NSData data, string filename, string contentType, Action<ZDKUploadResponse, NSError> callback);

        // -(void)createRequest:(ZDKRequest *)request withTags:(NSArray *)tags andCallback:(ZDKCreateRequestCallback)callback;
        [Export ("createRequest:withTags:andCallback:")]
        void CreateRequest (ZDKRequest request, NSObject [] tags, Action<NSObject, NSError> callback);

        // -(void)addComment:(ZDKComment *)comment forRequestId:(NSString *)requestId withCallback:(ZDKRequestAddCommentCallback)callback;
        [Export ("addComment:forRequestId:withCallback:")]
        void AddComment (ZDKComment comment, string requestId, Action<ZDKComment, NSError> callback);

        // -(void)deleteFilename:(NSString *)filename;
        [Export ("deleteFilename:")]
        void DeleteFilename (string filename);

        // -(NSString *)MIMETypeForData:(NSData *)data;
        [Export ("MIMETypeForData:")]
        string MIMETypeForData (NSData data);
    }

    // @interface ZDKRMADataObject : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRMADataObject {

        // @property (assign, nonatomic) ZDKRMAAction chosenZDKRMAAction;
        [Export ("chosenZDKRMAAction", ArgumentSemantic.UnsafeUnretained)]
        ZDKRMAAction ChosenZDKRMAAction { get; set; }

        // @property (retain, nonatomic) NSNumber * visitCount;
        [Export ("visitCount", ArgumentSemantic.Retain)]
        NSNumber VisitCount { get; set; }

        // @property (retain, nonatomic) NSDate * initialCheckDate;
        [Export ("initialCheckDate", ArgumentSemantic.Retain)]
        NSDate InitialCheckDate { get; set; }

        // @property (retain, nonatomic) NSDate * dateOfActionChosen;
        [Export ("dateOfActionChosen", ArgumentSemantic.Retain)]
        NSDate DateOfActionChosen { get; set; }

        // @property (retain, nonatomic) NSString * requestText;
        [Export ("requestText", ArgumentSemantic.Retain)]
        string RequestText { get; set; }

        // @property (retain, nonatomic) NSString * appVersion;
        [Export ("appVersion", ArgumentSemantic.Retain)]
        string AppVersion { get; set; }

        // +(NSString *)currentAppVersion;
        [Static, Export ("currentAppVersion")]
        string CurrentAppVersion ();

        // +(NSString *)currentAppBuild;
        [Static, Export ("currentAppBuild")]
        string CurrentAppBuild ();

        // -(void)storeChosenAction:(ZDKRMAAction)action;
        [Export ("storeChosenAction:")]
        void StoreChosenAction (ZDKRMAAction action);
    }

    // @interface ZDKRMAConfigObject : NSObject <NSCopying>
    [BaseType (typeof (NSObject))]
    interface ZDKRMAConfigObject : INSCopying {

        // @property (readonly, nonatomic, getter = isEnabled) BOOL enabled;
        [Export ("enabled")]
        bool Enabled { [Bind ("isEnabled")] get; }

        // @property (readonly, nonatomic, strong) NSNumber * minimumVisits;
        [Export ("minimumVisits", ArgumentSemantic.Retain)]
        NSNumber MinimumVisits { get; }

        // @property (readonly, nonatomic, strong) NSNumber * minimumDays;
        [Export ("minimumDays", ArgumentSemantic.Retain)]
        NSNumber MinimumDays { get; }

        // @property (readonly, nonatomic, strong) NSString * itunesAppId;
        [Export ("itunesAppId", ArgumentSemantic.Retain)]
        string ItunesAppId { get; }

        // @property (readonly, nonatomic, strong) NSNumber * displayDelay;
        [Export ("displayDelay", ArgumentSemantic.Retain)]
        NSNumber DisplayDelay { get; }

        // @property (readonly, nonatomic, strong) NSArray * serverConfigTags;
        [Export ("serverConfigTags", ArgumentSemantic.Retain)]
        NSObject [] ServerConfigTags { get; }

        // @property (nonatomic, strong) NSArray * additionalTags;
        [Export ("additionalTags", ArgumentSemantic.Retain)]
        NSObject [] AdditionalTags { get; set; }

        // @property (nonatomic, strong) NSString * additionalRequestInfo;
        [Export ("additionalRequestInfo", ArgumentSemantic.Retain)]
        string AdditionalRequestInfo { get; set; }

        // @property (nonatomic, strong) NSArray * dialogActions;
        [Export ("dialogActions", ArgumentSemantic.Retain)]
        NSObject [] DialogActions { get; set; }

        // @property (nonatomic, strong) NSString * successImageName;
        [Export ("successImageName", ArgumentSemantic.Retain)]
        string SuccessImageName { get; set; }

        // @property (nonatomic, strong) NSString * errorImageName;
        [Export ("errorImageName", ArgumentSemantic.Retain)]
        string ErrorImageName { get; set; }

        // @property (readonly, copy, nonatomic) ShouldShow shouldShowBlock;
        [Export ("shouldShowBlock", ArgumentSemantic.Copy)]
        Func<NSNumber, NSDate, NSDate, ZDKRMAAction, NSString, bool> ShouldShowBlock { get; }

        // @property (copy, nonatomic) SendFeedback sendFeedbackBlock;
        [Export ("sendFeedbackBlock", ArgumentSemantic.Copy)]
        Action<NSString> SendFeedbackBlock { get; set; }

        // +(NSArray *)arrayWithZDKRMAActions:(ZDKRMAAction)action, ...;
        [Static, Export ("arrayWithZDKRMAActions:")]
        NSObject [] ArrayWithZDKRMAActions (ZDKRMAAction action);

        // +(NSInteger)daysBetweenDate:(NSDate *)fromDate andDate:(NSDate *)toDate;
        [Static, Export ("daysBetweenDate:andDate:")]
        nint DaysBetweenDate (NSDate fromDate, NSDate toDate);

        // -(NSArray *)tagList;
        [Export ("tagList")]
        NSObject [] TagList ();
    }

    // @protocol ZDKRMAFeedbackViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKRMAFeedbackViewDelegate {

        // @required -(void)sendFeedback:(NSString *)feedback;
        [Export ("sendFeedback:")]
        [Abstract]
        void SendFeedback (string feedback);

        // @required -(void)back;
        [Export ("back")]
        [Abstract]
        void Back ();

        // @required -(void)closeDialog;
        [Export ("closeDialog")]
        [Abstract]
        void CloseDialog ();
    }

    // @interface ZDKRMAFeedbackView : UIView <UITextViewDelegate>
    [BaseType (typeof (UIView))]
    interface ZDKRMAFeedbackView : IUITextViewDelegate {

        // -(instancetype)initWithDelegate:(id<ZDKRMAFeedbackViewDelegate>)del;
        [Export ("initWithDelegate:")]
        IntPtr Constructor (ZDKRMAFeedbackViewDelegate del);

        // @property (nonatomic) ZDKRMAFeedbackDialogState feedbackState;
        [Export ("feedbackState")]
        ZDKRMAFeedbackDialogState FeedbackState { get; set; }

        // @property (retain, nonatomic) ZDKUITextView * textView;
        [Export ("textView", ArgumentSemantic.Retain)]
        ZDKUITextView TextView { get; set; }

        // @property (retain, nonatomic) UIButton * backButton;
        [Export ("backButton", ArgumentSemantic.Retain)]
        UIButton BackButton { get; set; }

        // @property (retain, nonatomic) UIButton * submitButton;
        [Export ("submitButton", ArgumentSemantic.Retain)]
        UIButton SubmitButton { get; set; }

        // @property (retain, nonatomic) UIButton * closeButton;
        [Export ("closeButton", ArgumentSemantic.Retain)]
        UIButton CloseButton { get; set; }

        // @property (retain, nonatomic) UILabel * titleLabel;
        [Export ("titleLabel", ArgumentSemantic.Retain)]
        UILabel TitleLabel { get; set; }

        // @property (retain, nonatomic) UILabel * detailTitleLabel;
        [Export ("detailTitleLabel", ArgumentSemantic.Retain)]
        UILabel DetailTitleLabel { get; set; }

        // @property (retain, nonatomic) UIImageView * submissionStatusImageView;
        [Export ("submissionStatusImageView", ArgumentSemantic.Retain)]
        UIImageView SubmissionStatusImageView { get; set; }

        // @property (nonatomic, strong) UIColor * buttonColor;
        [Export ("buttonColor", ArgumentSemantic.Retain)]
        UIColor ButtonColor { get; set; }

        // @property (nonatomic, strong) UIColor * buttonSelectedColor;
        [Export ("buttonSelectedColor", ArgumentSemantic.Retain)]
        UIColor ButtonSelectedColor { get; set; }

        // @property (nonatomic, strong) UIColor * buttonBackgroundColor;
        [Export ("buttonBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ButtonBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * separatorLineColor;
        [Export ("separatorLineColor", ArgumentSemantic.Retain)]
        UIColor SeparatorLineColor { get; set; }

        // @property (nonatomic, strong) UIFont * headerFont;
        [Export ("headerFont", ArgumentSemantic.Retain)]
        UIFont HeaderFont { get; set; }

        // @property (nonatomic, strong) UIFont * subheaderFont;
        [Export ("subheaderFont", ArgumentSemantic.Retain)]
        UIFont SubheaderFont { get; set; }

        // @property (nonatomic, strong) UIFont * textEntryFont;
        [Export ("textEntryFont", ArgumentSemantic.Retain)]
        UIFont TextEntryFont { get; set; }

        // @property (nonatomic, strong) UIFont * buttonFont;
        [Export ("buttonFont", ArgumentSemantic.Retain)]
        UIFont ButtonFont { get; set; }

        // @property (nonatomic, strong) id<ZDKSpinnerDelegate> spinner;
        [Export ("spinner", ArgumentSemantic.Retain)]
        ZDKSpinnerDelegate Spinner { get; set; }

        // @property (nonatomic, strong) UIColor * viewBackgroundColor;
        [Export ("viewBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ViewBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * headerColor;
        [Export ("headerColor", ArgumentSemantic.Retain)]
        UIColor HeaderColor { get; set; }

        // @property (nonatomic, strong) UIColor * subHeaderColor;
        [Export ("subHeaderColor", ArgumentSemantic.Retain)]
        UIColor SubHeaderColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryColor;
        [Export ("textEntryColor", ArgumentSemantic.Retain)]
        UIColor TextEntryColor { get; set; }

        // @property (nonatomic, strong) UIColor * textEntryBackgroundColor;
        [Export ("textEntryBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TextEntryBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * placeHolderColor;
        [Export ("placeHolderColor", ArgumentSemantic.Retain)]
        UIColor PlaceHolderColor { get; set; }

        // @property (nonatomic, strong) NSString * successImageName;
        [Export ("successImageName", ArgumentSemantic.Retain)]
        string SuccessImageName { get; set; }

        // @property (nonatomic, strong) NSString * errorImageName;
        [Export ("errorImageName", ArgumentSemantic.Retain)]
        string ErrorImageName { get; set; }

        // -(void)showSpinner:(BOOL)show;
        [Export ("showSpinner:")]
        void ShowSpinner (bool show);

        // -(void)successTransition;
        [Export ("successTransition")]
        void SuccessTransition ();

        // -(void)transitionToError;
        [Export ("transitionToError")]
        void TransitionToError ();

        // -(void)transitionFromError;
        [Export ("transitionFromError")]
        void TransitionFromError ();
    }

    // @interface ZDKRMATableHeaderView : UIView
    [BaseType (typeof (UIView))]
    interface ZDKRMATableHeaderView {

        // -(id)initWithFrame:(CGRect)frame andTitle:(NSString *)title;
        [Export ("initWithFrame:andTitle:")]
        IntPtr Constructor (CGRect frame, string title);

        // @property (nonatomic, strong) UILabel * textLabel;
        [Export ("textLabel", ArgumentSemantic.Retain)]
        UILabel TextLabel { get; set; }
    }

    // @interface ZDKRMADialogViewCell : UITableViewCell
    [BaseType (typeof (UITableViewCell))]
    interface ZDKRMADialogViewCell {

        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier separatorColor:(UIColor *)theSeparatorColor backgroundColor:(UIColor *)theBgColor selectedBackgroundColor:(UIColor *)theSelectedBgColor;
        [Export ("initWithStyle:reuseIdentifier:separatorColor:backgroundColor:selectedBackgroundColor:")]
        IntPtr Constructor (UITableViewCellStyle style, string reuseIdentifier, UIColor theSeparatorColor, UIColor theBgColor, UIColor theSelectedBgColor);

        // @property (nonatomic, strong) UIColor * bgColor;
        [Export ("bgColor", ArgumentSemantic.Retain)]
        UIColor BgColor { get; set; }

        // @property (nonatomic, strong) UIColor * selectedBgColor;
        [Export ("selectedBgColor", ArgumentSemantic.Retain)]
        UIColor SelectedBgColor { get; set; }
    }

    // @protocol ZDKRMADialogViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface ZDKRMADialogViewDelegate {

        // @required -(void)rateApp;
        [Export ("rateApp")]
        [Abstract]
        void RateApp ();

        // @required -(void)neverShowDialogAgain;
        [Export ("neverShowDialogAgain")]
        [Abstract]
        void NeverShowDialogAgain ();

        // @optional -(void)showFeedbackView;
        [Export ("showFeedbackView")]
        void ShowFeedbackView ();
    }

    // @interface ZDKRMADialogView : UITableView <UITableViewDataSource, UITableViewDelegate>
    [BaseType (typeof (UITableView))]
    interface ZDKRMADialogView : IUITableViewDataSource, IUITableViewDelegate {

        // -(id)initWithDelegate:(id<ZDKRMADialogViewDelegate>)delegate;
        [Export ("initWithDelegate:")]
        IntPtr Constructor (ZDKRMADialogViewDelegate ZDKRMADialogViewDelegate);

        // -(id)initWithFrame:(CGRect)frame delegate:(id<ZDKRMADialogViewDelegate>)delegate;
        [Export ("initWithFrame:delegate:")]
        IntPtr Constructor (CGRect frame, ZDKRMADialogViewDelegate ZDKRMADialogViewDelegate);

        // -(id)initWithFrame:(CGRect)frame style:(UITableViewStyle)style delegate:(id<ZDKRMADialogViewDelegate>)delegate;
        [Export ("initWithFrame:style:delegate:")]
        IntPtr Constructor (CGRect frame, UITableViewStyle style, ZDKRMADialogViewDelegate ZDKRMADialogViewDelegate);

        // @property (retain, nonatomic) NSArray * rows;
        [Export ("rows", ArgumentSemantic.Retain)]
        NSObject [] Rows { get; set; }

        // @property (nonatomic, strong) UIColor * headerBackgroundColor;
        [Export ("headerBackgroundColor", ArgumentSemantic.Retain)]
        UIColor HeaderBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * headerColor;
        [Export ("headerColor", ArgumentSemantic.Retain)]
        UIColor HeaderColor { get; set; }

        // @property (nonatomic, strong) UIColor * separatorLineColor;
        [Export ("separatorLineColor", ArgumentSemantic.Retain)]
        UIColor SeparatorLineColor { get; set; }

        // @property (nonatomic, strong) UIColor * buttonBackgroundColor;
        [Export ("buttonBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ButtonBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * buttonSelectedBackgroundColor;
        [Export ("buttonSelectedBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ButtonSelectedBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * buttonColor;
        [Export ("buttonColor", ArgumentSemantic.Retain)]
        UIColor ButtonColor { get; set; }

        // @property (nonatomic, strong) UIFont * headerFont;
        [Export ("headerFont", ArgumentSemantic.Retain)]
        UIFont HeaderFont { get; set; }

        // @property (nonatomic, strong) UIFont * buttonFont;
        [Export ("buttonFont", ArgumentSemantic.Retain)]
        UIFont ButtonFont { get; set; }
    }

    // @interface ZDKRMADialogViewController : ZDKUIViewController <ZDKRMADialogViewDelegate, ZDKRMAFeedbackViewDelegate>
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKRMADialogViewController : ZDKRMADialogViewDelegate, ZDKRMAFeedbackViewDelegate {

        // -(instancetype)initWithConfig:(ZDKRMAConfigObject *)config;
        [Export ("initWithConfig:")]
        IntPtr Constructor (ZDKRMAConfigObject config);

        // @property (retain, nonatomic) ZDKRMADialogView * dialog;
        [Export ("dialog", ArgumentSemantic.Retain)]
        ZDKRMADialogView Dialog { get; set; }

        // @property (retain, nonatomic) ZDKRMAFeedbackView * feedbackView;
        [Export ("feedbackView", ArgumentSemantic.Retain)]
        ZDKRMAFeedbackView FeedbackView { get; set; }
    }

    // @interface ZDKRMA : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKRMA {

        // @property (readonly, retain, nonatomic) ZDKRMAConfigObject * zdkrmaConfigObject;
        [Export ("zdkrmaConfigObject", ArgumentSemantic.Retain)]
        ZDKRMAConfigObject ZdkrmaConfigObject { get; }

        // @property (readonly, retain, nonatomic) ZDKRMADataObject * zdkrmaDataObject;
        [Export ("zdkrmaDataObject", ArgumentSemantic.Retain)]
        ZDKRMADataObject ZdkrmaDataObject { get; }

        // +(void)configure:(void (^)(ZDKAccount *, ZDKRMAConfigObject *))configBlock;
        [Static, Export ("configure:")]
        void Configure (Action<ZDKAccount, ZDKRMAConfigObject> configBlock);

        // +(void)showInView:(UIView *)view;
        [Static, Export ("showInView:")]
        void ShowInView (UIView view);

        // +(void)showAlwaysInView:(UIView *)view;
        [Static, Export ("showAlwaysInView:")]
        void ShowAlwaysInView (UIView view);

        // +(void)logVisit;
        [Static, Export ("logVisit")]
        void LogVisit ();

        // +(void)notifyFeedbackSuccess;
        [Static, Export ("notifyFeedbackSuccess")]
        void NotifyFeedbackSuccess ();

        // +(void)notifyFeedbackError;
        [Static, Export ("notifyFeedbackError")]
        void NotifyFeedbackError ();
    }

    // @interface ZDKSdkStorage : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKSdkStorage {

        // @property (readonly, nonatomic) ZDKRequestStorage * requestStorage;
        [Export ("requestStorage")]
        ZDKRequestStorage RequestStorage { get; }

        // @property (readonly, nonatomic) ZDKIdentityStorage * identityStorage;
        [Export ("identityStorage")]
        ZDKIdentityStorage IdentityStorage { get; }

        // @property (readonly, nonatomic) ZDKSettingsStorage * settingsStorage;
        [Export ("settingsStorage")]
        ZDKSettingsStorage SettingsStorage { get; }

        // -(void)clearUserData;
        [Export ("clearUserData")]
        void ClearUserData ();

        // +(instancetype)instance;
        [Static, Export ("instance")]
        ZDKSdkStorage Instance ();
    }

    // @interface ZDKSettings : ZDKCoding
    [BaseType (typeof (ZDKCoding))]
    interface ZDKSettings {

        // -(id)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (readonly, nonatomic) ZDKAppSettings * appSettings;
        [Export ("appSettings")]
        ZDKAppSettings AppSettings { get; }

        // @property (readonly, nonatomic) ZDKAccountSettings * accountSettings;
        [Export ("accountSettings")]
        ZDKAccountSettings AccountSettings { get; }
    }

    // @interface ZDKSettingsProvider : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKSettingsProvider {

        // -(void)getSdkSettingsWithCallback:(ZDKSettingsCallback)callback;
        [Export ("getSdkSettingsWithCallback:")]
        void GetSdkSettingsWithCallback (Action<ZDKSettings, NSError> callback);

        // -(void)getSdkSettingsWithLocale:(NSString *)locale andCallback:(ZDKSettingsCallback)callback;
        [Export ("getSdkSettingsWithLocale:andCallback:")]
        void GetSdkSettingsWithLocale (string locale, Action<ZDKSettings, NSError> callback);
    }

    // @interface ZDKSettingsStorage : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKSettingsStorage {

        // @property (nonatomic) ZDKSettings * settings;
        [Export ("settings")]
        ZDKSettings Settings { get; set; }

        // -(void)setLastSettingsReloadInterval:(NSTimeInterval)interval;
        [Export ("setLastSettingsReloadInterval:")]
        void SetLastSettingsReloadInterval (double interval);

        // -(NSTimeInterval)getLastSettingsReloadInterval;
        [Export ("getLastSettingsReloadInterval")]
        double GetLastSettingsReloadInterval ();

        // -(BOOL)hasStoredSettings;
        [Export ("hasStoredSettings")]
        bool HasStoredSettings ();

        // -(void)deleteStoredData;
        [Export ("deleteStoredData")]
        void DeleteStoredData ();
    }

    // @interface ZDKSupportTableViewCell : UITableViewCell <UIAppearanceContainer>
    [BaseType (typeof (UITableViewCell))]
    interface ZDKSupportTableViewCell : IUIAppearanceContainer {

        // @property (readonly, nonatomic, strong) UILabel * title;
        [Export ("title", ArgumentSemantic.Retain)]
        UILabel Title { get; }

        // @property (nonatomic, strong) UIColor * viewBackgroundColor;
        [Export ("viewBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ViewBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIFont * titleLabelFont;
        [Export ("titleLabelFont", ArgumentSemantic.Retain)]
        UIFont TitleLabelFont { get; set; }

        // @property (nonatomic, strong) UIColor * titleLabelColor;
        [Export ("titleLabelColor", ArgumentSemantic.Retain)]
        UIColor TitleLabelColor { get; set; }

        // @property (nonatomic, strong) UIColor * titleLabelBackground;
        [Export ("titleLabelBackground", ArgumentSemantic.Retain)]
        UIColor TitleLabelBackground { get; set; }

        // -(CGFloat)cellHeightForWidth:(CGFloat)width;
        [Export ("cellHeightForWidth:")]
        nfloat CellHeightForWidth (nfloat width);

        // +(NSString *)cellIdentifier;
        [Static, Export ("cellIdentifier")]
        string CellIdentifier ();
    }

    // @interface ZDKSupportArticleTableViewCell : UITableViewCell <UIAppearanceContainer>
    [BaseType (typeof (UITableViewCell))]
    interface ZDKSupportArticleTableViewCell : IUIAppearanceContainer {

        // @property (readonly, nonatomic, strong) UILabel * articleParents;
        [Export ("articleParents", ArgumentSemantic.Retain)]
        UILabel ArticleParents { get; }

        // @property (readonly, nonatomic, strong) UILabel * title;
        [Export ("title", ArgumentSemantic.Retain)]
        UILabel Title { get; }

        // @property (nonatomic, strong) UIColor * viewBackgroundColor;
        [Export ("viewBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ViewBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIFont * articleParentsLabelFont;
        [Export ("articleParentsLabelFont", ArgumentSemantic.Retain)]
        UIFont ArticleParentsLabelFont { get; set; }

        // @property (nonatomic, strong) UIColor * articleParentsLabelColor;
        [Export ("articleParentsLabelColor", ArgumentSemantic.Retain)]
        UIColor ArticleParentsLabelColor { get; set; }

        // @property (nonatomic, strong) UIColor * articleParnetsLabelBackground;
        [Export ("articleParnetsLabelBackground", ArgumentSemantic.Retain)]
        UIColor ArticleParnetsLabelBackground { get; set; }

        // @property (nonatomic, strong) UIFont * titleLabelFont;
        [Export ("titleLabelFont", ArgumentSemantic.Retain)]
        UIFont TitleLabelFont { get; set; }

        // @property (nonatomic, strong) UIColor * titleLabelColor;
        [Export ("titleLabelColor", ArgumentSemantic.Retain)]
        UIColor TitleLabelColor { get; set; }

        // @property (nonatomic, strong) UIColor * titleLabelBackground;
        [Export ("titleLabelBackground", ArgumentSemantic.Retain)]
        UIColor TitleLabelBackground { get; set; }

        // -(CGFloat)cellHeightForWidth:(CGFloat)width;
        [Export ("cellHeightForWidth:")]
        nfloat CellHeightForWidth (nfloat width);

        // +(NSString *)cellIdentifier;
        [Static, Export ("cellIdentifier")]
        string CellIdentifier ();
    }

    // @interface ZDKSupportAttachmentCell : UITableViewCell <UIAppearanceContainer>
    [BaseType (typeof (UITableViewCell))]
    interface ZDKSupportAttachmentCell : IUIAppearanceContainer {

        // @property (readonly, nonatomic, strong) UILabel * fileSize;
        [Export ("fileSize", ArgumentSemantic.Retain)]
        UILabel FileSize { get; }

        // @property (readonly, nonatomic, strong) UILabel * title;
        [Export ("title", ArgumentSemantic.Retain)]
        UILabel Title { get; }

        // @property (nonatomic, strong) UIColor * viewBackgroundColor;
        [Export ("viewBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ViewBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIFont * fileSizeLabelFont;
        [Export ("fileSizeLabelFont", ArgumentSemantic.Retain)]
        UIFont FileSizeLabelFont { get; set; }

        // @property (nonatomic, strong) UIColor * fileSizeLabelColor;
        [Export ("fileSizeLabelColor", ArgumentSemantic.Retain)]
        UIColor FileSizeLabelColor { get; set; }

        // @property (nonatomic, strong) UIColor * fileSizeLabelBackground;
        [Export ("fileSizeLabelBackground", ArgumentSemantic.Retain)]
        UIColor FileSizeLabelBackground { get; set; }

        // @property (nonatomic, strong) UIFont * titleLabelFont;
        [Export ("titleLabelFont", ArgumentSemantic.Retain)]
        UIFont TitleLabelFont { get; set; }

        // @property (nonatomic, strong) UIColor * titleLabelColor;
        [Export ("titleLabelColor", ArgumentSemantic.Retain)]
        UIColor TitleLabelColor { get; set; }

        // @property (nonatomic, strong) UIColor * titleLabelBackground;
        [Export ("titleLabelBackground", ArgumentSemantic.Retain)]
        UIColor TitleLabelBackground { get; set; }

        // +(NSString *)cellIdentifier;
        [Static, Export ("cellIdentifier")]
        string CellIdentifier ();
    }

    // @interface ZDKSupportView : UIView <UIAppearanceContainer>
    [BaseType (typeof (UIView))]
    interface ZDKSupportView : IUIAppearanceContainer {

        // @property (nonatomic) ZDKSupportViewState viewState;
        [Export ("viewState")]
        ZDKSupportViewState ViewState { get; set; }

        // @property (readonly, nonatomic, strong) UITableView * table;
        [Export ("table", ArgumentSemantic.Retain)]
        UITableView Table { get; }

        // @property (readonly, nonatomic, strong) UISearchBar * searchField;
        [Export ("searchField", ArgumentSemantic.Retain)]
        UISearchBar SearchField { get; }

        // @property (readonly, nonatomic, strong) UILabel * noResultsFoundLabel;
        [Export ("noResultsFoundLabel", ArgumentSemantic.Retain)]
        UILabel NoResultsFoundLabel { get; }

        // @property (readonly, nonatomic, strong) UIButton * noResultsContactButton;
        [Export ("noResultsContactButton", ArgumentSemantic.Retain)]
        UIButton NoResultsContactButton { get; }

        // @property (nonatomic, strong) id<ZDKSpinnerDelegate> spinner;
        [Export ("spinner", ArgumentSemantic.Retain)]
        ZDKSpinnerDelegate Spinner { get; set; }

        // @property (nonatomic, strong) UIColor * viewBackgroundColor;
        [Export ("viewBackgroundColor", ArgumentSemantic.Retain)]
        UIColor ViewBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * tableBackgroundColor;
        [Export ("tableBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TableBackgroundColor { get; set; }

        // @property (nonatomic, strong) NSNumber * searchBarStyle;
        [Export ("searchBarStyle", ArgumentSemantic.Retain)]
        NSNumber SearchBarStyle { get; set; }

        // @property (nonatomic, strong) UIColor * separatorColor;
        [Export ("separatorColor", ArgumentSemantic.Retain)]
        UIColor SeparatorColor { get; set; }

        // @property (nonatomic, strong) UIFont * noResultsFoundLabelFont;
        [Export ("noResultsFoundLabelFont", ArgumentSemantic.Retain)]
        UIFont NoResultsFoundLabelFont { get; set; }

        // @property (nonatomic, strong) UIColor * noResultsFoundLabelColor;
        [Export ("noResultsFoundLabelColor", ArgumentSemantic.Retain)]
        UIColor NoResultsFoundLabelColor { get; set; }

        // @property (nonatomic, strong) UIColor * noResultsFoundLabelBackground;
        [Export ("noResultsFoundLabelBackground", ArgumentSemantic.Retain)]
        UIColor NoResultsFoundLabelBackground { get; set; }

        // @property (nonatomic, strong) UIColor * noResultsContactButtonBackground;
        [Export ("noResultsContactButtonBackground", ArgumentSemantic.Retain)]
        UIColor NoResultsContactButtonBackground { get; set; }

        // @property (nonatomic, strong) UIColor * noResultsContactButtonBorderColor;
        [Export ("noResultsContactButtonBorderColor", ArgumentSemantic.Retain)]
        UIColor NoResultsContactButtonBorderColor { get; set; }

        // @property (nonatomic, strong) NSNumber * noResultsContactButtonBorderWidth;
        [Export ("noResultsContactButtonBorderWidth", ArgumentSemantic.Retain)]
        NSNumber NoResultsContactButtonBorderWidth { get; set; }

        // @property (nonatomic, strong) NSNumber * noResultsContactButtonCornerRadius;
        [Export ("noResultsContactButtonCornerRadius", ArgumentSemantic.Retain)]
        NSNumber NoResultsContactButtonCornerRadius { get; set; }

        // @property (nonatomic, strong) UIFont * noResultsContactButtonFont;
        [Export ("noResultsContactButtonFont", ArgumentSemantic.Retain)]
        UIFont NoResultsContactButtonFont { get; set; }

        // @property (nonatomic, strong) NSValue * noResultsContactButtonEdgeInsets;
        [Export ("noResultsContactButtonEdgeInsets", ArgumentSemantic.Retain)]
        NSValue NoResultsContactButtonEdgeInsets { get; set; }

        // @property (nonatomic, strong) UIColor * noResultsContactButtonTitleColorNormal;
        [Export ("noResultsContactButtonTitleColorNormal", ArgumentSemantic.Retain)]
        UIColor NoResultsContactButtonTitleColorNormal { get; set; }

        // @property (nonatomic, strong) UIColor * noResultsContactButtonTitleColorHighlighted;
        [Export ("noResultsContactButtonTitleColorHighlighted", ArgumentSemantic.Retain)]
        UIColor NoResultsContactButtonTitleColorHighlighted { get; set; }

        // @property (nonatomic, strong) UIColor * noResultsContactButtonTitleColorDisabled;
        [Export ("noResultsContactButtonTitleColorDisabled", ArgumentSemantic.Retain)]
        UIColor NoResultsContactButtonTitleColorDisabled { get; set; }

        // @property (nonatomic, strong) NSNumber * automaticallyHideNavBarOnLandscape;
        [Export ("automaticallyHideNavBarOnLandscape", ArgumentSemantic.Retain)]
        NSNumber AutomaticallyHideNavBarOnLandscape { get; set; }
    }

    // @interface ZDKSupportViewController : ZDKUIViewController <UIScrollViewDelegate, UISearchBarDelegate>
    [BaseType (typeof (ZDKUIViewController))]
    interface ZDKSupportViewController : IUIScrollViewDelegate, IUISearchBarDelegate {

        // -(instancetype)initWithLabels:(NSArray *)labels;
        [Export ("initWithLabels:")]
        IntPtr Constructor (NSObject [] labels);

        // -(instancetype)initWithCategory:(ZDKHelpCenterCategory *)category;
        [Export ("initWithCategory:")]
        IntPtr Constructor (ZDKHelpCenterCategory category);

        // -(instancetype)initWithSection:(ZDKHelpCenterSection *)section;
        [Export ("initWithSection:")]
        IntPtr Constructor (ZDKHelpCenterSection section);

        // @property (nonatomic, strong) ZDKSupportView * supportView;
        [Export ("supportView", ArgumentSemantic.Retain)]
        ZDKSupportView SupportView { get; set; }

        // @property (nonatomic, weak) id<ZDKHelpCenterConversationsUIDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.Weak)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, weak) id<ZDKHelpCenterConversationsUIDelegate> delegate;
        [Wrap ("WeakDelegate")]
        ZDKHelpCenterConversationsUIDelegate Delegate { get; set; }
    }

    // @interface ZDKStringUtil : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKStringUtil {

        // +(NSString *)csvStringFromArray:(NSArray *)array;
        [Static, Export ("csvStringFromArray:")]
        string CsvStringFromArray (NSObject [] array);
    }

    // @interface ZDKToastStyle : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKToastStyle {

        // +(void)setValue:(id)value forType:(ZDKToastUIType)type andStyle:(ZDKToastUIStyle)style;
        [Static, Export ("setValue:forType:andStyle:")]
        void SetValue (NSObject value, ZDKToastUIType type, ZDKToastUIStyle style);

        // +(id)getValueForType:(ZDKToastUIType)type andStyle:(ZDKToastUIStyle)style;
        [Static, Export ("getValueForType:andStyle:")]
        NSObject GetValueForType (ZDKToastUIType type, ZDKToastUIStyle style);
    }

    // @interface ZDKToastView : UIView
    [BaseType (typeof (UIView))]
    interface ZDKToastView {

        // -(instancetype)initInView:(UIView *)view forViewController:(UIViewController *)viewController atY:(CGFloat)initialYPosisition withMessage:(NSString *)message buttonText:(NSString *)buttonText buttonAction:(ZDKToastButtonAction)buttonActionBlock andType:(ZDKToastUIType)type duration:(NSTimeInterval)durationInSeconds animationTime:(NSTimeInterval)animationTime animation:(ZDKToastAnimation)animationBlock animateIn:(BOOL)animateIn;
        [Export ("initInView:forViewController:atY:withMessage:buttonText:buttonAction:andType:duration:animationTime:animation:animateIn:")]
        IntPtr Constructor (UIView view, UIViewController viewController, nfloat initialYPosisition, string message, string buttonText, Action buttonActionBlock, ZDKToastUIType type, double durationInSeconds, double animationTime, Action<bool, double> animationBlock, bool animateIn);

        // @property (strong) NSDate * timePresented;
        [Export ("timePresented", ArgumentSemantic.Retain)]
        NSDate TimePresented { get; set; }

        // @property (copy, nonatomic) ZDKToastAnimation animationBlock;
        [Export ("animationBlock", ArgumentSemantic.Copy)]
        Action<bool, double> AnimationBlock { get; set; }

        // @property (copy, nonatomic) ZDKToastButtonAction buttonBlock;
        [Export ("buttonBlock", ArgumentSemantic.Copy)]
        Action ButtonBlock { get; set; }

        // @property (nonatomic, weak) UIViewController * viewController;
        [Export ("viewController", ArgumentSemantic.Weak)]
        UIViewController ViewController { get; set; }

        // -(void)present:(BOOL)animate;
        [Export ("present:")]
        void Present (bool animate);

        // -(void)dismiss:(BOOL)animate;
        [Export ("dismiss:")]
        void Dismiss (bool animate);

        // -(void)dismiss:(BOOL)animate comepletion:(ZDKToastCompletion)completion;
        [Export ("dismiss:comepletion:")]
        void Dismiss (bool animate, Action completion);
    }

    // @interface ZDKToast : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKToast {

        // +(void)showMessage:(NSString *)message ofType:(ZDKToastUIType)type inViewController:(UIViewController *)viewController withDuration:(NSTimeInterval)durationInSeconds andAnimation:(ZDKToastAnimation)animationBlock animated:(BOOL)animated;
        [Static, Export ("showMessage:ofType:inViewController:withDuration:andAnimation:animated:")]
        void ShowMessage (string message, ZDKToastUIType type, UIViewController viewController, double durationInSeconds, Action<bool, double> animationBlock, bool animated);

        // +(void)showMessage:(NSString *)message ofType:(ZDKToastUIType)type inView:(UIView *)view inViewController:(UIViewController *)viewController withDuration:(NSTimeInterval)durationInSeconds andAnimation:(ZDKToastAnimation)animationBlock animated:(BOOL)animated;
        [Static, Export ("showMessage:ofType:inView:inViewController:withDuration:andAnimation:animated:")]
        void ShowMessage (string message, ZDKToastUIType type, UIView view, UIViewController viewController, double durationInSeconds, Action<bool, double> animationBlock, bool animated);

        // +(void)showMessage:(NSString *)message ofType:(ZDKToastUIType)type inView:(UIView *)view startingAt:(CGFloat)initialYPosisition withDuration:(NSTimeInterval)durationInSeconds andAnimation:(ZDKToastAnimation)animationBlock animated:(BOOL)animated;
        [Static, Export ("showMessage:ofType:inView:startingAt:withDuration:andAnimation:animated:")]
        void ShowMessage (string message, ZDKToastUIType type, UIView view, nfloat initialYPosisition, double durationInSeconds, Action<bool, double> animationBlock, bool animated);

        // +(void)showMessage:(NSString *)message ofType:(ZDKToastUIType)type inViewController:(UIViewController *)viewController withButtonText:(NSString *)buttonText buttonAction:(ZDKToastButtonAction)buttonActionBlock andAnimation:(ZDKToastAnimation)animationBlock animated:(BOOL)animated;
        [Static, Export ("showMessage:ofType:inViewController:withButtonText:buttonAction:andAnimation:animated:")]
        void ShowMessage (string message, ZDKToastUIType type, UIViewController viewController, string buttonText, Action buttonActionBlock, Action<bool, double> animationBlock, bool animated);

        // +(void)showMessage:(NSString *)message ofType:(ZDKToastUIType)type inView:(UIView *)view startingAt:(CGFloat)initialYPosisition withButtonText:(NSString *)buttonText buttonAction:(ZDKToastButtonAction)buttonActionBlock andAnimation:(ZDKToastAnimation)animationBlock animated:(BOOL)animated;
        [Static, Export ("showMessage:ofType:inView:startingAt:withButtonText:buttonAction:andAnimation:animated:")]
        void ShowMessage (string message, ZDKToastUIType type, UIView view, nfloat initialYPosisition, string buttonText, Action buttonActionBlock, Action<bool, double> animationBlock, bool animated);

        // +(void)setAnimationDuration:(NSTimeInterval)durationInSeconds;
        [Static, Export ("setAnimationDuration:")]
        void SetAnimationDuration (double durationInSeconds);

        // +(void)dismissForViewController:(UIViewController *)viewController animate:(BOOL)animate;
        [Static, Export ("dismissForViewController:animate:")]
        void DismissForViewController (UIViewController viewController, bool animate);

        // +(void)dismissForView:(UIView *)view animate:(BOOL)animate;
        [Static, Export ("dismissForView:animate:")]
        void DismissForView (UIView view, bool animate);
    }

    // @interface ZDKUIActivityView : UIImageView <ZDKSpinnerDelegate>
    [BaseType (typeof (UIImageView))]
    interface ZDKUIActivityView : ZDKSpinnerDelegate {

    }

    // @interface ZDKUIImageScrollView : UIScrollView
    [BaseType (typeof (UIScrollView))]
    interface ZDKUIImageScrollView {

        // -(instancetype)initWithImage:(UIImage *)image;
        [Export ("initWithImage:")]
        IntPtr Constructor (UIImage image);

        // @property (nonatomic, strong) UIImageView * imageView;
        [Export ("imageView", ArgumentSemantic.Retain)]
        UIImageView ImageView { get; set; }
    }

    // @interface ZDKUILoadingView : UIView
    [BaseType (typeof (UIView))]
    interface ZDKUILoadingView {

        // @property (readonly, nonatomic) UIActivityIndicatorView * spinner;
        [Export ("spinner")]
        UIActivityIndicatorView Spinner { get; }
    }

    // @interface ZDKUIUtil : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKUIUtil {

        // +(id)appearanceForClass:(Class)class selector:(SEL)selector;
        [Static, Export ("appearanceForClass:selector:")]
        NSObject AppearanceForClass (Class pClass, Selector selector);

        // +(id)appearanceForClass:(Class)class selector:(SEL)selector defaultValue:(id)defaultValue;
        [Static, Export ("appearanceForClass:selector:defaultValue:")]
        NSObject AppearanceForClass (Class pClass, Selector selector, NSObject defaultValue);

        // +(id)appearanceForView:(UIView *)view selector:(SEL)selector;
        [Static, Export ("appearanceForView:selector:")]
        NSObject AppearanceForView (UIView view, Selector selector);

        // +(id)appearanceForView:(UIView *)view selector:(SEL)selector defaultValue:(id)defaultValue;
        [Static, Export ("appearanceForView:selector:defaultValue:")]
        NSObject AppearanceForView (UIView view, Selector selector, NSObject defaultValue);

        // +(BOOL)isOlderVersion:(NSNumber *)majorVersionNumber;
        [Static, Export ("isOlderVersion:")]
        bool IsOlderVersion (NSNumber majorVersionNumber);

        // +(BOOL)isNewerVersion:(NSNumber *)majorVersionNumber;
        [Static, Export ("isNewerVersion:")]
        bool IsNewerVersion (NSNumber majorVersionNumber);

        // +(BOOL)isSameVersion:(NSNumber *)majorVersionNumber;
        [Static, Export ("isSameVersion:")]
        bool IsSameVersion (NSNumber majorVersionNumber);

        // +(CGFloat)separatorHeightForScreenScale;
        [Static, Export ("separatorHeightForScreenScale")]
        nfloat SeparatorHeightForScreenScale ();

        // +(UIButton *)buildButtonWithFrame:(CGRect)frame andTitle:(NSString *)title;
        [Static, Export ("buildButtonWithFrame:andTitle:")]
        UIButton BuildButtonWithFrame (CGRect frame, string title);

        // +(UIInterfaceOrientation)currentInterfaceOrientation;
        [Static, Export ("currentInterfaceOrientation")]
        UIInterfaceOrientation CurrentInterfaceOrientation ();

        // +(CGFloat)scaledHeightForSize:(CGSize)size constrainedByWidth:(CGFloat)width;
        [Static, Export ("scaledHeightForSize:constrainedByWidth:")]
        nfloat ScaledHeightForSize (CGSize size, nfloat width);

        // +(BOOL)isPad;
        [Static, Export ("isPad")]
        bool IsPad ();

        // +(BOOL)isLandscape;
        [Static, Export ("isLandscape")]
        bool IsLandscape ();

        // +(UIImage *)fixOrientationOfImage:(UIImage *)image;
        [Static, Export ("fixOrientationOfImage:")]
        UIImage FixOrientationOfImage (UIImage image);
    }

    // @interface ZDKUser : NSObject
    [BaseType (typeof (NSObject))]
    interface ZDKUser {

        // -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
        [Export ("initWithDictionary:")]
        IntPtr Constructor (NSDictionary dictionary);

        // @property (nonatomic, strong) NSNumber * userId;
        [Export ("userId", ArgumentSemantic.Retain)]
        NSNumber UserId { get; set; }

        // @property (nonatomic, strong) NSString * name;
        [Export ("name", ArgumentSemantic.Retain)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * avatarURL;
        [Export ("avatarURL", ArgumentSemantic.Retain)]
        string AvatarURL { get; set; }

        // @property (assign, nonatomic) BOOL isAgent;
        [Export ("isAgent", ArgumentSemantic.UnsafeUnretained)]
        bool IsAgent { get; set; }
    }


}

