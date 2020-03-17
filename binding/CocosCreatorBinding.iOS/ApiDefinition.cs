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

        [Export("callNativeWithReturnBool:andContent:")]
        bool CallNativeWithReturnBool(string title, string content);

        [Export("callNativeWithReturnString:andContent:")]
        string CallNativeWithReturnString(string title, string content);
    }

    [BaseType(typeof(NSObject))]
    interface AppController
    {
        [Static]
        [Export("statusBarOrientationChanged")]
        void StatusBarOrientationChanged();

        [Static]
        [Export("applicationWillResignActive")]
        void ApplicationWillResignActive();

        [Static]
        [Export("applicationDidBecomeActive")]
        void ApplicationDidBecomeActive();

        [Static]
        [Export("applicationWillTerminate")]
        void ApplicationWillTerminate();

        [Static]
        [Export("evalScript:")]
        bool EvalScript(string script);

        [Static]
        [Export("initGame:")]
        void InitGame(string key);

        [Static]
        [Export("getGameView")]
        UIView GetGameView();

        [Static]
        [Export("startGame")]
        void StartGame();
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

