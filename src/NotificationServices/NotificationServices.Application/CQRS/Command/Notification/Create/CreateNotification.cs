using Microsoft.Extensions.Logging;
using NotificationServices.Application.Dto;
using NotificationServices.Application.Interface;
using NotificationServices.Domain;
using Postgres.Application.Context;

namespace NotificationServices.Application.CQRS.Command.Notification.Create
{
    public class CreateNotification : INotificationService
    {
        private readonly PostgresContext _postgresContext;
        private readonly ILogger<CreateNotification> _logger;

        public CreateNotification(PostgresContext postgresContext, ILogger<CreateNotification> logger)
        {
            _postgresContext = postgresContext;
            _logger = logger;
        }

        /// <summary>
        /// Асинхронный метод для создания уведомления.
        /// </summary>
        /// <param name="message">Сообщение уведомления.</param>
        /// <param name="type">Тип уведомления.</param>
        /// <param name="timestamp">Временная метка, указывающая время создания уведомления.</param>
        /// <returns></returns>
        public async Task<ServiceResultDto> CreateNotificationAsync(string message, NotificationType type)
        {
            try
            {
                Domain.Notification notification = new Domain.Notification
                {
                    Message = message,
                    Type = type,
                    Timestamp = DateTime.UtcNow,
                    IsRead = false
                };
                _postgresContext.Notification.Add(notification);
                await _postgresContext.SaveChangesAsync();

                return new ServiceResultDto() { IsSuccesful = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating notification.");
                return new ServiceResultDto()
                {
                    IsSuccesful = false,
                    ErrorMsg = ex.Message,
                };
            }

        }
    }
}
