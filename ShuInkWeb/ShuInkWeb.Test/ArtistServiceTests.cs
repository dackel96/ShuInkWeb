using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Services;
using ShuInkWeb.Data;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Identities;

namespace ShuInkWeb.Test
{
    [TestFixture]
    public class ArtistServiceTests
    {
        private IDeletableEntityRepository<Artist> artistRepository;

        private ApplicationDbContext applicationDbContext;

        private IArtistService artistService;

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

            artistService = new ArtistService(artistRepository);

            var artistId = Guid.Parse("158b3e9b-fe93-462d-918f-4ab1686f82cd");

            var secondArtistId = Guid.Parse("bdff32fa-2c35-4726-93b5-668e607c589f");

            var userId = "c8c08a0c-3724-4f30-ac40-374cd824bfbf";

            var secondUserId = "e5b5c98f-a527-4bb5-a8fa-ab0552e080f4";

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = userId,
                    FirstName = "dimitrichko",
                    LastName = "dimev",
                    UserName = "DimiTrix",
                    PhoneNumber = "0895792078",
                    SocialMedia = "facebook.Dimitrix.95.com"
                },
                new ApplicationUser()
                {
                    Id = secondUserId,
                    FirstName = "pesho",
                    LastName = "peshev",
                    UserName = "Penko",
                    PhoneNumber = "0895792078",
                    SocialMedia = "facebook.Penio.93.com"
                }
            };

            var artists = new List<Artist>()
            {
                new Artist()
                {
                    Id = artistId,
                    Resume = "Lorem Ipsum",
                    ImageUrl = "imageUrl",
                    Address = "far far away",
                    ApplicationUserId = userId
                },
                new Artist()
                {
                    Id = secondArtistId,
                    Resume = "Lorem Ipsum",
                    ImageUrl = "imageUrl",
                    Address = "far far away",
                    ApplicationUserId = secondUserId
                }
            };

            applicationDbContext.Users.AddRange(users);
            applicationDbContext.SaveChanges();

            applicationDbContext.Artists.AddRange(artists);
            applicationDbContext.SaveChanges();

            var images = new List<Image>()
            {
                new Image()
                {
                    Title = "tatus",
                    ImageUrl = "urlDoCloud",
                    ArtistId = artistId
                },
                 new Image()
                {
                     Title = "tatus1",
                    ImageUrl = "urlDoCloud",
                    ArtistId = secondArtistId
                },
                  new Image()
                {
                      Title = "tatus2",
                    ImageUrl = "urlDoCloud",
                    ArtistId = artistId
                },
                  new Image()
                {
                    Title = "tatus",
                    ImageUrl = "urlDoCloud",
                    ArtistId = secondArtistId
                },
                 new Image()
                {
                     Title = "tatus1",
                    ImageUrl = "urlDoCloud",
                    ArtistId = artistId
                },
                  new Image()
                {
                      Title = "tatus2",
                    ImageUrl = "urlDoCloud",
                    ArtistId = secondArtistId
                },
            };
            applicationDbContext.Images.AddRange(images);
            applicationDbContext.SaveChanges();
        }

        [Test]
        public async Task GetArtistInfoMethodTest()
        {
            var dummies = await artistService.GetArtistsInfoAsync();

            Assert.IsNotNull(dummies);

            Assert.That(dummies.Any(x => x.Works.Any()));
        }

        [Test]
        public async Task GetArtistIdMethodTest()
        {
            var artistIdTest = Guid.Parse("158b3e9b-fe93-462d-918f-4ab1686f82cd");

            var userIdTest = "c8c08a0c-3724-4f30-ac40-374cd824bfbf";

            var falseUserId = "8a4161c0-ebc8-431d-ba6f-338190fa4dfb";

            var idFromService = await artistService.GetArtistIdAsync(userIdTest);

            Assert.That(artistIdTest, Is.EqualTo(idFromService));

            Assert.That(Guid.Empty, Is.EqualTo(await artistService.GetArtistIdAsync(falseUserId)));

            //Assert.ThrowsAsync<ApplicationException>(async () => await artistService.GetArtistIdAsync(falseUserId));
        }

        [Test]
        public async Task IsExistByIdMethodTest()
        {
            var id = "c8c08a0c-3724-4f30-ac40-374cd824bfbf";

            Assert.IsTrue(await artistService.ExistByIdAsync(id));

            Assert.IsFalse(await artistService.ExistByIdAsync(Guid.NewGuid().ToString()));
        }

        [Test]
        public async Task GetArtistsIdAndNameMethodTest()
        {
            var artistId = Guid.Parse("158b3e9b-fe93-462d-918f-4ab1686f82cd");

            var artistName = "DimiTrix";

            var secondArtistId = Guid.Parse("bdff32fa-2c35-4726-93b5-668e607c589f");

            var secondArtistName = "Penko";

            var artistsFromService = await artistService.GetArtistsIdAsync();

            Assert.NotNull(artistsFromService);

            Assert.That(artistsFromService.Any(x => x.Id == artistId));

            Assert.That(artistsFromService.Any(x => x.Name == artistName));

            Assert.That(artistsFromService.Any(x => x.Id == secondArtistId));

            Assert.That(artistsFromService.Any(x => x.Name == secondArtistName));

        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
