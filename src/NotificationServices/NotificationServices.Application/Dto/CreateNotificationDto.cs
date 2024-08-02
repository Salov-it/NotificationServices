

namespace NotificationServices.Application.Dto
{
    /// <summary>
    /// DTO (Data Transfer Object) для создания уведомления.
    /// </summary>
    public class CreateNotificationDto
    {
        /// <summary>
        /// Сообщение уведомления.
        /// </summary>
        public string Message {  get; set; }

        /// <summary>
        /// Тип уведомления.
        /// </summary>
        public string Type {  get; set; }
                       
    }
}
