using System;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;

namespace TimeTrackerTutorial.ViewModels
{
    public class WorkItemViewModel : ExtendedBindableObject
    {
        private WorkItem _model;

        public string JobName { get; }
        public string StartEnd { get; }
        public string Date { get; }
        public string Earnings { get; }
        public double TotalHours { get; }

        public WorkItemViewModel(WorkItem item)
        {
            _model = item;
            StartEnd = $"{item.Start:h:mm tt} - {item.End:h:mm tt}";
            Date = $"{item.Start:MMMM d, yyyy}";
            TotalHours = item.Total.TotalHours;

            if (item.Job != null)
            {
                JobName = item.Job.Name;
                Earnings = $"+{(item.Job.Rate * TotalHours):C}";
            }
            else
            {
                JobName = "(undefined)";
                Earnings = "(undefined)";
            }
        }
    }
}
