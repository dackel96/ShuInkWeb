using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Exceptions;
using ShuInkWeb.Core.FilesCloudService;
using ShuInkWeb.Core.Services;
using ShuInkWeb.Data;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.HappeningModels;
using Microsoft.AspNetCore.Http;
using ShuInkWeb.Data.Entities.Identities;

namespace ShuInkWeb.Test
{
    [TestFixture]
    public class BlogServiceTests
    {
        private ApplicationDbContext applicationDbContext;

        private IOldCapitalCloud cloud;

        private IDeletableEntityRepository<Happening> postRepository;

        private IDeletableEntityRepository<Artist> artistRepository;

        private ILogger<BlogService> logger;

        private IGuard guard;

        private IConfiguration config;

        private IBlogService blogService;

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

            artistRepository = new EfDeletableEntityRepository<Artist>(applicationDbContext);

            postRepository = new EfDeletableEntityRepository<Happening>(applicationDbContext);

            guard = new Guard();

            var loggerMoq = new Mock<ILogger<BlogService>>();
            logger = loggerMoq.Object;

            var cloudMoq = new Mock<IOldCapitalCloud>();
            cloud = cloudMoq.Object;

            blogService = new BlogService(postRepository, cloud, logger, guard, artistRepository);

            var postId = Guid.Parse("429acc97-c912-43e5-838e-7867423f8854");

            var artistId = Guid.Parse("d3040dcf-02de-4b9e-a1f9-4c4d6f802b77");

            var userId = "cf150210-849d-4dfe-b396-7f8ccda90b72";

            var postModel = new Happening()
            {
                Id = postId,
                ArtistId = artistId,
                Title = "Novi Ceni",
                Content = "Lorem Ipsum",
                ImageUrl = "dimitrichkoslashimage"
            };

            var user = new ApplicationUser()
            {
                Id = userId,
                FirstName = "dimitrichko",
                LastName = "dimev",
                UserName = "DimiTrix",
                PhoneNumber = "0895792078",
                SocialMedia = "facebook.Dimitrix.95.com"
            };

            var artist = new Artist()
            {
                Id = artistId,
                Resume = "Lorem Ipsum",
                ImageUrl = "imageUrl",
                Address = "far far away",
                ApplicationUserId = userId
            };

            applicationDbContext.Happenings.Add(postModel);
            applicationDbContext.SaveChanges();
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
            applicationDbContext.Artists.Add(artist);
            applicationDbContext.SaveChanges();
        }

        [Test]
        public async Task GetEntitiesMethodTest()
        {
            var result = await blogService.GetPostsAsync();

            Assert.NotNull(result);

            Assert.That(result.Count() == 1);

        }
        [Test]
        public async Task GetEntityForAnArtistMethodTest()
        {
            var artistId = Guid.Parse("d3040dcf-02de-4b9e-a1f9-4c4d6f802b77");

            var results = await blogService.GetPostsForAnArtistAsync(artistId);

            Assert.NotNull(results);

            Assert.That(results.Count() == 1);

            Assert.ThrowsAsync<CustomNullException>(() => blogService.GetPostsForAnArtistAsync(Guid.NewGuid()));
        }
        [Test]
        public async Task AddEntityMethodTest()
        {
            var model = new HappeningViewModel()
            {
                ArtistId = Guid.NewGuid(),
                Title = "Novi Ceni",
                Content = "Lorem Ipsum",
                ImageUrl = ""
            };

            await blogService.AddAsync(model, file);

            var entity = applicationDbContext.Happenings.FirstOrDefault(x => x.Title == "Novi Ceni");

            Assert.IsNotNull(entity);

            var wrongModel = new HappeningViewModel();

            Assert.ThrowsAsync<ApplicationException>(() => blogService.AddAsync(wrongModel, file));
        }
        [Test]
        public async Task ExistingEntityMethodTest()
        {
            var postId = Guid.Parse("429acc97-c912-43e5-838e-7867423f8854");

            Assert.IsTrue(await blogService.IsExistAsync(postId));

            Assert.IsFalse(await blogService.IsExistAsync(Guid.NewGuid()));
        }
        [Test]
        public async Task GetSingleEntityMethodTest()
        {
            var postId = Guid.Parse("429acc97-c912-43e5-838e-7867423f8854");

            var entity = await blogService.GetSinglePostAsync(postId);

            Assert.That(entity.Title, Is.EqualTo("Novi Ceni"));

            Assert.ThrowsAsync<CustomNullException>(() => blogService.GetSinglePostAsync(Guid.NewGuid()));
        }
        [Test]
        public async Task EditAnEntityMethodTest()
        {
            var postId = Guid.Parse("429acc97-c912-43e5-838e-7867423f8854");

            var model = new HappeningViewModel()
            {
                ArtistId = Guid.NewGuid(),
                Title = "Novite Ceni",
                Content = "Lorem Ipsum bratochka",
                ImageUrl = "https://res.cloudinary.com/oldcapitalcloud/image/upload/v1671146726/Novi%20Ceni%20ot%202023.png"
            };

            var beforeEdit = applicationDbContext.Happenings.FirstOrDefault(x => x.Id == postId);

            Assert.That(beforeEdit!.Title, Is.EqualTo("Novi Ceni"));
            Assert.That(beforeEdit!.ImageUrl, Is.EqualTo("dimitrichkoslashimage"));

            await blogService.EditAsync(postId, model, file);

            var afterEdit = applicationDbContext.Happenings.FirstOrDefault(x => x.Id == postId);

            Assert.That(afterEdit!.Title, Is.EqualTo(model.Title));
            Assert.That(afterEdit!.ImageUrl, Is.EqualTo(model.ImageUrl));

            Assert.ThrowsAsync<CustomNullException>(() => blogService.EditAsync(Guid.NewGuid(), model, file));

        }
        [Test]
        public async Task DeleteEntityMethodTest()
        {
            var postId = Guid.Parse("429acc97-c912-43e5-838e-7867423f8854");

            Assert.IsTrue(applicationDbContext.Happenings.Any(x => x.Id == postId));

            await blogService.DeleteAsync(postId);

            var dummy = applicationDbContext.Happenings.FirstOrDefault(x => x.Id == postId);

            Assert.IsNull(dummy);

            var deletedDummy = applicationDbContext.Happenings.IgnoreQueryFilters().FirstOrDefault(x => x.Id == postId);

            Assert.IsTrue(deletedDummy != null);

            Assert.IsTrue(deletedDummy!.IsDeleted == true);

            Assert.ThrowsAsync<CustomNullException>(() => blogService.DeleteAsync(Guid.NewGuid()));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
