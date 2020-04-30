using NotificationApp.API;
using NotificationApp.DTO.Trips;
using NotificationApp.Enums;
using NotificationApp.Helpers;
using NotificationApp.Hubs;
using NotificationApp.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Job
{
    public class TripBeforeTwoHoursJob : IJob
    {
        NotificationAPIConsume _NotificationAPIConsume = new NotificationAPIConsume();
        NotificationHelper _NotificationHelper = new NotificationHelper();
        NotificationHub _NotificationHub = new NotificationHub();
        public void Execute(IJobExecutionContext context)
        {

            try
            {
                IList<TripsDto> AllShecudledTrips = new List<TripsDto>();
                //get All Driver assign for Scheduled Trip 
               // RequestData Data = _NotificationAPIConsume.GetAllSheduledDriver();
                AllShecudledTrips = _NotificationAPIConsume.GetAllSheduledDriver();
                AllShecudledTrips = AllShecudledTrips.Where(x => x.Trip_Date.AddHours(2).Date == DateTime.Now.Date).ToList();
                //create Notification
                foreach (var Trip in AllShecudledTrips)
                {
                    if (Trip.Driver_Id != 0)
                    {
                        //create Notification
                        List<NotificationDestinationDto> LstDestenation = new List<NotificationDestinationDto>();
                        NotificationDestinationDto Dest = new NotificationDestinationDto()
                        {
                            NotificationDestination_ToUserId = Trip.Driver_Id,
                            NotificationDestination_ToUser_TypeId = (int)DestinationUserType.Driver
                        };
                        NotificationModel notification = new NotificationModel()
                        {
                            Notification_Title = "إشعار تذكير برحلتك ",
                            Notification_Link = "",
                            Notification_Description = "تذكير بميعاد رحتلك القادمة  بعد يومين الساعه " + Trip.Trip_Time,
                            Notification_FromUserId = 1,
                            Notification_TimeStamp = DateTime.Now,
                            Notification_FromUser_TypeId = 1,//super Admin,
                        };
                        notification.NotificationDestinations.Add(Dest);
                        ///create Notification
                         _NotificationAPIConsume.CreateNotification(notification);

                        //send notification
                        _NotificationHub.ReminderNotification(Trip.Driver_Id.ToString(), Trip.Trip_Schedule_Id.ToString());
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
