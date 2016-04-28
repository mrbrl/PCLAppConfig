using System;
using System.Reflection;
using Android.App;
using Android.OS;
using PCLCoreApp.Droid.Helpers;
using PCLAppConfig.Interfaces;
using PCLResolver;
using PCLResolver.Resolvers;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Platform.Mvvm;

namespace PCLCoreApp.Droid
{
    public abstract class CoreMainActivity : XFormsApplicationDroid
    {
        protected void RunApplication<TApp, TRootViewModel>(Activity activity, Bundle bundle,
            System.Action initialisePlatformContainers = null, Action onAuthenticated = null)
            where TApp : CoreApplication, new() where TRootViewModel : ViewModel
        {
            if (Resolver<AutofacResolver>.Instance.IsInitialised)
                return;

            var appAndroid = new CoreApplicationAndroid();
            Resolver<AutofacResolver>.Instance.Register<IXFormsApp>(appAndroid);
            appAndroid.Init(this, false);

            Forms.Init(activity, bundle);

            //init portable app
            var application = new TApp();
            application.Init(SetApplicationDomain, initialisePlatformContainers);

            base.OnCreate(bundle);

            application.SetMainPage<TRootViewModel, TRootViewModel>();

            LoadApplication(application);
        }

        private void SetApplicationDomain()
        {
            // Retreving configuration from temporary config file in app storage
            var tempConfigFile = FileHelper.GetTempConfigFile(Assets, "app.config");

            Resolver<AutofacResolver>.Instance.Resolve<IApplicationDomain>().BaseDirectory = tempConfigFile.Directory.Path;
            Resolver<AutofacResolver>.Instance.Resolve<IApplicationDomain>().ConfigFilePath = tempConfigFile.Path;
            Resolver<AutofacResolver>.Instance.Resolve<IApplicationDomain>().ExecutingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}