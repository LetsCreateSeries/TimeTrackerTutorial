using System;
using TimeTrackerTutorial.Droid.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace TimeTrackerTutorial.Droid.Services
{
    public class TestDataRepository : BaseRepository<TestData>
    {
        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/test";
    }
}
