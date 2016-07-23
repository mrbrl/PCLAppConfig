using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLAppConfig.FileSystemStream
{
	public static class PortableStream
	{
		private static Lazy<Stream> appConfigStream = new Lazy<Stream>(() => CreateAppConfigStream(),
			System.Threading.LazyThreadSafetyMode.PublicationOnly);

		public static Stream Current
		{
			get
			{
				Stream result = appConfigStream.Value;
				return result;
			}
		}

		private static Stream CreateAppConfigStream()
		{
			IAppConfigPathExtractor pathExtractor = CreateAppConfigPathExtractor();
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

		private static Stream GetStream(string path)
		{
			IFile file = FileSystem.Current.GetFileFromPath(path).Result;
			if (file == null)
				throw new FileNotFoundException($"path: {path}");
			return file.Open(PCLStorage.FileAccess.Read).Result;
		}

		private static async Task<ExistenceCheckResult> CheckExists(this IFolder folder, string path)
		{
			return await Task.Run(() => folder.CheckExistsAsync(path)).ConfigureAwait(false);
		}

		private static async Task<IList<IFile>> GetFiles(this IFolder folder)
		{
			return await Task.Run(() => folder.GetFilesAsync()).ConfigureAwait(false);
		}
		private static async Task<IFile> GetFile(this IFolder folder, string name)
		{
			return await Task.Run(() => folder.GetFileAsync(name)).ConfigureAwait(false);
		}

		private static async Task<IFile> GetFileFromPath(this IFileSystem fileSystem, string path)
		{
			return await Task.Run(() => fileSystem.GetFileFromPathAsync(path)).ConfigureAwait(false);
		}

		private static async Task<Stream> Open(this IFile file, PCLStorage.FileAccess fileAccess)
		{
			return await Task.Run(() => file.OpenAsync(fileAccess)).ConfigureAwait(false);
		}
	}
}
