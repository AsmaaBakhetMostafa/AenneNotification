using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Linq;
using NotificationApp.DTO.Driver;
using NotificationApp.DTO.Financial;
using NotificationApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotificationApp.API
{
    public class APIConsume
    {
        private RestClient client = new RestClient("http://aenee.app.192-185-7-211.hgws27.hgwin.temp.domains/Api/");//("http://localhost:49950/Api/");

        //to get matched driver 
        public IList<MatchedDriverVehicalDto> GetMatchedDriver(int Healty_number, int Handicapped_Number)
        {
            var request = new RestRequest("Drivers/GetMatchedDriver/{Healty_number}/{Handicapped_Number}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddParameter("Healty_number", Healty_number, ParameterType.UrlSegment);
            request.AddParameter("Handicapped_Number", Handicapped_Number, ParameterType.UrlSegment);


            var response = client.Execute<IList<MatchedDriverVehicalDto>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        ////// to ge t GetRashHours
        public FinancialsRushHoursDto GetRashHours(int WeekDay)
        {
            var request = new RestRequest("Venusera/Financial/GetRashHours/{WeekDay}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddParameter("WeekDay", WeekDay, ParameterType.UrlSegment);
            var response = client.Execute<FinancialsRushHoursDto>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }
        // to CalculatePriceCost
        public decimal CalculatePriceCost(PriceCostDto pricecost)
        {
            var request = new RestRequest("Venusera/Financial/CalculateCostPrice/{pricecost}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddParameter("pricecost", pricecost, ParameterType.UrlSegment);
            var response = client.Execute<decimal>(request);

            if (response.Data == 0)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }
    }
}
