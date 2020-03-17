using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using NativeLibrary;

namespace CocosCreatorFormsSample.iOS
{
    public class GameViewController : RootViewController
    {
        public override bool CallNativeWithReturnBool(string title, string content)
        {
            return base.CallNativeWithReturnBool(title, content);
        }

        public override string CallNativeWithReturnString(string title, string content)
        {
            return base.CallNativeWithReturnString(title, content);
        }
    }
}