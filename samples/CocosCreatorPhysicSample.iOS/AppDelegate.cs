using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using NativeLibrary;
using UIKit;

namespace CocosCreatorSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : AppController
    {
        public override bool DidFinishLaunchingWithOptions(UIApplication app, NSDictionary options)
        {
            options = new NSDictionary(new NSString("xxtea_key"), new NSString("123456789"));
            return base.DidFinishLaunchingWithOptions(app, options);
        }

        public override bool CallNativeWithReturnBool(string title, string content)
        {
            System.Diagnostics.Debug.WriteLine($"CallNativeWithReturnBool: title: { title} & content: {content}");
            return base.CallNativeWithReturnBool(title, content);
        }

        public override string CallNativeWithReturnString(string title, string content)
        {
            System.Diagnostics.Debug.WriteLine($"CallNativeWithReturnString: title: { title} & content: {content}");
            return base.CallNativeWithReturnString(title, content);
        }
    }
}
