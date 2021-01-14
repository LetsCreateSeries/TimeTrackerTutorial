using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Firestore;
using TimeTrackerTutorial.Droid.Extensions;
using TimeTrackerTutorial.Droid.ServiceListeners;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Droid.Services
{
    public enum CachingStrategy
    {
        None,
        Session,
        Daily
    }
    public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
    {
        public BaseRepository()
        {

        }

        protected abstract string DocumentPath { get; }
        protected virtual CachingStrategy CachingStrategy { get; } = CachingStrategy.None;

        public Task<bool> Delete(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(item.Id)
                .Delete()
                .AddOnCompleteListener(new OnDeleteCompleteListener(tcs));

            return tcs.Task;
        }

        private Task<T> _getTask;
        public Task<T> Get(string id)
        {
            if (IsValidPerCacheStrategy(_getTask, id))
            {
                return _getTask;
            }
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));
            _getTask = tcs.Task;
            return tcs.Task;
        }

        private Task<IList<T>> _getAllTask;
        public Task<IList<T>> GetAll()
        {
            if(IsValidPerCacheStrategy(_getAllTask, null))
            {
                return _getAllTask;
            }
            var tcs = new TaskCompletionSource<IList<T>>();
           
            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Get()
                .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));
            _getAllTask = tcs.Task;
            return tcs.Task;
        }

        public Task<string> Save(T item)
        {
            var tcs = new TaskCompletionSource<string>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Add(item.Convert())
                .AddOnCompleteListener(new OnCreateCompleteListener(tcs));

            return tcs.Task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool IsTaskValid<TResult>(Task<TResult> t)
        {
            if (t == null)
                return false;

            if (t.IsFaulted || t.IsCanceled)
                return false;

            if (t.IsCompleted && t.Result != null)
                return true;

            return false;
        }

        private bool IsValidPerCacheStrategy<TResult>(Task<TResult> t, string id = null)
        {
            switch (CachingStrategy)
            {
                case CachingStrategy.None:
                    return false;
                case CachingStrategy.Session:
                    return IsValidInSessionCache(t, id);
                case CachingStrategy.Daily:
                    return IsValidInDailyCache(t, id);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool IsValidInSessionCache<TResult>(Task<TResult> t, string id)
        {
            if (!IsTaskValid(t))
                return false;

            if (t.IsCompleted)
            {
                if (id != null)
                {
                    if (t.Result is IList<IIdentifiable> list
                        && list.Any(n => n.Id == id))
                        return true;

                    if (t.Result is IIdentifiable item && item.Id == id)
                        return true;
                }
                else
                {
                    if (t.Result is IList genericList
                        && genericList.Count > 0)
                        return true;
                }
            }
            return false;
        }

        private bool IsValidInDailyCache<TResult>(Task<TResult> t, string id)
        {
            if (!IsTaskValid(t))
                return false;
            // otherwise, we need to check if it is in our local db
            // AND if we've retrieved from Firebase today already

            return false;
        }
    }
}
