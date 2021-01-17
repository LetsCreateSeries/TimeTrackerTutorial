using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Work
{
    public class MockWorkService : IWorkService
    {
        public List<WorkItem> Items { get; set; }
        public MockWorkService()
        {
            Items = new List<WorkItem>();
        }
        private int index = 0;
        public Task<string> LogWorkAsync(WorkItem item)
        {
            Items.Add(item);
            return Task.FromResult((++index).ToString());
        }

        public Task<ObservableCollection<WorkItem>> GetTodaysWorkAsync()
        {
            return Task.FromResult(new ObservableCollection<WorkItem>(Items));
        }

        public Task<List<WorkItem>> GetWorkForThisPeriodAsync()
        {
            return Task.FromResult(new List<WorkItem>
            {
                new WorkItem
                {
                     Start = DateTime.Now.AddDays(-2),
                     End = DateTime.Now.AddDays(-2).AddHours(1)
                },
                new WorkItem
                {
                     Start = DateTime.Now.AddDays(-1),
                     End = DateTime.Now.AddDays(-1).AddHours(1)
                },
            });
        }
    }
}
