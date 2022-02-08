
namespace ShareARide.Models;
public interface IUsersContext 
{
    /// <summary>
    /// Forces SqlUsersContext to implement this method to get all Users
    /// </summary>
    /// <returns>Retruns a UserList with all Users</returns>
    public Task<List<Users>> GetAllAsync();

    /// <summary>
    /// Forces SqlUsersContext to implement this method to get a single User
    /// </summary>
    /// <returns>Retruns a Userobject</returns>
    public Task<Users> GetSingleAsync(int id);

    /// <summary>
    /// Forces SqlUsersContext to implement this method to add a User
    /// </summary>
    /// <returns>Retruns the added User</returns>
    public Task<Users> AddUserAsync(Users user);

    /// <summary>
    /// Forces SqlUsersContext to implement this method to edit a User
    /// </summary>
    /// <returns>Retruns the edited User</returns>
    public Task<Users> EditUserAsync(int id, Users user);

    /// <summary>
    /// Forces SqlUsersContext to implement this method to delete a User
    /// </summary>
    /// <param name="id">ID of the User, who will be deleted</param>
    /// <returns>Returns the deleted Users</returns>
    public Task<Users> DeleteaUserAsync(int id);
}