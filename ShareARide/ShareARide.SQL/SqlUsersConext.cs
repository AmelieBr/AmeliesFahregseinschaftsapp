using ShareARide.Models;
using System.Data.SqlClient;

namespace ShareARide.SQL;
public class SqlUsersContext : IUsersContext
{
    /// <summary>
    /// Method to get all Users out of the Database
    /// </summary>
    /// <returns>A List with all Users available</returns>
    public async Task<List<Users>> GetAllAsync()
    {
        List<Users> userListe = new List<Users>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();

            using (SqlCommand commandUserlist = new SqlCommand($"SELECT * FROM Users", con))
            using (SqlDataReader readerUserlist = await commandUserlist.ExecuteReaderAsync())
            {
                while (readerUserlist.Read())
                {
                    Users user = new Users();
                    SqlUsersReader(user, readerUserlist);
                    userListe.Add(user);
                }
            }
            return userListe;
        }
    }
    /// <summary>
    /// Method to get one User out of the Database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retruns the searched User</returns>
    public async Task<Users> GetSingleAsync(int id){
        Users user = new Users();
        using (SqlConnection con =new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE UserID = {id}", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while(reader.Read())
                {
                    SqlUsersReader(user, reader);
                }
            }
        }
        return user;
    }
    /// <summary>
    /// Method to add a User to the Database
    /// </summary>
    /// <param name="user">The Userobject, which shall be added</param>
    /// <returns>Returns the added User</returns>
    public async Task<Users> AddUserAsync(Users user)
    {
        Users userErstellen = new Users();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            using (SqlCommand command1 = new SqlCommand($"INSERT INTO Users (FirstName, LastName, EMail, Phone) VALUES ('{user.FirstName}', '{user.LastName}',  '{user.UserEmail}', '{user.Phone}')", con))
                await command1.ExecuteNonQueryAsync();
            using (SqlCommand command2 = new SqlCommand($"SELECT TOP 1 * FROM Users ORDER BY UserID DESC", con))
            using (SqlDataReader reader = await command2.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlUsersReader(userErstellen, reader);
                }
            }
        }
        return userErstellen;
    }
    /// <summary>
    /// Method to edit an existing User via id
    /// </summary>
    /// <param name="id">ID of the User to edit</param>
    /// <param name="user">Userobject with edited data</param>
    /// <returns>Returns the edited Userobject</returns>
    public async Task<Users> EditUserAsync(int id, Users user)
    {
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            using (SqlCommand command1 = new SqlCommand($"UPDATE Users SET FirstName = '{user.FirstName}', LastName = '{user.LastName}', EMail = '{user.UserEmail}', Phone = '{user.Phone}' WHERE UserID = {id}", con))
            await command1.ExecuteNonQueryAsync();
            using (SqlCommand command2 = new SqlCommand($"SELECT TOP 1 * FROM Users ORDER BY UserID DESC", con))
            using (SqlDataReader reader = await command2.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlUsersReader(user, reader);
                }
            }
        }
        return user;
    }
    public async Task<Users> DeleteaUserAsync(int id)
    {
        Users gelöschterUser = new Users();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command1 = new SqlCommand($"SELECT * FROM Users WHERE UserID = {id}", con))
            using (SqlDataReader reader = await command1.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlUsersReader(gelöschterUser, reader);
                }
            }
            using (SqlCommand command2 = new SqlCommand($"DELETE FROM Users WHERE UserID = {id}", con))
            await command2.ExecuteNonQueryAsync();
        }
        return gelöschterUser;
    }



    /// <summary>
    /// Reads all Data of User out of SqlDataBase
    /// </summary>
    /// <param name="user"></param>
    /// <param name="reader"></param>
    private void SqlUsersReader(Users user, SqlDataReader reader)
    {
        user.UserID = reader.GetInt32(0);
        user.FirstName = reader.GetString(1);
        user.LastName = reader.GetString(2);
        user.UserEmail = reader.GetString(3);
        user.Phone = reader.GetString(4);
    }

}