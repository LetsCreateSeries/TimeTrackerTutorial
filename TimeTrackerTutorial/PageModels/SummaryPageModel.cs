using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Account;
using TimeTrackerTutorial.Services.Statement;
using TimeTrackerTutorial.Services.Work;
using TimeTrackerTutorial.ViewModels;

namespace TimeTrackerTutorial.PageModels
{
    public class SummaryPageModel : PageModelBase
    {
        private string _currentPayDateRange;
        public string CurrentPayDateRange
        {
            get => _currentPayDateRange;
            set => SetProperty(ref _currentPayDateRange, value);
        }

        private double _currentPeriodEarnings;
        public double CurrentPeriodEarnings
        {
            get => _currentPeriodEarnings;
            set => SetProperty(ref _currentPeriodEarnings, value);
        }

        private DateTime _currentPeriodPayDate;
        public DateTime CurrentPeriodPayDate
        {
            get => _currentPeriodPayDate;
            set => SetProperty(ref _currentPeriodPayDate, value);
        }

        private List<PayStatementViewModel> _statements;
        public List<PayStatementViewModel> Statements
        {
            get => _statements;
            set => SetProperty(ref _statements, value);
        }

        private IAccountService _accountService;
        private IStatementService _statementService;
        private IWorkService _workService;
        private double _hourlyRate;

        public SummaryPageModel(IStatementService statementService, IWorkService workService,
            IAccountService accountService)
        {
            _accountService = accountService;
            _statementService = statementService;
            _workService = workService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            _hourlyRate = await _accountService.GetCurrentPayRateAsync();
            var statements = await _statementService.GetStatementHistoryAsync();
            if (statements != null)
            {
                Statements = statements.Select(s => new PayStatementViewModel(s)).ToList();
                var lastStatement = statements.FirstOrDefault();
                if (lastStatement != null)
                {
                    var today = DateTime.Now;
                    var max = 100;
                    var currentCount = 0;
                    var currentEnd = lastStatement.End;
                    while (currentEnd < today && currentCount < max)
                    {
                        currentEnd = currentEnd.AddDays(14);
                        ++currentCount;
                    }
                    if (currentEnd > today)
                    {
                        if (currentEnd.AddDays(-13) < today)
                        {
                            SetDateRange(currentEnd.AddDays(-13), currentEnd);
                        }
                    }
                }
            }
            var currentPeriodItems = await _workService.GetWorkForThisPeriodAsync();
            foreach (var item in currentPeriodItems)
            {
                CurrentPeriodEarnings += item.Total.TotalHours * _hourlyRate;
            }
            await base.InitializeAsync(navigationData);
        }

        private void SetDateRange(DateTime start, DateTime end)
        {
            CurrentPayDateRange = start.ToString("MMMM d") + " - " + end.ToString("MMMM d, yyyy");
            CurrentPeriodPayDate = end.AddDays(6);
        }
    }
}
