using Foundation;
using PCLAppConfig.Common;
using UnifiedStorage;
using UnifiedStorage.iOS;
using XLabs.Forms;

using XLabs.Platform.Device;
using XLabs.Platform.Services.Geolocation;
using XLabs.Platform.Services.IO;
using XLabs.Platform.Services.Media;

namespace PCLAppConfig.App.iOS
{
    public class CoreApplicationiOS : XFormsAppiOS
    {
        [Preserve]
        public CoreApplicationiOS()
        {
        }

        protected override void OnInit(XFormsApplicationDelegate app, bool initServices = true)
        {
            // setting this to false to prevent XLabs registering services in its own global static container
            base.OnInit(app, false);
            InitialiseContainer();
        }

        private void InitialiseContainer()
        {
            // platform-specific registrations
            Resolver.Instance.Register<IFileSystem, FileSystem>();

            // manually registering XLabs services into our container so that they're globally available
            Resolver.Instance.Register<IGeolocator, Geolocator>();
            Resolver.Instance.Register<IMediaPicker, MediaPicker>();
            Resolver.Instance.Register<ISoundService, SoundService>();
            Resolver.Instance.Register<IFileManager, FileManager>();
            Resolver.Instance.Register<IDevice>(AppleDevice.CurrentDevice);
        }
    }
}
