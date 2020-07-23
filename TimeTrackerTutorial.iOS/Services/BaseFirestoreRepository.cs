using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.CloudFirestore;
using TimeTrackerTutorial.iOS.Extensions;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.iOS.Services
{
    public abstract class BaseFirestoreRepository<T> : IRepository<T> where T : IIdentifiable
    {
        protected abstract string CollectionName { get; }
        public virtual Task<bool> Delete(T item)
        {
            Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection(CollectionName)
                .GetDocument(item.Id)
                .DeleteDocument();
            return Task.FromResult(true);
        }

        public virtual Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();
            //GetDocumentReference(id)
            Firestore.SharedInstance
                .GetCollection(CollectionName)
                .GetDocument(id)
                .GetDocument((snapshot, error) =>
                {
                    if (error != null)
                    {
                        tcs.TrySetResult(default);
                        return;
                    }
                    tcs.TrySetResult(snapshot.Convert<T>());
                });
            return tcs.Task;
        }

        public virtual Task<IList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}
