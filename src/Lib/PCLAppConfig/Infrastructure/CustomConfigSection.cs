using System.Xml;
using System.Xml.Linq;

namespace PCLAppConfig
{
    public class CustomConfigSection
    {
        protected void DeserializeSection(XmlReader reader)
        {
            Element = XElement.Load(reader);
        }

        public XElement Element { get; set; }
    }
}
