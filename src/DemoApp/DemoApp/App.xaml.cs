using PCLAppConfig;
using System.Reflection;
using Xamarin.Forms;

namespace DemoApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
            
		    ConfigurationManager.Initialise();
            
            // Uncomment below to test resource based app config
            // Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            // ConfigurationManager.Initialise(assembly.GetManifestResourceStream("DemoApp.ResourceApp.config"));

            MainPage = new MainPage();
		}
	}
}
