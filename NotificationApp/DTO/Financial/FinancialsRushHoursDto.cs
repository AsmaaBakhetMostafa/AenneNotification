using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Financial
{
    public class FinancialsRushHoursDto
    {

        public int Financials_RushHours_Id { get; set; }

        public TimeSpan RashHour_1_From { get; set; }

        public TimeSpan RashHour_1_To { get; set; }

        public TimeSpan RashHour_2_From { get; set; }

        public TimeSpan RashHour_2_To { get; set; }

        public Nullable<int> Week_Day { get; set; }
        public string WeekDayName { get; set; }



        public Nullable<decimal> Price_Per_KilloMeter_RashHour { get; set; }



        public FinancialDto Financial { get; set; }


    }
}
