using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLAppConfig.Interfaces
{
    public interface IConfigManager
    {
        object GetSection(string sectionName, string configPath);
    }
}
