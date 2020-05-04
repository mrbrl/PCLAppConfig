using System.Threading.Tasks;
using DemoApp;

namespace PCLAppConfig.UnitTest
{
	public partial class TestApp : Xamariners.UnitTest.Xamarin.TestApp
    {
        private static MainViewModel _mainViewModel;

		public TestApp() : base(GetCurrentViewModelImpl, () => typeof(MainViewModel), GoBackImpl, "PCLAppConfig.UnitTest.dll.config")
        {
            InitializeComponent();

            // Uncomment below to test resource based app config
            // Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            //ConfigurationManager.AppSettings = null;
            // ConfigurationManager.Initialise(assembly.GetManifestResourceStream("DemoApp.ResourceApp.config"));

            MainPage = new MainPage();
            _mainViewModel = (MainViewModel)MainPage.BindingContext;
        }

        private static async Task<object> GetCurrentViewModelImpl()
        {
            return _mainViewModel;
        }

        private static async Task GoBackImpl()
        {
        }
    }
}
