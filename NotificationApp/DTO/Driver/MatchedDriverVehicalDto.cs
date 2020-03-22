using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Driver
{
    public class MatchedDriverVehicalDto
    {
        public int Driver_Id { get; set; }
        public double Driver_Pickup_Long { get; set; }
        public double Driver_Pickup_Latt { get; set; }
    }
}
