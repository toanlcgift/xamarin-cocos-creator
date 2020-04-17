using CocosCreator.Forms;
using CocosCreator.Forms.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CocosCreatorBinding.iOS;

[assembly: ExportRenderer(typeof(CocosView), typeof(CocosViewRenderer))]
namespace CocosCreator.Forms.iOS.Renderer
{
    public class CocosViewRenderer : ViewRenderer<CocosView, UIView>
    {
        static NativeCall nativeCall;

        public static void Init(string xxteakey = "")
        {
            AppController.InitGame(xxteakey);
            if (nativeCall == null)
            {
                nativeCall = new NativeCall();
                nativeCall.InitNativeCall();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CocosView> e)
        {
            base.OnElementChanged(e);

            var view = AppController.GetGameView();
            SetNativeControl(view);
            NativeCall.ReceiveData += NativeCall_ReceiveData;
            AppController.StartGame();
        }

        private void NativeCall_ReceiveData(string title, string message, System.Type type)
        {
            var element = this.Element;
            if (element != null)
                CocosView.Execute(element.NativeCallCommand, new JSMessage() { Title = title, Content = message, Type = type });
        }
    }
}