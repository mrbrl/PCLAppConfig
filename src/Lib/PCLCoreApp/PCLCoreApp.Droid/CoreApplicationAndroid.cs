using PCLResolver;
using PCLResolver.Resolvers;
using UnifiedStorage;
using UnifiedStorage.Android;
using XLabs.Forms;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Geolocation;
using XLabs.Platform.Services.IO;
using XLabs.Platform.Services.Media;

namespace PCLCoreApp.Droid
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
            Resolver<AutofacResolver>.Instance.Register<IFileSystem, FileSystem>();

            //manually registering XLabs services into our container so that they're globally available
            Resolver<AutofacResolver>.Instance.Register<IGeolocator, Geolocator>();
            Resolver<AutofacResolver>.Instance.Register<IMediaPicker, MediaPicker>();
            Resolver<AutofacResolver>.Instance.Register<ISoundService, SoundService>();
            Resolver<AutofacResolver>.Instance.Register<IFileManager, FileManager>();
            Resolver<AutofacResolver>.Instance.Register<IDevice>(AndroidDevice.CurrentDevice);
        }
    }
}