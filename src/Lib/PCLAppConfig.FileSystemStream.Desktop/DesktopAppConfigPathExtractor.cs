using System.Reflection;

namespace PCLAppConfig.FileSystemStream
{
    public class DesktopAppConfigPathExtractor : IAppConfigPathExtractor
    {
        private string _path;

        public string Path
        {
            get
            {
                string rootPath;
                if (_path == null &&
                    (rootPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) != null)
                {
                    _path = System.IO.Path.Combine(rootPath, "App.config");
                }

                return _path;
            }
        }
    }
}
