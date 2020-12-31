﻿using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;

namespace TimeTrackerTutorial.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to asynchonously navigate between Page Models,
        /// and optionally pass navigation Data.
        /// </summary>
        /// <typeparam name="TPageModel"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <param name="isModal">Added to present page modally</param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false, bool isModal = false)
            where TPageModel : PageModelBase;

        /// <summary>
        /// Pop navigation backstack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
