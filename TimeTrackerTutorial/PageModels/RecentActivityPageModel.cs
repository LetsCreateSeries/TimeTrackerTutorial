using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Work;
using TimeTrackerTutorial.ViewModels;
using TimeTrackerTutorial.ViewModels.Buttons;

namespace TimeTrackerTutorial.PageModels
{
    public class RecentActivityPageModel : PageModelBase
    {
        private IWorkService _workService;

        private List<WorkItemViewModel> _workItems;
        public List<WorkItemViewModel> WorkItems
        {
            get => _workItems;
            set => SetProperty(ref _workItems, value);
        }

        private ButtonModel _clockInModel;
        /// <summary>
        /// tba
        /// </summary>
        public ButtonModel ClockInModel
        {
            get => _clockInModel;
            set => SetProperty(ref _clockInModel, value);
        }

        public RecentActivityPageModel(IWorkService workService)
        {
            _workService = workService;
            ClockInModel = new ButtonModel("CLOCK IN", OnClockIn);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            var workitems = await _workService.GetWorkForThisPeriodAsync();
            if (workitems != null)
            {
                WorkItems = workitems.Select(w => new WorkItemViewModel(w)).ToList();
            }
            await base.InitializeAsync(navigationData);
        }

        private void OnClockIn()
        {

        }
    }
}
