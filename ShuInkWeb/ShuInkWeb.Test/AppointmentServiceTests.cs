using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.Services;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Data;
using Moq;

namespace ShuInkWeb.Test
{
    [TestFixture]
    public class AppointmentServiceTests
    {
        private IAppointmentService appointmentService;

        private IDeletableEntityRepository<Appointment> appointmentRepository;

        private IDeletableEntityRepository<Artist> artistRepository;

        private IClientService clientService;

        private IGuard guard;

        private ILogger<AppointmentService> logger;

        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("AppointmentTestDataBase")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();

            guard = new Guard();

            var loggerMoq = new Mock<ILogger<AppointmentService>>();
            logger = loggerMoq.Object;
            var repository = new EfDeletableEntityRepository<Appointment>(applicationDbContext);
            var artistRepository = new EfDeletableEntityRepository<Artist>(applicationDbContext);
            var clientServiceMoq = new Mock<IClientService>();
            clientService = clientServiceMoq.Object;

            appointmentService = new AppointmentService(repository, clientService, guard, logger, artistRepository);
        }

        [Test]
        public async Task AddMethodTest()
        {
            


        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
