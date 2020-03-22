using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using NativeLibrary;

namespace CocosCreator.Forms.iOS
{
    internal class NativeCall : NativeOcClass
    {
        public override bool CallNativeWithReturnBool(string title, string content)
        {
            return base.CallNativeWithReturnBool(title, content);
        }

        public override string CallNativeWithReturnString(string title, string content)
        {
            //AppController.EvalScript("cc.TestNativeCallJS()");
            return base.CallNativeWithReturnString(title, content);
        }
    }
}