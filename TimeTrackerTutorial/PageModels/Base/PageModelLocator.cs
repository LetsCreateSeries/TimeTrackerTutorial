using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerTutorial.Pages;
using TimeTrackerTutorial.Services.Account;
using TimeTrackerTutorial.Services.Navigation;
using TimeTrackerTutorial.Services.Statement;
using TimeTrackerTutorial.Services.Work;
using TinyIoC;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _lookupTable;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _lookupTable = new Dictionary<Type, Type>();

            // Register Page and Page Models
            Register<DashboardPageModel, DashboardPage>();
            Register<LoginPageModel, LoginPage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();
            Register<TimeClockPageModel, TimeClockPage>();

            // Register Services (registerd as Singletons by default)
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IAccountService, MockAccountService>();
            _container.Register<IStatementService, MockStatementService>();
            _container.Register<IWorkService, MockWorkService>();
        }

        /// <summary>
        /// Private utility method to Register page and page model for page retrieval by it's
        /// specified page model type.
        /// </summary>
        /// <typeparam name="TPageModel"></typeparam>
        /// <typeparam name="TPage"></typeparam>
        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _lookupTable.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _lookupTable[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            try
            {
                var pageModel = _container.Resolve(pageModelType);
                page.BindingContext = pageModel;
            }
            catch (TinyIoCResolutionException e)
            {
                // Print to output for easier debugging
                System.Diagnostics.Debug.WriteLine(e.Message);
                while (e.InnerException is TinyIoCResolutionException ex)
                {
                    System.Diagnostics.Debug.WriteLine("\t Resolution exception:" + ex.Message);
                    e = ex;
                }
                // Still crash the app
                throw e;
            }
            return page;
        }
    }
}
