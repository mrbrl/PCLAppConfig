# PCLAppConfig


Created for a xamarin demo at MSFT Singapore on 27/04/2016


Xamarin.Forms PCL:

	- PCL AppConfig : cross platfom xamarin forms app settings reader
	
## PCL AppConfig

usage:

- Install PCLAppConfig package from [nuget](https://www.nuget.org/packages/PCLAppConfig) to your PCL projects.

### FOR FILE SYSTEM  APP.CONFIG
- Initialize ConfigurationManager.AppSettings on each of your  platform project, just after  'Xamarin.Forms.Forms.Init'  like below:

#### iOS (AppDelegate.cs)
``` C#
  global::Xamarin.Forms.Forms.Init();

   ConfigurationManager.Initialise(PCLAppConfig.FileSystemStream.PortableStream.Current);

    LoadApplication(new App());
```

#### Android (MainActivity.cs)
``` C#
  global::Xamarin.Forms.Forms.Init(this, bundle);

   ConfigurationManager.Initialise(PCLAppConfig.FileSystemStream.PortableStream.Current);

    LoadApplication(new App());
```

#### UWP / Windows 8.1 / WP 8.1 (App.xaml.cs)
``` C#
	Xamarin.Forms.Forms.Init(e);

    ConfigurationManager.Initialise(PCLAppConfig.FileSystemStream.PortableStream.Current);
```

- Add an app.config on your shared pcl project, and add your appSettings entries, as you would do with any app.config
- Add this PCL app.config file as a linked file on all your platform projects. For android, make sure to set the build action to  'AndroidAsset', for UWP set the build action to 'Content'


### FOR EMBEDDED APP.CONFIG
- Initialize ConfigurationManager.AppSettings on your pcl project like below:

``` C#
Assembly assembly = typeof(App).GetTypeInfo().Assembly;
ConfigurationManager.AppSettings = new ConfigurationManager(assembly.GetManifestResourceStream("DemoApp.App.config")).GetAppSettings;
```

- Add an app.config on your shared pcl project and ensure that Build Action:EmbeddedResource, and add your appSettings entries, as you would do with any app.config

``` xml
<configuration>
	<appSettings>
        <add key="config.text" value="hello from app.settings!" />
    </appSettings>
</configuration>
```

- Access your setting:

``` C#
ConfigurationManager.AppSettings["webapiaddress"];

```

## Roadmap

- Complete fs config for windows 8.1 & WP 8.1
- Add Tests


Comments and suggestions are welcomed!
