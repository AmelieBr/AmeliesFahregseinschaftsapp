
namespace ShareARide.Models;
public interface INotificationsContext 
{
    /// <summary>
    /// Method to send a mail about a deleted carpool
    /// </summary>
    public Task MailDeleteCarpoolAsync(int id);


    /// <summary>
    /// Method to send a mail about a newly created carpool
    /// </summary>
    public Task MailCreateCarpoolAsync(Carpools carpool);

    /// <summary>
    /// Method to send a mail about an updated carpool
    /// </summary>
    public Task MailUpdateCarpoolAsync(Carpools carpool);

    /// <summary>
    /// Method to send a mail about an user that joined the carpool
    /// </summary>
    public Task MailUserJoinCarpoolAsync(Carpools carpool, CarpoolUsers carpoolUser);


    /// <summary>
    /// Method to send a mail about an user that left the carpool
    /// </summary>
    public Task MailUserLeftCarpoolAsync(Carpools carpool, CarpoolUsers carpoolUser);

    /// <summary>
    /// Method to send a mail about a deleted acount
    /// </summary>
    public Task MailDeleteAcountAsync(Users user);

    /// <summary>
    /// Method to send a mail about a newly created acount
    /// </summary>
    public Task MailCreateAcountAsync(Users user);

    /// <summary>
    /// Method to send a mail about an updated acount
    /// </summary>
    public Task MailUpdateAcountAsync(Users user);
}

