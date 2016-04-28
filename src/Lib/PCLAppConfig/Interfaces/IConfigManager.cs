using System.Collections.Generic;
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
