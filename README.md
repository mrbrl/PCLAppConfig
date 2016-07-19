# PCLAppConfig


Created for a xamarin demo at MSFT Singapore on 27/04/2016


Xamarin.Forms PCL:

	- PCL AppConfig : cross platfom xamarin forms app settings reader
	
## PCL AppConfig

usage:

- Install PCLAppConfig package from [nuget](https://www.nuget.org/packages/PCLAppConfig) to your PCL projects.
- Initialize ConfigurationManager.AppSettings on your portable project like below

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
ConfigurationManager.AppSettings["webapiaddress"]; // New API, not available in package yet.
ConfigurationManager.AppSettings.FirstOrDefault(x => x.Key == "webapiaddress").Value; // Old API currently available on package.
```

## Roadmap

- Add navigation examples
- Add portable filesystem support as provider config file stream
- Add Xamarin.Forms tdd testing shell (and therefore add the tests that i left out so far)


Comments and suggestions are welcomed!
