using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PCLAppConfig.FileSystemStream
{
	public class DefaultConfigPathExtractor : IAppConfigPathExtractor
	{
		public string Path
		{
			get
			{
                var rootPath = System.IO.Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location);

                return System.IO.Path.Combine(rootPath, "App.config");
			}
		}
	}
}
