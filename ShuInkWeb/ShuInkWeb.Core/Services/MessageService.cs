using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.FilesCloudService;
using ShuInkWeb.Core.Models.MessageModels;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities.Clients;

namespace ShuInkWeb.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IDeletableEntityRepository<Message> messageRepository;

        private readonly IOldCapitalCloud cloud;

        public MessageService(IDeletableEntityRepository<Message> _messageRepository, IOldCapitalCloud _cloud)
        {
            messageRepository = _messageRepository;
            cloud = _cloud;
        }

        public async Task Add(MessageViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Name);

            var message = new Message()
            {
                Name = model.Name,
                Content = model.Content,
                ImageUrl = cloud.GetUrl(model.Name)
            };

            await messageRepository.AddAsync(message);

            await messageRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageViewModel>> All()
        {
            return await messageRepository
                .AllAsNoTracking()
                .Select(x => new MessageViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl != null ? x.ImageUrl : "None",
                    UserId = x.UserId != null ? x.UserId : "Anonymous"
                })
                .ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await messageRepository.GetByIdAsync(id);

            messageRepository.Delete(entity);

            await messageRepository.SaveChangesAsync();
        }

        public async Task<bool> IsExistById(Guid id)
        {
            return await messageRepository.AllAsNoTracking().AnyAsync(x => x.Id == id);
        }
    }
}
