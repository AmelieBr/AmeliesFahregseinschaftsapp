namespace ShareARide.Models
{
    /// <summary>
    /// User class contains ID, Name, Email
    /// is the identification of the App users 
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// FirstName of the user
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// LastName of the user
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Email of the user
        /// </summary>
        public string? UserEmail { get; set; }
        /// <summary>
        /// Phone of the User
        /// </summary>
        public string? Phone { get; set; }

        
    }
}