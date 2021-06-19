using FireForgetStressTestApp.Controllers;
using FireForgetStressTestApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Models;
using Moq;
using FireForgetTask;
using FireForgetTask.Implementations;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FireForgetTask.Interfaces;
using FireForgetStressTestApp.Services.Implementations;
using System.Linq;

namespace FireAndForgetStressTestAppUnitTest
{
    [TestClass]
    public class TestServiceControllerUnitTest
    {
        private Notifications_TestingContext _context;

        private DbContextOptions<Notifications_TestingContext> _contextOptions;

        private Mock<IFireForgetTask<ITestService>> _fireForgetTask;

        private Mock<ITestService> _testService;

        [TestInitialize]
        public void SetUp()
        {
            _contextOptions = new DbContextOptionsBuilder<Notifications_TestingContext>()
                                    .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                                    .EnableSensitiveDataLogging()
                                    .Options;

            _context = new Notifications_TestingContext(_contextOptions);

        }


        [TestCleanup]
        public void Clean()
        {
            if (_context.Database.IsInMemory())
            {
                _context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ServiceTest_TestService_AssertDatabaseRecordsCreated()
        {
            var testSerive = new TestService(_context);

            _ = testSerive.MakeFakeHttpCall();

            Assert.IsTrue(_context.TaskInformations.Any());
        }

        [TestMethod]
        public async Task ControllerMethodTest_TestService_AssertDatabaseRecordsCreated()
        {
            _fireForgetTask = new Mock<IFireForgetTask<ITestService>>(MockBehavior.Strict);
            _fireForgetTask.Setup(x => x.Execute(It.IsAny<Func<ITestService, Task>>()));
            _testService = new Mock<ITestService>(MockBehavior.Strict);

            var controller = new FireAndForgetController(_fireForgetTask.Object, _testService.Object);

            var result = await controller.TestService().ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }
}
