using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using NotificationApp.API;
using NotificationApp.DTO;
using NotificationApp.DTO.Driver;
using NotificationApp.DTO.Financial;
using NotificationApp.Enums;
using NotificationApp.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Hubs
{
    [HubName("TripNotification")]
    public class TripNotificationHub : Hub
    {
        static List<AllDriverPickUpLocationsDto> AllMatchedDriverVehicalDto = new List<AllDriverPickUpLocationsDto>();
        static List<MatchedDriverVehicalDto> _MatchedDriverVehicalDto = new List<MatchedDriverVehicalDto>();
        
        APIConsume _APIConsume = new APIConsume();
        private static readonly ConcurrentDictionary<string, UserHubModels> Users =
                            new ConcurrentDictionary<string, UserHubModels>(StringComparer.InvariantCultureIgnoreCase);

        private readonly ILogger<TripNotificationHub> _logger;
        public TripNotificationHub(ILogger<TripNotificationHub> logger)
        {
            _logger = logger;
        }
        ///1-Fire Push Rash Hours
        ///3-Push another notification  with Price Cost To Driver
        public async Task RequestRashHour(int WeekDay,int Driver_Id)
        {
            FinancialsRushHoursDto RashHours = new FinancialsRushHoursDto();
            RashHours = _APIConsume.GetRashHours(WeekDay);

            var LstConnIDsdriver = Users.Where(x => x.Key == Driver_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                              .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDsdriver != null)
            {
                foreach (var ConnID in LstConnIDsdriver.ConnectionIds)
                {
                    await Clients.Client(ConnID).SendAsync("NotifiedDriverRashHour", RashHours);
                }
            }
            //return await Task.Run<FinancialsRushHoursDto>(() =>
            //{
            //    return _APIConsume.GetRashHours(WeekDay);
            //}
            //);
        }

        public async Task RequestPriceCost(PriceCostDto priceCostDto,int Client_Id,int Driver_Id)
        {

            
            double TripCost=(double) _APIConsume.CalculatePriceCost(priceCostDto);

            var LstConnIDs = Users.Where(x => x.Key == Client_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Client)
                                     .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    await Clients.Client(ConnID).SendAsync("NotifiedClientTripCost", TripCost, priceCostDto.TotalWaitingMinutes, priceCostDto.NormalKM, priceCostDto.RusKM, priceCostDto.TotalMinutes);
                }
            }
            ////////////////
            var LstConnIDsdriver = Users.Where(x => x.Key == Driver_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDsdriver != null)
            {
                foreach (var ConnID in LstConnIDsdriver.ConnectionIds)
                {
                    await Clients.Client(ConnID).SendAsync("NotifiedDriverTripCost", TripCost);
                }
            }
            //  return await Task.Run<double>(() =>
            //  {
            //      return TripCost;
            //  }
            //);
            // decimal PriceCost = financialservice.CalculatePriceCost(priceCostDto);
            //await Clients.User(User).ReciveTripCost(PriceCost);

        }

        //////////////////////////
        ///1-Fire Push Get mateched Drivers for  using Healty_number amd Handicapped_Number
        ///3-Push another notification  with Driver Id and Trip_Pickup_Long and Trip_Pickup_Latt of Driver
        public async Task GetMatchedDriver(int Client_Id, int Healty_number, int Handicapped_Number, 
            double Client_Pickup_Long, double Client_Pickup_Latt, double Trip_Destination_Long,
            double Trip_Destination_Latt,double Trip_Time)
        {

            //to remove all data for specific client 
            if (AllMatchedDriverVehicalDto.Count() > 0)
            {
              //  AllMatchedDriverVehicalDto.Remove(AllMatchedDriverVehicalDto.Single(s => s.Client_Id == Client_Id));
                AllMatchedDriverVehicalDto.RemoveAll(x=>x.Client_Id==Client_Id);
            }

            _MatchedDriverVehicalDto = _APIConsume.GetMatchedDriver(Healty_number, Handicapped_Number).ToList();

            //await Clients.All.SendAsync("NotifiedCurrentLongAndLattForDriver");


            for (int i = 0; i < _MatchedDriverVehicalDto.Count; i++)
            {
                var LstConnIDs = Users.
                                    Where(x => x.Key == _MatchedDriverVehicalDto[i].Driver_Id.ToString() &&x.Value.UserType==(int)DestinationUserType.Driver)
                                     .Select(x => x.Value).FirstOrDefault();
                //  await Clients.All.SendAsync("NotifiedCurrentLongAndLattForDriver", Client_Id, Client_Pickup_Long,  Client_Pickup_Latt);
                //  await Clients.All.SendAsync("NotifiedCurrentLongAndLattForDriver", Client_Id, Client_Pickup_Long, Client_Pickup_Latt);
              //  Clients.All.SendAsync("CatchConnectionIds", LstConnIDs.ConnectionIds, Client_Id, _MatchedDriverVehicalDto[i].Driver_Id);

                //push to specific driver 
                //  await Clients.User(_MatchedDriverVehicalDto[i].Driver_Id.ToString()).SendAsync("NotifiedCurrentLongAndLattForDriver");
                if (LstConnIDs != null)
                {
                    foreach (var ConnID in LstConnIDs.ConnectionIds)
                    {

                        await Clients.Client(ConnID).SendAsync("NotifiedCurrentLongAndLattForDriver", Client_Id, Client_Pickup_Long, Client_Pickup_Latt, Trip_Destination_Long, Trip_Destination_Latt, Healty_number, Handicapped_Number
                            ,Trip_Time);

                        // await Clients.All.SendAsync("NotifiedCurrentLongAndLattForDriver", Client_Id, Client_Pickup_Long,  Client_Pickup_Latt);
                    }
                }
            }
        }


        public async Task GetCurrentLongAndLattForDriver(int Client_Id,double Client_Pickup_Long,double Client_Pickup_Latt, int Driver_Id, double Driver_Pickup_Long, double Driver_Pickup_Latt)
        {

            if (Driver_Id != 0)
            {


                //AllDriverPickUpLocationsDto DriverPickUpLocations = new AllDriverPickUpLocationsDto();
                //DriverPickUpLocations.Client_Id = Client_Id;
                //DriverPickUpLocations.MatchedDriverVehical.Driver_Id =Driver_Id;
                //DriverPickUpLocations.MatchedDriverVehical.Driver_Pickup_Latt = Driver_Pickup_Latt;
                //DriverPickUpLocations.MatchedDriverVehical.Driver_Pickup_Long = Driver_Pickup_Long;


                AllMatchedDriverVehicalDto.Add(new AllDriverPickUpLocationsDto()
                {
                    Client_Id = Client_Id,
                    MatchedDriverVehical = new MatchedDriverVehicalDto()
                    {
                        Driver_Id = Driver_Id,
                        Driver_Pickup_Latt = Driver_Pickup_Latt,
                        Driver_Pickup_Long = Driver_Pickup_Long
                    }
                });
                // Clients.All.SendAsync("CatchListbeforSendToDriver", AllMatchedDriverVehicalDto.Count, _MatchedDriverVehicalDto.Count, Client_Id);
                _logger.LogInformation("CatchListbeforSendToDriver :(");
                var listforspecificclient = AllMatchedDriverVehicalDto.Where(x => x.Client_Id == Client_Id).ToList();
                if (listforspecificclient.Count == _MatchedDriverVehicalDto.Count)
                {
                    //  Clients.All.SendAsync("CatchListAfterSendToDriver", AllMatchedDriverVehicalDto.Count, _MatchedDriverVehicalDto.Count, Client_Id);
                    _logger.LogInformation("CatchListAfterSendToDriver :(");
                    MatchedDriverVehicalDto nearestdriverobj = GetNearestDriver(Client_Id, Client_Pickup_Long, Client_Pickup_Latt);
                    //  Push Notification To Nearest Driver
                    if (nearestdriverobj != null)
                    {
                        PushToNearestLongAndLattOfDriverForDriver(Client_Id, nearestdriverobj.Driver_Id, Client_Pickup_Long, Client_Pickup_Latt);//nearestdriverobj.Driver_Id, nearestdriverobj.Driver_Pickup_Long, nearestdriverobj.Driver_Pickup_Latt);
                    }
                }
            }
        }
        public void PushToNearestLongAndLattOfDriverForDriver(int Client_Id1, int DriverID, double Client_Pickup_Long1, double Client_Pickup_Latt1)
        {
            //push Notification to Driver
            //Clients.User(DriverID.ToString()).SendAsync("NotifiedNearestDriverLongAndLattForDriver",DriverID, Driver_Pickup_Long, Driver_Pickup_Latt);
            //Clients.All.SendAsync("NotifiedNearestDriverLongAndLattForDriver", Client_Id, Driver_Pickup_Long, Driver_Pickup_Latt);
            var LstConnIDs = Users.Where(x => x.Key == DriverID.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                        .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    Clients.Client(ConnID).SendAsync("NotifiedNearestDriverLongAndLattForDriver", Client_Id1, Client_Pickup_Long1, Client_Pickup_Latt1);
                }
            }
        }


        //To Get Nearest Pickup_Long and Trip_Pickup_Latt of   Driver  
        public MatchedDriverVehicalDto GetNearestDriver(int Client_Id, double Client_Pickup_Long, double Client_Pickup_Latt)
        {
            var coord = new GeoCoordinate(Client_Pickup_Long, Client_Pickup_Latt);

            var listforspecificclient = AllMatchedDriverVehicalDto.Where(x => x.Client_Id == Client_Id).ToList();

            var nearest = listforspecificclient.Where(x => x.Client_Id == Client_Id).Select(x => new GeoCoordinate(x.MatchedDriverVehical.Driver_Pickup_Latt, x.MatchedDriverVehical.Driver_Pickup_Long))
                                   .OrderBy(x => x.GetDistanceTo(coord))
                                   .FirstOrDefault();

            MatchedDriverVehicalDto obj = listforspecificclient.Where(x => x.MatchedDriverVehical.Driver_Pickup_Latt == nearest.Latitude
                                                                                && x.MatchedDriverVehical.Driver_Pickup_Long == nearest.Longitude
            ).Select(x => new MatchedDriverVehicalDto
            {
                Driver_Id = x.MatchedDriverVehical.Driver_Id,
                Driver_Pickup_Long = x.MatchedDriverVehical.Driver_Pickup_Long,
                Driver_Pickup_Latt = x.MatchedDriverVehical.Driver_Pickup_Latt
            }).FirstOrDefault();
            return obj;
        }


        //// calling when driver accept or reject trip 
        public async Task StatusTripFromDriver(int Client_Id, int Driver_Id, int TripStatusFromDriver, double Client_Pickup_Long, double Client_Pickup_Latt, TimeSpan StartTime,
            double Driver_Pickup_Long, double Driver_Pickup_Latt)
        {


            if (TripStatusFromDriver == (int)Enums.TripStatusFromDriver.Accepted)
            {
                int Vehicle_Id = 0;
                // to get Vehicle that assined for this driver
                Driver_Vehicle DriverVehicle = _APIConsume.GetDriverVehicleByDriverId(Driver_Id);
                if (DriverVehicle != null)
                {
                    Vehicle_Id = DriverVehicle.Vehicle_Id;
                }

                var LstConnIDs = Users.Where(x => x.Key == Client_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Client)
                                         .Select(x => x.Value).FirstOrDefault();
                if (LstConnIDs != null)
                {
                    foreach (var ConnID in LstConnIDs.ConnectionIds)
                    {
                        // await Clients.User(Client_Id.ToString()).SendAsync("NotifiedForClientByNearestDriver",Driver_Id);
                        await Clients.Client(ConnID).SendAsync("NotifiedForClientByNearestDriver", Driver_Id, Vehicle_Id, StartTime,  Driver_Pickup_Long,  Driver_Pickup_Latt);
                    }
                }
            }
            else // Rejected or TimerEnded
            {
                MatchedDriverVehicalDto Nextdriverobj = GetNextNearestDriver(Client_Id, Client_Pickup_Long, Client_Pickup_Latt, Driver_Id);
                //  Push Notification To Next Driver
                if (Nextdriverobj != null)
                {
                    PushToNearestLongAndLattOfDriverForDriver(Client_Id, Nextdriverobj.Driver_Id, Nextdriverobj.Driver_Pickup_Long, Nextdriverobj.Driver_Pickup_Latt);
                }
            }
        }

        //to Get Next Nearest Driver
        public MatchedDriverVehicalDto GetNextNearestDriver(int Client_Id, double Client_Pickup_Long, double Client_Pickup_Latt, int Driver_Id)
        {

            //Get all Drivers from list expect specific driver 
            var listforspecificclient = AllMatchedDriverVehicalDto.Where(x => x.Client_Id == Client_Id).ToList();

            List<AllDriverPickUpLocationsDto> ListNextMatchedDriver = listforspecificclient.Where(a => a.Client_Id == Client_Id && a.MatchedDriverVehical.Driver_Id != Driver_Id).ToList();

            var coord = new GeoCoordinate(Client_Pickup_Long, Client_Pickup_Latt);

            var nearest = ListNextMatchedDriver.Where(q => q.Client_Id == Client_Id).Select(x => new GeoCoordinate(x.MatchedDriverVehical.Driver_Pickup_Latt, x.MatchedDriverVehical.Driver_Pickup_Long))
                                   .OrderBy(x => x.GetDistanceTo(coord))
                                   .FirstOrDefault();

            MatchedDriverVehicalDto obj = ListNextMatchedDriver.Where(x => x.MatchedDriverVehical.Driver_Pickup_Latt == nearest.Latitude
                                                                                && x.MatchedDriverVehical.Driver_Pickup_Long == nearest.Longitude
            ).Select(x => new MatchedDriverVehicalDto
            {
                Driver_Id = x.MatchedDriverVehical.Driver_Id,
                Driver_Pickup_Long = x.MatchedDriverVehical.Driver_Pickup_Long,
                Driver_Pickup_Latt = x.MatchedDriverVehical.Driver_Pickup_Latt
            }).FirstOrDefault();
            return obj;
        }
        ///Get next driver after 30 sec

        // to tracking driver in map 
        public async Task DriverOnlineTracking(int Driver_Id)
        {
            //push to specific driver 
            var LstConnIDs = Users.Where(x => x.Key == Driver_Id.ToString() && x.Value.UserType==(int)DestinationUserType.Driver)
                                      .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    await Clients.Client(ConnID).SendAsync("NotifiedCurrentLongAndLattForDriver");
                    //await Clients.User(Driver_Id.ToString()).SendAsync("NotifiedGetCurrentLongAndLattForDriver");
                }
            }
        }
        public async Task GetCurrentLongAndLattForSpecificDriver(int Client_Id, int Driver_Id, double Driver_Pickup_Long, double Driver_Pickup_Latt)
        {

            if (Driver_Id != 0)
            {
                //push Notification to client
             
                var LstConnIDs = Users.Where(x => x.Key == Client_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Client)
                                      .Select(x => x.Value).FirstOrDefault();
                if (LstConnIDs != null)
                {
                    foreach (var ConnID in LstConnIDs.ConnectionIds)
                    {
                        // await Clients.User(Client_Id.ToString()).SendAsync("NotifiedCurrenDriverLocationForClient",Driver_Id, Driver_Pickup_Long, Driver_Pickup_Latt);
                        await Clients.Client(ConnID).SendAsync("NotifiedCurrenDriverLocationForClient", Driver_Id, Driver_Pickup_Long, Driver_Pickup_Latt);
                    }
                }
            }
        }
        // to clear  static list for specfic client when trip is Ended
        public void EndedTripForClient(int Client_Id)
        {

            //to remove all data for specific client 
            if (AllMatchedDriverVehicalDto.Count() > 0)
            {
                AllMatchedDriverVehicalDto.RemoveAll(x => x.Client_Id == Client_Id);
            }
        }


        // to Tell Driver that  client cancel trip 
        public async Task NotifiClientCancleTrip(int Driver_Id, TimeSpan StartTime, TimeSpan CancelTime)
        {

            // to  CalculateDoorOpenCost for Trip
            decimal DoorOpenCost = _APIConsume.CalculateDoorOpenCost(StartTime, CancelTime);
            //push to specific driver 
            var LstConnIDs = Users.Where(x => x.Key == Driver_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                  .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    //  await Clients.All.SendAsync("NotifiedDriverClientCancleTrip");
                    await Clients.Client(ConnID).SendAsync("NotifiedDriverClientCancleTrip",DoorOpenCost);
                }
            }

        }
        // to Tell Driver that  client arrived
        public async Task NotifiDriverArrived(int Client_Id)
        {
            //push to specific driver 
          
            var LstConnIDs = Users.Where(x => x.Key == Client_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Client)
                                    .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    //  await Clients.All.SendAsync("NotifiedClientDriverArrived");
                    await Clients.Client(ConnID).SendAsync("NotifiedClientDriverArrived");
                }
            }
            //await Clients.User(Client_Id.ToString()).SendAsync("NotifiedGetCurrentLongAndLattForDriver");
        }

        // to Tell Client that  Driver cancel trip 
        public async Task NotifiDriverCancleTrip(int Client_Id, TimeSpan StartTime, TimeSpan CancelTime)
        {

            // to  CalculateDoorOpenCost for Trip
            decimal DoorOpenCost = _APIConsume.CalculateDoorOpenCost(StartTime, CancelTime);
            //push to specific driver 
            var LstConnIDs = Users.Where(x => x.Key == Client_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Client)
                                  .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    await Clients.Client(ConnID).SendAsync("NotifiedClientDriverCancleTrip", DoorOpenCost);
                }
            }

        }
        public async Task OnConnectedAsync(string UserID,int UserType)
        {
            //string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
           // Clients.All.SendAsync("userConnected", UserID, connectionId);
            var user = Users.GetOrAdd(UserID, _=> new UserHubModels
            {
                UserID = UserID,
                UserType= UserType,
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

        public async Task OnDisconnectedAsync(string UserID,int UserType)
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

        //To get TripId after insert in database from client
        // to Tell Driver that  client cancel trip 
        public async Task NotifiClientSaveTrip(int Driver_Id,int Trip_Id, string Trip_Pickup, string Trip_Destination)
        {
            //push Trip_Id  to specific driver 
            var LstConnIDs = Users.Where(x => x.Key == Driver_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Driver)
                                  .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    await Clients.Client(ConnID).SendAsync("NotifiedDriverTripId", Trip_Id, Trip_Pickup, Trip_Destination);
                }
            }
        }

        ///Trip_Chat between Client and Driver
        public async Task SendMessage(int Trip_Id, int User_Id_From, int UserId_To, string Message, string UserName, int UserTypeFrom, int UserTypeTo, string MessageTime)
        {
            // Save Notification in database 
            //create TripChat
            DateTime Chatedate = DateTime.Now.Date;
            Trip_Chat _Trip_Chat = new Trip_Chat()
            {
                Trip_Id = Trip_Id,
                Client_Id = UserTypeFrom == (int)ChatUserType.Client ? User_Id_From : (int?)null,
                Driver_Id = UserTypeFrom == (int)ChatUserType.Driver ? User_Id_From : (int?)null,
                Message = Message,
                TimeStamp = Chatedate + TimeSpan.Parse(MessageTime),//DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm")),
                UserType = UserTypeFrom,
            };

            _APIConsume.CreateTripChat(_Trip_Chat);

            //  await Clients.All.SendAsync("ReceiveMessage", Trip_Id, User_Id_From, UserId_To, Message, UserName, UserType);

            //if (UserType == (int)ChatUserType.Client)
            //{
            int UserTypeId = UserTypeTo == (int)ChatUserType.Client ? (int)DestinationUserType.Client : (int)DestinationUserType.Driver;

            var LstConnIDs = Users.Where(x => x.Key == UserId_To.ToString() && x.Value.UserType == UserTypeId)
                                        .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    await Clients.Client(ConnID).SendAsync("ReceiveMessage", Trip_Id, User_Id_From, UserId_To, Message, UserName, UserTypeFrom, UserTypeTo, MessageTime);

                }
            }
            //  }

        }

        //to make Share Location for web 
        public async Task GetClientId(int Client_Id,double Driver_Pickup_Latt,double Driver_Pickup_Long)
        {
            //push location  to specific Client  
            //var LstConnIDs = Users.Where(x => x.Key == Client_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Client)
            //                      .Select(x => x.Value).FirstOrDefault();
            //if (LstConnIDs != null)
            //{
            //    foreach (var ConnID in LstConnIDs.ConnectionIds)
            //    {
                    await Clients.All.SendAsync("NotifiedGetClientId", Client_Id,Driver_Pickup_Latt, Driver_Pickup_Long);
            // }
            //}
            //push location url  to specific Client  
            var LstConnIDs = Users.Where(x => x.Key == Client_Id.ToString() && x.Value.UserType == (int)DestinationUserType.Client)
                                  .Select(x => x.Value).FirstOrDefault();
            if (LstConnIDs != null)
            {
                foreach (var ConnID in LstConnIDs.ConnectionIds)
                {
                    string LocationUrl = "http://doaaberam2020-001-site1.htempurl.com/MapLocation?ClientId=" + Client_Id;
                    await Clients.All.SendAsync("NotifiedClientLocationUrl", LocationUrl);
                }
            }
        }
    }
}
