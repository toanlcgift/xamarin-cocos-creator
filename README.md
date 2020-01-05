<p align="center">
<img src="docs/banner.png" alt="Xamarin.CocosCreator banner" height="300" >
</p>

# Xamarin.CocosCreator #

## Packages ##

Platform/Feature               | Package name                              | Stable      | Prerelease | Cocos Creator Version
-----------------------|-------------------------------------------|-----------------------------|------------------------- |-------------------------|
CocosCreator             | `CocosCreator` | [![NuGet](https://img.shields.io/nuget/v/CocosCreator?style=flat-square&label=nuget)](https://www.nuget.org/packages/CocosCreator/) | [![NuGet](https://img.shields.io/nuget/vpre/CocosCreator?style=flat-square&label=nuget)](https://www.nuget.org/packages/CocosCreator/) | 2.2.1 |


## Getting Started ##

### Environment ###

- CocosCreator v2.2.x
- Visual Studio 2017+

### Build your Cocos Creator Project ###

- template: default
- platform: android/iOS
- buildPath: ./build

<p align="center">
<img src="docs/buildsetting.png" alt="Xamarin.CocosCreator banner" height="800" >
</p>

### Xamarin Android ###
##### Install nuget CocosCreator #####

1. Create Android Activity

```C#
  public class MainActivity : Cocos2dxActivity
  ```
  
2. Override OnCreate

```C#
protected override void OnCreate(Bundle savedInstanceState)
        {
            if (!IsTaskRoot)
            {
                return;
            }

            Java.Lang.JavaSystem.LoadLibrary("cocos2djs");
            this.Setxxteakey("123456789");
            base.OnCreate(savedInstanceState);
            app = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
        }
  ```
  *NOTE: Make sure the xxteakey is matched with your cocos creator's build setting*
  
  <p align="center">
<img src="docs/xxkeytea.png" alt="Xamarin.CocosCreator banner" height="300" >
</p>

3. override Cocos2dxGLSurfaceView OnCreateView()

```C#
  public override Cocos2dxGLSurfaceView OnCreateView()
        {
            Cocos2dxGLSurfaceView glSurfaceView = new Cocos2dxGLSurfaceView(this);
            glSurfaceView.SetEGLConfigChooser(8, 8, 8, 8, 16, 0);
            return glSurfaceView;
        }
  ```
  
  4. Copy Resources
  
  Copy resources in Cocos Creator's build folder to Xamarin.Android Assets folder (except frameworks & js backups folder)
  
  - jsb-adapter
  - res
  - src
  - subpackages
  - main.js
  - project.json
  - ...
  
  5. Add to your android project *.csproj file
  
  ```xml
  <ItemGroup>
    <AndroidAsset Include="Assets\**" />
  </ItemGroup>
  ```
  
### Xamarin iOS ###
##### Install nuget CocosCreator #####

1. Create iOS AppDelegate

```C#
  public partial class AppDelegate : AppController
  ```
  
2. Override DidFinishLaunchingWithOptions

```C#
public override bool DidFinishLaunchingWithOptions(UIApplication app, NSDictionary options)
        {
            options = new NSDictionary(new NSString("xxtea_key"), new NSString("123456789"));
            return base.DidFinishLaunchingWithOptions(app, options);
            
        }
  ```
  *NOTE: Make sure the xxteakey is matched with your cocos creator's build setting*
  
  <p align="center">
<img src="docs/xxkeytea.png" alt="Xamarin.CocosCreator banner" height="300" >
</p>

  3. Copy Resources
  
  Copy resources in Cocos Creator's build folder to Xamarin.iOS Resources folder (except frameworks & js backups folder)
  
  - jsb-adapter
  - res
  - src
  - subpackages
  - main.js
  - project.json
  - ...
  
  4. Add to your iOS project *.csproj file
  
  ```xml
  <BundleResource Include="Resources\**\*.plist">
      <Optimize>False</Optimize>
    </BundleResource>
    <BundleResource Include="Resources\main.js" />
    <BundleResource Include="Resources\project.json" />
    <BundleResource Include="Resources\jsb-adapter\**" />
    <BundleResource Include="Resources\res\**" />
    <BundleResource Include="Resources\src\**" />
  ```
  
  ##### Please run sample project to check all configuration #####
  
  ### Advanced topics ###
  
  1. How to Call Xamarin.Android & Xamarin.iOS C# methods using JavaScript
  
  please refer articles for [android](https://docs.cocos.com/creator/manual/en/advanced-topics/java-reflection.html) & [ios](https://docs.cocos.com/creator/manual/en/advanced-topics/oc-reflection.html) first
  
  In cocos creator javascript:
  
  ```js
  if (cc.sys.os === cc.sys.OS_ANDROID) {

            var result = jsb.reflection.callStaticMethod("org/cocos2dx/lib/Cocos2dxActivity",
             "paramFromJSStaticString", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;",
              "title",
               "Native Call Test");
               
            cc.log(result);
        }
        else if (cc.sys.os === cc.sys.OS_IOS) {
            var ret = jsb.reflection.callStaticMethod("NativeOcClass",
                "callNativeUIWithTitle:andContent:",
                "cocos2d-js",
                "Yes! you call a Native UI from Reflection");
                
            cc.log(ret);
        }
  ```
  
  To get the value from js:
  
  - In android, override following methods in MainActivity:
   
   ```C#
    public override void ParamFromJSVoid(string title, string message)
        {
            System.Diagnostics.Debug.WriteLine($"title: {title}, message: {message}");
        }

        public override int ParamFromJSInt(string title, string message)
        {
            return base.ParamFromJSInt(title, message);
        }

        public override string ParamFromJSString(string title, string message)
        {
            return base.ParamFromJSString(title, message);
        }
   ```
   
   - In ios, override following methods in AppDelegate:
   
   ```C#
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
   ```
  2. Cocos Creator HotUpdate
  
  Of course, it's fully compatible with Xamarin!
