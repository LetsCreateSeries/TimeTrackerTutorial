using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
            if (Application.Current.MainPage is NavigationPage navPage)
            {
                return navPage.PopAsync();
            }
            return Task.CompletedTask;
        }

        public async Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase
        {
            Page page = PageModelLocator.CreatePageFor(typeof(TPageModel));

            if (setRoot)
            {
                if (page is TabbedPage tabbedPage)
                {
                    Application.Current.MainPage = tabbedPage;
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(page);
                }
            }
            else
            {
                if (Application.Current.MainPage is NavigationPage navigationPage)
                {
                    await navigationPage.PushAsync(page);
                }
                else if (Application.Current.MainPage is TabbedPage tabbedPage)
                {
                    if (tabbedPage.CurrentPage is NavigationPage nPage)
                    {
                        await nPage.PushAsync(page);
                    }
                }
                else
                {
                    if (page is TabbedPage tPage)
                    {
                        Application.Current.MainPage = tPage;
                    }
                    else
                    {
                        Application.Current.MainPage = new NavigationPage(page);
                    }
                }
            }

            if (page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }
        }
    }
}
