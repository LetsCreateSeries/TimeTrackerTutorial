
using TimeTrackerTutorial.Droid.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(WorkRepository))]
namespace TimeTrackerTutorial.Droid.Services
{
    public class WorkRepository : BaseRepository<WorkItem>
    {
        protected override CachingStrategy CachingStrategy => CachingStrategy.Session;
        protected override string CollectionPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/work";
    }
}