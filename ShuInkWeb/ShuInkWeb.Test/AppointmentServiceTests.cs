using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.Services;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Data;
using Moq;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities.Clients;
using ShuInkWeb.Data.Entities.Identities;

namespace ShuInkWeb.Test
{
    [TestFixture]
    public class AppointmentServiceTests
    {
        private IAppointmentService appointmentService;

        private IDeletableEntityRepository<Appointment> appointmentRepository;

        private IDeletableEntityRepository<Artist> artistRepository;

        private IDeletableEntityRepository<Client> clientRepository;

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

            appointmentRepository = new EfDeletableEntityRepository<Appointment>(applicationDbContext);
            artistRepository = new EfDeletableEntityRepository<Artist>(applicationDbContext);
            clientRepository = new EfDeletableEntityRepository<Client>(applicationDbContext);

            appointmentService = new AppointmentService(appointmentRepository, clientRepository, guard, logger, artistRepository);
        }

        [Test]
        public async Task AddMethodTest()
        {
            var id = Guid.Parse("c2343ead-d0a1-491a-a74b-e42b6cdfb6ac");

            await artistRepository.AddAsync(new Artist()
            {
                Id = id,
                Address = "",
                ImageUrl = ""
            });

            var modelId = Guid.Parse("f9916eab-b511-44ad-aad6-86cfb4fafc84");

            var model = new AppointmentViewModel()
            {
                Id = modelId,
                Title = "nov",
                Description = "chas",
                FirstName = "ivan",
                LastName = "iliev",
                PhoneNumber = "0857575757",
                SocialMedia = "facebook.com",
                Start = DateTime.Now,
                Duration = 2
            };

            await appointmentService.AddAsync(model, id);

            Assert.That(artistRepository.AllAsNoTracking().Any(x => x.Id == id));

            Assert.ThrowsAsync<CustomNullException>(() => appointmentService.AddAsync(model, Guid.NewGuid()));

            Assert.IsTrue(applicationDbContext.Appointments.Any(x => x.Title == "nov"));

            Assert.ThrowsAsync<ApplicationException>(() => appointmentService.AddAsync(null!, id));
        }

        [Test]
        public async Task DetailsModelGetByIdTest()
        {
            var applicationUser = new ApplicationUser()
            {
                Id = "67cc85fb-2f48-4957-8015-d6e2c2b13f26",
                FirstName = "pesho"
            };

            applicationDbContext.Users.Add(applicationUser);

            var artist = new Artist()
            {
                Id = Guid.NewGuid(),
                Address = "test",
                ImageUrl = "test",
                ApplicationUserId = applicationUser.Id
            };

            applicationDbContext.Artists.Add(artist);

            var appointmentId = Guid.Parse("67cc85fb-2f48-4957-8015-d6e2c2b13f26");

            var testAppointment = new Appointment()
            {
                Id = appointmentId,
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                },
                ArtistId = artist.Id
            };

            applicationDbContext.Appointments.Add(testAppointment);

            applicationDbContext.SaveChanges();

            var dummy = await appointmentService.DetailsModelByIdAsync(appointmentId);


            Assert.IsTrue(applicationDbContext.Appointments.Any(x => x.Id == appointmentId));

            Assert.IsTrue(dummy != null);

            Assert.IsTrue(dummy!.ArtistName == "pesho");

            Assert.ThrowsAsync<CustomNullException>(() => appointmentService.DetailsModelByIdAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task DeleteMethodTest()
        {

            var appointmentId = Guid.Parse("67cc85fb-2f48-4957-8015-d6e2c2b13f26");

            var testAppointment = new Appointment()
            {
                Id = appointmentId,
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                },
                IsDeleted = false
            };
            applicationDbContext.Appointments.Add(testAppointment);
            applicationDbContext.SaveChanges();

            Assert.IsTrue(applicationDbContext.Appointments.Any(x => x.Id == appointmentId));

            await appointmentService.DeleteAsync(appointmentId);

            var dummy = applicationDbContext.Appointments.FirstOrDefault(x => x.Id == appointmentId);

            Assert.IsTrue(dummy == null);

            var deletedDummy = applicationDbContext.Appointments.IgnoreQueryFilters().FirstOrDefault(x => x.Id == appointmentId);

            Assert.IsTrue(deletedDummy != null);

            Assert.IsTrue(deletedDummy!.IsDeleted == true);

            Assert.ThrowsAsync<CustomNullException>(() => appointmentService.DeleteAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task EditMethodTest()
        {
            var modelId = Guid.Parse("f9916eab-b511-44ad-aad6-86cfb4fafc84");

            var testAppointment = new Appointment()
            {
                Id = modelId,
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                }
            };

            await applicationDbContext.Appointments.AddAsync(testAppointment);

            await applicationDbContext.SaveChangesAsync();

            var model = new AppointmentViewModel()
            {
                Title = "nov",
                Description = "chas",
                FirstName = "ivan",
                LastName = "iliev",
                PhoneNumber = "0857575757",
                SocialMedia = "facebook.com",
                Start = DateTime.Now,
                Duration = 2
            };



            var dummy = applicationDbContext.Appointments.FirstOrDefault(x => x.Id == modelId);

            Assert.IsTrue(dummy!.Title == "test");

            await appointmentService.EditAsync(modelId, model);

            var newDummy = applicationDbContext.Appointments.FirstOrDefault(x => x.Id == modelId);

            Assert.IsTrue(newDummy!.Title == "nov");

            Assert.ThrowsAsync<CustomNullException>(() => appointmentService.EditAsync(Guid.NewGuid(), model));

            Assert.ThrowsAsync<ApplicationException>(() => appointmentService.EditAsync(modelId, null!));
        }

        [Test]
        public async Task ExistingMethodTest()
        {
            var modelId = Guid.Parse("f9916eab-b511-44ad-aad6-86cfb4fafc84");

            var testAppointment = new Appointment()
            {
                Id = modelId,
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                }
            };

            await applicationDbContext.Appointments.AddAsync(testAppointment);

            await applicationDbContext.SaveChangesAsync();

            Assert.IsTrue(await appointmentService.IsExistingAsync(modelId));

            Assert.IsFalse(await appointmentService.IsExistingAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task GetEntityFromDataBaseMethodTest()
        {
            var modelId = Guid.Parse("f9916eab-b511-44ad-aad6-86cfb4fafc84");

            var testAppointment = new Appointment()
            {
                Id = modelId,
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                }
            };

            await applicationDbContext.Appointments.AddAsync(testAppointment);

            await applicationDbContext.SaveChangesAsync();

            var dummy = await appointmentService.GetEntityByIdAsync(modelId);

            Assert.IsNotNull(dummy);

            Assert.ThrowsAsync<CustomNullException>(() => appointmentService.GetEntityByIdAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task GetEntityForAnArtistMethodTest()
        {
            var artistId = Guid.Parse("c2343ead-d0a1-491a-a74b-e42b6cdfb6ac");

            var appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                },
                ArtistId = artistId
                },
                new Appointment()
                {
                      Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                },
                ArtistId = artistId
                },
                new Appointment()
                {
                      Id = Guid.NewGuid(),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                },
                ArtistId = artistId
                },
                new Appointment()
                {
                      Id = Guid.Parse("5062e591-7235-40d9-bd53-f305650f5007"),
                Title = "test",
                Description = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "test",
                    PhoneNumber = "test",
                    SocialMedia = "test",
                },
                ArtistId = Guid.NewGuid()
                }
            };

            applicationDbContext.AddRange(appointments);
            applicationDbContext.SaveChanges();

            var applicationUser = new ApplicationUser()
            {
                Id = "67cc85fb-2f48-4957-8015-d6e2c2b13f26",
                FirstName = "pesho",
                Appointments = appointments
            };

            applicationDbContext.Users.Add(applicationUser);
            var artistTest = new Artist()
            {
                Id = artistId,
                Address = "",
                ImageUrl = "",
                ApplicationUserId = "67cc85fb-2f48-4957-8015-d6e2c2b13f26",
            };

            applicationDbContext.Artists.Add(artistTest);
            applicationDbContext.SaveChanges();

            Assert.ThrowsAsync<CustomNullException>(() => appointmentService.GetAppointmentsForCurrentArtistAsync(Guid.NewGuid()));

            var list = await appointmentService.GetAppointmentsForCurrentArtistAsync(artistId);

            Assert.That(list.Count() == 3);

        }

        [Test]
        public async Task GetAllAsEditableEntityMethodTest()
        {
            var appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = Guid.NewGuid(),
                    Title = "test",
                    Start = DateTime.Now,
                    End = DateTime.Now.AddHours(1),
                    Artist = new Artist()
                    {
                    ApplicationUser = new ApplicationUser()
                    {
                        UserName = "pesho"
                    },
                    ImageUrl = "",
                    Address = ""
                    }
                },
                new Appointment()
                {
                   Id = Guid.NewGuid(),
                    Title = "test",
                    Start = DateTime.Now,
                    End = DateTime.Now.AddHours(1),
                    Artist = new Artist()
                    {
                    ApplicationUser = new ApplicationUser()
                    {
                        UserName = "pesho"
                    },
                    ImageUrl = "",
                    Address = ""
                    }
                },new Appointment()
                {
                    Id = Guid.NewGuid(),
                    Title = "test",
                    Start = DateTime.Now,
                    End = DateTime.Now.AddHours(1),
                    Artist = new Artist()
                    {
                    ApplicationUser = new ApplicationUser()
                    {
                        UserName = "pesho"
                    },
                    ImageUrl = "",
                    Address = ""
                    }
                },
            };
            applicationDbContext.AddRange(appointments);
            applicationDbContext.SaveChanges();

            var list = await appointmentService.GetAllAsync();

            Assert.That(list.Count() == 3);
        }

        [Test]
        public async Task HasArtistWithIdMethodTest()
        {
            var artistId = Guid.Parse("74deacbd-7b61-4d01-89fd-0d10e126c5f0");

            var userId = "f92ed4cf-a3b9-4348-a000-a75bd401988f";

            var appointmentId = Guid.Parse("dc6f88ce-f037-4e33-957f-35dd0be22365");

            var appointments =
                new Appointment()
                {
                    Id = appointmentId,
                    Title = "test",
                    ArtistId = artistId
                };

            applicationDbContext.Appointments.Add(appointments);
            applicationDbContext.SaveChanges();

            var user = new ApplicationUser()
            {
                Id = userId
            };

            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();

            var artist = new Artist()
            {
                Id = artistId,
                Address = "",
                ImageUrl = "",
                ApplicationUserId = user.Id
            };

            applicationDbContext.Artists.Add(artist);
            applicationDbContext.SaveChanges();

            Assert.IsTrue(await appointmentService.HasArtistWithIdAsync(appointmentId, userId));

            Assert.IsFalse(await appointmentService.HasArtistWithIdAsync(Guid.NewGuid(), userId));

            Assert.IsFalse(await appointmentService.HasArtistWithIdAsync(appointmentId, Guid.NewGuid().ToString()));
        }

        [Test]
        public async Task IsFreeHourMethodTest()
        {
            var start = DateTime.Parse("18 December 2022 13:00:00");
            var end = DateTime.Parse("18 December 2022 15:00:00");

            var artistId = Guid.Parse("c2343ead-d0a1-491a-a74b-e42b6cdfb6ac");

            var appointment = new Appointment()
            {
                Id = Guid.NewGuid(),
                Title = "test",
                Start = start,
                End = end,
                ArtistId = artistId
            };

            applicationDbContext.Appointments.Add(appointment);
            applicationDbContext.SaveChanges();

            var startTest = DateTime.Parse("18 December 2022 13:30:00");
            var endTest = DateTime.Parse("18 December 2022 14:00:00");

            Assert.IsFalse(await appointmentService.IsFreeThisHourAsync(startTest, endTest,artistId));

            var startTestBefore = DateTime.Parse("18 December 2022 10:00:00");
            var endTestBefore = DateTime.Parse("18 December 2022 12:00:00");

            Assert.IsTrue(await appointmentService.IsFreeThisHourAsync(startTestBefore, endTestBefore,artistId));

            var startTestAfter = DateTime.Parse("18 December 2022 15:00:00");
            var endTestAfter = DateTime.Parse("18 December 2022 16:00:00");

            Assert.IsTrue(await appointmentService.IsFreeThisHourAsync(startTestAfter, endTestAfter,artistId));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
