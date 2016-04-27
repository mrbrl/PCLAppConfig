using System;
using System.Reflection;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Core.App.Droid.Helpers;
using CoreApp;
using PCLAppConfig.App.Droid;
using PCLAppConfig.Common;
using PCLAppConfig.Interfaces;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Platform.Mvvm;

namespace PCLAppConfig.Droid
{
    [Activity(Label = "PCLAppConfig", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public abstract class CoreMainActivity : XFormsApplicationDroid
    {
        protected void RunApplication<TApp, TRootViewModel>(Activity activity, Bundle bundle,
            System.Action initialisePlatformContainers = null, Action onAuthenticated = null)
            where TApp : CoreApplication, new() where TRootViewModel : ViewModel
        {
            if (Resolver.Instance.IsInitialised)
                return;

            var appAndroid = new CoreApplicationAndroid();
            Resolver.Instance.Register<IXFormsApp>(appAndroid);
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

            Resolver.Instance.Resolve<IApplicationDomain>().BaseDirectory = tempConfigFile.Directory.Path;
            Resolver.Instance.Resolve<IApplicationDomain>().ConfigFilePath = tempConfigFile.Path;
            Resolver.Instance.Resolve<IApplicationDomain>().ExecutingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}