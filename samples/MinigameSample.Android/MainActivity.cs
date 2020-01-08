using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Org.Cocos2dx.Lib;
using Android.Content;
using Android.Content.Res;
using Java.Lang;

namespace CocosCreatorSample.Droid
{
    [Activity(Label = "CocosCreatorSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Cocos2dxActivity
    {
        public static MainActivity app = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (!IsTaskRoot)
            {
                return;
            }

            Java.Lang.JavaSystem.LoadLibrary("cocos2djs");
            this.Setxxteakey("123456789");
            base.OnCreate(savedInstanceState);
            app = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void ParamFromJSVoid(string title, string message)
        {
            System.Diagnostics.Debug.WriteLine($"title: {title}, message: {message}");
        }

        public override int ParamFromJSInt(string title, string message)
        {
            return base.ParamFromJSInt(title, message);
        }

        public override string ParamFromJSString(string title, string message)
        {
            app.RunOnGLThread(new Runnable(() =>
            {
                Cocos2dxJavascriptJavaBridge.EvalString("cc.TestNativeCallJS()");
            }));
            return base.ParamFromJSString(title, message);
        }

        public override Cocos2dxGLSurfaceView OnCreateView()
        {
            Cocos2dxGLSurfaceView glSurfaceView = new Cocos2dxGLSurfaceView(this);
            glSurfaceView.SetEGLConfigChooser(8, 8, 8, 8, 16, 0);
            return glSurfaceView;
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}