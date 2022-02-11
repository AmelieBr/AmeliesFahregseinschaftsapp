namespace ShareARide.Models;
public interface ICarpoolsContext 
{
    /// <summary>
    /// Forces SqlCarpoolsContext to implement this method to get all Carpools
    /// </summary>
    /// <returns>Retruns a CarpoolList with all Carpools</returns>
    public Task<List<Carpools>> GetAllAsync();

    /// <summary>
    /// Forces SqlCarpoolsContext to implement this method to get a single Carpool
    /// </summary>
    /// <returns>Retruns a Carpoolobject</returns>
    public Task<Carpools> GetSingleAsync(int id);


    /// <summary>
    /// Method to get a Carpool and its users
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Object, which combines Carpool and UserList</returns>

    public Task<UsersJoinCarpool> GetCarpoolandUser(int id);

    public Task<DriverJoinCarpool> GetCarpoolandDriver(int id);

    /// <summary>
    /// Forces SqlCarpoolsContext to implement this method to add a Carpool
    /// </summary>
    /// <returns>Retruns the added Carpoolobject</returns>
    public Task<Carpools> AddCarpoolAsync(Carpools carpool);

    /// <summary>
    /// Forces SqlCarpoolsContext to implement this method to edit a Carpool
    /// </summary>
    /// <returns>Retruns the edited Carpoolobject</returns>
    public Task<Carpools> EditCarpoolAsync(int id, Carpools carpool);

    /// <summary>
    /// Forces SqlCarpoolsContext to implement this method to delete a User
    /// </summary>
    /// <param name="id">ID of the Carpool, which will be deleted</param>
    /// <returns>Returns the deleted Carpool</returns>
    public Task<Carpools> DeleteaCarpoolAsync(int id);

    public Task<Carpools> DeleteDriverfromCarpoolsAsync(int driverUserID);

}