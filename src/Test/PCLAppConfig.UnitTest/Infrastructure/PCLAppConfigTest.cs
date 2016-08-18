using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp;
using SpecFlow.XForms;
using SpecFlow.XFormsNavigation;

namespace PCLAppConfig.UnitTest.Infrastructure
{
    public class PCLAppConfigTest : TestApp
    {
        protected override void SetViewModelMapping()
        {
            TestViewFactory.EnableCache = false;

            // register your views / viewmodels below
            RegisterView<MainPage, MainViewModel>();
        }

        protected override void InitialiseContainer()
        {
            // add any di registration here
            // Resolver.Instance.Register<TInterface, TType>();
            base.InitialiseContainer();
        }
    }
}
