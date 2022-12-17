using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.Services;
using ShuInkWeb.Data;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Clients;
using ShuInkWeb.Data.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Test
{
    [TestFixture]
    public class ClientServiceTests
    {
        private ApplicationDbContext applicationDbContext;

        private IDeletableEntityRepository<Client> clientRepository;

        private IDeletableEntityRepository<Appointment> appointmentRepository;

        private IGuard guard;

        private ILogger<ClientService> logger;

        private IClientService clientService;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("AppointmentTestDataBase")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();

            clientRepository = new EfDeletableEntityRepository<Client>(applicationDbContext);
            appointmentRepository = new EfDeletableEntityRepository<Appointment>(applicationDbContext);

            var loggerMoq = new Mock<ILogger<ClientService>>();
            logger = loggerMoq.Object;

            guard = new Guard();

            clientService = new ClientService(clientRepository, appointmentRepository, guard, logger);

            var clientId = Guid.Parse("c130cf16-6e38-446a-84fa-ba3c3ccfffd8");

            var appointmentId = Guid.Parse("afc77665-0f8c-4971-ae8b-880da26fe16c");

            var userId = "73baa9a1-24a2-4908-9c41-088e3d6f6859";

            var appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                ClientId = clientId
                },
                new Appointment()
                {
                      Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                ClientId = clientId
                },
                new Appointment()
                {
                      Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                ClientId = clientId
                },
                new Appointment()
                {
                      Id = Guid.Parse("5062e591-7235-40d9-bd53-f305650f5007"),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                ClientId = clientId
                }
            };

            var user = new ApplicationUser()
            {
                Id = userId,
                PhoneNumber = "0890101010",
                Appointments = appointments
            };
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
            var client = new Client()
            {
                Id = clientId,
                FirstName = "dimitrichko",
                LastName = "dimev",
                PhoneNumber = "0890101010",
                UserId = userId
            };
            applicationDbContext.Clients.Add(client);
            applicationDbContext.SaveChanges();

            var appointment = new Appointment()
            {
                Id = appointmentId,
                Title = "BashZapazeniqChas",
                ClientId = clientId
            };

            applicationDbContext.Appointments.Add(appointment);
            applicationDbContext.SaveChanges();
        }

        [Test]
        public async Task IsExistMethodTest()
        {
            var userId = "73baa9a1-24a2-4908-9c41-088e3d6f6859";

            Assert.IsTrue(await clientService.ExistById(userId));

            Assert.IsFalse(await clientService.ExistById(Guid.NewGuid().ToString()));

            Assert.IsFalse(await clientService.ExistById("brat sega shte ti otkradna dannite"));

        }

        [Test]
        public async Task GetEntityMethodTest()
        {
            var userId = "73baa9a1-24a2-4908-9c41-088e3d6f6859";

            var expectedResult = await clientService.GetClientByUserId(userId);

            Assert.NotNull(expectedResult);

            Assert.That(expectedResult, Is.EqualTo(Guid.Parse("c130cf16-6e38-446a-84fa-ba3c3ccfffd8")));

            Assert.ThrowsAsync<CustomNullException>(() => clientService.GetClientByUserId(Guid.NewGuid().ToString()));
        }

        [Test]
        public async Task GetCurrentUserAppointmentsMethodTest()
        {
            var userId = "73baa9a1-24a2-4908-9c41-088e3d6f6859";

            var clientId = Guid.Parse("c130cf16-6e38-446a-84fa-ba3c3ccfffd8");

            var collection = await clientService.GetCurrUserAppointments(clientId);

            Assert.That(collection.Any());

            Assert.That(collection.Count() == 4);

            Assert.ThrowsAsync<CustomNullException>(() => clientService.GetCurrUserAppointments(Guid.NewGuid()));
        }

        [Test]
        public async Task GetClientEntityMethodTest()
        {
            var clientId = Guid.Parse("c130cf16-6e38-446a-84fa-ba3c3ccfffd8");

            var result = await clientService.GetClientById(clientId);

            Assert.IsNotNull(result);

            Assert.That(result.FirstName, Is.EqualTo("dimitrichko"));

            Assert.ThrowsAsync<CustomNullException>(() => clientService.GetClientById(Guid.NewGuid()));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
