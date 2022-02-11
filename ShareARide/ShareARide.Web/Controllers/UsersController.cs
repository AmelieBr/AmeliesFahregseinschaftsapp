#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using ShareARide.Models;

namespace ShareARide.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersContext _context;
        private readonly ICarpoolsContext _contextCarpool;
        private readonly ICarpoolUsersContext _contextCarpoolUser;

        private readonly INotificationsContext _contextNotification;

        public UsersController(IUsersContext context, ICarpoolsContext contextCarpool, ICarpoolUsersContext contextCarpoolUser, INotificationsContext contextNotification)
        {
            _context = context;
            _contextCarpool = contextCarpool;
            _contextCarpoolUser = contextCarpoolUser;
            _contextNotification = contextNotification;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.GetAllAsync();
        }

        // GET: api/User/
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.GetSingleAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<Users>> PostCarpool(Users user)
        {
            await _context.AddUserAsync(user);
            await _contextNotification.MailCreateAcountAsync(user);
            return user;

        }

        // PUT: api/Users/x --> Edit a User
        [HttpPut("{id}")]
        public async Task<Users> PutUser(int id, Users user)
        {
            await _context.EditUserAsync(id, user);
            await _contextNotification.MailUpdateAcountAsync(user);
            return user;
        }

        // Delete: api/Users/x --> Delete a User
        [HttpDelete("{id}")]
        public async Task<Users> DeleteUser(int id)
        {
            Users user = new Users();
            await _contextNotification.MailDeleteAcountAsync(user);
            await _contextCarpool.DeleteDriverfromCarpoolsAsync(id);
            await _contextCarpoolUser.DeleteSingleUserinCarpoolsAsync(id);
            return await _context.DeleteaUserAsync(id);
        }
    }
}