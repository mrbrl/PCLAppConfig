using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLAppConfig.Common;
using PCLAppConfig.Interfaces;
using XLabs.Forms.Mvvm;

namespace PCLAppConfig.App.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        public string ConfigText { get; set; }


        public HomeViewModel()
        {
            SetViewModel();
        }

        private void SetViewModel()
        {
            ConfigText = Resolver.Instance.Resolve<IConfigManager>().GetAppSetting("config.text");
        }
    }
}
