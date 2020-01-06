using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace NativeLibrary
{
    [BaseType(typeof(UIViewController))]
    public partial interface RootViewController
    {
        [Export("prefersStatusBarHidden")]
        bool PrefersStatusBarHidden { get; }
    }

    [BaseType(typeof(NSObject))]
    interface AppController : IUIApplicationDelegate
    {
        [Export("viewController")]
        RootViewController ViewController { get; }

        [Export("application:didFinishLaunchingWithOptions:")]
        bool DidFinishLaunchingWithOptions(UIApplication application, [NullAllowed] NSDictionary launchOptions);

        [Export("applicationWillResignActive:")]
        void ApplicationWillResignActive(UIApplication application);

        [Export("applicationDidBecomeActive:")]
        void ApplicationDidBecomeActive(UIApplication application);

        [Export("applicationDidEnterBackground:")]
        void ApplicationDidEnterBackground(UIApplication application);

        [Export("applicationWillEnterForeground:")]
        void ApplicationWillEnterForeground(UIApplication application);

        [Export("applicationWillTerminate:")]
        void ApplicationWillTerminate(UIApplication application);

        [Export("applicationDidReceiveMemoryWarning:")]
        void ApplicationDidReceiveMemoryWarning(UIApplication application);

        [Export("callNativeWithReturnBool:andContent:")]
        bool CallNativeWithReturnBool(string title, string content);

        [Export("callNativeWithReturnString:andContent:")]
        string CallNativeWithReturnString(string title, string content);

        [Export("application:openURL:options:")]
        bool OpenUrl(UIApplication app, NSUrl url, NSDictionary<NSString, NSObject> options);

        [Export("application:openURL:sourceApplication:annotation:")]
        bool OpenUrl(UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, NSObject annotation);

        [Static]
        [Export("evalScript:")]
        bool EvalScript(string script);
    }

    [BaseType(typeof(NSObject))]
    interface NativeOcClass
    {
        // +(BOOL)callNativeWithReturnBool:(NSString * _Nonnull)title andContent:(NSString * _Nonnull)content;
        [Static]
        [Export("callNativeWithReturnBool:andContent:")]
        bool CallNativeWithReturnBool(string title, string content);

        // +(NSString *)callNativeWithReturnString:(NSString * _Nonnull)title andContent:(NSString * _Nonnull)content;
        [Static]
        [Export("callNativeWithReturnString:andContent:")]
        string CallNativeWithReturnString(string title, string content);
    }
}

