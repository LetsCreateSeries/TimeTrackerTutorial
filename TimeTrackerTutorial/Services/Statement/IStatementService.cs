using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Statement
{
    public interface IStatementService
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
    }
}
