using CocosCreator.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace NativeLibrary.Renderer
{
    public class CocosViewRenderer : ViewRenderer<CocosView, UIView>
    {
        public CocosViewRenderer()
        {
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