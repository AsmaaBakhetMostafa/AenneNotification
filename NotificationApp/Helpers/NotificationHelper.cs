using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using NotificationApp.API;
using NotificationApp.DTO.Notification;
using NotificationApp.Hubs;
using NotificationApp.Hubs.NotificationService;
using NotificationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Helpers
{
    public class NotificationHelper
    {
        NotificationAPIConsume _NotificationAPIConsume = new NotificationAPIConsume();
        // private static IHubContext NotificationHub => GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        public static void TestSendNotification(string title)//(string userId, string title, string description, string link)
        {
            string li = "";
            li = $"<li><a href =\"#\"><div><i class=\"fa fa-comment fa-fw\"></i>'{ title}'" +
                   $"<span class=\"pull-right text-muted small\">4 minutes ago</span>" +
                      "</div></a></li><li class=\"divider\"></li>";
            //create Notification in DB
            //push Notification 

            //NotificationHub.Clients.All.AdminNotifications(li);

        }

        public string UserNotifications()

        {

            var notis = (List<NotificationDto>)_NotificationAPIConsume.GetAllUnreadNotification();

            string li = "";
            if (notis != null)
            {
                foreach (var notification in notis)
                {


                    //li += $"<li><a href ='{notification.Notification_Link}' onclick=\"OnclickLink(this)\"  id='{notification.Notification_Id}'>" +
                    //    $"<div><i class=\"fa fa-comment fa-fw\"></i><div>'{ notification.Notification_Title}'" +
                    //    $"<div>'{ notification.Notification_Description}'" +"</div>"+ 
                    //       $"</div><div><span class=\"pull-right text-muted small\">{ notification.Notification_TimeStamp}</span></div>" +
                    //          "</div></a></li><li class=\"divider\"></li>";

                    //DateTime dt = DateTime.ParseExact(notification.Notification_TimeStamp.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                    //string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    li += $"<div class=\"sl-item\" onclick=\"OnclickLink(this)\"   id='{notification.Notification_Id}'" +
                        $"style =\"height: 60px!important ;background-color: white;\">" +
                                       $"<a href ='{notification.Notification_Link}'>" +
                                        $"<div class=\"icon bg-green\"><i class=\"ti-briefcase\"></i></div>" +
                                            $"<div class=\"sl-content\"><span class=\"inline-block capitalize-font  pull-right truncate head-notifications\">'{ notification.Notification_Title}'" +
                                              $"</span><span class=\"inline-block font-11  pull-left notifications-time\">{ notification.Notification_TimeStamp}</span>" +
                                                $"<div class=\"clearfix\"></div><p class=\"truncate\">'{ notification.Notification_Description}'</p></div></a></div><hr class=\"light-grey-hr ma-0\">";

                }
            }
            return li;
        }

        public string SpecificUserNotifications(int userTypeId, int destinationId)

        {

            var notis = (List<NotificationDto>)_NotificationAPIConsume.GetAllNotificationForSpecficUser(userTypeId, destinationId);

            string li = "";
            if (notis != null)
            {
                foreach (var notification in notis)
                {


                    //string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    li += $"<div class=\"sl-item\" onclick=\"OnclickLink(this)\"   id='{notification.Notification_Id}'" +
                        $"style =\"height: 60px!important ;background-color: white;\">" +
                                       $"<a href ='{notification.Notification_Link}'>" +
                                        $"<div class=\"icon bg-green\"><i class=\"ti-briefcase\"></i></div>" +
                                            $"<div class=\"sl-content\"><span class=\"inline-block capitalize-font  pull-right truncate head-notifications\">'{ notification.Notification_Title}'" +
                                              $"</span><span class=\"inline-block font-11  pull-left notifications-time\">{ notification.Notification_TimeStamp}</span>" +
                                                $"<div class=\"clearfix\"></div><p class=\"truncate\">'{ notification.Notification_Description}'</p></div></a></div><hr class=\"light-grey-hr ma-0\">";

                }
            }
            return li;
        }
        public int GetUserNotificationsCount()

        {

            var notis = (List<NotificationDto>)_NotificationAPIConsume.GetAllUnreadNotification();
            if (notis == null)
                return 0;
            else
                return notis.Count();
        }

        public int GetSpecificUserNotificationsCount(int UserId,int UserTypeId)

        {

            var notis = (List<NotificationDto>)_NotificationAPIConsume.GetAllUnreadSpecificAdminNotification(UserId, UserTypeId);
            if (notis == null)
                return 0;
            else
                return notis.Count();
        }

    }
}
