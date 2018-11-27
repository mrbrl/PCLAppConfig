using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace PCLAppConfig
{
	public class UWPAppConfigPathExtractor : IAppConfigPathExtractor
	{
		public string Path
		{
			get
			{
				string rootPath = Package.Current.InstalledLocation.Path;
				return System.IO.Path.Combine(rootPath, "App.config");
			}
		}
	}
}
