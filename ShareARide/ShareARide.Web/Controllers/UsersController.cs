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

        public UsersController(IUsersContext context)
        {
            _context = context;
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
            return await _context.AddUserAsync(user);
        }

        // PUT: api/Users/x --> Edit a User
        [HttpPut("{id}")]
        public async Task<Users> PutUser(int id, Users user)
        {
            
            return await _context.EditUserAsync(id, user);
        }

        // Delete: api/Users/x --> Delete a User
        [HttpDelete("{id}")]
        public async Task<Users> DeleteUser(int id)
        {
            
            return await _context.DeleteaUserAsync(id);
        }
    }
}