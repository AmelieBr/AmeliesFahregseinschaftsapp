namespace ShareARide.Models
{
    /// <summary>
    /// Notifications class contains ID, Subject, Body
    /// </summary>
    public class Notifications
    {
        /// <summary>
        /// Id of the notification
        /// </summary>
        public int NotificationID{ get; set; }

        /// <summary>
        /// Subject of the notification
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Body of the notification
        /// </summary>
        public string? Body { get; set; }

        public string? Email { get; set; }
    }
}