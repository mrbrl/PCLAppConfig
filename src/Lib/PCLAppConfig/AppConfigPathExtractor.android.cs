using System;
using System.IO;

namespace PCLAppConfig
{
    public class AndroidAppConfigPathExtractor : IAppConfigPathExtractor
	{
	    private const string CONFIG_APP_DEFAULT_PATH = "App.config";
        public string Path
		{
			get
			{
				string configFromOriginalFile;
				try
				{
				    using (var sr = new StreamReader(Android.App.Application.Context.Assets.Open(CONFIG_APP_DEFAULT_PATH)))
				        configFromOriginalFile = sr.ReadToEnd();
				}
				catch
				{
					throw new FileNotFoundException($@"please link the '{CONFIG_APP_DEFAULT_PATH}' file from your shared pcl project to
													the 'Assets' directory of your android project, with build action
													'AndroidAsset'");
				}

			    var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			    var filePath = localFolder + "/" + CONFIG_APP_DEFAULT_PATH;

			    if (File.Exists(filePath))
			        File.Delete(filePath);

                File.WriteAllText(filePath, configFromOriginalFile);

				return filePath;
			}
		}
	}
}