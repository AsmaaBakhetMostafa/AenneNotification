using NotificationApp.DTO.Notification;
using NotificationApp.DTO.Trips;
using NotificationApp.Models;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NotificationApp.API
{
    public class NotificationAPIConsume
    {
        private RestClient client = new RestClient("http://aenee.app.192-185-7-211.hgws27.hgwin.temp.domains/Api/"); //("http://localhost:49950/Api/");
        public  IList<TripsDto> GetAllSheduledDriver()
        {
            var request = new RestRequest("Venusera/Trips/GetAcceptedScheduledTrips", Method.GET) { RequestFormat = DataFormat.Json };

            var response = client.Execute<IList<TripModel>>(request);

            //if (response.Data == null)
            //    throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public void CreateNotification(NotificationModel NotificationData)
        {
            var request = new RestRequest("Venusera/Notifications/PostNotification") { RequestFormat = DataFormat.Json };
            
            client.UseNewtonsoftJson();
            request.Method = Method.POST;
            request.AddJsonBody(NotificationData);

            var response = client.Execute(request);
            var content = response.Content; // raw content as string  
        }
      
        public NotificationDto SetUnreadNotification(int id)
        {
            var request = new RestRequest("Venusera/Notifications/UpdateIsReadNotification/{id}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute<NotificationDto>(request);

            //if (response.Data == null)
            //    throw new Exception(response.ErrorMessage);

            return response.Data;
        }
        
        public IList<NotificationDto> GetAllUnreadNotification()
        {
            var request = new RestRequest("Venusera/Notifications/GetAllUnreadAdminNotification", Method.GET) { RequestFormat = DataFormat.Json };

            var response = client.Execute<IList<NotificationDto>>(request);

            //if (response.Data == null)
            //    throw new Exception(response.ErrorMessage);

            return response.Data;
        }
        public IList<NotificationDto> GetAllUnreadSpecificAdminNotification(int UserId)
        {
            var request = new RestRequest("Venusera/Notifications/GetAllUnreadSpecificAdminNotification/{UserId}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddParameter("UserId", UserId, ParameterType.UrlSegment);
            var response = client.Execute<IList<NotificationDto>>(request);

            //if (response.Data == null)
            //    throw new Exception(response.ErrorMessage);

            return response.Data;
        }
        public void SetNotificationLink(NotificationModel NotificationData)
        {
            var request = new RestRequest("Venusera/Notifications/UpdateNotificationLink") { RequestFormat = DataFormat.Json };

            client.UseNewtonsoftJson();
            request.Method = Method.POST;
            request.AddJsonBody(NotificationData);

            var response = client.Execute(request);
            var content = response.Content; // raw content as string  
        }

      
    }
}
