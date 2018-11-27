using System.Collections.Generic;
using System.Xml.Serialization;

namespace PCLAppConfig
{
    [XmlRoot("configuration")]
    public class Configuration
    {
        public Configuration()
        {
            Settings = new List<Setting>();
        }

        [XmlArray("appSettings")]
        [XmlArrayItem(typeof(Setting), ElementName = "add")]
        public List<Setting> Settings { get; set; }
    }

    [XmlRoot("add")]
    public class Setting : INameValueElement<string>
    {
        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}