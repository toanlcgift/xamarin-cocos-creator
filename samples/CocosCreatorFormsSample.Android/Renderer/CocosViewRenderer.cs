using Android.Content;
using Android.Widget;
using CocosCreator.Forms;
using CocosCreatorFormsSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CocosView), typeof(CocosViewRenderer))]
namespace CocosCreatorFormsSample.Droid
{
    public class CocosViewRenderer : ViewRenderer<CocosView, FrameLayout>
    {
        public CocosViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CocosView> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(MainActivity.Cocos2DxActivity.MFrameLayout);
        }
    }
}