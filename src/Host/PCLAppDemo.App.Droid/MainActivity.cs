using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PCLAppConfig.App.ViewModels;
using PCLAppConfig.Droid;


namespace PCLAppConfig.App.Droid
{
    [Activity(Label = "tippstr", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : CoreMainActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            if (bundle == null) bundle = new Bundle();

            // Set your start viewmodel here 
            RunApplication<PCLAppConfigApplication, HomeViewModel>(this, bundle, InitialisePlatformContainers);
        }

        private static void InitialisePlatformContainers()
        {
            // register android specific
        }
    }
}