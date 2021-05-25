using Android.Content;
using Org.Cocos2dx.Lib;
using System;

namespace CocosCreator.Forms.Android
{
    public class CocosCreatorForms : Org.Cocos2dx.Lib.Cocos2dxForms
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
            var receive = ReceiveData;
            if (receive != null)
            {
                ReceiveData(title, message, typeof(string));
            }
            return base.ParamFromJSString(title, message);
        }

        public override Cocos2dxGLSurfaceView OnCreateView(Context context)
        {
            Cocos2dxGLSurfaceView glSurfaceView = new Cocos2dxGLSurfaceView(context);
            glSurfaceView.SetEGLConfigChooser(5, 6, 5, 0, 16, 8);
            return glSurfaceView;
        }
    }
}