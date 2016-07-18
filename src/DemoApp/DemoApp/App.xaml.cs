using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using PCLAppConfig;
using System.Reflection;

namespace DemoApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			Assembly assembly = typeof(App).GetTypeInfo().Assembly;
			ConfigurationManager.AppSettings = new ConfigurationManager(assembly.GetManifestResourceStream("DemoApp.App.config")).GetAppSettings;

			MainPage = new DemoApp.MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
