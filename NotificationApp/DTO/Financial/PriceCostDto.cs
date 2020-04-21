using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO.Financial
{
    public class PriceCostDto
    {
        public int Trip_ID { get; set; }

        public decimal NormalKM { get; set; }
        public decimal RusKM { get; set; }
        public decimal TotalWaitingMinutes { get; set; }
        public string TotalMinutes { get; set; }

        public bool IsAdditionalFees { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public TimeSpan DropOffTime { get; set; }
        public int WeekDay { get; set; }
    }
}
