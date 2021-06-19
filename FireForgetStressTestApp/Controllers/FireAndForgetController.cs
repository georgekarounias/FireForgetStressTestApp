using FireForgetStressTestApp.Services.Interfaces;
using FireForgetTask.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using FireForgetStressTestApp.Services.Implementations;

namespace FireForgetStressTestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FireAndForgetController : ControllerBase
    {
        private readonly IFireForgetTask<ITestService> _fireForgetTask;
        private readonly ITestService _testService;

        public FireAndForgetController(IFireForgetTask<ITestService> fireForgetTask,
                                       ITestService testService)
        {
            _fireForgetTask = fireForgetTask;
            _testService = testService;
        }

        [HttpGet]
        public async Task<OkObjectResult> TestService()
        {

            _fireForgetTask.Execute(async task =>
            {
                await task.MakeFakeHttpCall().ConfigureAwait(false);

            });

            return Ok("DONE");
        }

        [HttpGet]
        public async Task<OkObjectResult> TestServiceSync()
        {
            await _testService.MakeFakeHttpCall().ConfigureAwait(false);

            return Ok("DONE");
        }
    }
}
