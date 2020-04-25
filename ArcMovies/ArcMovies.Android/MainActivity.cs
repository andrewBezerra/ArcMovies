using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using FFImageLoading;
using FFImageLoading.Forms.Platform;

namespace ArcMovies.Droid
{
    [Activity(
        Label = "ArcMovies",
        Icon = "@drawable/icon",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.SetTheme(Resource.Style.MainTheme);
            base.OnCreate(savedInstanceState);
            //var config = new FFImageLoading.Config.Configuration()

            //{

            //    VerboseLogging = false,
            //    VerbosePerformanceLogging = false,
            //    VerboseMemoryCacheLogging = false,
            //    VerboseLoadingCancelledLogging = false


            //};

            //ImageService.Instance.Initialize(config);
            CachedImageRenderer.Init(true);
            //CachedImageRenderer.iniInitImageViewHandler();
            //Android.Glide.Forms.Init();
            var t1 = typeof(CachedImageRenderer);
            var t2 = typeof(CachedImageFastRenderer);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

          
            LoadApplication(new App(new AndroidInitializer()));
           
        }
    }


  
}