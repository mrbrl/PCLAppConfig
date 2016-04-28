# PCLAppConfig


Created for a xamarin demo at MSFT Singapore on 27/04/2016


Xamarin.Forms PCL:

	- PCL AppConfig : cross platfom xamarin forms app settings reader
	
	- PCL Resolver : cross platform cross container dependency injection resolver. can be equally used on asp.net mvc projects, xamarin projects, workers... one solution for all
	
	- PCL CoreApp : provides true MVVM separation of concerns: Put all you logic on the viemodel, use commands, binding, and leave the .xaml code behind empty, and makes your app tdd, bdd friendly.Control the app flow from the viewmodel, PCL dependency registration, viewmodel / model registration

	
## PCL AppConfig

usage:

1. register unified file system dependency (https://www.nuget.org/packages/UnifiedStorage/) on all your platforms using your favourite DI container (here with the included PCLResolver with Autofac)

```
Resolver<AutofacResolver>.Instance.Register<IFileSystem, FileSystem>();
```

2. register the PCLAppConfig 'IApplicationDomain' dependency on your shared library 

```
Resolver<AutofacResolver>.Instance.Register<IApplicationDomain, ApplicationDomain>(LifetimeScope.Singleton);
```

3. set the ApplicationDomain properties on all you platforms:


```
Resolver<AutofacResolver>.Instance.Resolve<IApplicationDomain>().BaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
Resolver<AutofacResolver>.Instance.Resolve<IApplicationDomain>().ConfigFilePath = System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
Resolver<AutofacResolver>.Instance.Resolve<IApplicationDomain>().ExecutingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
Resolver<AutofacResolver>.Instance.Resolve<IApplicationDomain>().DeviceType = DeviceType.iOS;
```

4. register the PCLAppConfig 'IConfigManager' dependency on your shared library 

```
Resolver<AutofacResolver>.Instance.Register<IConfigManager, ConfigManager>(LifetimeScope.Singleton);

```

5. Add an app.config on your shared pcl project, and add your appSettings entries, as you would do with any app.config
add a link to this file on all your platforms project. 
for android, link the 'app.config' file from your shared pcl project to the /Assets' directory of your android project, with build action 'AndroidAsset'
```
<configuration>
	<appSettings>
        <add key="config.text" value="hello from app.settings!" />
    </appSettings>
</configuration>
```

6. Access your setting:

```
Resolver<AutofacResolver>.Instance.Resolve<IConfigManager>().GetAppSetting("config.text");
```

If you use PCL CoreApp, you can skip points 1,2,3


## Roadmap
- Publish as Nuget
- Add navigation examples
- Add Xamarin.Forms tdd testing shell (and therefore add the tests that i left out so far)


Comments and suggestions are welcomed!