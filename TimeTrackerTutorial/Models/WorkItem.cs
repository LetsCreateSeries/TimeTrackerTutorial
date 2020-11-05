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

        public string Id { get; set; }
    }
}
