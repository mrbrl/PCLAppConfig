using SpecFlow.XForms;
using DemoApp;
using SpecFlow.XFormsDependency;
using SpecFlow.XFormsExtensions;
using SpecFlow.XFormsNavigation;
using TechTalk.SpecFlow;

namespace PCLAppConfig.UnitTest.Test
{
    [Binding]
    public class GeneralSteps : TestStepBase
    {
        public GeneralSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            // you need to instantiate your steps by passing the scenarioContext to the base
        }

        [Given(@"I am on the main page")]
        public void GivenIAmOnTheMainPage()
        {
            Resolver.Instance.Resolve<INavigationService>().PushAsync<MainViewModel>();
            Resolver.Instance.Resolve<INavigationService>().CurrentViewModelType.ShouldEqualType<MainViewModel>();
        }
        
        [When(@"I click on the text button")]
        public void WhenIClickOnTheTextButton()
        {
            GetCurrentViewModel<MainViewModel>().PclSettingCommand.Execute(null);
        }
        
        [Then(@"I can see a Label with text ""(.*)""")]
        public void ThenICanSeeALabelWithText(string text)
        {
            GetCurrentViewModel<MainViewModel>().ConfigText.ShouldEqual(text);
        }
    }
}