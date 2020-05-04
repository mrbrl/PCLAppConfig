using System;
using System.Collections.Generic;
using System.Text;
using DemoApp;
using TechTalk.SpecFlow;
using Xamariners.UnitTest.Xamarin.Infrastructure;

namespace PCLAppConfig.UnitTest.Tests
{
    [Binding]
    public class GeneralSteps : StepBase
    {
        private readonly MainViewModel _viewModel;
        public GeneralSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _viewModel = (MainViewModel)App.GetCurrentViewModel().Result;
        }
    }
}
