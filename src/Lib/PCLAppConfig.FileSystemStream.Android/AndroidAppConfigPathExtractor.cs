using Android.Content.Res;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PCLAppConfig.FileSystemStream
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

				IFile file = FileSystem.Current.LocalStorage.CreateFileAsync(CONFIG_APP_DEFAULT_PATH, CreationCollisionOption.ReplaceExisting).Result;
				file.WriteAllTextAsync(configFromOriginalFile).Wait();

				return file.Path;
			}
		}
	}
}
