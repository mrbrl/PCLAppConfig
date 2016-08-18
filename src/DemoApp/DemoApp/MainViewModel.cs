using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PCLAppConfig;
using Xamarin.Forms;

namespace DemoApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      
        private string _configText = "";

        public ICommand PclSettingCommand => new Command(() => GetPclSetting());

        public string ConfigText
        {
            get { return _configText; }
            set
            {
                if (_configText == value) return;
                _configText = value;
                OnPropertyChanged(nameof(ConfigText));
            }
        }

        public string GetPclSetting()
        {
            ConfigText = ConfigurationManager.AppSettings["testkey"];
            return ConfigText;
        }
    }
}
