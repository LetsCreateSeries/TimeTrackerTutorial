using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using Task = Android.Gms.Tasks.Task;

namespace TimeTrackerTutorial.Droid.ServiceListeners
{
    public class OnCreateCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<string> _tcs;

        public OnCreateCompleteListener(TaskCompletionSource<string> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                if (task.Result is DocumentReference doc)
                {
                    _tcs.TrySetResult(doc.Id);
                    return;
                }
            }
            _tcs.TrySetResult(default);
        }
    }
}
