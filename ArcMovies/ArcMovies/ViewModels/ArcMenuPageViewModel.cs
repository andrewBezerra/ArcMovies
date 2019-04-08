using ArcMovies.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ArcMovies.ViewModels
{
    public class ArcMenuPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public ObservableCollection<ArcMenuItem> MenuItems { get; set; }

        private ArcMenuItem selectedMenuItem;
        public ArcMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }

        public DelegateCommand NavigateCommand { get; private set; }
        public ArcMenuPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MenuItems = new ObservableCollection<ArcMenuItem>();

            MenuItems.Add(new ArcMenuItem()
            {
                Icon = "",
                PageName = nameof(MainPage),
                Title = "Coming Soon"
            });



            NavigateCommand = new DelegateCommand(Navigate);
        }

        async void Navigate()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
        }
    }
}
