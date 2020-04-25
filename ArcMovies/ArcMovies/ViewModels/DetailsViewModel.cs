using ArcMovies.Models;
using ArcMovies.Services;
using Prism.Navigation;
using Prism.Services;

namespace ArcMovies.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
      
        private INavigationService _navigationService;
        private ITheMovieDBAPIService _TheMovieDBAPIService;

        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { SetProperty(ref _movie, value); }
        }
        //public Movie Movie
        //{
        //    get { return _movie; }
        //    set
        //    {
        //        _movie = value;
        //        OnPropertyChanged();
        //    }
        //}


        protected DetailsViewModel(ITheMovieDBAPIService theMovieDBAPIService, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            _TheMovieDBAPIService = theMovieDBAPIService;

        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {

            IsBusy = true;
            var movie = parameters.GetValue<Movie>("movie");
            Movie = movie;
            IsBusy = false;

        }
    }

}
