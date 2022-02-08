namespace ShareARide.Models
{
    /// <summary>
    /// Carpool class: contains CarpoolID, DriverUserID, RouteStart, RouteEnd, StartTime, EndTime, Seats, Stopps
    /// Is the Carpool, which will be seen, when a passenger wants to join it.
    /// </summary>
    public class CarpoolUsers
    {

        /// <summary>
        /// Id of the User in the CarpoolUser
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Id of the Carpool in CarpoolUser
        /// </summary>
        public int CarpoolID { get; set; }
    }
}
