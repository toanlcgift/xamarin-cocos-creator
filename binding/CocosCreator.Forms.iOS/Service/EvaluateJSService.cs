using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CocosCreator.Forms.iOS.Service;
using Foundation;
using UIKit;
using CocosCreatorBinding.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(EvaluateJSService))]
namespace CocosCreator.Forms.iOS.Service
{
    public class EvaluateJSService : IEvaluateJSService
    {
        public void InjectScript(string script)
        {
            AppController.EvalScript(script);
        }
    }
}