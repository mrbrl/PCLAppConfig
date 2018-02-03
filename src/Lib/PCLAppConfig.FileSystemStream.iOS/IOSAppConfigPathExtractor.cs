using System;
using System.Collections.Generic;
using System.IO;
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
			    try
			    {
			        return System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			    }
                catch
                {
                    throw new FileNotFoundException(@"please link the 'App.config' file from your shared pcl project to
													the root directory of your ios project");
                }
            }
		}
	}
}
