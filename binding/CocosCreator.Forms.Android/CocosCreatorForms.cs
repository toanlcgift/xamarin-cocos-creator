using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Org.Cocos2dx.Lib;

namespace CocosCreator.Forms.Android
{
    public class CocosCreatorForms : Org.Cocos2dx.Lib.Cocos2dxForms
    {
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
            this.RunOnGLThread(new Runnable(() =>
             {
                 Cocos2dxJavascriptJavaBridge.EvalString("cc.TestNativeCallJS()");
             }));
            return base.ParamFromJSString(title, message);
        }
    }
}