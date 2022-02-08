namespace ShareARide.Models
{
    /// <summary>
    /// Carpool class: contains CarpoolID, DriverUserID, RouteStart, RouteEnd, StartTime, EndTime, Seats, Stopps
    /// Is the Carpool, which will be seen, when a passenger wants to join it.
    /// </summary>
    public class Carpools
    {
        /// <summary>
        /// Id of the Carpool
        /// </summary>
        public int CarpoolID { get; set; }
        /// <summary>
        /// Id of the driver of the Carpool
        /// </summary>
        public int DriverUserID { get; set; }
        /// <summary>
        /// Start of the Route
        /// </summary>
        public string? RouteStart { get; set; }
        /// <summary>
        /// End of the Route
        /// </summary>
        public string? RouteEnd { get; set; }
        /// <summary>
        /// StartTime of the Carpool
        /// </summary>
        public string? StartTime { get; set; }
        /// <summary>
        /// DestinationTime of the Carpool
        /// </summary>
        public string? EndTime { get; set; }
        /// <summary>
        /// Amount of Seats
        /// </summary>
        public int Seats { get; set; }
        
    }
}