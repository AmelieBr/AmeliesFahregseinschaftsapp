using ShareARide.Models;
using System.Data.SqlClient;

namespace ShareARide.SQL;
public class SqlCarpoolsContext : ICarpoolsContext
{
      /// <summary>
    /// Method to get all carpools put of the Database
    /// </summary>
    /// <returns>Retruns a Carpoollsit with all Carpools available in the Database</returns>
    public async Task<List<Carpools>> GetAllAsync()
    {
        List<Carpools> carpoolliste = new List<Carpools>();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand commandcarpoollist = new SqlCommand($"SELECT * FROM Carpools", con))
            using (SqlDataReader readercarpoollist = await commandcarpoollist.ExecuteReaderAsync())
            {
                while (readercarpoollist.Read())
                {
                    Carpools carpool = new Carpools();
                    SqlCarpoolsReader(carpool, readercarpoollist);
                    carpoolliste.Add(carpool);
                }
            }
            
            return carpoolliste;
        }
    }

    /// <summary>
    /// Method to get a single Carpool out of the Database
    /// </summary>
    /// <param name="id">ID of Carpool to get</param>
    /// <returns>Retruns the searched Carpool</returns>
    public async Task<Carpools> GetSingleAsync(int id) 
    {
        Carpools carpool = new Carpools();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command = new SqlCommand($"SELECT* FROM Carpools WHERE CarpoolID = {id}", con))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
            while (reader.Read())
                {
                    SqlCarpoolsReader(carpool, reader);
                }
            }
        }
        return carpool;
    }

    /// <summary>
    /// Method to add a carpool to the Database
    /// </summary>
    /// <param name="carpool">Carpoolobject, which will be added</param>
    /// <returns></returns>
    public async Task<Carpools> AddCarpoolAsync(Carpools carpool)
    {

        Carpools carpoolerstellt = new Carpools();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command1 = new SqlCommand($"INSERT INTO Carpools (DriverUserID, RouteStart, StartTime, RouteEnd, EndTime, Seats) VALUES ({carpool.DriverUserID}, '{carpool.RouteStart}',  '{carpool.StartTime}', '{carpool.RouteEnd}', '{carpool.EndTime}', {carpool.Seats})", con))
            await command1.ExecuteNonQueryAsync();
            using (SqlCommand command2 = new SqlCommand($"SELECT TOP 1 * FROM Carpools ORDER BY CarpoolID DESC", con))
            using (SqlDataReader reader = await command2.ExecuteReaderAsync())
            {
            while (reader.Read())
                {
                    SqlCarpoolsReader(carpoolerstellt, reader);
                }
            }
        }
        
        return carpoolerstellt;
    }


    /// <summary>
    /// Method to edit an existing carpool via id
    /// </summary>
    /// <param name="id">ID of the Carpool to edit</param>
    /// <param name="carpoolalt">Carpoolobject with edited data</param>
    /// <returns>Returns the edited Carpoolobject</returns>
    public async Task<Carpools> EditCarpoolAsync(int id, Carpools carpoolalt)
    {
        Carpools carpoolneu = new Carpools();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command1 = new SqlCommand($"UPDATE Carpools SET DriverUserID = {carpoolalt.DriverUserID}, RouteStart = '{carpoolalt.RouteStart}', StartTime = '{carpoolalt.StartTime}', RouteEnd = '{carpoolalt.RouteEnd}', EndTime = '{carpoolalt.EndTime}', Seats = {carpoolalt.Seats} WHERE CarpoolID = {id}", con))
            await command1.ExecuteNonQueryAsync();
            using (SqlCommand command2 = new SqlCommand($"SELECT* FROM Carpools WHERE CarpoolID = {id}", con))
            using (SqlDataReader reader = await command2.ExecuteReaderAsync())
            {
            while (reader.Read())
                {
                    SqlCarpoolsReader(carpoolneu, reader);
                }
            }
        }
        return carpoolneu;
    }


    public async Task<Carpools> DeleteaCarpoolAsync(int id)
    {
        Carpools gelöschterCarpool = new Carpools();
        using (SqlConnection con = new SqlConnection(Config.ConnectionString))
        {
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            using (SqlCommand command1 = new SqlCommand($"SELECT * FROM Carpools WHERE CarpoolID = {id}", con))
            using (SqlDataReader reader = await command1.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    SqlCarpoolsReader(gelöschterCarpool, reader);
                }
            }
            using (SqlCommand command2 = new SqlCommand($"DELETE FROM Carpools WHERE CarpoolID = {id}", con))
            await command2.ExecuteNonQueryAsync();
        }
        return gelöschterCarpool;
    }




    /// <summary>
    /// Reads all Data of User out of SqlDataBase
    /// </summary>
    /// <param name="user"></param>
    /// <param name="reader"></param>
    private void SqlCarpoolsReader(Carpools carpool, SqlDataReader reader)
    {
        carpool.CarpoolID = reader.GetInt32(0);
        carpool.DriverUserID = reader.GetInt32(1);
        carpool.RouteStart = reader.GetString(2);
        carpool.StartTime = reader.GetString(3);
        carpool.RouteEnd = reader.GetString(4);
        carpool.EndTime = reader.GetString(5);
        carpool.Seats = reader.GetInt32(6);
    }

}