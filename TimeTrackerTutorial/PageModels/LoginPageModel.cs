using System;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Navigation;
using TimeTrackerTutorial.ViewModels;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private LoginOptionViewModel _loginEmailViewModel;
        public LoginOptionViewModel LoginEmailViewModel
        {
            get => _loginEmailViewModel;
            set => SetProperty(ref _loginEmailViewModel, value);
        }

        private LoginOptionViewModel _loginPhoneViewModel;
        public LoginOptionViewModel LoginPhoneViewModel
        {
            get => _loginPhoneViewModel;
            set => SetProperty(ref _loginPhoneViewModel, value);
        }

        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginPhoneViewModel = new LoginOptionViewModel(
                "Sign in with phone",
                GoToPhoneLogin,
                Color.FromHex("#02bd7e") // green color
                );

            LoginEmailViewModel = new LoginOptionViewModel(
                "Sign in with email",
                GoToEmailLogin,
                Color.FromHex("#db4437") // red color
                );

        }

        private void GoToEmailLogin()
        {
            _navigationService.NavigateToAsync<LoginEmailPageModel>();
        }

        private void GoToPhoneLogin()
        {
            _navigationService.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}
