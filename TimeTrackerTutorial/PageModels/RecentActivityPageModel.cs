using System;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.ViewModels.Buttons;

namespace TimeTrackerTutorial.PageModels
{
    public class RecentActivityPageModel : PageModelBase
    {
        private ButtonModel _clockInModel;
        /// <summary>
        /// tba
        /// </summary>
        public ButtonModel ClockInModel
        {
            get => _clockInModel;
            set => SetProperty(ref _clockInModel, value);
        }
        public RecentActivityPageModel()
        {

            ClockInModel = new ButtonModel("CLOCK IN", OnClockIn);
        }

        private void OnClockIn()
        {

        }
    }
}
