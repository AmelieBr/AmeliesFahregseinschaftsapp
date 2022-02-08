namespace ShareARide.Models;
public interface ICarpoolUsersContext
{

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to get all CarpoolUsers
    /// </summary>
    /// <returns>Returns a CarpoolUsersList with all CarpoolUsers</returns>
    public Task<List<CarpoolUsers>> GetAllAsync();

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to get all Users of a single Carpool
    /// </summary>
    /// <param name="carpoolid">ID of Carpool</param>
    /// <returns>Returns a CarpoolUsersList with all Users of the Carpool</returns>
    public Task<List<CarpoolUsers>> GetSingleCarpoolUsersAsync(int carpoolid);

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to get all Carpools, a single User takes part in
    /// </summary>
    /// <param name="userid">ID of the User</param>
    /// <returns>Returns a CarpoolUsersList with all matching Carpools</returns>
    public Task<List<CarpoolUsers>> GetSingleUserinCarpoolsAsync(int userid);

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to get a Carpools, a single User takes part in
    /// </summary>
    /// <param name="userid">ID of the User</param>
    /// <param name="carpoolid">ID of the Carpool</param>
    /// <returns>Returns a CarpoolUsersobject with the matching Carpool and User</returns>
    public Task<CarpoolUsers> GetSingleUserinSingleCarpoolAsync(int userid, int carpoolid);

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to match a User with a Carpool, who is then a passenger
    /// </summary>
    /// <param name="carpooluser">CarpoolUsers object with Carpoolid and Userid</param>
    /// <returns>Returns the created CarpoolUser</returns>
    public Task<CarpoolUsers> AddCarpoolUserAsync(CarpoolUsers carpooluser);

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to delete all Users in a Carpool
    /// </summary>
    /// <param name="carpoolid"></param>
    /// <returns>Retruns a List with deleted Carpoolusers</returns>
    public Task<List<CarpoolUsers>> DeleteSingleCarpoolUsersAsync(int carpoolid);

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to delete a user out of all used Carpools
    /// </summary>
    /// <param name="userid">ID of the User</param>
    /// <returns>Returns a List with deleted Carpoolusers</returns>
    public Task<List<CarpoolUsers>> DeleteSingleUserinCarpoolsAsync(int userid);

    /// <summary>
    /// Forces SqlCarpoolUsersContext to implement this method to delete a user out of a Carpools
    /// </summary>
    /// <param name="userid">ID of the User</param>
    /// <param name="carpoolid">ID of the Carpool</param>
    /// <returns>Returns the deleted carpooluserobject</returns>
    public Task<CarpoolUsers> DeleteSingleUserinSingleCarpoolAsync(int userid, int carpoolid);
}

