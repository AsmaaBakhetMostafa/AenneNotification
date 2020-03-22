using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Trips
{
    public class TripsDto
    {


        public int Trip_Id { get; set; }
        public Nullable<System.Guid> Trip_Key { get; set; }
        public int Client_Id { get; set; }
        public int Driver_Id { get; set; }
        public int Vehicle_Id { get; set; }
        public System.DateTime Trip_Date { get; set; }
        public System.DateTime Trip_Time { get; set; }
        public Nullable<int> Trip_Type_Id { get; set; }
        public Nullable<int> Handicapped_Number { get; set; }
        public Nullable<int> Healthy_Number { get; set; }
        public string Trip_Pickup { get; set; }
        public Nullable<decimal> Trip_Pickup_Long { get; set; }
        public Nullable<decimal> Trip_Pickup_Latt { get; set; }
        public string Trip_Destination { get; set; }
        public Nullable<decimal> Trip_Destination_Long { get; set; }
        public Nullable<decimal> Trip_Destination_Latt { get; set; }
        public Nullable<decimal> Trip_Distance { get; set; }
        public Nullable<decimal> Trip_Cost { get; set; }
        public Nullable<int> Payment_Type { get; set; }
        public string Visa_Number { get; set; }
        public Nullable<int> Trip_Status { get; set; }
        public string Trip_Notes { get; set; }
        public Nullable<int> Goverments_Id { get; set; }
        public Nullable<System.DateTime> Trip_Schedule_Date { get; set; }
        public Nullable<System.DateTime> Trip_Schedule_Time { get; set; }
        public Nullable<System.DateTime> Trip_Destination_Date { get; set; }
        public Nullable<System.DateTime> Trip_Destination_Time { get; set; }
        public System.DateTime Trip_Duration { get; set; }
        //public Trips_RatesDto Trips_Rates { get; set; }
        //public DriverDto Driver { get; set; }
        //public ClientDto Client { get; set; }
        //public VehicleDto Vehicle { get; set; }
        public string Goverment_Name { get; set; }

        public bool IsAssignToDriver { get; set; } = false;

        public Nullable<int> Trip_Schedule_Id { get; set; }

        IList<ScheduledTripDto> ScheduledTrip { get; set; }



    }

    public class ScheduledTripDto
    {


        public int Trip_Id { get; set; }
        public int Client_Id { get; set; }

        public System.DateTime Trip_Date { get; set; }
        public System.DateTime Trip_Time { get; set; }
        public Nullable<int> Trip_Type_Id { get; set; }
        public Nullable<int> Handicapped_Number { get; set; }
        public Nullable<int> Healthy_Number { get; set; }
        public string Trip_Pickup { get; set; }
        public Nullable<decimal> Trip_Pickup_Long { get; set; }
        public Nullable<decimal> Trip_Pickup_Latt { get; set; }
        public string Trip_Destination { get; set; }
        public Nullable<decimal> Trip_Destination_Long { get; set; }
        public Nullable<decimal> Trip_Destination_Latt { get; set; }
        public Nullable<decimal> Trip_Distance { get; set; }
        public Nullable<decimal> Trip_Cost { get; set; }
        public Nullable<int> Payment_Type { get; set; }
        public string Visa_Number { get; set; }
        public Nullable<int> Trip_Status { get; set; }
        public Nullable<int> Trip_Schedule_Id { get; set; }



        //public System.DateTime Trip_Duration { get; set; }
        //public Nullable<System.DateTime> Trip_Schedule_Date { get; set; }
        //public Nullable<System.DateTime> Trip_Schedule_Time { get; set; }
        //public Nullable<System.DateTime> Trip_Destination_Date { get; set; }
        //public Nullable<System.DateTime> Trip_Destination_Time { get; set; }
    }
}
