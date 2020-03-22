using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Notification
{
    public class NotificationDto
    {
        public int Notification_Id { get; set; }
        public string Notification_Title { get; set; }
        public string Notification_Description { get; set; }
        public string Notification_Link { get; set; }
        public System.DateTime Notification_TimeStamp { get; set; }
        public int Notification_FromUser_TypeId { get; set; }
        public int Notification_FromUserId { get; set; }
        public List<NotificationDestinationDto> NotificationDestinations { get; set; }
    }
}
