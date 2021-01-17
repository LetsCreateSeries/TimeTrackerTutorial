using System;
using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Account;
using TimeTrackerTutorial.Services.Navigation;
using TimeTrackerTutorial.ViewModels;
using TimeTrackerTutorial.ViewModels.Buttons;
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

        public LoginEntryViewModel EmailEntryViewModel { get; set; }
        public LoginEntryViewModel PasswordEntryViewModel { get; set; }

        public ButtonModel LoginButtonModel { get; set; }

        private IAccountService _accountService;
        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            EmailEntryViewModel = new LoginEntryViewModel("email", false);
            PasswordEntryViewModel = new LoginEntryViewModel("password", true);
            LoginButtonModel = new ButtonModel("Log In", TryLoginAsync);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            var user = await _accountService.GetUserAsync();
            if (user != null)
                await _navigationService.NavigateToAsync<DashboardPageModel>();
        }

        private async void TryLoginAsync()
        {
            var loginAttempt = await _accountService.LoginAsync(EmailEntryViewModel.Text, PasswordEntryViewModel.Text);
            if (loginAttempt)
            {
                // navigate to the Dashboard.
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
            else
            {
                // TODO: Display an Alert for Failure!
            }
        }

        private void GoToPhoneLogin()
        {
            _navigationService.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}
