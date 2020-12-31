using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTrackerTutorial.iOS.Extensions;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.iOS.Services
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
    {
        public abstract string DocumentPath { get; }

        public virtual Task<bool> Delete(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection(DocumentPath)
                .GetDocument(item.Id)
                .DeleteDocument((error) =>
                {
                    tcs.TrySetResult(error == null);
                });

            return tcs.Task;
        }

        public virtual Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection(DocumentPath)
                .GetDocument(id)
                .GetDocument((snapshot, error) =>
                {
                    if (error != null)
                    {
                        // something went wrong
                        tcs.TrySetResult(default);
                        return;
                    }
                    tcs.TrySetResult(snapshot.Convert<T>());
                });
            return tcs.Task;
        }

        public virtual Task<IList<T>> GetAll()
        {
            var tcs = new TaskCompletionSource<IList<T>>();
            var list = new List<T>();
            Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection(DocumentPath)
                .GetDocuments((snapshot, error) =>
                {
                    if (error != null)
                    {
                        // something went wrong
                        tcs.TrySetResult(default);
                        return;
                    }
                    var docs = snapshot.Documents;
                    foreach (var doc in docs)
                    {
                        var item = doc.Convert<T>();
                        list.Add(item);
                    }
                    tcs.TrySetResult(list);
                });

            return tcs.Task;
        }

        public virtual async Task<string> Save(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            var docRef = Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection(DocumentPath)
                .AddDocument(item.Convert(), new Firebase.CloudFirestore.AddDocumentCompletionHandler((error) =>
                {
                    if (error != null)
                    {
                        // something went wrong.
                        tcs.TrySetResult(default);
                        return;
                    }
                    tcs.TrySetResult(true);
                }));
            var result = await tcs.Task;
            if (result)
                return docRef.Id;

            return null;
        }
    }
}
