using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.FilesCloudService;
using ShuInkWeb.Core.Models.GalleryModels;
using ShuInkWeb.Core.Services;
using ShuInkWeb.Data;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Test
{
    [TestFixture]
    public class GalleryServiceTests
    {
        private IDeletableEntityRepository<Image> imageRepository;

        private IDeletableEntityRepository<Artist> artistRepository;

        private IOldCapitalCloud cloud;

        private IGuard guard;

        private IFormFile file;

        private IGalleryService galleryService;

        private ApplicationDbContext applicationDbContext;

        private ILogger<GalleryService> logger;
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("AppointmentTestDataBase")
            .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();

            artistRepository = new EfDeletableEntityRepository<Artist>(applicationDbContext);

            imageRepository = new EfDeletableEntityRepository<Image>(applicationDbContext);

            guard = new Guard();

            var loggerMoq = new Mock<ILogger<GalleryService>>();
            logger = loggerMoq.Object;

            var cloudMoq = new Mock<IOldCapitalCloud>();
            cloud = cloudMoq.Object;

            galleryService = new GalleryService(imageRepository, artistRepository, cloud, guard, logger);

            var artistId = Guid.Parse("421b3663-1570-4461-9069-f5be7a096a10");

            var imageId = Guid.Parse("1bb666f2-595f-407c-839b-11f0cb92d3da");

            var models = new List<Image>()
            {
                new Image()
                {
                    Id = imageId,
                    Title = "novoto",
                    ImageUrl = "",
                    ArtistId = artistId
                },
                 new Image()
                {
                    Title = "staroto",
                    ImageUrl = "",
                }, new Image()
                {
                    Title = "neshto",
                    ImageUrl = "",
                }, new Image()
                {
                    Title = "tatus",
                    ImageUrl = "",
                    ArtistId = artistId
                }, new Image()
                {
                    Title = "tatusa",
                    ImageUrl = "",
                    ArtistId = artistId
                }
            };

            var artist = new Artist()
            {
                Id = artistId,
                Address = "",
                ImageUrl = ""
            };

            applicationDbContext.Artists.Add(artist);

            applicationDbContext.Images.AddRange(models);
            applicationDbContext.SaveChanges();
        }

        [Test]
        public async Task GetAllMethodTest()
        {
            var entities = await galleryService.GetAllPhotosAsync();

            Assert.IsNotNull(entities);

            Assert.That(entities.Count(), Is.EqualTo(5));
        }
        [Test]
        public async Task GetAllForArtistMethodTest()
        {
            var artistId = Guid.Parse("421b3663-1570-4461-9069-f5be7a096a10");

            var entities = await galleryService.GetAllPhotosForAnArtistAsync(artistId);

            Assert.IsNotNull(entities);

            Assert.That(entities.Count(), Is.EqualTo(3));

            Assert.ThrowsAsync<CustomNullException>(() => galleryService.GetAllPhotosForAnArtistAsync(Guid.NewGuid()));
        }
        [Test]
        public async Task AddMethodTest()
        {
            var artistId = Guid.Parse("421b3663-1570-4461-9069-f5be7a096a10");

            var model = new ImageViewModel()
            {
                ArtistId = artistId,
                Title = "Title",
                ImageUrl = ""
            };

            await galleryService.AddAsync(model, file);

            var entity = applicationDbContext.Images.FirstOrDefault(x => x.Title == model.Title);

            Assert.IsNotNull(entity);

            Assert.ThrowsAsync<ApplicationException>(() => galleryService.AddAsync(new ImageViewModel(), file));
        }
        [Test]
        public async Task EditMethodTest()
        {
            var imageId = Guid.Parse("1bb666f2-595f-407c-839b-11f0cb92d3da");

            var model = new ImageViewModel()
            {
                Title = "googleIt",
                ImageUrl = ""
            };

            var beforeEntity = applicationDbContext.Images.FirstOrDefault(x => x.Id == imageId);

            Assert.That(beforeEntity.Title, Is.EqualTo("novoto"));

            await galleryService.EditAsync(imageId, model, file);

            var afterEntity = applicationDbContext.Images.FirstOrDefault(x => x.Id == imageId);

            Assert.That(afterEntity.Title, Is.EqualTo("googleIt"));

            Assert.ThrowsAsync<CustomNullException>(() => galleryService.EditAsync(Guid.NewGuid(), model, file));
        }
        [Test]
        public async Task DeleteMethodTest()
        {
            var imageId = Guid.Parse("1bb666f2-595f-407c-839b-11f0cb92d3da");

            Assert.IsNotNull(applicationDbContext.Images.FirstOrDefault(x => x.Id == imageId));

            await galleryService.DeleteAsync(imageId);

            Assert.IsNull(applicationDbContext.Images.FirstOrDefault(x => x.Id == imageId));

            var entitie = applicationDbContext.Images.IgnoreQueryFilters().FirstOrDefault(x => x.Id == imageId);

            Assert.That(entitie.IsDeleted == true);

        }
        [Test]
        public async Task IsExistMethodTest()
        {
            var imageId = Guid.Parse("1bb666f2-595f-407c-839b-11f0cb92d3da");

            Assert.IsTrue(await galleryService.IsExistAsync(imageId));

            Assert.IsFalse(await galleryService.IsExistAsync(Guid.NewGuid()));
        }
        [Test]
        public async Task GetSingleEntityMethodTest()
        {
            var imageId = Guid.Parse("1bb666f2-595f-407c-839b-11f0cb92d3da");

            var entity = await galleryService.GetSinglePhotoAsync(imageId);

            Assert.That(entity.Title, Is.EqualTo("novoto"));

            Assert.ThrowsAsync<CustomNullException>(() => galleryService.GetSinglePhotoAsync(Guid.NewGuid()));
        }
        [Test]
        public async Task GetLastFiveMEthodTest()
        {
            var dummies = await galleryService.GetLastFivePhotosAsync();

            Assert.That(dummies.Count, Is.EqualTo(5));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
