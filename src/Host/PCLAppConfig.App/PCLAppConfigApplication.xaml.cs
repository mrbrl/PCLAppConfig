using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLAppConfig.App.ViewModels;
using PCLAppConfig.App.Views;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using CoreApp;

namespace PCLAppConfig.App
{
    public partial class PCLAppConfigApplication : CoreApplication
    {
        public PCLAppConfigApplication()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                // on tests, this will always throw an exception
                if (!tie.Message.Contains("MUST"))
                    throw;
            }
            catch (System.InvalidOperationException soe)
            {
                if (!soe.Message.Contains("MUST"))
                    throw;
            }
        }

        protected override void SetViewModelMapping()
        {
            ViewFactory.EnableCache = true;

            // register your views with viewmodels here
            RegisterView<HomeView, HomeViewModel>();
        }

        protected override void InitComplete()
        {
            base.InitComplete();

            // add stuff post init here
        }

        protected override void InitialiseContainer(Action initialisePlatformContainer = null)
        {
            base.InitialiseContainer(initialisePlatformContainer);

            // Add shared registrations here
        }
    }
}
