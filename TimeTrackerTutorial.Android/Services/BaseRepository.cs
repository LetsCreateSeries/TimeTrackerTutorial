using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;
using TimeTrackerTutorial.Droid.ServiceListeners;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Droid.Services
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
    {
        public BaseRepository()
        {
        }

        protected abstract string DocumentPath { get; }

        public Task<bool> Delete(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<IList<T>> GetAll()
        {
            var tcs = new TaskCompletionSource<IList<T>>();
            var list = new List<T>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Get()
                .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<bool> Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}
