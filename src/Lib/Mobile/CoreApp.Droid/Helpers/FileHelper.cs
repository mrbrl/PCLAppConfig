using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PCLAppConfig.Common;
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
            IFile tempConfigFile = Resolver.Instance.Resolve<IFileSystem>()
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