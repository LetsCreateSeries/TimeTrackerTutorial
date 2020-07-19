using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Account
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<double> GetCurrentPayRateAsync();
        Task<bool> SendOtpCodeAsync(string phoneNumber);
        Task<bool> VerifyOtpCodeAsync(string code);

        Task<AuthenticatedUser> GetUserAsync();
    }
}
