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
		public string Path
		{
			get
			{
				string configFromOriginalFile;
				try
				{
					using (StreamReader streamReader = new StreamReader(Xamarin.Forms.Forms.Context.Assets.Open("App.config")))
					{
						configFromOriginalFile = streamReader.ReadToEnd();
					}
				}
				catch
				{
					throw new FileNotFoundException(@"please link the 'App.config' file from your shared pcl project to
													the root directory of your android project, with build action
													'AndroidAsset'");
				}
				IFile file = FileSystem.Current.LocalStorage.CreateFileAsync("App.config",
					CreationCollisionOption.ReplaceExisting).Result;
				file.WriteAllTextAsync(configFromOriginalFile).Wait();

				return file.Path;
			}
		}
	}
}
