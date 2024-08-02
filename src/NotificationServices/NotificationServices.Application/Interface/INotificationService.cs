using MediatR;
using NotificationServices.Application.Dto;
using NotificationServices.Domain;

namespace NotificationServices.Application.Interface
{
    /// <summary>
    /// Интерфейс для уведомлений
    /// </summary>
    public interface INotificationService
    {
        Task<ServiceResultDto> CreateNotificationAsync(string message, NotificationType type, DateTime timestamp);
        IEnumerable<Notification> GetNotifications();
        void MarkAsRead(int notificationId);
        void DeleteNotification(int notificationId);
    }
}
