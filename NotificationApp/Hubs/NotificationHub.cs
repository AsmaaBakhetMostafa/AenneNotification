using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using NotificationApp.API;
using NotificationApp.Enums;
using NotificationApp.Helpers;
using NotificationApp.Hubs.NotificationService;
using NotificationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Hubs
{
    [HubName("AdminNotification")]

    public class NotificationHub : Hub
    {

        NotificationAPIConsume _NotificationAPIConsume = new NotificationAPIConsume();
        NotificationHelper _NotificationHelper = new NotificationHelper();
        /// <summary>
        /// /Test
        /// </summary>
        /// <param name="User"></param>
        /// <param name="message"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public async Task PushNotification(string User, string message, string link)
        {
            await Clients.User(User).SendAsync("CreatNewNotification",message);
        }

        public async Task ReciveNotification(string User, string message, string link)
        {
            await Clients.User(User).SendAsync("ReciveNotification",message);
        }

        public void UnreadNotification(int id)
        {

            _NotificationAPIConsume.SetUnreadNotification(id);
        }
        public void AdminNotifications(int NotificationID, string UserType, int TypeID, int Type)
        {
            // to make Update for UpdateNotificationLink
            if (Type == (int)NotificationType.Emergency) //Emergency
            {
                NotificationModel model = new NotificationModel();

                model.Notification_Id = NotificationID;
                model.Notification_Link = "http://doaaberam-001-site1.itempurl.com/" + "Reports/Emergencies/SpecificEmergency?EmergencyId=" + TypeID;
                _NotificationAPIConsume.SetNotificationLink(model);
            }
            Clients.All.SendAsync("AdminNotifications",_NotificationHelper.UserNotifications());
        }
        public void AdminNotificationsCount()
        {

            Clients.All.SendAsync("AdminNotificationsCount",_NotificationHelper.GetUserNotificationsCount());
        }
        //////////////////////////////////////////////////////////////////////////////

        #region PushNotifaction
        public  void AssignDriverToTrip(string DriverID, string notificationID, string tripeId)

        {
            //push Notification 
            Clients.User(DriverID).SendAsync("NotifiedScheduledTrip",DriverID, notificationID, tripeId);
        }
        public  void AssignDriverToVechial(string DriverID, string notificationID, string VehicleID)

        {
            //push Notification 
            Clients.User(DriverID).SendAsync("NotifiedScheduledTrip",DriverID, notificationID, VehicleID);
        }
        public  void ReminderNotification(string DriverID, string notificationID, string tripeId, DateTime tripdate, DateTime triptime)//(string userId)
        {
            //push Notification 
            Clients.User(DriverID).SendAsync("NotifiedScheduledTrip",DriverID, notificationID, tripeId, tripdate, triptime);
        }

        #endregion
    }
}
