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
				string packageConfig = System.IO.Path.Combine(rootPath, Package.Current.DisplayName + ".exe.config");
				string exeConfig = System.IO.Path.Combine(rootPath, System.AppDomain.CurrentDomain.FriendlyName + ".exe.config");
				if (File.Exists(packageConfig))
				{
					return packageConfig;
				}
				else if (File.Exists(exeConfig))
				{
					return exeConfig;
				}
				else
				{
					return System.IO.Path.Combine(rootPath, "App.config");
				}
			}
		}
	}
}
