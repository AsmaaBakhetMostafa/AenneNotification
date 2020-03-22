using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Notification
{
    public class CreateNotificationDto
    {
        public string Notification_Title { get; set; }
        public string Notification_Description { get; set; }
        public string Notification_Link { get; set; }
        public int Notification_FromUser_TypeId { get; set; }
        public int Notification_FromUserId { get; set; }
        public List<CreateNotificationDestinationDto> NotificationDestinations { get; set; }
    }

    public class CreateNotificationDestinationDto
    {
        public int NotificationDestination_ToUser_TypeId { get; set; }
        public int NotificationDestination_ToUserId { get; set; }
    }
}
