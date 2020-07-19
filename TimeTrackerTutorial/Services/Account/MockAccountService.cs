using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Account
{
    public class MockAccountService : IAccountService
    {
        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10.0);
        }

        public Task<AuthenticatedUser> GetUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }
            return Task.Delay(1000).ContinueWith((task) => true);
        }

        public Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
