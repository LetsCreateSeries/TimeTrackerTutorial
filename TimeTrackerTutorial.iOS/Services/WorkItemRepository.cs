using System;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.iOS.Services
{
    public class WorkItemRepository : BaseRepository<WorkItem>
    {
        public override string DocumentPath =>
            "users/"
            + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid
            + "/work";
    }
}
