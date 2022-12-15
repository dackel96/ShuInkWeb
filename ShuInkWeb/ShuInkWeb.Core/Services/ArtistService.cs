#nullable disable

using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Core.Models.ArtistModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IDeletableEntityRepository<Artist> repository;

        public ArtistService(IDeletableEntityRepository<Artist> _repository)
        {
            this.repository = _repository;
        }

        public async Task<IEnumerable<ArtistViewModel>> GetArtistsInfoAsync()
        {
            var models = await repository.All()
                .Include(a => a.Images)
                .Select(x => new ArtistViewModel()
                {
                    FirstLastName = $"{x.ApplicationUser!.FirstName} {x.ApplicationUser.LastName}",
                    NickName = x.ApplicationUser.UserName,
                    PhoneNumber = x.ApplicationUser.PhoneNumber,
                    Resume = x.Resume ?? "None",
                    SocialMediaLink = x.ApplicationUser.SocialMedia,
                    imageUrl = x.ImageUrl,
                    Works = x.Images.ToList()
                }).ToListAsync();

            return models;
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.All()
                .AnyAsync(x => x.ApplicationUserId == userId);
        }

        public async Task<Guid> GetArtistIdAsync(string userId)
        {
            return (await repository.AllAsNoTracking().FirstOrDefaultAsync(x => x.ApplicationUserId == userId))?.Id ?? Guid.Parse("00000000-0000-0000-0000-000000000000");
        }
        public async Task<IEnumerable<AppointmentArtistViewModel>> GetArtistsIdAsync()
        {
            var models = await repository.All()
                .Select(x => new AppointmentArtistViewModel
                {
                    Id = x.Id,
                    Name = x.ApplicationUser.UserName
                })
                .ToListAsync();

            return models;
        }
    }
}
