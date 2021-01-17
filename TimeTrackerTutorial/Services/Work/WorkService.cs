using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Work
{
    public class WorkService : IWorkService
    {
        private IRepository<WorkItem> _repo;

        public WorkService(IRepository<WorkItem> repository)
        {
            _repo = repository;
        }

        public async Task<ObservableCollection<WorkItem>> GetTodaysWorkAsync()
        {
            var all = await _repo.GetAll();
            return new ObservableCollection<WorkItem>(all.Where(item => IsForToday(item)));
        }

        public Task<List<WorkItem>> GetWorkForThisPeriodAsync()
        {
            return Task.FromResult(new List<WorkItem>());
        }

        public Task<string> LogWorkAsync(WorkItem item)
        {
            return _repo.Save(item);
        }

        private bool IsForToday(WorkItem item)
        {
            var today = DateTime.Now;
            return item.Start.Year == today.Year && item.Start.DayOfYear == today.DayOfYear;
        }

    }
}
