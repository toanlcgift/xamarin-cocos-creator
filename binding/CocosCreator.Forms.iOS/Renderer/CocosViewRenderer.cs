using CocosCreator.Forms;
using CocosCreator.Forms.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using NativeLibrary;

[assembly: ExportRenderer(typeof(CocosView), typeof(CocosViewRenderer))]
namespace CocosCreator.Forms.iOS.Renderer
{
    public class CocosViewRenderer : ViewRenderer<CocosView, UIView>
    {
        static NativeCall nativeCall;
        public CocosViewRenderer()
        {
            AppController.InitGame("123456789");
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
            AppController.StartGame();
        }
    }
}