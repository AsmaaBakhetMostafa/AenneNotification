using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Models
{
    public class Trip_Chat
    {
        public int Chat_Id { get; set; }
        public int Trip_Id { get; set; }
        public Nullable<int> Client_Id { get; set; }
        public Nullable<int> Driver_Id { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public Nullable<int> UserType { get; set; }

    }
}
