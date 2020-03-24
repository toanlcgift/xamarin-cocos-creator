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
    internal class CocosCreatorForms : Org.Cocos2dx.Lib.Cocos2dxForms
    {
        public static event OnReceiveDataHandler ReceiveData;

        public delegate void OnReceiveDataHandler(string title, string message, Type type);
        public override void ParamFromJSVoid(string title, string message)
        {
            var receive = ReceiveData;
            if (receive != null)
            {
                ReceiveData(title, message, typeof(void));
            }
        }

        public override int ParamFromJSInt(string title, string message)
        {
            var receive = ReceiveData;
            if (receive != null)
            {
                ReceiveData(title, message, typeof(int));
            }
            return base.ParamFromJSInt(title, message);
        }

        public override string ParamFromJSString(string title, string message)
        {
            //this.RunOnGLThread(new Runnable(() =>
            // {
            //     Cocos2dxJavascriptJavaBridge.EvalString("cc.TestNativeCallJS()");
            // }));
            var receive = ReceiveData;
            if (receive != null)
            {
                ReceiveData(title, message, typeof(string));
            }
            return base.ParamFromJSString(title, message);
        }
    }
}