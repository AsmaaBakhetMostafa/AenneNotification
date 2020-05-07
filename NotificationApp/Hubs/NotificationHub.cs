using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using NotificationApp.API;
using NotificationApp.DTO;
using NotificationApp.Enums;
using NotificationApp.Helpers;
using NotificationApp.Hubs.NotificationService;
using NotificationApp.Models;
using System;
using System.Collections.Concurrent;
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
        private static readonly ConcurrentDictionary<string, UserHubModels> Users =
                           new ConcurrentDictionary<string, UserHubModels>(StringComparer.InvariantCultureIgnoreCase);

        string AdminBaseUrl = "http://venusera-001-site6.atempurl.com/";
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
            await Clients.All.SendAsync("CreatNewNotification", message);

        }

        public async Task ReciveNotification(string User, string message, string link)
        {
            await Clients.User(User).SendAsync("ReciveNotification",message);
        }

        public void UnreadNotification(int id, int userTypeId, int UserId, bool IsRead)
        {
            _NotificationAPIConsume.SetUnreadNotification(id, userTypeId, UserId,IsRead);
        }
        public async Task AdminNotifications(int NotificationID, string UserType, int TypeID, int Type)
        {
            // to make Update for UpdateNotificationLink
            if (Type == (int)NotificationType.Emergency) //Emergency
            {
                NotificationModel model = new NotificationModel();

                model.Notification_Id = NotificationID;
                model.Notification_Link = AdminBaseUrl + "Reports/Emergencies/SpecificEmergency?EmergencyId=" + TypeID;

                _NotificationAPIConsume.SetNotificationLink(model);
            }
            if (Type == (int)NotificationType.Complaint) //Complaint
            {
                NotificationModel model = new NotificationModel();

                model.Notification_Id = NotificationID;
                // in case Complaint 
                model.Notification_Link = AdminBaseUrl + "Reports/Complaints/SpecificComplaint?ComplaintID=" + TypeID;
                _NotificationAPIConsume.SetNotificationLink(model);
            }
            if (Type == (int)NotificationType.ScheduledTrip) //ScheduledTrip
            {
                NotificationModel model = new NotificationModel();

                model.Notification_Id = NotificationID;
                // in case Complaint 
                model.Notification_Link = AdminBaseUrl + "Trips/ScheduledTrips/ViewScheduleTrip?ScheduleId=" + TypeID;
                _NotificationAPIConsume.SetNotificationLink(model);
            }
            if (Type == (int)NotificationType.RequestCar)
            {
                NotificationModel model = new NotificationModel();

                model.Notification_Id = NotificationID;
                // in case Complaint 
                model.Notification_Link = "";
                _NotificationAPIConsume.SetNotificationLink(model);
            }
            await Clients.All.SendAsync("AdminNotifications",_NotificationHelper.UserNotifications(),
               NotificationID, UserType, TypeID, Type);
        }
        public void AdminNotificationsCount(int UserId,int UserTypeId)
        {

            Clients.All.SendAsync("AdminNotificationsCount",_NotificationHelper.GetSpecificUserNotificationsCount(UserId, UserTypeId));
        }
        //////////////////////////////////////////////////////////////////////////////

        #region PushNotifaction
        public  void AssignDriverToTrip(string DriverID, string notificationID, string tripeId)

        {
            //push Notification 
            Clients.User(DriverID).SendAsync("NotifiedScheduledTrip",DriverID, notificationID, tripeId);
        }
        //Admin Assign driver to vehicle or vehicle to driver
        public async Task AssignDriverToVehicle(int DriverID, int VehicleID,int UserId,int UserTypeId)
        {
            if (DriverID != 0)
            {
                // Save Notification in data base 
                //create Notification
                int Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                List<NotificationDestinationDto> LstDestenation = new List<NotificationDestinationDto>();
                NotificationDestinationDto Dest = new NotificationDestinationDto()
                {
                    NotificationDestination_ToUserId = DriverID,
                    NotificationDestination_ToUser_TypeId = (int)DestinationUserType.Driver,
                };
                if (UserTypeId == 1)//SuperAdmin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.SuperAdmin;
                }
                else //admin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                }
                NotificationModel notification = new NotificationModel()
                {
                    Notification_Title = "إشعارتخصيص سائق علي سيارة ",
                    Notification_Link = "",
                    Notification_Description = "تم تخصيص هذا السائق علي سياره رقم " + VehicleID,
                    Notification_FromUserId = UserId,
                    Notification_TimeStamp = MyDateTime.Now,
                    Notification_FromUser_TypeId = Notification_FromUser_TypeId,
                };
                notification.NotificationDestinations.Add(Dest);
                _NotificationAPIConsume.CreateNotification(notification);

                //push Notification 
                var LstConnIDs = Users.Where(x => x.Key == DriverID.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                 .Select(x => x.Value).FirstOrDefault();
                if (LstConnIDs != null)
                {
                    foreach (var ConnID in LstConnIDs.ConnectionIds)
                    {
                        //Clients.User(DriverID).SendAsync("NotifiedAssignDriverToVehicle", DriverID, notificationID, VehicleID);
                        await Clients.Client(ConnID).SendAsync("NotifiedAssignDriverToVehicle", DriverID, VehicleID);

                    }
                }
            }
        }
       // Admin UnAssign driver from vehicle or vehicle from driver
        public async Task UnAssignDriverToVehicle(int DriverID, int VehicleID, int UserId, int UserTypeId)
        {
            if (DriverID != 0)
            {
                // Save Notification in data base 
                //create Notification
                int Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                List<NotificationDestinationDto> LstDestenation = new List<NotificationDestinationDto>();
                NotificationDestinationDto Dest = new NotificationDestinationDto()
                {
                    NotificationDestination_ToUserId = DriverID,
                    NotificationDestination_ToUser_TypeId = (int)DestinationUserType.Driver,
                };
                if (UserTypeId == 1)//SuperAdmin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.SuperAdmin;
                }
                else //admin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                }
                NotificationModel notification = new NotificationModel()
                {
                    Notification_Title = "إشعار الغاء تخصيص سائق علي سيارة ",
                    Notification_Link = "",
                    Notification_Description = "تم الغاء تخصيص هذا السائق علي سياره رقم " + VehicleID,
                    Notification_FromUserId = UserId,
                    Notification_TimeStamp = MyDateTime.Now,
                    Notification_FromUser_TypeId = Notification_FromUser_TypeId,
                };
                notification.NotificationDestinations.Add(Dest);
                _NotificationAPIConsume.CreateNotification(notification);
                //push Notification 
                var LstConnIDs = Users.Where(x => x.Key == DriverID.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                 .Select(x => x.Value).FirstOrDefault();
                if (LstConnIDs != null)
                {
                    foreach (var ConnID in LstConnIDs.ConnectionIds)
                    {
                        //Clients.All.SendAsync("NotifiedUnAssignDriverToVehicle", DriverID,VehicleID);
                        await Clients.Client(ConnID).SendAsync("NotifiedUnAssignDriverToVehicle", DriverID, VehicleID);
                    }
                }

            }
        }

        //Admin Assign driver to Scheduled Trip
        public async Task AssignDriverToScheduledTrip(int DriverID,int TripScheduleId, int UserId, int UserTypeId)
        {
            if (DriverID != 0)
            {
                // Save Notification in data base 
                //create Notification
                int Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                List<NotificationDestinationDto> LstDestenation = new List<NotificationDestinationDto>();
                NotificationDestinationDto Dest = new NotificationDestinationDto()
                {
                    NotificationDestination_ToUserId = DriverID,
                    NotificationDestination_ToUser_TypeId = (int)DestinationUserType.Driver,
                };
                if (UserTypeId == 1)//SuperAdmin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.SuperAdmin;
                }
                else //admin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                }
                NotificationModel notification = new NotificationModel()
                {
                    Notification_Title = "إشعارتخصيص سائق علي رحلة مجدولة ",
                    Notification_Link = "",
                    Notification_Description = "تم تخصيص هذا السائق علي رحلة رقم " + TripScheduleId,
                    Notification_FromUserId = UserId,
                    Notification_TimeStamp = MyDateTime.Now,
                    Notification_FromUser_TypeId = Notification_FromUser_TypeId,
                };
                notification.NotificationDestinations.Add(Dest);
                _NotificationAPIConsume.CreateNotification(notification);

                //push Notification 
                var LstConnIDs = Users.Where(x => x.Key == DriverID.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                 .Select(x => x.Value).FirstOrDefault();
                if (LstConnIDs != null)
                {
                    foreach (var ConnID in LstConnIDs.ConnectionIds)
                    {
                        await Clients.Client(ConnID).SendAsync("NotifiedAssignDriverToScheduledTrip", DriverID, TripScheduleId);
                    }
                }
            }
        }

        //Admin UnAssign driver to Scheduled Trip
        public async Task UnAssignDriverToScheduledTrip(int DriverID, int TripScheduleId, int UserId, int UserTypeId)
        {
            if (DriverID != 0)
            {
                // Save Notification in data base 
                //create Notification
                int Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                List<NotificationDestinationDto> LstDestenation = new List<NotificationDestinationDto>();
                NotificationDestinationDto Dest = new NotificationDestinationDto()
                {
                    NotificationDestination_ToUserId = DriverID,
                    NotificationDestination_ToUser_TypeId = (int)DestinationUserType.Driver,
                };
                if (UserTypeId == 1)//SuperAdmin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.SuperAdmin;
                }
                else //admin
                {
                    Notification_FromUser_TypeId = (int)DestinationUserType.Admin;
                }
                NotificationModel notification = new NotificationModel()
                {
                    Notification_Title = "إشعارالغاء تخصيص سائق علي رحلة مجدولة ",
                    Notification_Link = "",
                    Notification_Description = "تم الغاء تخصيص هذا السائق علي رحلة رقم " + TripScheduleId,
                    Notification_FromUserId = UserId,
                    Notification_TimeStamp = MyDateTime.Now,
                    Notification_FromUser_TypeId = Notification_FromUser_TypeId,
                };
                notification.NotificationDestinations.Add(Dest);
                _NotificationAPIConsume.CreateNotification(notification);

                //push Notification 
                var LstConnIDs = Users.Where(x => x.Key == DriverID.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                 .Select(x => x.Value).FirstOrDefault();
                if (LstConnIDs != null)
                {
                    foreach (var ConnID in LstConnIDs.ConnectionIds)
                    {
                        await Clients.Client(ConnID).SendAsync("NotifiedUnAssignDriverToScheduledTrip", DriverID, TripScheduleId);
                    }
                }
            }
        }


        public void ReminderNotification(string DriverID, string TripScheduleId)//(string userId)
        {
            
            //push Notification 
            var LstConnIDs = Users.Where(x => x.Key == DriverID.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                             .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                  
                   Clients.Client(ConnID).SendAsync("NotifiedAssignDriverToScheduledTrip", DriverID, TripScheduleId);
                }
            }
        }
        public string AdminAllNotifications(int userTypeId, int destinationId)
        {
            return _NotificationHelper.SpecificUserNotifications(userTypeId, destinationId);
        }
        public async Task OnConnectedAsync(string UserID, int UserType)
        {
            //string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            // Clients.All.SendAsync("userConnected", UserID, connectionId);
            var user = Users.GetOrAdd(UserID, _ => new UserHubModels
            {
                UserID = UserID,
                UserType = UserType,
                ConnectionIds = new HashSet<string>()
            });

            lock (user.ConnectionIds)
            {
                user.ConnectionIds.Add(connectionId);
                if (user.ConnectionIds.Count == 1)
                {
                    // Clients.All.SendAsync("userConnected", UserID,connectionId);
                }
            }

            // return base.OnConnectedAsync();
        }

        public async Task OnDisconnectedAsync(string UserID, int UserType)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            UserHubModels user;
            Users.TryGetValue(userName, out user);

            if (user != null)
            {
                lock (user.ConnectionIds)
                {
                    user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
                    if (!user.ConnectionIds.Any())
                    {
                        UserHubModels removedUser;
                        Users.TryRemove(userName, out removedUser);
                        //Clients.Others.userDisconnected(userName);
                        // Clients.Others.SendAsync("userDisconnected", userName);

                    }
                }
            }

            // return base.OnDisconnectedAsync(UserID,UserType);
        }

        #endregion
    }
}
