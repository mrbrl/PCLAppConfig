using PCLAppConfig.Common;
using UnifiedStorage;
using UnifiedStorage.Android;
using XLabs.Forms;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Geolocation;
using XLabs.Platform.Services.IO;
using XLabs.Platform.Services.Media;

namespace PCLAppConfig.App.Droid
{
    public class CoreApplicationAndroid : XFormsAppDroid
    {
        protected override void OnInit(XFormsApplicationDroid app, bool initServices = true)
        {
            // setting this to false to prevent XLabs registering services in its own global static container
            base.OnInit(app, false);
            InitialiseContainer();
        }

        private void InitialiseContainer()
        {
            Resolver.Instance.Register<IFileSystem, FileSystem>();

            //manually registering XLabs services into our container so that they're globally available
            Resolver.Instance.Register<IGeolocator, Geolocator>();
            Resolver.Instance.Register<IMediaPicker, MediaPicker>();
            Resolver.Instance.Register<ISoundService, SoundService>();
            Resolver.Instance.Register<IFileManager, FileManager>();
            Resolver.Instance.Register<IDevice>(AndroidDevice.CurrentDevice);
        }
    }
}