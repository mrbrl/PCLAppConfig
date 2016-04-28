using PCLAppConfig.Enum;

namespace PCLAppConfig.Interfaces
{
    public interface IApplicationDomain
    {
        string BaseDirectory { get; set; }
        string ConfigFilePath { get; set; }
        string ExecutingAssemblyName { get; set; }
        DeviceType DeviceType { get; set; }
    }
}