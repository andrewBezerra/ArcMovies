using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace ArcMovies.ViewModels
{
    public class NoConnectionViewModel : ViewModelBase
    {
        private DelegateCommand _goHomeCommand;

        //public DelegateCommand GoHomeCommand =>
        //    _goHomeCommand ?? (_goHomeCommand = new DelegateCommand(async () =>
        //    await ExecuteGoHomeCommand(), () => !IsBusy));

        protected NoConnectionViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "No Internet Connection";

        }


        //private async Task ExecuteGoHomeCommand()
        //{
        //    //if (HasConectivity)
        //    //    await NavigationService.NavigateAsync("/NavigationPage/MenuPage");
        //    //else
        //    //    await PageDialogService.DisplayAlertAsync("Warning", "No internet connection. Try again later.", "OK");
        //}
    }
}
