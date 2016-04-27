using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLAppConfig.Infrastructure;

namespace PCLAppConfig.Interfaces
{
    public interface IConfigManager
    {
        List<Setting> AppSettings { get; }

        string GetAppSetting(string key);

        T LoadSection<T>();
    }
}
