using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PCLAppConfig.Helpers;
using PCLAppConfig.Interfaces;
using UnifiedStorage;


namespace PCLAppConfig
{
    public class ConfigManager : IConfigManager
    {
        protected readonly IFileSystem _fileSystem;
        private Dictionary<string, XDocument> _docMap;
        private const string ROOT_ELEMENT = "configuration";

        public ConfigManager(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            _docMap = new Dictionary<string, XDocument>();
        }

        public object GetSection(string sectionName, string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
                configPath = ApplicationDomainHelpers.GetConfigFilePath();

            if (!_docMap.ContainsKey(configPath))
                InitDoc(configPath);

            var doc = _docMap[configPath];

            var section = doc.Element(ROOT_ELEMENT).Element(sectionName);

            return new CustomConfigSection() { Element = section };
        }

        private void InitDoc(string configPath)
        {
            string fullPath;

            if (!(configPath.Contains("/") || configPath.Contains("\\")))
                fullPath = Path.Combine(ApplicationDomainHelpers.GetBaseDirectory(), configPath);
            else
                fullPath = configPath;

            var file = _fileSystem.GetFileFromPathAsync(fullPath).Result;

            if (!file.ExistsAsync().Result)
                throw new Exception("Config file path not found: " + file.Path);

            var stream = file.OpenAsync(FileAccessOption.ReadOnly).Result;

            using (var reader = new StreamReader(stream))
            {
                var doc = XDocument.Parse(reader.ReadToEnd());
                _docMap.Add(configPath, doc);
            }
        }
    }   
}