using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PCLAppConfig.Common;
using PCLAppConfig.Infrastructure;
using PCLAppConfig.Interfaces;

namespace PCLAppConfig.Helpers
{
    public static class ApplicationDomainHelpers
    {
        public static string GetBaseDirectory()
        {
            if (Resolver.Instance.IsInitialised)
            {
                var baseDirectory = Resolver.Instance.Resolve<IApplicationDomain>().BaseDirectory;
                if (!string.IsNullOrEmpty(baseDirectory))
                    return baseDirectory;
            }

            var currentDomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
            var baseDirectoryInfo = currentDomain.GetType().GetRuntimeProperty("BaseDirectory");
            return (string)baseDirectoryInfo.GetValue(currentDomain);
        }

        public static string GetConfigFilePath()
        {
            if (Resolver.Instance.IsInitialised)
            {
                var configFilePath = Resolver.Instance.Resolve<IApplicationDomain>().ConfigFilePath;

                if (!string.IsNullOrEmpty(configFilePath))
                    return configFilePath;
            }

            var currentDomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
            var setupInformationInfo = currentDomain.GetType().GetRuntimeProperty("SetupInformation");
            var setupInformation = setupInformationInfo.GetValue(currentDomain);
            var configurationFileInfo = setupInformation.GetType().GetRuntimeProperty("ConfigurationFile");
            var configurationFile = configurationFileInfo.GetValue(setupInformation);
            return (string)configurationFile;
        }
    }
}
