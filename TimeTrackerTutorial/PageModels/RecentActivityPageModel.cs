using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Account;
using TimeTrackerTutorial.Services.Navigation;
using TimeTrackerTutorial.Services.Work;
using TimeTrackerTutorial.ViewModels.Buttons;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class RecentActivityPageModel : PageModelBase
    {
        bool _isClockedIn;
        public bool IsClockedIn
        {
            get => _isClockedIn;
            set => SetProperty(ref _isClockedIn, value);
        }

        TimeSpan _runningTotal;
        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }

        DateTime _currentStartTime;
        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }

        public ObservableCollection<WorkItem> WorkItems
        {
            get => _workItems;
            set => SetProperty(ref _workItems, value);
        }

        double _todaysEarnings;
        public double TodaysEarnings
        {
            get => _todaysEarnings;
            set => SetProperty(ref _todaysEarnings, value);
        }

        ButtonModel _clockInOutButtonModel;
        public ButtonModel ClockInOutButtonModel
        {
            get => _clockInOutButtonModel;
            set => SetProperty(ref _clockInOutButtonModel, value);
        }

        public ICommand SummaryCommand => new Command(GoToPage<SummaryPageModel>);
        public ICommand ProfileCommand => new Command(GoToPage<ProfilePageModel>);
        public ICommand SettingsCommand => new Command(GoToPage<SettingsPageModel>);

        private Timer _timer;
        private ObservableCollection<WorkItem> _workItems;
        private INavigationService _navigationService;
        private IAccountService _accountService;
        private IWorkService _workService;
        private double _hourlyRate;

        public RecentActivityPageModel(IAccountService accountService,
            IWorkService workService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            _workService = workService;
            ClockInOutButtonModel = new ButtonModel("Clock In", () => _navigationService.NavigateToAsync<TimeClockPageModel>(isModal: true));
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Enabled = false;
            _timer.Elapsed += _timer_Elapsed;
        }

        private async void GoToPage<T>() where T : PageModelBase
        {
            await _navigationService.NavigateToAsync<T>();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunningTotal += TimeSpan.FromSeconds(1);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            RunningTotal = new TimeSpan();
            _hourlyRate = await _accountService.GetCurrentPayRateAsync();
            WorkItems = await _workService.GetTodaysWorkAsync();
            if (WorkItems.Count == 0)
            {
                for (int i = 1; i < 4; i++)
                {
                    WorkItems.Add(new WorkItem
                    {
                        Id = i.ToString(),
                        Start = DateTime.Now.AddDays(-i).AddHours(-i),
                        End = DateTime.Now.AddDays(-i),
                        Rate = _hourlyRate
                    });
                }
                TodaysEarnings = 6 * _hourlyRate;
            }
            await base.InitializeAsync(navigationData);
        }

        private async void OnClockInOutAction()
        {
            if (IsClockedIn)
            {
                _timer.Enabled = false;
                TodaysEarnings += _hourlyRate * RunningTotal.TotalHours;
                RunningTotal = TimeSpan.Zero;
                ClockInOutButtonModel.Text = "Clock In";
                var item = new WorkItem
                {
                    Start = CurrentStartTime,
                    End = DateTime.Now
                };
                WorkItems.Insert(0, item);
                await _workService.LogWorkAsync(item);
            }
            else
            {
                CurrentStartTime = DateTime.Now;
                _timer.Enabled = true;
                ClockInOutButtonModel.Text = "Clock Out";
            }
            IsClockedIn = !IsClockedIn;
        }
    }
}
