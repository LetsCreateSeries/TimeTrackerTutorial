using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Navigation;
using Xamarin.Forms;

namespace TimeTrackerTutorial
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        private Task InitNavigation()
        {
            var navigationService = PageModelLocator.Resolve<INavigationService>();
            return navigationService.NavigateToAsync<LoginPageModel>(null, true);
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
            base.OnResume();
        }

        protected override void OnSleep()
        {
        }
    }
}
