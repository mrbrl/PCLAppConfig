using System.Collections;
using System.Reflection;
using BoDi;
using TechTalk.SpecFlow;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace PCLAppConfig.UnitTest.Infrastructure
{
    [Binding]
    public class SetupHooks : Xamariners.UnitTest.Xamarin.Infrastructure.SetupHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public SetupHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext) : base(objectContainer)
        {
            _scenarioContext = scenarioContext;
        }
        /// <summary>
        ///     The before scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            base.BeforeScenario();
            App = new TestApp();
        }


        [AfterScenario(Order = 10)]
        public override void AfterScenario()
        {
            //base.AfterScenario();
            _scenarioContext.Clear();
        }
    }
}
