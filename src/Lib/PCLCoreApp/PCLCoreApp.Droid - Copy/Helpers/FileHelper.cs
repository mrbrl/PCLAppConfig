using System.IO;
using Android.Content.Res;
using PCLResolver.Resolvers;
using UnifiedStorage;

namespace Core.App.Droid.Helpers
{
    public static class FileHelper
    {
        /// Retreiving Configurations through temp config file
        /// </summary>
        /// <param name="Assets"></param>
        /// <returns></returns>
        public static IFile GetTempConfigFile(AssetManager Assets, string filename)
        {
            string configFromOriginalFile;
            using (StreamReader streamReader = new StreamReader(Assets.Open(filename)))
            {
                configFromOriginalFile = streamReader.ReadToEnd();
            }

            // Creating temporary config file in app storage
            IFile tempConfigFile = Resolver<AutofacResolver>.Instance.Resolve<IFileSystem>()
                .LocalStorage.CreateFileAsync(filename, CollisionOption.ReplaceExisting).Result;

            // On successful file creation
            if (tempConfigFile.ExistsAsync().Result)
            {
                // Writing configuration to the temp file
                using (var streamWriter = new StreamWriter(tempConfigFile.Path, false))
                {
                    streamWriter.Write(configFromOriginalFile);
                }
            }

            return tempConfigFile;
        }
    }
}