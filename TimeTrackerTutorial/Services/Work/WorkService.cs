using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Task<ObservableCollection<WorkItem>> GetTodaysWorkAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<WorkItem>> GetWorkForThisPeriodAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogWorkAsync(WorkItem item)
        {
            throw new NotImplementedException();
        }
    }
}
