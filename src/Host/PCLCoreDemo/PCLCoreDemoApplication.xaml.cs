using System;
using PCLCoreApp;
using XLabs.Forms.Mvvm;
using PCLCoreDemo.ViewModels;
using PCLCoreDemo.Views;

namespace PCLCoreDemo
{
    public partial class PCLCoreDemoApplication : CoreApplication
    {
        public PCLCoreDemoApplication()
        {
           
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

            // add post init logic here
        }

        protected override void InitialiseContainer(Action initialisePlatformContainer = null)
        {
            base.InitialiseContainer(initialisePlatformContainer);

            // register shared dependencies here
        }
    }
}
