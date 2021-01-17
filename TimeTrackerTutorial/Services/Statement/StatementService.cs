using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Statement
{
    public class StatementService : IStatementService
    {
        private IRepository<WorkItem> _repo;

        public StatementService(IRepository<WorkItem> workRepo)
        {
            _repo = workRepo;
        }

        public async Task<List<PayStatement>> GetStatementHistoryAsync()
        {
            var allWork = await _repo.GetAll();
            var response = new List<PayStatement>();

            var orderedWork = allWork.OrderBy(n => n.Start);
            var start = Constants.FIRST_PAY_PERIOD_START;
            var end = Constants.FIRST_PAY_PERIOD_END;
            var currentStatement = new PayStatement
            {
                Start = start,
                End = end,
                Date = end.AddDays(6),
                WorkItems = new List<WorkItem>()
            };

            foreach (var work in orderedWork)
            {
                if (currentStatement.End < work.Start)
                {
                    if (currentStatement.WorkItems.Count > 0)
                        response.Add(currentStatement);
                    start = currentStatement.Start;
                    end = currentStatement.End;
                    currentStatement = new PayStatement
                    {
                        Start = start.AddDays(14),
                        End = end.AddDays(14),
                        Date = end.AddDays(20),
                        WorkItems = new List<WorkItem>()
                    };
                }
                currentStatement.WorkItems.Add(work);
            }

            if (currentStatement.WorkItems.Count > 0)
                response.Add(currentStatement);

            return response;
        }
    }
}
