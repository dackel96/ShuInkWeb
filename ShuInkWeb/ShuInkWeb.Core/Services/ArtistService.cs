using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.ArtistModels;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository repository;

        public ArtistService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IEnumerable<ArtistViewModel>> ArtistsInfo()
        {
            var models = await repository.All<Artist>()
                .Include(a => a.Tattos)
                .Select(x => new ArtistViewModel()
                {
                    FirstLastName = $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}",
                    NickName = x.ApplicationUser.UserName,
                    PhoneNumber = x.ApplicationUser.PhoneNumber,
                    Resume = x.Resume ?? "None",
                    SocialMediaLink = x.ApplicationUser.SocialMedia,
                    imageUrl = x.ImageUrl,
                    Works = x.Tattos.ToList()
                }).ToListAsync();

            return models;
        }
    }
}
