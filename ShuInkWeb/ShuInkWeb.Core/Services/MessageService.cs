using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Exceptions;
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

        private readonly IGuard guard;

        private readonly ILogger<MessageService> logger;

        public MessageService(IDeletableEntityRepository<Message> _messageRepository,
            IOldCapitalCloud _cloud,
            IGuard _guard,
            ILogger<MessageService> _logger)
        {
            messageRepository = _messageRepository;
            cloud = _cloud;
            guard = _guard;
            logger = _logger;
        }

        public async Task AddAsync(MessageViewModel model, IFormFile file)
        {
            await cloud.UploadFile(file, model.Name);

            var message = new Message()
            {
                Name = model.Name,
                Content = model.Content,
                ImageUrl = cloud.GetUrl(model.Name)
            };

            try
            {
                await messageRepository.AddAsync(message);

                await messageRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddAsync), ex);
                throw new ApplicationException("Database failed to Add Message!", ex);
            }
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllMessagesAsync()
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

        public async Task DeleteAsync(Guid id)
        {
            var entity = await messageRepository.GetByIdAsync(id);

            guard.AgainstNull(entity, "This Message Doe's Not Exists!");

            try
            {
                messageRepository.Delete(entity);

                await messageRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(DeleteAsync), ex);
                throw new ApplicationException("Database failed to Delete Message!", ex);
            }
        }

        public async Task<bool> IsExistByIdAsync(Guid id)
        {
            return await messageRepository.AllAsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
    }
}
