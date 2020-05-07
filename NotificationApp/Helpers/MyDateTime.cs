using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Helpers
{
    public class MyDateTime
    {
        public static DateTime Now
        {
            get
            {
                return DateTime.Now.AddHours(7);
            }
        }
    }
}
