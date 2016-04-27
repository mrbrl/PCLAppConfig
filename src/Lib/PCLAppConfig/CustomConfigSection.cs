using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
