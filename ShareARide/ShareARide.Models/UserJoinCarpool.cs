namespace ShareARide.Models
{
    /// <summary>
    /// Class which combines Carpool and User
    /// </summary>
    public class UsersJoinCarpool
    {
        public Carpools? carpool{ get; set; }
        public List<Users>? userlist{ get; set; }
        
    }
}
