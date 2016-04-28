using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Humanizer;
using PCLAppConfig.Infrastructure;
using PCLAppConfig.Interfaces;
using UnifiedStorage;


namespace PCLAppConfig
{
    public class ConfigManager : IConfigManager
    {
        private readonly IFileSystem _fileSystem;
        private readonly Dictionary<string, XDocument> _docMap;
        private readonly IApplicationDomain _applicationDomain;
        private const string ROOT_ELEMENT = "configuration";

        public List<Setting> AppSettings => LoadSection<Configuration>().Settings;

        public ConfigManager(IFileSystem fileSystem, IApplicationDomain applicationDomain)
        {
            _fileSystem = fileSystem;
            _applicationDomain = applicationDomain;
            _docMap = new Dictionary<string, XDocument>();
        }

        public string GetAppSetting(string key)
        {
            try
            {
                return AppSettings.First(x => x.Key == key).Value;
            }
            catch (Exception)
            {
                throw new Exception($"Configuration key not found: {key}");
            }
        } 

        public T LoadSection<T>()
        {
            // load custom sections
            // skip custom element if root is configuration
            var sectionName = typeof(T).Name.ToLower() == ROOT_ELEMENT ? null : typeof(T).Name.Camelize();
            var section = GetSection(sectionName, null);

            if (!(section is CustomConfigSection)) throw new Exception(
                "The configuration section '" + sectionName +
                "' must have a section handler of type '" +
                typeof(CustomConfigSection).FullName + "'.");

            if (section == null) throw new Exception(
                "Could not find configuration section '" + sectionName + "'.");

            using (var stream = new MemoryStream())
            {
                var element = ((CustomConfigSection)section).Element;
                element.Save(stream);
                stream.Position = 0;

                var serializer = new XmlSerializer(typeof(T));
                var result = serializer.Deserialize(stream);
                return (T)result;
            }
        }

        private object GetSection(string sectionName, string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
                configPath = _applicationDomain.ConfigFilePath;

            if (!_docMap.ContainsKey(configPath))
                InitDoc(configPath);

            var doc = _docMap[configPath];

            var section = string.IsNullOrEmpty(sectionName) ? doc.Element(ROOT_ELEMENT)
                : doc.Element(ROOT_ELEMENT).Element(sectionName);

            return new CustomConfigSection() { Element = section };
        }

        private void InitDoc(string configPath)
        {
            string fullPath;

            if (!(configPath.Contains("/") || configPath.Contains("\\")))
                fullPath = Path.Combine(_applicationDomain.BaseDirectory, configPath);
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