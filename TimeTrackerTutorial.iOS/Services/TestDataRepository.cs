using System;
using TimeTrackerTutorial.iOS.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace TimeTrackerTutorial.iOS.Services
{
    public class TestDataRepository : BaseRepository<TestData>
    {
        public override string DocumentPath =>
            "users/"
            + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid
            + "/test";
    }
}
