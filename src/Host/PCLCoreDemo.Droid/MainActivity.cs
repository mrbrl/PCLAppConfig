using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PCLCoreApp.Droid;
using PCLCoreDemo;
using PCLCoreDemo.ViewModels;
using PCLCoreDemo.Droid;

namespace PCLCoreDemo.Droid
{
    [Activity(Label = "PCLCoreDemo.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : CoreMainActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            if (bundle == null) bundle = new Bundle();

            // Set your start viewmodel here 
            RunApplication<PCLCoreDemoApplication, HomeViewModel>(this, bundle, InitialisePlatformContainers);
        }

        private static void InitialisePlatformContainers()
        {
            // register android specific dependencies
        }
    }
}

