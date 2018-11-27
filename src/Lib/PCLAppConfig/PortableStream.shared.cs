using System;
using System.IO;

namespace PCLAppConfig
{
    public static class PortableStream
	{
		private static readonly Lazy<Stream> _appConfigStream = new Lazy<Stream>(CreateAppConfigStream,
			System.Threading.LazyThreadSafetyMode.PublicationOnly);

		public static Stream Current
		{
			get
			{
				var result = _appConfigStream.Value;
				return result;
			}
		}

		private static Stream CreateAppConfigStream()
		{
			var pathExtractor = CreateAppConfigPathExtractor();
			if (pathExtractor == null)
				throw new NotImplementedException(@"This functionality is not implemented in the portable version of this assembly.
												You should reference the PCLAppConfig NuGet package from your main application project
												in order to reference the platform-specific implementation.");

			return GetStream(pathExtractor.Path);
		}

		private static IAppConfigPathExtractor CreateAppConfigPathExtractor()
		{
#if ANDROID
			return new AndroidAppConfigPathExtractor();
#elif __IOS__
			return new IOSAppConfigPathExtractor();
#elif WINDOWS_UWP
			return new UWPAppConfigPathExtractor();
#else
			return null;
#endif
		}

	    private static Stream GetStream(string configPath)
	    {
	        if (!File.Exists(configPath))
	        {
	            var dllConfigPath = configPath.Replace("iOS.exe", ".dll");

	            var dllConfigPathExists = File.Exists(dllConfigPath);

	            if (dllConfigPathExists)
	                return File.OpenRead(dllConfigPath);

	            throw new FileNotFoundException($"path: {configPath}");
	        }

	        return File.OpenRead(configPath);
	    }
	}
}