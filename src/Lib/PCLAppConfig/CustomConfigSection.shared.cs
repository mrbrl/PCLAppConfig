using System.Xml;

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
