using Android.App;
using Android.Content.PM;
using Android.OS;



namespace ArcMovies.Droid
{
    [Activity(
        Label = "ArcMovies",
        Icon = "@drawable/icon",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.SetTheme(Resource.Style.MainTheme);
            base.OnCreate(savedInstanceState);
          
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //Android.Glide.Forms.Init();
            LoadApplication(new App(new AndroidInitializer()));
        }
    }


  
}