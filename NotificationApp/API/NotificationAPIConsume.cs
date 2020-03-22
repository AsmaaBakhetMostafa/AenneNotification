using NotificationApp.DTO.Notification;
using NotificationApp.DTO.Trips;
using NotificationApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NotificationApp.API
{
    public class NotificationAPIConsume
    {
        private RestClient client = new RestClient("http://localhost:49950/Api/");
        public  IList<TripsDto> GetAllSheduledDriver()
        {
            var request = new RestRequest("Venusera/Trips/GetAcceptedScheduledTrips", Method.GET) { RequestFormat = DataFormat.Json };

            var response = client.Execute<IList<TripsDto>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public void CreateNotification(NotificationModel NotificationData)
        {
            var request = new RestRequest("Venusera/Notifications/PostNotification", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(NotificationData);

            var response = client.Execute<NotificationModel>(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception(response.ErrorMessage);
        }
    
      
        public NotificationDto SetUnreadNotification(int id)
        {
            var request = new RestRequest("Venusera/Notifications/UpdateIsReadNotification/{id}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute<NotificationDto>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public IList<NotificationDto> GetAllUnreadNotification()
        {
            var request = new RestRequest("Venusera/Notifications/GetAllUnreadAdminNotification", Method.GET) { RequestFormat = DataFormat.Json };

            var response = client.Execute<IList<NotificationDto>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public void SetNotificationLink(NotificationModel NotificationData)
        {
            var request = new RestRequest("Venusera/Notifications/UpdateNotificationLink", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(NotificationData);

            var response = client.Execute<NotificationModel>(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception(response.ErrorMessage);
        }

      
    }
}
