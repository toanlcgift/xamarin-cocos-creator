using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CocosCreatorBinding.iOS;

namespace CocosCreator.Forms.iOS
{
    internal class NativeCall : NativeOcClass
    {
        public static event OnReceiveDataHandler ReceiveData;

        public delegate void OnReceiveDataHandler(string title, string message, Type type);
        public override bool CallNativeWithReturnBool(string title, string content)
        {
            var receive = ReceiveData;
            if (receive != null)
            {
                ReceiveData(title, content, typeof(int));
            }
            return base.CallNativeWithReturnBool(title, content);
        }

        public override string CallNativeWithReturnString(string title, string content)
        {
            var receive = ReceiveData;
            if (receive != null)
            {
                ReceiveData(title, content, typeof(int));
            }
            //AppController.EvalScript("cc.TestNativeCallJS()");
            return base.CallNativeWithReturnString(title, content);
        }
    }
}