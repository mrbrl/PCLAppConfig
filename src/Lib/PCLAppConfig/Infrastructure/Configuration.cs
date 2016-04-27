using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PCLAppConfig.Infrastructure
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
    public class Setting
    {
        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
