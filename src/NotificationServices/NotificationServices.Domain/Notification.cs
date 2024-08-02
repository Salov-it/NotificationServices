

using System.ComponentModel.DataAnnotations;

namespace NotificationServices.Domain
{
    /// <summary>
    /// Сущность, представляющий уведомление
    /// </summary>
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
    }

    // Перечисление типов уведомлений
    public enum NotificationType
    {
        Info,
        Warning,
        Error
    }
}
