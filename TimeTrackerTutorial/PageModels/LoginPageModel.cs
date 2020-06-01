using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Navigation;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get => _loginCommand;
            set => SetProperty(ref _loginCommand, value);
        }

        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Init our Login Command
            LoginCommand = new Command(DoLoginAction);
        }

        /// <summary>
        /// Perform login validation and navigation if applicable
        /// </summary>
        private void DoLoginAction()
        {
            // Skip the validation for now, but assume success and 
            // navigate to the Dashboard.
            _navigationService.NavigateToAsync<DashboardPageModel>();
        }
    }
}
