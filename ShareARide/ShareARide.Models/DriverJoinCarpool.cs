namespace ShareARide.Models
{
    /// <summary>
    /// Class which combines Carpool and User
    /// </summary>
    public class DriverJoinCarpool
    {
        public Carpools? carpool { get; set; }
        public Users? user{ get; set;}
}
}