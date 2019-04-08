using Xamarin.Forms;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace ArcMovies.Views
{
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            InitializeComponent();

            //On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            NavigationPage.SetHasNavigationBar(this, false);
            Master = new MainPage();
          
            Detail = new NavigationPage(new MainPage());

        }
    }
}