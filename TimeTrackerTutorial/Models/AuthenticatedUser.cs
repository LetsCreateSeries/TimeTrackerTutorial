using System;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Models
{
    public class AuthenticatedUser : IIdentifiable
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
