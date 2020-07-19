using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Droid.ServiceListeners
{
    public class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<AuthenticatedUser> _tcs;

        public OnCompleteListener(TaskCompletionSource<AuthenticatedUser> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                // process document
                var result = task.Result;
                if (result is DocumentSnapshot doc)
                {
                    var user = new AuthenticatedUser();
                    user.Id = doc.Id;
                    user.FirstName = doc.GetString("FirstName");
                    user.LastName = doc.GetString("LastName");
                    _tcs.TrySetResult(user);
                    return;
                }
            }
            // something went wrong
            _tcs.TrySetResult(default(AuthenticatedUser));
        }
    }
}
