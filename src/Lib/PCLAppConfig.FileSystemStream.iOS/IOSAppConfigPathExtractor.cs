using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCLAppConfig.FileSystemStream
{
	public class IOSAppConfigPathExtractor : IAppConfigPathExtractor
	{
		public string Path
		{
			get
			{
				return System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			}
		}
	}
}
