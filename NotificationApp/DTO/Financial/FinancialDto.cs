using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Financial
{
    public class FinancialDto
    {


        public int Financial_Id { get; set; }

        public Nullable<decimal> Door_Open_Price { get; set; }

        public Nullable<decimal> Price_Per_KilloMeter_NormalHour { get; set; }

        public Nullable<int> WatingTime_FreeMinutes_Number { get; set; }

        public Nullable<decimal> WaitingTime_ExtraMinute_Price { get; set; }

        public Nullable<decimal> Airports_aAdditional_Fees { get; set; }

        public Nullable<int> Unemployed_Drivers_Payable_Percentage { get; set; }

        public List<FinancialsRushHoursDto> FinancialsRushHours { get; set; } = new List<FinancialsRushHoursDto>();



    }
}
