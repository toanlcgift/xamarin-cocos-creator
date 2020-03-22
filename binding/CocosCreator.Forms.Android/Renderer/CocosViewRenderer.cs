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
        public static CocosCreatorForms Cocos2dxForms;
        public CocosViewRenderer(Context context) : base(context)
        {

        }
        public CocosViewRenderer(Activity activity, Bundle savedInstanceState) : base(activity)
        {
            Java.Lang.JavaSystem.LoadLibrary("cocos2djs");
            Cocos2dxForms = new CocosCreatorForms();
            Cocos2dxForms.Setxxteakey("123456789");
            Cocos2dxForms.OnCreate(savedInstanceState, activity);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CocosView> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(Cocos2dxForms.MFrameLayout);
        }
    }
}