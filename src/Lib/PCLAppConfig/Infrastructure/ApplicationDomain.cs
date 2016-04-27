using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLAppConfig.Enum;
using PCLAppConfig.Interfaces;

namespace PCLAppConfig.Infrastructure
{
    public class ApplicationDomain : IApplicationDomain
    {
        public string BaseDirectory { get; set; }
        public string ConfigFilePath { get; set; }
        public string ExecutingAssemblyName { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}