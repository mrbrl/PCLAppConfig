using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp;
using SpecFlow.XForms;
using TechTalk.SpecFlow;

namespace PCLAppConfig.UnitTest.Infrastructure
{
    [Binding]
    public class SetupHooks : TestSetupHooks
    {
        /// <summary>
        ///     The before scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            // bootstrap test app with your test app and your starting viewmodel
            new TestAppBootstrap().RunApplication<PCLAppConfigTest, MainViewModel>();
            ConfigurationManager.Initialise(PCLAppConfig.FileSystemStream.PortableStream.Current);
        }
    }
}
