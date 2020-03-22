using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Notification
{
    public class NotificationDestinationDto
    {
        public int NotificationDestination_Id { get; set; }
        public bool NotificationDestination_IsRead { get; set; }
        public int NotificationDestination_ToUser_TypeId { get; set; }
        public int NotificationDestination_ToUserId { get; set; }
        public string userType { get; set; }
    }
}
