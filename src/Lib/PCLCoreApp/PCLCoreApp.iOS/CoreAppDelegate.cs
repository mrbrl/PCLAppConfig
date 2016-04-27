using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CoreApp;
using Foundation;
using PCLAppConfig.App.iOS;
using PCLAppConfig.Common;
using PCLAppConfig.Interfaces;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Platform.Mvvm;

namespace PCLAppConfig.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    public abstract class CoreAppDelegate : XFormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // see https://developer.xamarin.com/api/type/MonoTouch.UIKit.UIKitThreadAccessException
            UIApplication.CheckForIllegalCrossThreadCalls = true;

            return base.FinishedLaunching(app, options);
        }


        protected void RunApplication<TApp, TRootViewModel>(Action initialisePlatformContainers = null)
            where TApp : CoreApplication, new() where TRootViewModel : ViewModel
        {
            Forms.Init();

            //init iOS app
            var appIos = new CoreApplicationiOS();
            Resolver.Instance.Register<IXFormsApp>(appIos);
            appIos.Init(this, false);

            //init portable app
            var application = new TApp();
            application.Init(SetApplicationDomain, initialisePlatformContainers);
          
            application.SetMainPage<TRootViewModel, TRootViewModel>();

            LoadApplication(application);
        }

        private void SetApplicationDomain()
        {
            Resolver.Instance.Resolve<IApplicationDomain>().BaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            Resolver.Instance.Resolve<IApplicationDomain>().ConfigFilePath = System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            Resolver.Instance.Resolve<IApplicationDomain>().ExecutingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}