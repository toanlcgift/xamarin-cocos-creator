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
using CocosCreator.Forms.Android.Service;
using Java.Lang;
using Org.Cocos2dx.Lib;

[assembly: Xamarin.Forms.Dependency(typeof(EvaluateJSService))]
namespace CocosCreator.Forms.Android.Service
{
    public class EvaluateJSService : IEvaluateJSService
    {
        public void InjectScript(string script)
        {
            CocosViewRenderer.Cocos2dxForms.RunOnGLThread(new Runnable(() =>
            {
                Cocos2dxJavascriptJavaBridge.EvalString(script);
            }));
        }
    }
}