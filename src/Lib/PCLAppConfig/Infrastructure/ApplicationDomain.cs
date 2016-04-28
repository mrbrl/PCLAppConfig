using System;
using System.Reflection;
using PCLAppConfig.Enum;
using PCLAppConfig.Interfaces;

namespace PCLAppConfig.Infrastructure
{
    public class ApplicationDomain : IApplicationDomain
    {
        private string _baseDirectory;
        private string _configFilePath;

        public string BaseDirectory
        {
            get { return GetBaseDirectory(); }
            set { _baseDirectory = value; }
        }

        public string ConfigFilePath
        {
            get { return GetConfigFilePath(); }
            set { _configFilePath = value; }
        }

        public string ExecutingAssemblyName { get; set; }
        public DeviceType DeviceType { get; set; }

        private string GetBaseDirectory()
        {
            if (!string.IsNullOrEmpty(_baseDirectory))
                return _baseDirectory;

            var currentDomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
            var baseDirectoryInfo = currentDomain.GetType().GetRuntimeProperty("BaseDirectory");
            _baseDirectory = (string)baseDirectoryInfo.GetValue(currentDomain);

            if(string.IsNullOrEmpty(_baseDirectory))
                throw new Exception("IApplicationDomain BaseDirectory not set");

            return _baseDirectory;
        }

        private string GetConfigFilePath()
        {
            if (!string.IsNullOrEmpty(_configFilePath))
                return _configFilePath;

            var currentDomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
            var setupInformationInfo = currentDomain.GetType().GetRuntimeProperty("SetupInformation");
            var setupInformation = setupInformationInfo.GetValue(currentDomain);
            var configurationFileInfo = setupInformation.GetType().GetRuntimeProperty("ConfigurationFile");
            var configurationFile = configurationFileInfo.GetValue(setupInformation);
            _configFilePath = (string) configurationFile;

            if (string.IsNullOrEmpty(_configFilePath))
                throw new Exception("IApplicationDomain ConfigFilePath not set");

            return _configFilePath;
        }
    }
}