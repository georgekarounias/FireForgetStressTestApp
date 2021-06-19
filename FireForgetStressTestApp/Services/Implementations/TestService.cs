using FireForgetStressTestApp.Services.Interfaces;
using Model.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FireForgetStressTestApp.Services.Implementations
{
    public class TestService : ITestService
    {
        private Notifications_TestingContext _context;

        public TestService(Notifications_TestingContext context)
        {
            _context = context;
        }

        public async Task MakeFakeHttpCall()
        {
            
            var stopWatch = Stopwatch.StartNew();
            var ServiceName = GetType().Name;
            var taskinformation = new TaskInformation()
            {
                CreatedTime = DateTime.Now,
                ServiceTaskName = ServiceName,
                Guid = Guid.NewGuid()
            };
            try
            {
                System.Threading.Thread.Sleep(10000);

                var time = stopWatch.Elapsed.TotalMilliseconds;

                taskinformation.CompletionSuccess = true;

                taskinformation.TimeToComplete = (decimal)time;
            }
            catch(Exception e)
            {
                taskinformation.CompletionSuccess = false;

                taskinformation.ExceptionMessage = e.ToString();
            }

            await _context.TaskInformations.AddAsync(taskinformation).ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

        }
    }
}
