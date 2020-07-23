using System;
using Firebase.CloudFirestore;
using TimeTrackerTutorial.iOS.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(SampleDateService))]
namespace TimeTrackerTutorial.iOS.Services
{
    public class SampleDateService : BaseFirestoreRepository<SampleData>
    {
        protected override string CollectionName =>
            "users/"
            + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid
            + "/sample";
    }
}
