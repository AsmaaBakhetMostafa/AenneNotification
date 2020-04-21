using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Enums
{
    public enum TripStatus
    {
        FindingDriver = 1,
        Accepted = 2,
        Started = 3,
        Ended = 4,
        Canceled = 5
    }

    public enum UserType
    {
        Admin = 1,
        SuperAdmin = 2,
        Driver = 3,
        Client = 4
    }
    public enum DestinationUserType
    {
        Admin = 1,
        SuperAdmin = 2,
        Driver = 3,
        Client = 4
    }
    public enum TripType
    {
        NormalTrip = 1,
        ScheduledTrip = 2,
    }
    public enum ChatUserType
    {
        Client = 1,
        Driver = 2
    }
  

    public enum LoginStatus
    {
        LoggedIn = 1,
        LoggedOut = 2
    }
    public enum DurationType
    {
        AllTime = 1,
        Monthly = 2,
        Weekly = 3,
        Daily = 4
    }
    public enum TripStatusFromDriver
    {
        Accepted = 1,
        Rejected = 2,
    }
    public enum NotificationType
    {
        Complaint = 1,
        Emergency = 2,
        ScheduledTrip = 3,
        RequestCar = 4,
        AssignDriverToTrip = 5,
        AssignDriverToVehical = 6
    }
}
