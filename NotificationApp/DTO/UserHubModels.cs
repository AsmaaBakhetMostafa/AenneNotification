using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.DTO
{
    public class UserHubModels
    {
       public string UserID { get; set; }
        public int UserType{ get; set; } // UserType: Client =4 & Driver =3

        public HashSet<string> ConnectionIds { get; set; }
    }
}
