using System;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Models
{
    public class SampleData : IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime SomeTime { get; set; }
        public bool Flag { get; set; }
        public int Age { get; set; }
    }
}
