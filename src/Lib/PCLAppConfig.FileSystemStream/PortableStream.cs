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
		public static async Task<Stream> GetStreamAsync(string path)
		{
			IFile file = FileSystem.Current.LocalStorage.GetFile(path).Result;
			if (file == null)
				throw new FileNotFoundException($"path: {path}");
			return await file.OpenAsync(FileAccess.Read);
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
	}
}
