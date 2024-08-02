using MediatR;
using NotificationServices.Application.Dto;


namespace NotificationServices.Application.CQRS.Command.Notification.Create
{
    /// <summary>
    /// Команда для создания уведомления.
    /// </summary>
    public class CreateNotificationCommand : IRequest<ServiceResultDto>
    {
        /// <summary>
        /// DTO для создания уведомления.
        /// </summary>
        public CreateNotificationDto create {  get; set; }
    }
}
