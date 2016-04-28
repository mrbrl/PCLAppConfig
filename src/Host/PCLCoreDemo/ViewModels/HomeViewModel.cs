using System;
using System.Windows.Input;
using PCLAppConfig.Interfaces;
using PCLCoreApp;
using PCLCoreApp.Commands;
using PCLResolver;
using PCLResolver.Resolvers;


namespace PCLCoreDemo.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private string _configText;

        public string ConfigText
        {
            get { return _configText; }
            set
            {
                if (_configText == value) return;
                _configText = value;
                OnPropertyChanged(() => ConfigText);
            }
        }

        public ICommand PclSettingCommand => CommandBuilder.GetCommand((object o) => GetPclSetting(), o => true);
     

        public string GetPclSetting()
        {
            ConfigText = Resolver<AutofacResolver>.Instance.Resolve<IConfigManager>().GetAppSetting("config.text");
            return ConfigText;
        }

        public HomeViewModel()
        {
            SetViewModel();
        }

        private void SetViewModel()
        {
        }
    }
}