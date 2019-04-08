using ArcMovies.Models;
using ArcMovies.Services;
using ArcMovies.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArcMovies.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Movie> Movies { get; }

        private DelegateCommand<Movie> _ShowMovieCommand;
        public DelegateCommand<Movie> ShowMovieCommand =>
            _ShowMovieCommand ?? (_ShowMovieCommand = new DelegateCommand<Movie>(async (itemSelect) =>
            await ExecuteShowMovieCommand(itemSelect), (itemSelect) => !IsBusy));

        private DelegateCommand<Movie> _loadMoreCommand;
        public DelegateCommand<Movie> LoadMoreCommand =>
            _loadMoreCommand ?? (_loadMoreCommand = new DelegateCommand<Movie>(async (itemSelect) =>
            await ExecuteLoadMoreCommand(itemSelect), (itemSelect) => !IsBusy));

        private DelegateCommand _pullToRefreshCommand;
        public DelegateCommand PullToRefreshCommand =>
            _pullToRefreshCommand ?? (_pullToRefreshCommand = new DelegateCommand(async () =>
             await ExecutePullToRefreshCommand(), () => !IsBusy));

        ITheMovieDBAPIService _TheMovieDBAPIService;

        private int _pageindex = 1;

        protected MainViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService, ITheMovieDBAPIService theMovieDBAPIService) : base(navigationService, pageDialogService)
        {
            Title = "Coming Soon";

            Movies = new ObservableCollection<Movie>();
            _TheMovieDBAPIService = theMovieDBAPIService;

            if (!HasConectivity)
                NavigationService.NavigateAsync("NoConnectionPage");

        }


        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            if (HasConectivity)
                await LoadAsync();

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var navigationMode = parameters.GetNavigationMode();
            if (navigationMode == NavigationMode.Back)
            {
                Console.Write("Voltei!");
                return;
            }
            else
            {
                Console.Write("Navegando para");
            }

        }

        private async Task ExecuteShowMovieCommand(Movie movie)
        {

            try
            {
                IsBusy = true;
               
               
                movie = await _TheMovieDBAPIService.FindByIdAsync(movie.Id);
                var navigationParams = new NavigationParameters
                {
                    {"movie", movie}
                };
                await NavigationService.NavigateAsync(nameof(DetailsPage), navigationParams);
               

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Error on Load Movie:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }


        }
        private async Task ExecuteLoadMoreCommand(Movie item)
        {
            if (Movies.Last() == item)
            {
                _pageindex++;
                await LoadAsync(_pageindex);
            }
        }
        private async Task ExecutePullToRefreshCommand()
        {
            Movies.Clear();
            _pageindex = 1;
            await LoadAsync();
        }

        private async Task LoadAsync(int page = 1)
        {
            try
            {
                IsBusy = true;

                var movies = await _TheMovieDBAPIService.GetUpcomingMoviesAsync(page);


                foreach (var movie in movies.Results)
                {
                    Movies.Add(movie);
                }

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Error on Load Movies:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }
        }

    }
}
