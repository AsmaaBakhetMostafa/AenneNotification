using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Models
{
    public  class Driver_Vehicle
    {
        public int Driver_Vehicle_Id { get; set; }
        public int Driver_Id { get; set; }
        public int Vehicle_Id { get; set; }
        public Nullable<System.DateTime> From_Date { get; set; }
        public Nullable<System.DateTime> To_Date { get; set; }
        public Nullable<bool> Is_Current { get; set; }

   
    }
}
