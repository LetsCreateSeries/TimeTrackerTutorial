using System;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.ViewModels.Buttons;

namespace TimeTrackerTutorial.PageModels
{
    public class RecentActivityPageModel : PageModelBase
    {

        private ButtonModel _viewAllModel;
        public ButtonModel ViewAllModel
        {
            get => _viewAllModel;
            set => SetProperty(ref _viewAllModel, value);
        }

        private ButtonModel _clockInModel;
        public ButtonModel ClockInModel
        {
            get => _clockInModel;
            set => SetProperty(ref _clockInModel, value);
        }
        public RecentActivityPageModel()
        {

            ViewAllModel = new ButtonModel("View All", OnViewAll);
            ClockInModel = new ButtonModel("CLOCK IN", OnClockIn);
        }

        private void OnClockIn()
        {

        }

        private void OnViewAll()
        {

        }
    }
}
