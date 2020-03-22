using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Driver
{
    public class AllDriverPickUpLocationsDto
    {
        public int Client_Id { get; set; }
        public MatchedDriverVehicalDto MatchedDriverVehical { get; set; }
    }
}
