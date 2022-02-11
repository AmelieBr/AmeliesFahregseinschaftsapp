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
    
    [Route("api/carpools")]
    [ApiController]
    public class CarpoolsController : ControllerBase
    {
        private readonly ICarpoolsContext _context;
        private readonly INotificationsContext _contextNotification;
        private readonly ICarpoolUsersContext _contextCarpoolUser;

        public CarpoolsController(ICarpoolsContext context, INotificationsContext contextNotification, ICarpoolUsersContext contextCarpoolUser)
        {
            _context = context;
            _contextNotification = contextNotification;
            _contextCarpoolUser = contextCarpoolUser;

        }

        

        // Get: api/get --> get all Carpools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carpools>>> GetCarpools()
        {
            return await _context.GetAllAsync();
        }


        // GET: api/Carpools/x --> Get one Carpool with ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Carpools>> GetCarpool(int id)
        {
            var carpool = await _context.GetSingleAsync(id);

            if (carpool == null)
            {
                return NotFound();
            }

            return carpool;
        }
        // GET: api/Carpools/x --> Get one Carpool with ID with adiitional Information
        [HttpGet("Get a single Carpool and the CarpoolUsers/{id}")]
        public async Task<UsersJoinCarpool> GetCarpoolandUser(int id)
        {
            UsersJoinCarpool usersincarpool = await _context.GetCarpoolandUser(id);
            return usersincarpool;
        }

        [HttpGet("Get a single Carpool and the CarpoolDriver/{id}")]
        public async Task<DriverJoinCarpool> GetCarpoolandDriver(int id)
        {
            DriverJoinCarpool driverjoincarpool = await _context.GetCarpoolandDriver(id);
            return driverjoincarpool;
        }
        // POST: api/Carpools
        [HttpPost]
        public async Task<ActionResult<Carpools>> PostCarpool(Carpools carpool)
        {
            await _contextNotification.MailCreateCarpoolAsync(carpool);
            return await _context.AddCarpoolAsync(carpool);
        }

        // PUT: api/Carpools/x --> Edit a Carpool 
        [HttpPut("{id}")]
        public async Task<Carpools> PutCarpool(int id, Carpools carpool)
        {
            await _contextNotification.MailUpdateCarpoolAsync(carpool);
            return await _context.EditCarpoolAsync(id, carpool);
        }
        

        // Delete: api/Users/x --> Delete a Carpool
        [HttpDelete("{id}")]
        public async Task<Carpools> DeleteCarpool(int id)
        {
            
            await _contextNotification.MailDeleteCarpoolAsync(id);
            await _contextCarpoolUser.DeleteSingleCarpoolUsersAsync(id);

            return await _context.DeleteaCarpoolAsync(id);
        }
    }
}