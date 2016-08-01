using Xamarin.Forms;

using PCLAppConfig;

namespace DemoApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            // Uncomment below to test resource based app config
            // Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            //ConfigurationManager.InitializeStaticFields(assembly.GetManifestResourceStream("DemoApp.ResourceApp.config"));

            // Uncomment below to test file system based app config
            // You need to ling the PCL Project app.config in your platform app project
            ConfigurationManager.InitializeStaticFields(PCLAppConfig.FileSystemStream.PortableStream.Current);

			MainPage = new MainPage();
		}
	}
}
