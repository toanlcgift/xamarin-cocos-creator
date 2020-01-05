<p align="center">
<img src="docs/banner.png" alt="Xamarin.CocosCreator banner" height="300" >
</p>

# Xamarin.CocosCreator #

## Packages ##

Platform/Feature               | Package name                              | Stable      | Prerelease |
-------------------------------------------|-----------------------------|------------------------- |-------------------------|
CocosCreator             | `CocosCreator` | [![NuGet](https://img.shields.io/nuget/v/CocosCreator?style=flat-square&label=nuget)](https://www.nuget.org/packages/CocosCreator/) | [![NuGet](https://img.shields.io/nuget/vpre/CocosCreator?style=flat-square&label=nuget)](https://www.nuget.org/packages/CocosCreator/) |


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
  
  
  
  3. Copy Resources
  
  

### Xamarin iOS ###
##### Install nuget CocosCreator #####

