using System;
using System.Windows.Input;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Account;
using TimeTrackerTutorial.Services.Navigation;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class LoginPhonePageModel : PageModelBase
    {
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _code;
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private bool _codeSent;
        public bool CodeSent
        {
            get => _codeSent;
            set => SetProperty(ref _codeSent, value);
        }

        private string _buttonText = "Send Code";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        private ICommand _nextCommand;
        public ICommand NextCommand
        {
            get => _nextCommand;
            set => SetProperty(ref _nextCommand, value);
        }

        private IAccountService _accountService;
        private INavigationService _navigationService;
        private bool _codeRequested;

        public LoginPhonePageModel(IAccountService accountService,
            INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;

            NextCommand = new Command(OnNextAction);
        }

        private async void OnNextAction(object obj)
        {
            if (_codeRequested)
            {
                // verify code that user entered.
                var loginAttempt = await _accountService.VerifyOtpCodeAsync(Code);
                if (loginAttempt)
                {
                    await _navigationService.NavigateToAsync<DashboardPageModel>(null, true);
                }
                else
                {
                    // Something went wrong
                    // TODO: Alert via Dialog Service.
                }
            }
            else
            {
                CodeSent = await _accountService.SendOtpCodeAsync(PhoneNumber);

                if (!CodeSent)
                    return;

                _codeRequested = true;
                ButtonText = "Verify Code";
            }
        }
    }
}
