using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CocosCreator.Forms
{
    public interface IEvaluateJSService
    {
        void InjectScript(string script);
    }

    public class JSBrigde
    {
        public static void EvaluateScript(string script)
        {
            DependencyService.Get<IEvaluateJSService>().InjectScript(script);
        }
    }
}
