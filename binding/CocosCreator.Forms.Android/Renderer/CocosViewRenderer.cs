using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using CocosCreator.Forms;
using CocosCreator.Forms.Android;
using Org.Cocos2dx.Lib;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CocosView), typeof(CocosViewRenderer))]
namespace CocosCreator.Forms.Android
{
    public class CocosViewRenderer : ViewRenderer<CocosView, FrameLayout>
    {
        public static Cocos2dxActivity Cocos2DxActivity;
        public CocosViewRenderer(Context context) : base(context)
        {
            
        }
        public CocosViewRenderer(Bundle savedInstanceState, Activity activity, Context context) : base(context)
        {
            Java.Lang.JavaSystem.LoadLibrary("cocos2djs");
            Cocos2DxActivity = new Cocos2dxActivity();
            Cocos2DxActivity.OnCreate(savedInstanceState, activity, context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CocosView> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(Cocos2DxActivity.MFrameLayout);
        }
    }
}