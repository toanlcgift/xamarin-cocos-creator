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
  Make sure the xxteakey is matched with your cocos creator's build setting
  
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
            global::Xamarin.Forms.Forms.Init();
            options = new NSDictionary(new NSString("xxtea_key"), new NSString("123456789"));
            return base.DidFinishLaunchingWithOptions(app, options);
            
        }
  ```
  Make sure the xxteakey is matched with your cocos creator's build setting
  
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
