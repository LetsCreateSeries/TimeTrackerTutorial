using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Models
{
    public class WorkItem : IIdentifiable
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeSpan Total
        {
            get => End - Start;
        }

        public double Rate { get; set; }
        public double Earnings
        {
            get => Total.TotalHours * Rate;
        }

        public string Id { get; set; }
    }
}
