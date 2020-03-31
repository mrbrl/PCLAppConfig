# PCLAppConfig

![CI on Push and Pull Request](https://github.com/soroshsabz/PCLAppConfig/workflows/CI%20on%20Push%20and%20Pull%20Request/badge.svg)


Xamarin.Forms .Net Standard:

	- PCL AppConfig : cross platfom xamarin forms app settings reader
	
## Usage


- Install PCLAppConfig package from [nuget](https://www.nuget.org/packages/PCLAppConfig) to your PCL and each target projects.

### FOR FILE SYSTEM  APP.CONFIG
- Initialize ConfigurationManager.AppSettings on PCL project like below:

``` C#
	ConfigurationManager.Initialise(PCLAppConfig.FileSystemStream.PortableStream.Current);
```

- Add an app.config on your shared pcl project, and add your appSettings entries, as you would do with any app.config
- Add this PCL app.config file as a linked file on all your platform projects. For android, make sure to set the build action to  'AndroidAsset', for UWP set the build action to 'Content'


### FOR EMBEDDED APP.CONFIG
- Initialize ConfigurationManager.AppSettings on your pcl project like below:

``` C#
	Assembly assembly = typeof(App).GetTypeInfo().Assembly;
	ConfigurationManager.Initialise(assembly.GetManifestResourceStream("DemoApp.App.config"));	
```

- Add an App.config on your shared pcl project and ensure that Build Action:EmbeddedResource, and add your appSettings entries, as you would do with any App.config

``` xml
<configuration>
	<appSettings>
        <add key="config.text" value="hello from app.settings!" />
    </appSettings>
</configuration>
```

- Access your setting:

``` C#
	ConfigurationManager.AppSettings["config.text"];

```

## Author
- Ben Ishiyama-levy (Xamariners)

## Contributors
- Seyyed Soroosh Hosseinalipour

## Roadmap

- Add encryption


Comments and suggestions are welcomed!
