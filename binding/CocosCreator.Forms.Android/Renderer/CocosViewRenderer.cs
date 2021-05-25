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

        public static void Init(Activity activity, Bundle savedInstanceState, string xxteakey = "")
        {
            Java.Lang.JavaSystem.LoadLibrary("cocos2djs");
            Cocos2dxForms = new CocosCreatorForms();
            Cocos2dxForms.Setxxteakey(xxteakey);
            Cocos2dxForms.OnCreate(savedInstanceState, activity);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CocosView> e)
        {
            base.OnElementChanged(e);
            CocosCreatorForms.ReceiveData += CocosCreatorForms_ReceiveData;
            SetNativeControl(Cocos2dxForms.MFrameLayout);
        }

        private void CocosCreatorForms_ReceiveData(string title, string message, System.Type type)
        {
            var element = this.Element;
            if (element != null)
                CocosView.Execute(element.NativeCallCommand, new JSMessage() { Title = title, Content = message, Type = type });
        }
    }
}