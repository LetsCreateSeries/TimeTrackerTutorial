using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.Pages;
using TimeTrackerTutorial.Services;
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
            Register<LoginEmailPageModel, LoginEmailPage>();
            Register<LoginPhonePageModel, LoginPhonePage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();
            Register<TimeClockPageModel, TimeClockPage>();

            Register<RecentActivityPageModel, RecentActivityPage>();

            // Register Services (registered as Singletons by default)
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IAccountService>(DependencyService.Get<IAccountService>());
            _container.Register<IStatementService, MockStatementService>();
            _container.Register<IWorkService, MockWorkService>();
            //_container.Register(DependencyService.Get<IRepository<WorkItem>>());
            _container.Register(DependencyService.Get<IRepository<TestData>>());
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
            try
            {
                return _container.Resolve<T>();
            }
            catch (TinyIoCResolutionException e)
            {
                var message = e.Message;
                System.Diagnostics.Debug.WriteLine(e.Message);

                while (e.InnerException is TinyIoCResolutionException ex)
                {
                    message = ex.Message;
                    System.Diagnostics.Debug.WriteLine("\t" + ex.Message);
                    e = ex;
                }
#if DEBUG
                App.Current.MainPage.DisplayAlert("Resolution Error", message, "Ok");
#endif
            }
            return default(T);
        }


        public static Page CreatePageFor<TPageModelType>() where TPageModelType : PageModelBase
        {
            Type pageModelType = typeof(TPageModelType);
            var pageType = _lookupTable[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = Resolve<TPageModelType>();
            page.BindingContext = pageModel;
            return page;
        }
    }
}
