using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using PCLCoreApp.Commands;
using PCLCoreApp.Interfaces;
using PCLAppConfig;
using PCLAppConfig.Infrastructure;
using PCLAppConfig.Interfaces;
using PCLResolver;
using PCLResolver.Enum;
using PCLResolver.Resolvers;
using Xamarin.Forms;
using XLabs;
using XLabs.Enums;
using XLabs.Forms.Mvvm;
using XLabs.Platform.Mvvm;


namespace PCLCoreApp
{
    public abstract class CoreApplication : Application, IXFormsApp
    {
        private IXFormsApp _formsApp;
        private readonly List<Action> _viewMappingActions;

        public CoreApplication()
        {
            _viewMappingActions = new List<Action>();
        }

        /// <summary>
        ///     Initializes the application.
        /// </summary>
        public void Init(Action containerInitialized, Action initialisePlatformContainer = null)
        {
            // Setup Dependemcy injection container
            InitialiseContainer(initialisePlatformContainer);

            SetViewModelMapping();

            // build di container
            Resolver<AutofacResolver>.Instance.Initialise();

            // set internal Xlabs di container to our container
            XLabs.Ioc.Resolver.SetResolver(new XLabs.Ioc.Autofac.AutofacResolver(Resolver<AutofacResolver>.Instance.GetContainer<IContainer>()));

            containerInitialized();

            // apply mapping now the container is initialized
            ApplyViewMappings();

            _formsApp = Resolver<AutofacResolver>.Instance.Resolve<IXFormsApp>();

            if (_formsApp == null)
                throw new Exception("Failed to resolve IXFormsApp - please ensure your platform-specific app is registering itself with the container");
        }

        public void SetMainPage<TRootViewModel, TAuthenticatedViewModel>()
            where TRootViewModel : ViewModel
            where TAuthenticatedViewModel : ViewModel
        {
            var page = (Page)ViewFactory.CreatePage<TRootViewModel, Page>();
            var mainPage = new NavigationPage(page);
            MainPage = mainPage;
        }

        protected void RegisterView<TView, TViewModel>()
          where TView : class
          where TViewModel : class, IViewModel
        {
            Resolver<AutofacResolver>.Instance.Register<TViewModel>();
            _viewMappingActions.Add(() =>
            {
                ViewFactory.Register<TView, TViewModel>(x => Resolver<AutofacResolver>.Instance.Resolve<TViewModel>());
            });
        }

        private void ApplyViewMappings()
        {
            foreach (Action action in _viewMappingActions)
                action.Invoke();
        }

        protected abstract void SetViewModelMapping();

        protected virtual void InitComplete()
        {
            // Add stuff to be fired after init is complete
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected virtual void InitialiseContainer(Action initialisePlatformContainer = null)
        {
            initialisePlatformContainer?.Invoke();

            Resolver<AutofacResolver>.Instance.RegisterGeneric(typeof(IDelegateCommand<,>), typeof(DelegateCommand<,>), LifetimeScope.InstancePerDependency);
            Resolver<AutofacResolver>.Instance.Register<IApplicationDomain, ApplicationDomain>(LifetimeScope.Singleton);
            Resolver<AutofacResolver>.Instance.Register<IConfigManager, ConfigManager>(LifetimeScope.Singleton);
        }

        public bool IsInitialized { get; }
        public string AppDataDirectory { get; set; }
        public Orientation Orientation { get; }
        public Func<Task<bool>> BackPressDelegate { get; set; }
        public EventHandler<EventArgs> Initialize { get; set; }
        public EventHandler<EventArgs> Startup { get; set; }
        public EventHandler<EventArgs> Closing { get; set; }
        public EventHandler<EventArgs> Suspended { get; set; }
        public EventHandler<EventArgs> Resumed { get; set; }
        public EventHandler<EventArgs> Error { get; set; }
        public EventHandler<EventArgs<Orientation>> Rotation { get; set; }
        public EventHandler<EventArgs> BackPress { get; set; }
    }
}