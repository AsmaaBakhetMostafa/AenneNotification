using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO
{
    public class UserHubModels
    {
       public string UserID { get; set; }
        public int UserType{ get; set; }

        public HashSet<string> ConnectionIds { get; set; }
    }
}
