#nullable disable

using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Core.Models.ArtistModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
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

        public async Task<IEnumerable<ArtistViewModel>> ArtistsInfo()
        {
            var models = await repository.All()
                .Include(a => a.Tattos)
                .Select(x => new ArtistViewModel()
                {
                    FirstLastName = $"{x.ApplicationUser!.FirstName} {x.ApplicationUser.LastName}",
                    NickName = x.ApplicationUser.UserName,
                    PhoneNumber = x.ApplicationUser.PhoneNumber,
                    Resume = x.Resume ?? "None",
                    SocialMediaLink = x.ApplicationUser.SocialMedia,
                    imageUrl = x.ImageUrl,
                    Works = x.Tattos.ToList()
                }).ToListAsync();

            return models;
        }

        public async Task<bool> ExistById(string userId)
        {
            return await repository.All().AnyAsync(x => x.ApplicationUserId == userId);
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
