<p align="center">
<img src="docs/banner.png" alt="Xamarin.CocosCreator banner" height="300" >
</p>

# Xamarin.CocosCreator #

## Packages ##

Platform/Feature               | Package name                              | Stable      | Lastest | Cocos Creator Version
-----------------------|-------------------------------------------|-----------------------------|------------------------- |-------------------------|
CocosCreator             | `CocosCreator` | ![NuGet](https://img.shields.io/static/v1?label=nuget&message=2.2.1&color=green) - ![NuGet](https://img.shields.io/static/v1?label=nuget&message=2.2.5&color=green) | [![NuGet](https://badge.fury.io/nu/CocosCreator.svg)](https://www.nuget.org/packages/CocosCreator/) | 2.2.0 - 2.2.2 |
CocosCreator             | `CocosCreator` | ![NuGet](https://img.shields.io/static/v1?label=nuget&message=2.2.6&color=green) | [![NuGet](https://badge.fury.io/nu/CocosCreator.svg)](https://www.nuget.org/packages/CocosCreator/) | 2.3.0 |


## Getting Started ##

### Environment ###

- CocosCreator v2.x
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

##### 1. Create Android Activity #####

```C#
  public class MainActivity : Cocos2dxActivity
  ```
  
##### 2. Override OnCreate #####

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

##### 3. override Cocos2dxGLSurfaceView OnCreateView() #####

```C#
  public override Cocos2dxGLSurfaceView OnCreateView()
        {
            Cocos2dxGLSurfaceView glSurfaceView = new Cocos2dxGLSurfaceView(this);
            glSurfaceView.SetEGLConfigChooser(8, 8, 8, 8, 16, 0);
            return glSurfaceView;
        }
  ```
  
  ##### 4. Copy Resources #####
  
  Copy resources in Cocos Creator's build folder to Xamarin.Android Assets folder (except frameworks & js backups folder)
  
  - jsb-adapter
  - res
  - src
  - subpackages
  - main.js
  - project.json
  - ...
  
  ##### 5. Add to your android project *.csproj file #####
  
  ```xml
  <ItemGroup>
    <AndroidAsset Include="Assets\**" />
  </ItemGroup>
  ```
  
### Xamarin iOS ###
##### Install nuget CocosCreator #####

##### 1. Create iOS AppDelegate #####

```C#
  public partial class AppDelegate : AppController
  ```
  
##### 2. Override DidFinishLaunchingWithOptions #####

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

  ##### 3. Copy Resources #####
  
  Copy resources in Cocos Creator's build folder to Xamarin.iOS Resources folder (except frameworks & js backups folder)
  
  - jsb-adapter
  - res
  - src
  - subpackages
  - main.js
  - project.json
  - ...
  
  ##### 4. Add to your iOS project *.csproj file #####
  
  ```xml
    <BundleResource Include="Resources\**">
      <Optimize>False</Optimize>
    </BundleResource>
  ```
  
  ##### Please run sample project to check all configuration #####
  
  *NOTE: This package does not support iOS emulator*
  
  ### Advanced topics ###
  
  ##### 1. How to Call Xamarin.Android & Xamarin.iOS C# methods using JavaScript #####
  
  please refer articles for [android](https://docs.cocos.com/creator/manual/en/advanced-topics/java-reflection.html) & [ios](https://docs.cocos.com/creator/manual/en/advanced-topics/oc-reflection.html) first
  
  In cocos creator javascript:
  
  ```js
  if (cc.sys.os === cc.sys.OS_ANDROID) {

            var result = jsb.reflection.callStaticMethod("org/cocos2dx/lib/Cocos2dxActivity",
             "paramFromJSStaticString", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;",
              "cocos2d-js",
               "Native Call Test");
            cc.log(result);
        }
        else if (cc.sys.os === cc.sys.OS_IOS) {
            var ret = jsb.reflection.callStaticMethod("NativeOcClass",
                "callNativeWithReturnString:andContent:",
                "cocos2d-js",
                "Native Call Test");
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
  ##### 2. C# Call Javascript #####
  - Xamarin.Android:
  
  ```C#
    app.RunOnGLThread(new Runnable(() =>
            {
                Cocos2dxJavascriptJavaBridge.EvalString("cc.TestNativeCallJS()");
            }));
   ```
   
   - Xamarin.iOS :
   
   ```C#
    AppController.EvalScript("cc.TestNativeCallJS()");
   ```
   
  ##### 3. Cocos Creator HotUpdate #####
  
  Of course, it's fully compatible with Xamarin!
  
  ##### 4. SDK box integration? #####
  
  No, don't need anymore, we have Xamarin Community instead!
