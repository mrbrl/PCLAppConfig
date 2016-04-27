using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreApp;
using CoreApp.Commands;
using PCLAppConfig.Common;
using PCLAppConfig.Interfaces;
using XLabs.Forms.Mvvm;


namespace PCLAppConfig.App.ViewModels
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

        public ICommand PclCommand => CommandBuilder.GetCommand((object o) => GetPcl(), o => true);

        public ICommand NativeCommand => CommandBuilder.GetCommand((object o) => GetNative(), o => true);
      
        public ICommand ConstantCommand => CommandBuilder.GetCommand((object o) => GetConstant(), o => true);

        public string GetPcl()
        {
            ConfigText = Resolver.Instance.Resolve<IConfigManager>().GetAppSetting("config.text");
            return ConfigText;
        }

        public string GetNative()
        {
            throw new NotImplementedException();
        }

        public string GetConstant()
        {
            throw new NotImplementedException();
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
