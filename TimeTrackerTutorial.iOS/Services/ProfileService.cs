using System;
using System.Threading.Tasks;
using Firebase.CloudFirestore;
using TimeTrackerTutorial.iOS.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProfileService))]
namespace TimeTrackerTutorial.iOS.Services
{
    public class ProfileService : BaseFirestoreRepository<AuthenticatedUser>
    {
        protected override string CollectionName => "users";

        public override Task<AuthenticatedUser> Get(string id)
        {
            return base.Get(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid);
        }
    }
}
