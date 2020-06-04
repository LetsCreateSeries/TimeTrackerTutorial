using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TimeTrackerTutorial.PageModels
{
    public class DashboardPageModel : PageModelBase
    {
        private ProfilePageModel _profilePM;
        public ProfilePageModel ProfilePageModel
        {
            get => _profilePM;
            set => SetProperty(ref _profilePM, value);
        }

        private SettingsPageModel _settingsPM;
        public SettingsPageModel SettingsPageModel
        {
            get => _settingsPM;
            set => SetProperty(ref _settingsPM, value);
        }

        private SummaryPageModel _summaryPM;
        public SummaryPageModel SummaryPageModel
        {
            get => _summaryPM;
            set => SetProperty(ref _summaryPM, value);
        }

        private TimeClockPageModel _timePM;
        public TimeClockPageModel TimeClockPageModel
        {
            get => _timePM;
            set => SetProperty(ref _timePM, value);
        }

        public DashboardPageModel(ProfilePageModel profilePM, 
            SettingsPageModel settingsPM,
            SummaryPageModel summaryPM,
            TimeClockPageModel timePM)
        {
            ProfilePageModel = profilePM;
            SettingsPageModel = settingsPM;
            SummaryPageModel = summaryPM;
            TimeClockPageModel = timePM;
        }
        
        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                ProfilePageModel.InitializeAsync(null),
                SettingsPageModel.InitializeAsync(null),
                SummaryPageModel.InitializeAsync(null),
                TimeClockPageModel.InitializeAsync(null));
        }
    }
}
