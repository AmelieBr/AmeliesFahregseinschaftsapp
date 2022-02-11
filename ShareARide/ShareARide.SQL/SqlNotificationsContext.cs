using ShareARide.Models;
using System.Data.SqlClient;

namespace ShareARide.SQL;
public class SqlNotificationsContext : INotificationsContext
{
    private readonly ICarpoolsContext _contextCarpool;
    private readonly IUsersContext _contextUser;

    private readonly ICarpoolUsersContext _contexCarpoolUser;
    public SqlNotificationsContext(ICarpoolsContext contextCarpool, IUsersContext contextUser, ICarpoolUsersContext contexCarpoolUser)
    {
        _contextCarpool = contextCarpool;
        _contextUser = contextUser;
        _contexCarpoolUser = contexCarpoolUser;
    }

    /// <summary>
    /// Method to send a mail about a deleted carpool
    /// </summary>
    public async Task MailDeleteCarpoolAsync(int id)
    {
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        UsersJoinCarpool usersJoinCarpool = await _contextCarpool.GetCarpoolandUser(id);
        Carpools carpool = usersJoinCarpool.carpool;
        List<Users> userlist = usersJoinCarpool.userlist;
        userlist.Add(await _contextUser.GetSingleAsync(carpool.DriverUserID));
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 1", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }
            mailBody = mailBody.Replace("#CarpoolID", $"{carpool.CarpoolID}");
            mailBody = mailBody.Replace("#RouteStart", $"{carpool.RouteStart}");
            mailBody = mailBody.Replace("#RouteEnd", $"{carpool.RouteEnd}");
            mailBody = mailBody.Replace("#StartTime", $"{carpool.StartTime}");
            for (int i = 0; i < userlist.Count; i++)
            {
                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{userlist[i].FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{userlist[i].LastName}");
                notification.Email = userlist[i].UserEmail;
                notificationList.Add(notification);

            }
        }
    }

    /// <summary>
    /// Method to send a mail about a newly created carpool
    /// </summary>
    public async Task MailCreateCarpoolAsync(Carpools carpool)
    {
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        UsersJoinCarpool usersJoinCarpool = await _contextCarpool.GetCarpoolandUser(carpool.CarpoolID);
        carpool = usersJoinCarpool.carpool;
        List<Users> userlist = usersJoinCarpool.userlist;
        userlist.Add(await _contextUser.GetSingleAsync(carpool.DriverUserID));
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 2", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }
            mailBody = mailBody.Replace("#CarpoolID", $"{carpool.CarpoolID}");
            mailBody = mailBody.Replace("#RouteStart", $"{carpool.RouteStart}");
            mailBody = mailBody.Replace("#RouteEnd", $"{carpool.RouteEnd}");
            mailBody = mailBody.Replace("#StartTime", $"{carpool.StartTime}");
            mailBody = mailBody.Replace("#EndTime", $"{carpool.EndTime}");
            mailBody = mailBody.Replace("#Seats", $"{carpool.Seats}");
            for (int i = 0; i < userlist.Count; i++)
            {
                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{userlist[i].FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{userlist[i].LastName}");
                notification.Email = userlist[i].UserEmail;
                notificationList.Add(notification);

            }
        }
    }

    /// <summary>
    /// Method to send a mail about an updated carpool
    /// </summary>
    public async Task MailUpdateCarpoolAsync(Carpools carpool)
    {
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        UsersJoinCarpool usersJoinCarpool = await _contextCarpool.GetCarpoolandUser(carpool.CarpoolID);
        carpool = usersJoinCarpool.carpool;
        List<Users> userlist = usersJoinCarpool.userlist;
        userlist.Add(await _contextUser.GetSingleAsync(carpool.DriverUserID));
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 3", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }
            mailBody = mailBody.Replace("#CarpoolID", $"{carpool.CarpoolID}");
            mailBody = mailBody.Replace("#RouteStart", $"{carpool.RouteStart}");
            mailBody = mailBody.Replace("#RouteEnd", $"{carpool.RouteEnd}");
            mailBody = mailBody.Replace("#StartTime", $"{carpool.StartTime}");
            mailBody = mailBody.Replace("#EndTime", $"{carpool.EndTime}");
            mailBody = mailBody.Replace("#Seats", $"{carpool.Seats}");
            for (int i = 0; i < userlist.Count; i++)
            {
                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{userlist[i].FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{userlist[i].LastName}");
                notification.Email = userlist[i].UserEmail;
                notificationList.Add(notification);
            }
        }
    }

        

        /// <summary>
        /// Method to send a mail about an user that joined the carpool
        /// </summary>
        public async Task MailUserJoinCarpoolAsync(Carpools carpool, CarpoolUsers carpoolUser)
        {
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        UsersJoinCarpool usersJoinCarpool = await _contextCarpool.GetCarpoolandUser(carpool.CarpoolID);
        carpool = usersJoinCarpool.carpool;
        List<Users> userlist = usersJoinCarpool.userlist;
        userlist.Add(await _contextUser.GetSingleAsync(carpool.DriverUserID));
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 4", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }
            mailBody = mailBody.Replace("#CarpoolID", $"{carpool.CarpoolID}");
            mailBody = mailBody.Replace("#RouteStart", $"{carpool.RouteStart}");
            mailBody = mailBody.Replace("#RouteEnd", $"{carpool.RouteEnd}");
            mailBody = mailBody.Replace("#StartTime", $"{carpool.StartTime}");
            
            for (int i = 0; i < userlist.Count; i++)
            {
                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{userlist[i].FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{userlist[i].LastName}");
                notification.Email = userlist[i].UserEmail;
                notificationList.Add(notification);
            }
            await _contexCarpoolUser.GetSingleCarpoolUsersAsync(carpool.CarpoolID);
        }
        }

        /// <summary>
        /// Method to send a mail about an user that left the carpool
        /// </summary>

        public async Task MailUserLeftCarpoolAsync(Carpools carpool, CarpoolUsers carpoolUser)
        {
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        UsersJoinCarpool usersJoinCarpool = await _contextCarpool.GetCarpoolandUser(carpool.CarpoolID);
        carpool = usersJoinCarpool.carpool;
        List<Users> userlist = usersJoinCarpool.userlist;
        userlist.Add(await _contextUser.GetSingleAsync(carpool.DriverUserID));
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 5", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }
            mailBody = mailBody.Replace("#CarpoolID", $"{carpool.CarpoolID}");
            mailBody = mailBody.Replace("#RouteStart", $"{carpool.RouteStart}");
            mailBody = mailBody.Replace("#RouteEnd", $"{carpool.RouteEnd}");
            mailBody = mailBody.Replace("#StartTime", $"{carpool.StartTime}");
            
            for (int i = 0; i < userlist.Count; i++)
            {
                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{userlist[i].FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{userlist[i].LastName}");
                notification.Email = userlist[i].UserEmail;
                notificationList.Add(notification);
            }
            await _contexCarpoolUser.GetSingleCarpoolUsersAsync(carpool.CarpoolID);
        }
        }

        /// <summary>
        /// Method to send a mail about a deleted acount
        /// </summary>
        public async Task MailDeleteAcountAsync(Users user)
        {
        
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 6", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }

                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{user.FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{user.LastName}");
                notification.Email = user.UserEmail;
                notificationList.Add(notification);
        }
        }

        /// <summary>
        /// Method to send a mail about a newly created acount
        /// </summary>

        public async Task MailCreateAcountAsync(Users user)
        {
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 7", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }

                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{user.FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{user.LastName}");
                notification.Body = notification.Body.Replace("#UserId", $"{user.UserID}");
                notification.Body = notification.Body.Replace("#Phone", $"{user.Phone}");
                notification.Email = user.UserEmail;
                notificationList.Add(notification);
        }
        }

        /// <summary>
        /// Method to send a mail about an updated acount
        /// </summary>
        public async Task MailUpdateAcountAsync(Users user)
        {
        Notifications notification = new Notifications();
        string mailBody = "";
        List<Notifications> notificationList = new List<Notifications>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Notification WHERE NotificationID = 8", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlNotificationsReader(notification, reader);
                    mailBody = reader.GetString(2);
                }
            }

                notification.Body = mailBody;
                notification.Body = notification.Body.Replace("#Firstname", $"{user.FirstName}");
                notification.Body = notification.Body.Replace("#Lastname", $"{user.LastName}");
                notification.Body = notification.Body.Replace("#UserId", $"{user.UserID}");
                notification.Body = notification.Body.Replace("#Phone", $"{user.Phone}");
                notification.Email = user.UserEmail;
                notificationList.Add(notification);
        }
        }
        private void SqlNotificationsReader(Notifications notification, SqlDataReader reader)
        {
            notification.NotificationID = reader.GetInt32(0);
            notification.Subject = reader.GetString(1);

        }
    
}
