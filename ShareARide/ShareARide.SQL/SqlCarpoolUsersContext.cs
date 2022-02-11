using ShareARide.Models;
using System.Data.SqlClient;

namespace ShareARide.SQL;
public class SqlCarpoolUsersContext : ICarpoolUsersContext
{
    /// <summary>
    /// Method to get all CarpoolUsers
    /// </summary>
    /// <returns>Returns a List with all CarpoolUsers</returns>
    public async Task<List<CarpoolUsers>> GetAllAsync(){
        List<CarpoolUsers> carpoolUserslist = new List<CarpoolUsers>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command = new SqlCommand($"SELECT * FROM CarpoolUsers", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    CarpoolUsers carpoolUser = new CarpoolUsers();
                    SqlCarpoolUsersreader(carpoolUser, reader);
                    carpoolUserslist.Add(carpoolUser);
                }
            }
        }
        return carpoolUserslist;
    }
    /// <summary>
    /// Method to get all Users (passengers) of a Carpool
    /// </summary>
    /// <param name="carpoolID">ID of the Carpool</param>
    /// <returns>Returns a List with matching CarpoolUsers</returns>

    public async Task<List<CarpoolUsers>> GetSingleCarpoolUsersAsync(int carpoolID)
    {
        List<CarpoolUsers> carpoolUserslist = new List<CarpoolUsers>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command = new SqlCommand($"SELECT * FROM CarpoolUsers WHERE CarpoolID = {carpoolID}", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    CarpoolUsers carpoolUser = new CarpoolUsers();
                    SqlCarpoolUsersreader(carpoolUser, reader);
                    carpoolUserslist.Add(carpoolUser);
                }
            }
        }
        return carpoolUserslist;
    }

    /// <summary>
    /// Method to get all Carpools, the User takes part in
    /// </summary>
    /// <param name="userID">ID of the User</param>
    /// <returns>Returns a List with matching CarpoolUsers</returns>
    public async Task<List<CarpoolUsers>> GetSingleUserinCarpoolsAsync(int userID)
    {
        List<CarpoolUsers> carpoolUserslist = new List<CarpoolUsers>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command = new SqlCommand($"SELECT * FROM CarpoolUsers WHERE UserID = {userID}", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    CarpoolUsers carpoolUser = new CarpoolUsers();
                    SqlCarpoolUsersreader(carpoolUser, reader);
                    carpoolUserslist.Add(carpoolUser);
                }
            }
        }
        return carpoolUserslist;
    }

    /// <summary>
    /// Method to add a CarpoolUser
    /// </summary>
    /// <param name="carpooluser"></param>
    /// <returns>Returns the added Carpooluser</returns>
    public async Task<CarpoolUsers> AddCarpoolUserAsync(CarpoolUsers carpoolUser)
    {
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command = new SqlCommand($"INSERT INTO CarpoolUsers (UserID, CarpoolID) VALUES ({carpoolUser.UserID}, {carpoolUser.CarpoolID})", con))
            await command.ExecuteNonQueryAsync();
        }
        return carpoolUser;
    }


    /// <summary>
    /// Method to delete all Users of a Carpool
    /// </summary>
    /// <param name="carpoolID">ID of Carpool</param>
    /// <returns>Returns a List with the deleted CarpoolUsers</returns>

    public async Task<List<CarpoolUsers>> DeleteSingleCarpoolUsersAsync(int carpoolID)
    {
        List<CarpoolUsers> deletedCarpoolUserlist = new List<CarpoolUsers>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command1 = new SqlCommand($"SELECT * FROM CarpoolUserss WHERE CarpoolID = {carpoolID}", con))
            using (SqlDataReader reader = await command1.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    CarpoolUsers deletedCarpoolUser = new CarpoolUsers();
                    SqlCarpoolUsersreader(deletedCarpoolUser, reader);
                    deletedCarpoolUserlist.Add(deletedCarpoolUser);
                }
            }
            using (SqlCommand command2 = new SqlCommand($"DELETE FROM CarpoolUsers WHERE CarpoolID = {carpoolID}", con))
            await command2.ExecuteNonQueryAsync();
        }
        return deletedCarpoolUserlist;
    }

    /// <summary>
    /// Mehtod to delete a User out of all Carpools
    /// </summary>
    /// <param name="userID">ID of the User</param>
    /// <returns>A List with all deleted Carpoolusers</returns>
    public async Task<List<CarpoolUsers>> DeleteSingleUserinCarpoolsAsync(int userID)
    {
        List<CarpoolUsers> deletedCarpoolUserlist = new List<CarpoolUsers>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command1 = new SqlCommand($"SELECT * FROM CarpoolUserss WHERE UserID = {userID}", con))
            using (SqlDataReader reader = await command1.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    CarpoolUsers deletedCarpoolUser = new CarpoolUsers();
                    SqlCarpoolUsersreader(deletedCarpoolUser, reader);
                    deletedCarpoolUserlist.Add(deletedCarpoolUser);
                }
            }
            using (SqlCommand command2 = new SqlCommand($"DELETE FROM CarpoolUsers WHERE UserID = {userID}", con))
            await command2.ExecuteNonQueryAsync();
        }
        return deletedCarpoolUserlist;
    }

    /// <summary>
    /// Method to delete a specific CarpoolUser
    /// </summary>
    /// <param name="userID">ID of the User</param>
    /// <param name="carpoolID">ID of the Carpool</param>
    /// <returns>Returns the deleted CarpoolUser</returns>

    public async Task<CarpoolUsers> DeleteSingleUserinSingleCarpoolAsync(int userID, int carpoolID)
    {
        CarpoolUsers deletedCarpoolUser = new CarpoolUsers();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command1 = new SqlCommand($"SELECT * FROM CarpoolUserss WHERE CarpoolID = {carpoolID} AND UserID = {userID}", con))
            using (SqlDataReader reader = await command1.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlCarpoolUsersreader(deletedCarpoolUser, reader);
                }
            }
            using (SqlCommand command2 = new SqlCommand($"DELETE FROM CarpoolUsers WHERE CarpoolID = {carpoolID} AND UserID = {userID}", con))
            await command2.ExecuteNonQueryAsync();
        }
        return deletedCarpoolUser;
    }



    /// <summary>
    /// Reads all Data of CarpoolsUser out of SqlDataBase
    /// </summary>
    /// <param name="user"></param>
    /// <param name="reader"></param>
    private void SqlCarpoolUsersreader(CarpoolUsers carpooluser, SqlDataReader reader)
    {
        carpooluser.UserID = reader.GetInt32(0);
        carpooluser.CarpoolID = reader.GetInt32(1);
    }
}