using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.FilesCloudService;
using ShuInkWeb.Core.Services;
using ShuInkWeb.Data;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuInkWeb.Core.Contracts;
using Microsoft.AspNetCore.Http;
using ShuInkWeb.Core.Models.MessageModels;
using Microsoft.AspNetCore.Mvc;

namespace ShuInkWeb.Test
{
    [TestFixture]
    public class MessageServiceTests
    {
        private IDeletableEntityRepository<Message> messageRepository;

        private IOldCapitalCloud cloud;

        private IGuard guard;

        private ILogger<MessageService> logger;

        private ApplicationDbContext applicationDbContext;

        private IMessageService messageService;

        private IFormFile file;

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

            var loggerMoq = new Mock<ILogger<MessageService>>();
            logger = loggerMoq.Object;

            var cloudMoq = new Mock<IOldCapitalCloud>();
            cloud = cloudMoq.Object;

            messageRepository = new EfDeletableEntityRepository<Message>(applicationDbContext);

            messageService = new MessageService(messageRepository, cloud, guard, logger);

            var messageId = Guid.Parse("b83922f2-fd15-4ea8-9f66-a307cbdb9084");

            var messages = new List<Message>()
            {
                new Message()
                {
                    Id = messageId,
                    Name = "test ivan",
                    Content = "Lorme Ipsum"
                },
                new Message()
                {
                    Name = "iliev ivan",
                    Content = "Lorme Ipsum"
                },
                new Message()
                {
                    Name = "iliev ivan",
                    Content = "Lorme Ipsum"
                },
                new Message()
                {
                    Name = "iliev ivan",
                    Content = "Lorme Ipsum"
                },
            };

            applicationDbContext.Messages.AddRange(messages);
            applicationDbContext.SaveChanges();
        }

        [Test]
        public async Task AddMethodTest()
        {
            var model = new MessageViewModel()
            {
                Name = "Da Popitam",
                Content = "Boli li kato te risuvat",
                ImageUrl = ""
            };

            await messageService.AddAsync(model, file);

            var entity = applicationDbContext.Messages.FirstOrDefault(x => x.Name == model.Name);

            Assert.IsNotNull(entity);

            var wrongModel = new MessageViewModel();

            Assert.ThrowsAsync<ApplicationException>(() => messageService.AddAsync(wrongModel, file));

        }

        [Test]
        public async Task GetAllMethodTest()
        {
            var result = await messageService.GetAllMessagesAsync();

            Assert.IsNotNull(result);

            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]
        public async Task DeleteMethodTest()
        {
            var messageId = Guid.Parse("b83922f2-fd15-4ea8-9f66-a307cbdb9084");

            var result = await messageRepository.All().ToListAsync();

            Assert.That(result.Count(), Is.EqualTo(4));

            await messageService.DeleteAsync(messageId);

            var resultDeleted = await messageRepository.All().ToListAsync();

            Assert.That(resultDeleted.Count(), Is.EqualTo(3));

            var entity = messageRepository.All().FirstOrDefault(x => x.Id == messageId);

            Assert.IsNull(entity);

            var entityDeleted = applicationDbContext.Messages.IgnoreQueryFilters().FirstOrDefault(x => x.Id == messageId);

            Assert.That(entityDeleted.IsDeleted == true);

        }

        [Test]
        public async Task IsExistMethodTest()
        {
            var messageId = Guid.Parse("b83922f2-fd15-4ea8-9f66-a307cbdb9084");

            Assert.IsTrue(await messageService.IsExistByIdAsync(messageId));

            Assert.IsFalse(await messageService.IsExistByIdAsync(Guid.NewGuid()));

        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
