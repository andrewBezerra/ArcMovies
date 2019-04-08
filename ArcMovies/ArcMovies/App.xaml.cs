using ArcMovies.Services;
using ArcMovies.ViewModels;
using ArcMovies.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArcMovies
{
    public partial class App : PrismApplication
    {
        public App()
             : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ArcMenuPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<DetailsPage, DetailsViewModel>();
            containerRegistry.RegisterForNavigation<NoConnectionPage, NoConnectionViewModel>();
            //containerRegistry.RegisterForNavigation<MenuPage, MenuViewModel>();
            containerRegistry.RegisterSingleton<IHttpRequest, HttpRequest>();
            containerRegistry.RegisterSingleton<ITheMovieDBAPIService, TheMovieDBAPIService>();



        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"xf:///{nameof(ArcMenuPage)}/NavigationPage/{nameof(MainPage)}");
        }
    }
}
