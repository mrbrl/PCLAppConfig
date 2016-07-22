using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCLAppConfig.FileSystemStream.Android
{
	public class AndroidAppConfigPathExtractor : IAppConfigPathExtractor
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
