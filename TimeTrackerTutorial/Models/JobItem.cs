using System;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Models
{
    public class JobItem : IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}
