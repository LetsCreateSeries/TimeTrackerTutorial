using System;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Models
{
    public class TestData : IIdentifiable
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public double Amount { get; set; }
        public bool Flag { get; set; }
        public string Name { get; set; }
        public DateTime SomeDate { get; set; }
    }
}
