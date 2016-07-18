# PCLAppConfig


Created for a xamarin demo at MSFT Singapore on 27/04/2016


Xamarin.Forms PCL:

	- PCL AppConfig : cross platfom xamarin forms app settings reader
	
	- PCL Resolver : cross platform cross container dependency injection resolver. can be equally used on asp.net mvc projects, xamarin projects, workers... one solution for all
	
	- PCL CoreApp : provides true MVVM separation of concerns: Put all you logic on the viemodel, use commands, binding, and leave the .xaml code behind empty, and makes your app tdd, bdd friendly.Control the app flow from the viewmodel, PCL dependency registration, viewmodel / model registration

	
## PCL AppConfig

usage:

- Add an app.config on your shared pcl project and ensure that Build Action:EmbeddedResource, and add your appSettings entries, as you would do with any app.config

```
<configuration>
	<appSettings>
        <add key="config.text" value="hello from app.settings!" />
    </appSettings>
</configuration>
```

- Access your setting:

```
Resolver<AutofacResolver>.Instance.Resolve<IConfigManager>().GetAppSetting("config.text");
```

If you use PCL CoreApp, you can skip points 1,2,3


## Roadmap

- Publish as Nuget
- Add navigation examples
- Add Xamarin.Forms tdd testing shell (and therefore add the tests that i left out so far)


Comments and suggestions are welcomed!
