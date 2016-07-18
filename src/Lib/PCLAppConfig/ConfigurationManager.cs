using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Humanizer;
using PCLAppConfig.Infrastructure;

namespace PCLAppConfig
{
    public class ConfigurationManager
    {
		public static List<Setting> AppSettings { get; set; }

        public ConfigurationManager(Stream configurationFile)
        {
			this.configurationFile = configurationFile;
            this.docMap = new Dictionary<string, XDocument>();
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

		public List<Setting> GetAppSettings => LoadSection<Configuration>().Settings;

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
				configPath = CONFIG_APP_DEFAULT_PATH; 

            if (!this.docMap.ContainsKey(configPath))
                InitDoc(configPath);

            var doc = this.docMap[configPath];

            var section = string.IsNullOrEmpty(sectionName) ? doc.Element(ROOT_ELEMENT)
                : doc.Element(ROOT_ELEMENT).Element(sectionName);

            return new CustomConfigSection() { Element = section };
        }

        private void InitDoc(string configPath)
        {
            using (var reader = new StreamReader(configurationFile))
            {
                var doc = XDocument.Parse(reader.ReadToEnd());
                this.docMap.Add(configPath, doc);
            }
        }

        private const string ROOT_ELEMENT = "configuration";
		private const string CONFIG_APP_DEFAULT_PATH = "App.config";

        private readonly Dictionary<string, XDocument> docMap;

		private readonly Stream configurationFile; 
    }   
}