
using Android.App;
using Android.OS;

namespace ArcMovies.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher = false,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}