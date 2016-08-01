# PCLAppConfig


Created for a xamarin demo at MSFT Singapore on 27/04/2016


Xamarin.Forms PCL:

	- PCL AppConfig : cross platfom xamarin forms app settings reader
	
## PCL AppConfig

usage:

- Install PCLAppConfig package from [nuget](https://www.nuget.org/packages/PCLAppConfig) to your PCL projects.
- Initialize ConfigurationManager.AppSettings on your portable project like below

### FOR FILE SYSTEM  APP.CONFIG
``` C#
ConfigurationManager.InitializeStaticFields(PCLAppConfig.FileSystemStream.PortableStream.Current);
```
- Add an app.config on your shared pcl project, and add your appSettings entries, as you would do with any app.config
- Add this PCL app.config file as a linked file on all your paltform projects. For android, make sure to set the build action to  'AndroidAsset'


### FOR EMBEDDED APP.CONFIG
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

- Add Tests


Comments and suggestions are welcomed!
