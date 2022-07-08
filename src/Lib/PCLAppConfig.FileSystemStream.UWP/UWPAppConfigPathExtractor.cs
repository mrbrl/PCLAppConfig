using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace PCLAppConfig.FileSystemStream
{
	public class UWPAppConfigPathExtractor : IAppConfigPathExtractor
	{
		public string Path
		{
			get
			{
				string rootPath = Package.Current.InstalledLocation.Path;
				string exeConfig = System.IO.Path.Combine(rootPath, Package.Current.DisplayName + ".exe.config");
				if (!File.Exists(exeConfig))
				{
					return System.IO.Path.Combine(rootPath, "App.config");
				}
				else
				{
					return exeConfig;
				}
			}
		}
	}
}
